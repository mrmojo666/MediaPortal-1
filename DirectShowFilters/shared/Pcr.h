/*
 *  Copyright (C) 2006-2008 Team MediaPortal
 *  http://www.team-mediaportal.com
 *
 *  This Program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2, or (at your option)
 *  any later version.
 *
 *  This Program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with GNU Make; see the file COPYING.  If not, write to
 *  the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.
 *  http://www.gnu.org/copyleft/gpl.html
 *
 */
#pragma once

#define MAX_PCR_BASE 0x1FFFFFFFF
#define MAX_PCR_EXTENSION 0x1ff

class CPcr
{
public:
  CPcr();
  CPcr(const CPcr& pcr);
  virtual ~CPcr();
  void   Reset();
  void   Decode(unsigned char* data);
  static bool DecodeFromPesHeader(unsigned char* pesHeader,int payloadStart,CPcr& pts, CPcr& dts);
  void   FromClock(double clock);
  double ToClock() const;
  void   Time(int& day, int& hour, int &minutes, int& seconds, int & millsecs);
  char*  ToString();
  
  CPcr& operator+=(const CPcr &rhs);
  CPcr& operator-=(const CPcr &rhs); 
  CPcr operator+(const CPcr &rhs); 
  CPcr operator-(const CPcr &rhs);
  CPcr& operator=(const CPcr &rhs);
  bool operator==(const CPcr &other) const ;
  bool operator>(const CPcr &other) const ;
  bool operator!=(const CPcr &other) const ;

  unsigned long long PcrReferenceBase;
  unsigned long long PcrReferenceExtension;
  bool   IsValid;
private:
  char m_buffer[100];
};
