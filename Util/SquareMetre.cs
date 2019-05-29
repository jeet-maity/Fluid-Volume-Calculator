using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    class SquareMetre : IUnitOfArea
    {
        /// <summary>Initializes a new instance of the <see cref="SquareMetre"/> class.</summary>
        /// <param name="value">The value.</param>
        public SquareMetre(decimal value) => this.Value = value;

        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        public decimal Value { get; set; }

        /// <summary>Gets or sets the unit.</summary>
        /// <value>The unit.</value>
        public AreaUnit Unit { get; set; } = AreaUnit.SquareMetre;

        /// <summary>Implements the operator ==.</summary>
        /// <param name="sm1">The SM1.</param>
        /// <param name="sm2">The SM2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(SquareMetre sm1, SquareMetre sm2) => sm1.Value == sm2.Value;

        /// <summary>Implements the operator !=.</summary>
        /// <param name="sm1">The SM1.</param>
        /// <param name="sm2">The SM2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(SquareMetre sm1, SquareMetre sm2) => !(sm1 == sm2);

        /// <summary>Implements the operator +.</summary>
        /// <param name="sm1">The SM1.</param>
        /// <param name="sm2">The SM2.</param>
        /// <returns>The result of the operator.</returns>
        public static SquareMetre operator +(SquareMetre sm1, SquareMetre sm2) => new SquareMetre(sm1.Value + sm2.Value);

        /// <summary>Implements the operator -.</summary>
        /// <param name="sm1">The SM1.</param>
        /// <param name="sm2">The SM2.</param>
        /// <returns>The result of the operator.</returns>
        public static SquareMetre operator -(SquareMetre sm1, SquareMetre sm2) => new SquareMetre(sm1.Value - sm2.Value);

        /// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            SquareMetre current = obj as SquareMetre;
            if (null == obj) return false;
            return this == current;
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString() => this.Value.ToString("0.############################");
    }
}
