using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Feet : IUnitOfLength
    {
        /// <summary>Initializes a new instance of the <see cref="Feet"/> class.</summary>
        /// <param name="value">The value.</param>
        public Feet(decimal value) => this.Value = value;

        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        public decimal Value { get; set; }

        /// <summary>Gets or sets the unit.</summary>
        /// <value>The unit.</value>
        public LengthUnit Unit { get; set; } = LengthUnit.Feet;

        /// <summary>Implements the operator ==.</summary>
        /// <param name="f1">The f1.</param>
        /// <param name="f2">The f2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Feet f1, Feet f2) => f1.Value == f2.Value;

        /// <summary>Implements the operator !=.</summary>
        /// <param name="f1">The f1.</param>
        /// <param name="f2">The f2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Feet f1, Feet f2) => !(f1 == f2);

        /// <summary>Implements the operator +.</summary>
        /// <param name="f1">The f1.</param>
        /// <param name="f2">The f2.</param>
        /// <returns>The result of the operator.</returns>
        public static Feet operator +(Feet f1, Feet f2) => new Feet(f1.Value + f2.Value);

        /// <summary>Implements the operator -.</summary>
        /// <param name="f1">The f1.</param>
        /// <param name="f2">The f2.</param>
        /// <returns>The result of the operator.</returns>
        public static Feet operator -(Feet f1, Feet f2) => new Feet(f1.Value - f2.Value);

        /// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            {
            Feet current = obj as Feet;
            if (null == obj) return false;
            return this == current;
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString() => this.Value.ToString("0.############################");

    }
}
