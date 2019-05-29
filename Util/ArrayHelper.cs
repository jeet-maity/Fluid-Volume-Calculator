using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /// <summary>Generic Array Utilities</summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayHelper<T>
    {
        /// <summary>Gets the column.</summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="columnNumber">The column number.</param>
        /// <returns></returns>
        public T[] GetColumn(T[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        /// <summary>Gets the row.</summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns></returns>
        public T[] GetRow(T[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }
}
