﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.LIbraries.Helpers.Connect
{
    public interface IWifiConnector
    {
        void ConnectToWifi(string ssid, string password);
    }
}
