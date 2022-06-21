using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppShopping.LIbraries.Helpers.Connect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppShopping.Droid.Libraries.Helpers.Connect.WifiConnector))]
namespace AppShopping.Droid.Libraries.Helpers.Connect
{
    public class WifiConnector : IWifiConnector
    {
      
        public void ConnectToWifi(string ssid, string password)
        {
            
            var wifiManager = (WifiManager)Android.App.Application.Context
                        .GetSystemService(Context.WifiService);

            var formattedSsid = $"\"{ssid}\""; // var formattedSsid = "NOMEDAREFEWIFI"
            var formattedPassword = $"\"{password}\"";

            var wifiConfig = new WifiConfiguration
            {
                Ssid = formattedSsid,//OI_ELIAS_4G
                PreSharedKey = formattedPassword
            };

            var addNetwork = wifiManager.AddNetwork(wifiConfig);

            var network = wifiManager.ConfiguredNetworks
                 .FirstOrDefault(n => n.Ssid == $"\"{ssid}\""); // OI_ELIAS_4G

            if (network == null)
            {
                throw new Exception($"Cannot connect to network: {ssid}");
            }


            wifiManager.Disconnect();
            var enableNetwork = wifiManager.EnableNetwork(network.NetworkId, true);
            wifiManager.Reconnect();
           
        }
    }
}