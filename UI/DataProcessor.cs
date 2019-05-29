using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace UI
{
    /// <summary>Processes UI input</summary>
    class DataProcessor
    {
        /// <summary>Finds the volume of Oil and Gas between the 2 horizons and above the fluid contact.</summary>
        /// <param name="path">The file path of the file containing the grid values of the top horizon depths.</param>
        /// <param name="horizonDepth">The horizon depth.</param>
        /// <param name="gridCellSize">Size of the grid cell.</param>
        /// <param name="fluidContact">The fluid contact.</param>
        /// <returns></returns>
        internal Dictionary<int, string> FindVolume(string path, decimal horizonDepth, decimal gridCellSize, decimal fluidContact)
        {
            Dictionary<int, string> display = new Dictionary<int, string>();

            Feet[,] topHorizonCoordinateMatrix = this.GetMatrix(path);

            ReservoirDataSet reservoirData = new ReservoirDataSet(topHorizonCoordinateMatrix, new Feet(horizonDepth), new Feet(gridCellSize), new Feet(fluidContact));
            IEnumerable<IUnitOfVolume> volumes = reservoirData.EvaluateVolume();
            foreach (var item in volumes)
            {
                if (item.Unit == VolumeUnit.CubicFeet)
                    display.Add(0, item.ToString());
                else if (item.Unit == VolumeUnit.CubicMetre)
                    display.Add(1, item.ToString());
                else
                    display.Add(2, item.ToString());
            }

            return display;
        }

        /// <summary>Formats top horizon depth values from file to a 2D array.</summary>
        /// <param name="path">The file path.</param>
        /// <returns></returns>
        private Feet[,] GetMatrix(string path)
        {
            IEnumerable<string> lazyLines = File.ReadLines(path);
            int columnCount = lazyLines.First().Split(new char[] { ' ' }, StringSplitOptions.None).Count();
            int rowCount = lazyLines.Count();

            string input = File.ReadAllText(path);

            int i = 0, j = 0;
            Feet[,] result = new Feet[rowCount, columnCount];
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    if (!string.IsNullOrWhiteSpace(col))
                    {
                        result[i, j] = new Feet(decimal.Parse(col.Trim()));
                        j++;
                    }
                }
                i++;
            }

            return result;
        }

    }
}
