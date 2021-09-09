using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class MartianRobotGridModel
    {

        [Range(0, 50)]
        public int Length { get; set; }
        [Range(0, 50)]
        public int Height { get; set; }

        public List<CoordinateModel> CoordinatesLostRobots { get; set; }

        /// <summary>
        /// TODO: gestionar las colisiones entre robots
        /// </summary>
        public List<CoordinateModel> CoordinatesFinishedRobots { get; set; }

        public MartianRobotGridModel()
        {
            CoordinatesLostRobots = new List<CoordinateModel>();
            CoordinatesFinishedRobots = new List<CoordinateModel>();
        }
    }
}
