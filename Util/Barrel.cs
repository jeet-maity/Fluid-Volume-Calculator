namespace Util
{
    public class Barrel : IUnitOfVolume
    {
        public Barrel(decimal value) => this.Value = value;
        public decimal Value { get; set; }
        public VolumeUnit Unit { get; set; } = VolumeUnit.Barrel;

        public override string ToString() => this.Value.ToString("0.############################");

        public static bool operator ==(Barrel brl1, Barrel brl2) => brl1.Value == brl2.Value;
        public static bool operator !=(Barrel brl1, Barrel brl2) => !(brl1 == brl2);

        public override bool Equals(object obj)
        {
            Barrel current = obj as Barrel;
            if (null == obj) return false;
            return this == current;
        }

        public static Barrel operator +(Barrel brl1, Barrel brl2) => new Barrel(brl1.Value + brl2.Value);
        public static Barrel operator -(Barrel brl1, Barrel brl2) => new Barrel(brl1.Value - brl2.Value);
    }
}