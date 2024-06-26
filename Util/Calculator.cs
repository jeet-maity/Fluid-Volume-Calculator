﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    static class Calculator
    {
        /// <summary>Evaluates the area.</summary>
        /// <param name="functionValues">The function values.</param>
        /// <param name="intervalDistance">The interval distance.</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException">Unsupported LengthUnit: {nameof(intervalDistance)}</exception>
        public static IUnitOfArea EvaluateArea(IUnitOfLength[] functionValues, IUnitOfLength intervalDistance)
        {
            // 26 areas
            decimal areaValue = Calculator.ApplyTrapezoidalRule(functionValues.Select(x => x.Value).ToArray(), intervalDistance.Value);
            switch (intervalDistance.Unit)
            {
                case LengthUnit.Feet:
                    return new SquareFeet(areaValue);
                case LengthUnit.Metre:
                    return new SquareMetre(areaValue);
                default:
                    throw new NotSupportedException($"Unsupported LengthUnit: {nameof(intervalDistance)}");
            }
        }

        /// <summary>Evaluates the volume.</summary>
        /// <param name="functionValues">The function values.</param>
        /// <param name="intervalDistance">The interval distance.</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException">Unsupported LengthUnit: {nameof(intervalDistance)}</exception>
        public static IUnitOfVolume EvaluateVolume(IUnitOfArea[] functionValues, IUnitOfLength intervalDistance)
        {
            if (null == functionValues || functionValues.Length <= 1)
                return new CubicFeet(0m);

            decimal volumeValue;
            if (functionValues.Length == 2)
                volumeValue = Calculator.ApplyTrapezoidalRule(functionValues.Select(x => x.Value).ToArray(), intervalDistance.Value);
            else if (functionValues.Length > 2 && ((functionValues.Length % 2) != 0))
                volumeValue = Calculator.ApplySimpsonsRule(functionValues.Select(x => x.Value).ToArray(), intervalDistance.Value);
            else
            {
                volumeValue = Calculator.ApplySimpsonsRule(functionValues.Skip(1).Select(x => x.Value).ToArray(), intervalDistance.Value)
                     + Calculator.ApplyTrapezoidalRule(functionValues.Take(2).Select(x => x.Value).ToArray(), intervalDistance.Value);
            }

            switch (intervalDistance.Unit)
            {
                case LengthUnit.Feet:
                    return new CubicFeet(volumeValue);
                case LengthUnit.Metre:
                    return new CubicMetre(volumeValue);
                default:
                    throw new NotSupportedException($"Unsupported LengthUnit: {nameof(intervalDistance)}");
            }
        }

        /// <summary>Applies the simpsons rule.</summary>
        /// <param name="functionValues">The function values.</param>
        /// <param name="intervalValue">The interval value.</param>
        /// <returns></returns>
        private static decimal ApplySimpsonsRule(decimal[] functionValues, decimal intervalValue)
        {
            decimal oddFuncValuesSum = 0m;
            decimal evenFuncValuesSum = 0m;
            foreach (decimal item in functionValues.Where((item, index) => (index > 0) && (index < (functionValues.Length - 1)) && (index % 2 != 0)))
                oddFuncValuesSum += item;
            foreach (decimal item in functionValues.Where((item, index) => (index > 0) && (index < (functionValues.Length - 1)) && (index % 2 == 0)))
                evenFuncValuesSum += item;

            return decimal.Divide(intervalValue, 3m) * (functionValues[0] + functionValues[functionValues.Length - 1] + (4m * oddFuncValuesSum) + (2m * evenFuncValuesSum));
        }

        /// <summary>Applies the trapezoidal rule.</summary>
        /// <param name="functionValues">The function values.</param>
        /// <param name="intervalValue">The interval value.</param>
        /// <returns></returns>
        private static decimal ApplyTrapezoidalRule(decimal[] functionValues, decimal intervalValue)
        {
            decimal intermediateSum = 0m;
            for (int i = 1; i < functionValues.Length - 1; i++)
                intermediateSum += functionValues[i];

            return decimal.Divide(intervalValue, 2m)*(functionValues[0] + functionValues[functionValues.Length - 1] + (2m* intermediateSum));
        }
    }
}
