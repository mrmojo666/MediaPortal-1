#include "TsMPEG1or2DemuxedServerMediaSubsession.h"
#include "MPEG1or2AudioStreamFramer.hh"
#include "MPEG1or2AudioRTPSink.hh"
#include "MPEG1or2VideoStreamFramer.hh"
#include "MPEG1or2VideoRTPSink.hh"
#include "AC3AudioStreamFramer.hh"
#include "AC3AudioRTPSink.hh"
#include "TsStreamFileSource.hh"

TsMPEG1or2DemuxedServerMediaSubsession* TsMPEG1or2DemuxedServerMediaSubsession
::createNew(TsMPEG1or2FileServerDemux& demux, u_int8_t streamIdTag,
	    Boolean reuseFirstSource, Boolean iFramesOnly, double vshPeriod) {
  return new TsMPEG1or2DemuxedServerMediaSubsession(demux, streamIdTag,
						  reuseFirstSource,
						  iFramesOnly, vshPeriod);
}

TsMPEG1or2DemuxedServerMediaSubsession
::TsMPEG1or2DemuxedServerMediaSubsession(TsMPEG1or2FileServerDemux& demux,
				       u_int8_t streamIdTag, Boolean reuseFirstSource,
				       Boolean iFramesOnly, double vshPeriod)
  : OnDemandServerMediaSubsession(demux.envir(), reuseFirstSource),
    fOurDemux(demux), fStreamIdTag(streamIdTag),
    fIFramesOnly(iFramesOnly), fVSHPeriod(vshPeriod) {
}

TsMPEG1or2DemuxedServerMediaSubsession::~TsMPEG1or2DemuxedServerMediaSubsession() {
}

FramedSource* TsMPEG1or2DemuxedServerMediaSubsession
::createNewStreamSource(unsigned clientSessionId, unsigned& estBitrate) {
  FramedSource* es = NULL;
  do {
    es = fOurDemux.newElementaryStream(clientSessionId, fStreamIdTag);
    if (es == NULL) break;

    if ((fStreamIdTag&0xF0) == 0xC0 /*MPEG audio*/) {
      estBitrate = 128; // kbps, estimate
      return MPEG1or2AudioStreamFramer::createNew(envir(), es);
    } else if ((fStreamIdTag&0xF0) == 0xE0 /*video*/) {
      estBitrate = 500; // kbps, estimate
      return MPEG1or2VideoStreamFramer::createNew(envir(), es,
						  fIFramesOnly, fVSHPeriod);
    } else if (fStreamIdTag == 0xBD /*AC-3 audio*/) {
      estBitrate = 192; // kbps, estimate
      return AC3AudioStreamFramer::createNew(envir(), es);
    } else { // unknown stream type
      break;
    }
  } while (0);

  // An error occurred:
  Medium::close(es);
  return NULL;
}

RTPSink* TsMPEG1or2DemuxedServerMediaSubsession
::createNewRTPSink(Groupsock* rtpGroupsock, unsigned char rtpPayloadTypeIfDynamic,
		   FramedSource* inputSource) {
  if ((fStreamIdTag&0xF0) == 0xC0 /*MPEG audio*/) {
    return MPEG1or2AudioRTPSink::createNew(envir(), rtpGroupsock);
  } else if ((fStreamIdTag&0xF0) == 0xE0 /*video*/) {
    return MPEG1or2VideoRTPSink::createNew(envir(), rtpGroupsock);
  } else if (fStreamIdTag == 0xBD /*AC-3 audio*/) {
    // Get the sampling frequency from the audio source; use it for the RTP frequency:
    AC3AudioStreamFramer* audioSource
      = (AC3AudioStreamFramer*)inputSource;
    return AC3AudioRTPSink::createNew(envir(), rtpGroupsock, rtpPayloadTypeIfDynamic,
				      audioSource->samplingRate());
  } else {
    return NULL;
  }
}

void TsMPEG1or2DemuxedServerMediaSubsession
::seekStreamSource(FramedSource* inputSource, double seekNPT) {
  float const dur = duration();
  unsigned const size = fOurDemux.fileSize();
  unsigned absBytePosition = dur == 0.0 ? 0 : (unsigned)((seekNPT/dur)*size);

  // "inputSource" is a 'framer'
  // Flush its data, to account for the seek that we're about to do:
  if ((fStreamIdTag&0xF0) == 0xC0 /*MPEG audio*/) {
    MPEG1or2AudioStreamFramer* framer = (MPEG1or2AudioStreamFramer*)inputSource;
    framer->flushInput();
  } else if ((fStreamIdTag&0xF0) == 0xE0 /*video*/) {
    MPEG1or2VideoStreamFramer* framer = (MPEG1or2VideoStreamFramer*)inputSource;
    framer->flushInput();
  }

  // "inputSource" is a filter; its input source is the original elem stream source:
  MPEG1or2DemuxedElementaryStream* elemStreamSource
    = (MPEG1or2DemuxedElementaryStream*)(((FramedFilter*)inputSource)->inputSource());

  // Next, get the original source demux:
  MPEG1or2Demux& sourceDemux = elemStreamSource->sourceDemux();

  // and flush its input buffers:
  sourceDemux.flushInput();

  // Then, get the original input file stream from the source demux:
  TsStreamFileSource* inputFileSource
    = (TsStreamFileSource*)(sourceDemux.inputSource());
  // Note: We can make that cast, because we know that the demux was originally
  // created from a "ByteStreamFileSource".

  // Do the appropriate seek within the input file stream:
  inputFileSource->seekToByteAbsolute(absBytePosition);
}

float TsMPEG1or2DemuxedServerMediaSubsession::duration() const {
  return fOurDemux.fileDuration();
}
