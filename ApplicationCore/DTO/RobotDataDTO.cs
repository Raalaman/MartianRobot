using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class RobotDataDTO
    {

        public string CurrentPosition { get; set; }
        public string Orders { get; set; }
    }
}
