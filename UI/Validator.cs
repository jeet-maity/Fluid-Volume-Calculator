using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    static class Validator
    {
        internal static string ValidateFilePath(string path)
        {
            if (null == path)
                throw new ArgumentNullException("Invalid top horizon data set file path. Please provide a valid path");
            if (!File.Exists(path))
                throw new FileNotFoundException($"Please ensure the file containing the data set for top horizon depths exist at the location [{path}]");
            return path;
        }


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
