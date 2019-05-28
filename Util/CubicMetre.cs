namespace Util
{
    public class CubicMetre : IUnitOfVolume
    {
        public CubicMetre(decimal value) => this.Value = value;
        public decimal Value { get; set; }
        public VolumeUnit Unit { get; set; } = VolumeUnit.CubicMetre;

        public override string ToString() => this.Value.ToString("0.############################");

        public static bool operator ==(CubicMetre cubm1, CubicMetre cubm2) => cubm1.Value == cubm2.Value;
        public static bool operator !=(CubicMetre cubm1, CubicMetre cubm2) => !(cubm1 == cubm2);

        public override bool Equals(object obj)
        {
            CubicMetre current = obj as CubicMetre;
            if (null == obj) return false;
            return this == current;
        }

        public static CubicMetre operator +(CubicMetre cubm1, CubicMetre cubm2) => new CubicMetre(cubm1.Value + cubm2.Value);
        public static CubicMetre operator -(CubicMetre cubm1, CubicMetre cubm2) => new CubicMetre(cubm1.Value - cubm2.Value);
    }
}