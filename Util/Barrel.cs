namespace Util
{
    public class OilBarrel : IUnitOfVolume
    {
        public OilBarrel(decimal value) => this.Value = value;
        public decimal Value { get; set; }
        public VolumeUnit Unit { get; set; } = VolumeUnit.Barrel;

        public override string ToString() => this.Value.ToString("0.############################");

        public static bool operator ==(OilBarrel brl1, OilBarrel brl2) => brl1.Value == brl2.Value;
        public static bool operator !=(OilBarrel brl1, OilBarrel brl2) => !(brl1 == brl2);

        public override bool Equals(object obj)
        {
            OilBarrel current = obj as OilBarrel;
            if (null == obj) return false;
            return this == current;
        }

        public static OilBarrel operator +(OilBarrel brl1, OilBarrel brl2) => new OilBarrel(brl1.Value + brl2.Value);
        public static OilBarrel operator -(OilBarrel brl1, OilBarrel brl2) => new OilBarrel(brl1.Value - brl2.Value);
    }
}