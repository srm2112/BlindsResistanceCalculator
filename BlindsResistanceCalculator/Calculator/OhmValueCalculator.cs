using System;
using BlindsResistanceCalculator.ViewModels;
using Unity.Attributes;

namespace BlindsResistanceCalculator.Calculator
{
    public class OhmValueCalculator : IOhmValueCalculator
    {
        private readonly IBandValue _significantFigure;
        private readonly IBandValue _multiplier;
        private readonly IBandValue _tolerance;

        public OhmValueCalculator([Dependency("SignificantFigure")]IBandValue significantFigure,
                                  [Dependency("Multiplier")]IBandValue multiplier,
                                  [Dependency("Tolerance")]IBandValue tolerance)
        {
            _significantFigure = significantFigure;
            _multiplier = multiplier;
            _tolerance = tolerance;
        }

        public CalculatedResult CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var firstSignificantFigure = _significantFigure.GetValue(bandAColor);
            var secondSignificantFigure = _significantFigure.GetValue(bandBColor);
            var multiplier = _multiplier.GetValue(bandCColor);
            var tolerance = _tolerance.GetValue(bandDColor);

            return CalculateResistance(firstSignificantFigure, secondSignificantFigure, multiplier, tolerance);
        }
        
        private CalculatedResult CalculateResistance(double firstSignificantFigure, double secondSignificantFigure, double multiplier, double tolerance)
        {
            var result = new CalculatedResult();

            result.CalculatedOhms = Convert.ToInt64(Convert.ToInt32("" + firstSignificantFigure + secondSignificantFigure) * multiplier);
            result.HighTolerance = result.CalculatedOhms + (result.CalculatedOhms * (tolerance / 100));
            result.LowTolerance = result.CalculatedOhms - (result.CalculatedOhms * (tolerance / 100));

            return result;
        }
    }
}