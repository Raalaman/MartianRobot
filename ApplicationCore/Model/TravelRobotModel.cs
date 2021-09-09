using ApplicationCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class TravelRobotModel
    {
        public CoordinateModel InitialCoordinate { get; set; }

        public CoordinateModel CurrentCoordinate { get; set; }

        [MaxCountInstruction(MaxLength = 100)]
        public List<Instruction> Instructions { get; set; }

    }
}
