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
        public decimal Value { get; set; }
        public LengthUnit Unit { get; set; } = LengthUnit.Metre;

        public static bool operator ==(Metre m1, Metre m2) => m1.Value == m2.Value;
        public static bool operator !=(Metre m1, Metre m2) => !(m1 == m2);
        public static Metre operator +(Metre m1, Metre m2) => new Metre(m1.Value + m2.Value);
        public static Metre operator -(Metre m1, Metre m2) => new Metre(m1.Value - m2.Value);

        public override bool Equals(object obj)
        {
            Metre current = obj as Metre;
            if (null == obj) return false;
            return this == current;
        }

        public override string ToString() => this.Value.ToString("0.############################");
    }
}
