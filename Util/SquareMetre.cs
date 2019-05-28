using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    class SquareMetre : IUnitOfArea
    {
        public SquareMetre(decimal value) => this.Value = value;
        public decimal Value { get; set; }
        public AreaUnit Unit { get; set; } = AreaUnit.SquareMetre;

        public static bool operator ==(SquareMetre sm1, SquareMetre sm2) => sm1.Value == sm2.Value;

        public static bool operator !=(SquareMetre sm1, SquareMetre sm2) => !(sm1 == sm2);

        public static SquareMetre operator +(SquareMetre sm1, SquareMetre sm2) => new SquareMetre(sm1.Value + sm2.Value);

        public static SquareMetre operator -(SquareMetre sm1, SquareMetre sm2) => new SquareMetre(sm1.Value - sm2.Value);

        public override bool Equals(object obj)
        {
            SquareMetre current = obj as SquareMetre;
            if (null == obj) return false;
            return this == current;
        }

        public override string ToString() => this.Value.ToString("0.############################");
    }
}
