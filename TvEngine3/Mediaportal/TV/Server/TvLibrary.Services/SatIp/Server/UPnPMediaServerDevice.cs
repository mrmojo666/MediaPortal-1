﻿#region Copyright (C) 2005-2011 Team MediaPortal

// Copyright (C) 2005-2011 Team MediaPortal
// http://www.team-mediaportal.com
// 
// MediaPortal is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// MediaPortal is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MediaPortal. If not, see <http://www.gnu.org/licenses/>.

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using UPnP.Infrastructure.Dv;
using UPnP.Infrastructure.Dv.DeviceTree;

namespace Mediaportal.TV.Server.TVLibrary.SatIp.Server
{
  public class UPnPMediaServerDevice : DvDevice
  {
    public const string MEDIASERVER_DEVICE_TYPE = "schemas-upnp-org:device:MediaServer";
    public const int MEDIASERVER_DEVICE_VERSION = 1;

    public const string CONTENT_DIRECTORY_SERVICE_TYPE = "schemas-upnp-org:service:ContentDirectory";
    public const int CONTENT_DIRECTORY_SERVICE_TYPE_VERSION = 1;
    public const string CONTENT_DIRECTORY_SERVICE_ID = "upnp-org:serviceId:ContentDirectory";

    public const string CONNECTION_MANAGER_SERVICE_TYPE = "schemas-upnp-org:service:ConnectionManager";
    public const int CONNECTION_MANAGER_SERVICE_TYPE_VERSION = 1;
    public const string CONNECTION_MANAGER_SERVICE_ID = "upnp-org:serviceId:ConnectionManager";


    public UPnPMediaServerDevice(string deviceUuid)
      : base(MEDIASERVER_DEVICE_TYPE, MEDIASERVER_DEVICE_VERSION, deviceUuid,
             new LocalizedUPnPDeviceInformation())
    {
      DescriptionGenerateHook += GenerateDescriptionFunc;
      //AddService(new UPnPContentDirectoryServiceImpl());
      //AddService(new UPnPConnectionManagerServiceImpl());
    }

    private static void GenerateDescriptionFunc(XmlWriter writer, DvDevice device, GenerationPosition pos,
                                                EndpointConfiguration config, CultureInfo culture)
    {
      if (pos == GenerationPosition.AfterDeviceList)
      {
        writer.WriteElementString("dlna", "X_DLNADOC", "urn:schemas-dlna-org:device-1-0", "DMS-1.50");
      }
    }
  }
}