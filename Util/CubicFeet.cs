using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class CubicFeet : IUnitOfVolume
    {
        public CubicFeet(decimal value) => this.Value = value;
        public decimal Value { get; set; }
        public VolumeUnit Unit { get; set; } = VolumeUnit.CubicFeet;
        public override string ToString() => this.Value.ToString("0.############################");

        public static bool operator ==(CubicFeet cf1, CubicFeet cf2) => cf1.Value == cf2.Value;
        public static bool operator !=(CubicFeet cf1, CubicFeet cf2) => !(cf1 == cf2);

        public override bool Equals(object obj)
        {
            CubicFeet current = obj as CubicFeet;
            if (null == obj) return false;
            return this == current;
        }

        public static CubicFeet operator +(CubicFeet cf1, CubicFeet cf2) => new CubicFeet(cf1.Value + cf2.Value);
        public static CubicFeet operator -(CubicFeet cf1, CubicFeet cf2) => new CubicFeet(cf1.Value - cf2.Value);
    }
}
