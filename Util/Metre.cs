using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Metre : IUnitOfLength
    {
        public Metre(decimal value) => this.Value = value;

        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        public decimal Value { get; set; }

        /// <summary>Gets or sets the unit.</summary>
        /// <value>The unit.</value>
        public LengthUnit Unit { get; set; } = LengthUnit.Metre;

        /// <summary>Implements the operator ==.</summary>
        /// <param name="m1">The m1.</param>
        /// <param name="m2">The m2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Metre m1, Metre m2) => m1.Value == m2.Value;

        /// <summary>Implements the operator !=.</summary>
        /// <param name="m1">The m1.</param>
        /// <param name="m2">The m2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Metre m1, Metre m2) => !(m1 == m2);

        /// <summary>Implements the operator +.</summary>
        /// <param name="m1">The m1.</param>
        /// <param name="m2">The m2.</param>
        /// <returns>The result of the operator.</returns>
        public static Metre operator +(Metre m1, Metre m2) => new Metre(m1.Value + m2.Value);

        /// <summary>Implements the operator -.</summary>
        /// <param name="m1">The m1.</param>
        /// <param name="m2">The m2.</param>
        /// <returns>The result of the operator.</returns>
        public static Metre operator -(Metre m1, Metre m2) => new Metre(m1.Value - m2.Value);

        /// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            Metre current = obj as Metre;
            if (null == obj) return false;
            return this == current;
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString() => this.Value.ToString("0.############################");
    }
}
