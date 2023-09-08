using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelMap.Core.Config
{
    public class MongoSettingConfig
    {
        public string BaseUrl { get; set; }

        public string HangfireUrl { get; set; }

        public string DatabaseName { get; set; }
    }
}