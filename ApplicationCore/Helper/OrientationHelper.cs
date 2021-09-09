using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public static class OrientationHelper
    {
        public static Orientation TurnRight(Orientation orientation)
        {
            Orientation response = orientation;
            switch (orientation)
            {
                case Orientation.E:
                    response = Orientation.S;
                    break;
                case Orientation.N:
                    response = Orientation.E;
                    break;
                case Orientation.S:
                    response = Orientation.W;
                    break;
                case Orientation.W:
                    response = Orientation.N;
                    break;
            }
            return response;
        }

        public static Orientation TurnLeft(Orientation orientation)
        {
            Orientation response = orientation;
            switch (orientation)
            {
                case Orientation.E:
                    response = Orientation.N;
                    break;
                case Orientation.N:
                    response = Orientation.W;
                    break;
                case Orientation.S:
                    response = Orientation.E;
                    break;
                case Orientation.W:
                    response = Orientation.S;
                    break;
            }
            return response;
        }
    }
}
