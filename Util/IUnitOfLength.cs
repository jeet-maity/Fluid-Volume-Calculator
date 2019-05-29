using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /// <summary>Represents a measurement of length, width, height, depth, etc</summary>
    public interface IUnitOfLength
    {
        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        decimal Value { get; set; }

        /// <summary>Gets or sets the unit.</summary>
        /// <value>The unit.</value>
        LengthUnit Unit { get; set; }
    }
}
