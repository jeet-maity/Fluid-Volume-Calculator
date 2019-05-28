using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    class DataSet
    {
        public DataSet(Feet[,] topHorizonCoordinateMatrix, Feet horizonDepth, Feet gridCellSize, Feet fluidContact)
        {
            this.TopHorizonCoordinateMatrix = topHorizonCoordinateMatrix;
            this.HorizonDepth = horizonDepth;
            this.GridCellSize = gridCellSize;
            this.FluidContact = fluidContact;
        }

        public Feet[,] TopHorizonCoordinateMatrix { get; private set; }
        public Feet HorizonDepth { get; private set; }
        public Feet GridCellSize { get; private set; }
        public Feet FluidContact { get; private set; }

        public Feet[,] PreciousFluidHeightMatrix
        {
            get
            {
                Feet[,] effectiveDepths = new Feet[this.TopHorizonCoordinateMatrix.GetLength(0), this.TopHorizonCoordinateMatrix.GetLength(1)];

                for (int i = 0; i < this.TopHorizonCoordinateMatrix.GetLength(0); i++)
                    for (int j = 0; j < this.TopHorizonCoordinateMatrix.GetLength(1); j++)
                        //effectiveDepths[i, j] = this.EvaluateEffectiveDepth(this.TopHorizonCoordinateMatrix[i, j], this.FluidContact);
                        effectiveDepths[i, j] = this.EvaluateEffectiveHeight(this.TopHorizonCoordinateMatrix[i, j], this.HorizonDepth, this.FluidContact);

                return effectiveDepths;
            }
        }

        /*
        #region Obsolete..
        public Feet[,] TopSurfaceHeightMatrix
        {
            get
            {
                Feet[,] effectiveDepths = new Feet[this.TopHorizonCoordinateMatrix.GetLength(0), this.TopHorizonCoordinateMatrix.GetLength(1)];

                for (int i = 0; i < this.TopHorizonCoordinateMatrix.GetLength(0); i++)
                    for (int j = 0; j < this.TopHorizonCoordinateMatrix.GetLength(1); j++)
                        effectiveDepths[i, j] = this.EvaluateEffectiveDepth(this.TopHorizonCoordinateMatrix[i, j], this.FluidContact);

                return effectiveDepths;
            }
        }
        public Feet[,] BottomSurfaceHeightMatrix
        {
            get
            {
                Feet[,] effectiveDepths = new Feet[this.TopHorizonCoordinateMatrix.GetLength(0), this.TopHorizonCoordinateMatrix.GetLength(1)];

                for (int i = 0; i < this.TopHorizonCoordinateMatrix.GetLength(0); i++)
                    for (int j = 0; j < this.TopHorizonCoordinateMatrix.GetLength(1); j++)
                        effectiveDepths[i, j] = this.EvaluateEffectiveDepth(this.TopHorizonCoordinateMatrix[i, j] + this.HorizonDepth, this.FluidContact);

                return effectiveDepths;
            }
        }
        private Feet EvaluateEffectiveDepth(Feet horizonPoint, Feet fluidContact)
        {
            return new Feet(Math.Max((fluidContact - horizonPoint).Value, 0m));
        }
        public IUnitOfVolume EvaluateVolume(Feet[,] topSurfaceMatrix, Feet[,] bottomSurfaceMatrix, VolumeUnit expectedUnit)
        {
            IUnitOfVolume topSurfaceVolume = this.EvaluateVolumeUnderSurface(topSurfaceMatrix);
            IUnitOfVolume bottomSurfaceVolume = this.EvaluateVolumeUnderSurface(bottomSurfaceMatrix);

            IUnitOfVolume effectiveVolume = new CubicFeet(topSurfaceVolume.Value - bottomSurfaceVolume.Value);
            switch (expectedUnit)
            {
                case VolumeUnit.CubicFeet:
                    return effectiveVolume;
                case VolumeUnit.CubicMetre:
                    return UnitConverter.CubicFeetToCubicMetre(effectiveVolume as CubicFeet);
                case VolumeUnit.Barrel:
                    return UnitConverter.CubicFeetToBarrels(effectiveVolume as CubicFeet);
                default:
                    throw new NotSupportedException("Unsupported VolumeUnit");
            }
        }

        private IUnitOfVolume EvaluateVolumeUnderSurface(IUnitOfLength[,] surfaceMatrix)
        {
            List<IUnitOfArea> crossSections = new List<IUnitOfArea>();
            ArrayHelper<IUnitOfLength> helper = new ArrayHelper<IUnitOfLength>();
            for (int i = 0; i < surfaceMatrix.GetLength(0); i++)
                crossSections.Add(Calculator.EvaluateArea(helper.GetRow(surfaceMatrix, i)));

            return Calculator.EvaluateVolume(crossSections.ToArray());
        }
        #endregion
        */

        public IUnitOfVolume EvaluateVolume(VolumeUnit expectedUnit)
        {
            return EvaluateVolume(this.PreciousFluidHeightMatrix, expectedUnit);
        }

        public IUnitOfVolume EvaluateVolume(Feet[,] preciousFluidHeightMatrix, VolumeUnit expectedUnit)
        {
            IUnitOfVolume effectiveVolume = this.EvaluatePreciousVolume(preciousFluidHeightMatrix);
            switch (expectedUnit)
            {
                case VolumeUnit.CubicFeet:
                    return effectiveVolume;
                case VolumeUnit.CubicMetre:
                    return UnitConverter.CubicFeetToCubicMetre(effectiveVolume as CubicFeet);
                case VolumeUnit.Barrel:
                    return UnitConverter.CubicFeetToBarrels(effectiveVolume as CubicFeet);
                default:
                    throw new NotSupportedException($"Unsupported VolumeUnit: {nameof(expectedUnit)}");
            }
        }


        private IUnitOfVolume EvaluatePreciousVolume(IUnitOfLength[,] preciousFluidHeightMatrix)
        {
            List<IUnitOfArea> crossSections = new List<IUnitOfArea>();
            ArrayHelper<IUnitOfLength> helper = new ArrayHelper<IUnitOfLength>();
            for (int i = 0; i < preciousFluidHeightMatrix.GetLength(0); i++)
                crossSections.Add(Calculator.EvaluateArea(helper.GetRow(preciousFluidHeightMatrix, i), this.GridCellSize));

            return Calculator.EvaluateVolume(crossSections.ToArray(), this.GridCellSize);
        }

        private Feet EvaluateEffectiveHeight(Feet topHorizonPoint, Feet horizonDepth, Feet fluidContact)
        {
            return new Feet(Math.Max(Math.Min((fluidContact - topHorizonPoint).Value, horizonDepth.Value), 0m));
        }

    }
}
