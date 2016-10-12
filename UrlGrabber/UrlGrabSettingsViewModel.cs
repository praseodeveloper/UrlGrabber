using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlGrabber
{
    class UrlGrabSettingsViewModel
    {
        public int Duration { get;  set; }
        public string Url { get;  set; }
        public string FirefoxPath { get;  set; }
        public string OutputPath { get;  set; }
    }
}
