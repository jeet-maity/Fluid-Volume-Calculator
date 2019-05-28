using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Feet : IUnitOfLength
    {
        public Feet(decimal value) => this.Value = value;
        public decimal Value { get; set; }
        public LengthUnit Unit { get; set; } = LengthUnit.Feet;

        public static bool operator ==(Feet f1, Feet f2) => f1.Value == f2.Value;
        public static bool operator !=(Feet f1, Feet f2) => !(f1 == f2);
        public static Feet operator +(Feet f1, Feet f2) => new Feet(f1.Value + f2.Value);
        public static Feet operator -(Feet f1, Feet f2) => new Feet(f1.Value - f2.Value);
        public override bool Equals(object obj)
            {
            Feet current = obj as Feet;
            if (null == obj) return false;
            return this == current;
        }
        public override string ToString() => this.Value.ToString("0.############################");

    }
}
