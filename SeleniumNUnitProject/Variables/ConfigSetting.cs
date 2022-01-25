using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumNUnit.Variables
{
    class ConfigSetting
    {
        public string BrowserType { get; set; }
        public string LogLevel { get; set; }
        public string DeviceName { get; set; }
        public string PlatformName { get; set; }
        public string PlatformVersion { get; set; }
        public string AppiumUrl { get; set; }
    }
}
