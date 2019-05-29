using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /// <summary>Represents a measurement of volume</summary>
    public interface IUnitOfVolume
    {
        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        decimal Value { get; set; }

        /// <summary>Gets or sets the unit.</summary>
        /// <value>The unit.</value>
        VolumeUnit Unit { get; set; }
    }
}
