using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Trapezoid : I2DShape
    {
        public Trapezoid(Feet firstBase, Feet secondBase, Feet height)
        {
            this.FirstBase = firstBase;
            this.SecondBase = secondBase;
            this.Height = height;
        }

        public Feet FirstBase { get; protected set; }
        public Feet SecondBase { get; protected set; }
        public Feet Height { get; protected set; }

        public override IUnitOfArea Area() => new SquareFeet(Decimal.Multiply(Decimal.Divide((this.FirstBase + this.SecondBase).Value, 2), this.Height.Value));
    }
}
