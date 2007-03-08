using System;
using System.Xml;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using TvDatabase;
using TvLibrary;
using TvLibrary.Interfaces;
using TvLibrary.Channels;
using Gentle.Common;
using Gentle.Framework;
using TvControl;

namespace WebGuide
{
  public class ProgramInfo
  {
    public string Title;
    public string startTime;
    public string endTime;
    public string description;
    public string genre;
    public string logo;
    public string channel;
    public int recordingType;
  }
  /// <summary>
  /// Summary description for WebGuideService
  /// </summary>
  [WebService(Namespace = "http://www.team-mediaportal.com/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [ScriptService]
  public class WebGuideService : System.Web.Services.WebService
  {

    public WebGuideService()
    {

      //Uncomment the following line if using designed components 
      //InitializeComponent(); 
    }

    [WebMethod]
    public ProgramInfo GetProgramInfo(int id)
    {
      Program prog = Program.Retrieve(id);
      ProgramInfo info = new ProgramInfo();
      info.Title = prog.Title;
      info.description = prog.Description;
      info.genre = prog.Genre;
      info.logo = String.Format("logos/{0}.png", prog.ReferencedChannel().Name);
      info.channel = prog.ReferencedChannel().Name;
      info.startTime = prog.StartTime.ToString("HH:mm");
      info.endTime = prog.EndTime.ToString("HH:mm");
      info.recordingType = -1;
      Schedule schedule;
      bool isSeries;
      if (IsRecording(prog, out schedule, out isSeries))
      {
        info.recordingType = (int)schedule.ScheduleType;
      }
      return info;
    }

    bool IsRecording(Program program,out Schedule sched, out bool isSeries)
    {
      sched = null;
      isSeries = false;
      IList _schedules = Schedule.ListAll();
      foreach (Schedule schedule in _schedules)
      {
        if (schedule.IsRecordingProgram(program, true))
        {
          if (schedule.ScheduleType != 0) isSeries = true;
          sched = schedule;
          return true;
        }
      }
      return false;
    }
  }

}