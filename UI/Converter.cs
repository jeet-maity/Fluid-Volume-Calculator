using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    /// <summary>Unit converter</summary>
    class Converter
    {
        /// <summary>Metres to feet.</summary>
        /// <param name="metre">The metre.</param>
        /// <returns></returns>
        public static decimal MetreToFeet(decimal metre)
        {
            return metre * 3.2808m;
        }
    }
}
