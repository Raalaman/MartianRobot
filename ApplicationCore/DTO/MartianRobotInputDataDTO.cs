using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class MartianRobotInputDataDTO
    {
        public MartianRobotInputDataDTO()
        {
            RobotsData = new List<RobotDataDTO>();
        }
        public int PlanetHeight { get; set; }
        public int PlanetWidth { get; set; }
        public List<RobotDataDTO> RobotsData { get; set; }
    }
}
