using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class OutputGeneratorDTO
    {
        public CoordinateModel Coordinate { get; set; }

        public bool IsLost { get; set; }

        public override string ToString()
        {
            return Coordinate.ToString() + (IsLost ? " LOST" : string.Empty);
        }
    }
}
