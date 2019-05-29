using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    /// <summary>input validator</summary>
    static class Validator
    {
        /// <summary>Validates the input file path.</summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Invalid top horizon data set file path. Please provide a valid path</exception>
        /// <exception cref="FileNotFoundException">Please ensure the file containing the data set for top horizon depths exist at the location [{path}</exception>
        internal static string ValidateFilePath(string path)
        {
            if (null == path)
                throw new ArgumentNullException("Invalid top horizon data set file path. Please provide a valid path");
            if (!File.Exists(path))
                throw new FileNotFoundException($"Please ensure the file containing the data set for top horizon depths exist at the location [{path}]");
            return path;
        }


        /// <summary>Validates if a string  is parsable into a decimal.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Invalid value. Please enter a number</exception>
        /// <exception cref="FormatException">The enetered value [{value}</exception>
        internal static decimal ValidateDecimal(string value)
        {
            if (null == value)
                throw new ArgumentNullException("Invalid value. Please enter a number");
            decimal number;
            if (decimal.TryParse(value, out number))
                return number;
            throw new FormatException($"The enetered value [{value}] is not a decimal number. Please enter a number.");
        }
    }
}
