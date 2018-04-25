using BlindsResistanceCalculator.Data;
using System.Linq;

namespace BlindsResistanceCalculator.Calculator
{
    public class SignificantFigure : IBandValue
    {
        private readonly IColorCodeData _data;

        public SignificantFigure(IColorCodeData data)
        {
            _data = data;
        }

        public double GetValue(string color)
        {
            var result = _data.GetSignificantFigures().Where(c => c.Name == color).FirstOrDefault();

            if (result != null)
            {
                return result.SignificantFigure;
            }
            else
            {
                return 0;
            }
        }
    }
}