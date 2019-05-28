using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    class SquareFeet : IUnitOfArea
    {
        public SquareFeet(decimal value) => this.Value = value;
        public decimal Value { get; set; }
        public AreaUnit Unit { get; set; } = AreaUnit.SquareFeet;
        
        public static bool operator ==(SquareFeet sf1, SquareFeet sf2) => sf1.Value == sf2.Value;

        public static bool operator !=(SquareFeet sf1, SquareFeet sf2) => !(sf1 == sf2);

        public static SquareFeet operator +(SquareFeet sf1, SquareFeet sf2) => new SquareFeet(sf1.Value + sf2.Value);

        public static SquareFeet operator -(SquareFeet sf1, SquareFeet sf2) => new SquareFeet(sf1.Value - sf2.Value);

        public override bool Equals(object obj)
        {
            SquareFeet current = obj as SquareFeet;
            if (null == obj) return false;
            return this == current;
        }

        public override string ToString() => this.Value.ToString("0.############################");
    }
}
