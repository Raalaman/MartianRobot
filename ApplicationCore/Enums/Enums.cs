using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public enum Orientation
    {
        N, S, E, W
    }

    public enum Dimension
    {
        Height, Length
    }

    public enum TravelResult
    {
        Lost, OK, Ignore
    }

    public enum Instruction
    {
        L, R, F
    }
}