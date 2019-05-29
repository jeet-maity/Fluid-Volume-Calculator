using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /// <summary>Represents an entire data set of the challenge</summary>
    public class ReservoirDataSet
    {
        /// <summary>Initializes a new instance of the <see cref="ReservoirDataSet"/> class.</summary>
        /// <param name="topHorizonCoordinateMatrix">The top horizon coordinate matrix.</param>
        /// <param name="horizonDepth">The horizon depth.</param>
        /// <param name="gridCellSize">Size of the grid cell.</param>
        /// <param name="fluidContact">The fluid contact.</param>
        public ReservoirDataSet(Feet[,] topHorizonCoordinateMatrix, Feet horizonDepth, Feet gridCellSize, Feet fluidContact)
        {
            this.TopHorizonCoordinateMatrix = topHorizonCoordinateMatrix;
            this.HorizonDepth = horizonDepth;
            this.GridCellSize = gridCellSize;
            this.FluidContact = fluidContact;
        }

        /// <summary>Gets the top horizon coordinate matrix.</summary>
        /// <value>The top horizon coordinate matrix.</value>
        public Feet[,] TopHorizonCoordinateMatrix { get; private set; }

        /// <summary>Gets the horizon depth.</summary>
        /// <value>The horizon depth.</value>
        public Feet HorizonDepth { get; private set; }

        /// <summary>Gets the size of the grid cell.</summary>
        /// <value>The size of the grid cell.</value>
        public Feet GridCellSize { get; private set; }

        /// <summary>Gets the fluid contact.</summary>
        /// <value>The fluid contact.</value>
        public Feet FluidContact { get; private set; }

        /// <summary>Gets the precious fluid (Oil and Gas) height matrix.</summary>
        /// <value>The precious fluid height matrix.</value>
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

        /// <summary>Evaluates the volume of Oil and Gas between the 2 horizons and above the fluid contact in <see cref="CubicFeet"/> <see cref="CubicMetre"/> and <see cref="OilBarrel"/>.</summary>
        /// <returns></returns>
        public IEnumerable<IUnitOfVolume> EvaluateVolume()
        {
            return EvaluateVolume(this.PreciousFluidHeightMatrix);
        }

        /// <summary>Evaluates the volume of Oil and Gas between the 2 horizons and above the fluid contact in <see cref="CubicFeet"/> <see cref="CubicMetre"/> and <see cref="OilBarrel"/>.</summary>
        /// <param name="preciousFluidHeightMatrix">The precious fluid height matrix.</param>
        /// <returns></returns>
        public IEnumerable<IUnitOfVolume> EvaluateVolume(Feet[,] preciousFluidHeightMatrix)
        {
            List<IUnitOfVolume> estimatedVolumes = new List<IUnitOfVolume>();

            IUnitOfVolume effectiveVolumeCubicFeet = this.EvaluatePreciousVolume(preciousFluidHeightMatrix);
            IUnitOfVolume effectiveVolumeCubicMetre = UnitConverter.CubicFeetToCubicMetre(effectiveVolumeCubicFeet as CubicFeet);
            IUnitOfVolume effectiveVolumeBarrel = UnitConverter.CubicFeetToBarrels(effectiveVolumeCubicFeet as CubicFeet);
            estimatedVolumes.Add(effectiveVolumeCubicFeet);
            estimatedVolumes.Add(effectiveVolumeCubicMetre);
            estimatedVolumes.Add(effectiveVolumeBarrel);

            return estimatedVolumes;
        }

        /// <summary>volume of Oil and Gas between the 2 horizons and above the fluid contact in <see cref="IUnitOfVolume"/>.</summary>
        /// <param name="preciousFluidHeightMatrix">The precious fluid height matrix.</param>
        /// <returns></returns>
        private IUnitOfVolume EvaluatePreciousVolume(IUnitOfLength[,] preciousFluidHeightMatrix)
        {
            List<IUnitOfArea> crossSections = new List<IUnitOfArea>();
            ArrayHelper<IUnitOfLength> helper = new ArrayHelper<IUnitOfLength>();
            for (int i = 0; i < preciousFluidHeightMatrix.GetLength(0); i++)
                crossSections.Add(Calculator.EvaluateArea(helper.GetRow(preciousFluidHeightMatrix, i), this.GridCellSize));

            return Calculator.EvaluateVolume(crossSections.ToArray(), this.GridCellSize);
        }

        /// <summary>Helper to evaluate the height of Oil and Gas at a given location on the grid or matrix.</summary>
        /// <param name="topHorizonPoint">The top horizon point.</param>
        /// <param name="horizonDepth">The horizon depth.</param>
        /// <param name="fluidContact">The fluid contact.</param>
        /// <returns></returns>
        private Feet EvaluateEffectiveHeight(Feet topHorizonPoint, Feet horizonDepth, Feet fluidContact)
        {
            return new Feet(Math.Max(Math.Min((fluidContact - topHorizonPoint).Value, horizonDepth.Value), 0m));
        }

    }
}
