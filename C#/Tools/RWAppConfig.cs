using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Tools
{
    public class RWAppConfig
    {
        public static string ReadAppconfig(string keyname)
        {
            return ConfigurationManager.AppSettings[keyname];
        }
        public static void WriteAppconfig(string kyname, string keyvalue)
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[kyname].Value = keyvalue;
            config.Save();

        }
        public static void AddKeyValue(string keyname, string keyvalue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("key", "Name");
            config.Save();
        }
    }
}
