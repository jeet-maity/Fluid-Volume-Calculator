using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class UnitConverter
    {
        public static CubicMetre CubicFeetToCubicMetre(CubicFeet volumeInCubicFeet)
        {
            return new CubicMetre(volumeInCubicFeet.Value * 0.3048m * 0.3048m * 0.3048m);
        }

        public static Barrel CubicFeetToBarrels(CubicFeet volumeInCubicFeet)
        {
            return new Barrel(volumeInCubicFeet.Value * 0.237476809m);
        }
    }
}
