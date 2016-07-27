using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp
{
    public class Settings
    {
        private static Settings _Instance = null;

        public static Settings Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Settings();
                }

                return _Instance;
            }
        }

        public string WebURL { get; set; }

        private Settings() { }
    }
}
