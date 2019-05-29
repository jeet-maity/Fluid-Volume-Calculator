using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class CubicFeet : IUnitOfVolume
    {
        /// <summary>Initializes a new instance of the <see cref="CubicFeet"/> class.</summary>
        /// <param name="value">The value.</param>
        public CubicFeet(decimal value) => this.Value = value;

        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        public decimal Value { get; set; }

        /// <summary>Gets or sets the unit.</summary>
        /// <value>The unit.</value>
        public VolumeUnit Unit { get; set; } = VolumeUnit.CubicFeet;

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString() => this.Value.ToString("0.############################");


        /// <summary>Implements the operator ==.</summary>
        /// <param name="cf1">The CF1.</param>
        /// <param name="cf2">The CF2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(CubicFeet cf1, CubicFeet cf2) => cf1.Value == cf2.Value;

        /// <summary>Implements the operator !=.</summary>
        /// <param name="cf1">The CF1.</param>
        /// <param name="cf2">The CF2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(CubicFeet cf1, CubicFeet cf2) => !(cf1 == cf2);


        /// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            CubicFeet current = obj as CubicFeet;
            if (null == obj) return false;
            return this == current;
        }

        /// <summary>Implements the operator +.</summary>
        /// <param name="cf1">The CF1.</param>
        /// <param name="cf2">The CF2.</param>
        /// <returns>The result of the operator.</returns>
        public static CubicFeet operator +(CubicFeet cf1, CubicFeet cf2) => new CubicFeet(cf1.Value + cf2.Value);

        /// <summary>Implements the operator -.</summary>
        /// <param name="cf1">The CF1.</param>
        /// <param name="cf2">The CF2.</param>
        /// <returns>The result of the operator.</returns>
        public static CubicFeet operator -(CubicFeet cf1, CubicFeet cf2) => new CubicFeet(cf1.Value - cf2.Value);
    }
}
