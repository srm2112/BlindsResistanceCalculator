using BlindsResistanceCalculator.Data;
using System.Linq;

namespace BlindsResistanceCalculator.Calculator
{
    public class Tolerance : IBandValue
    {
        private readonly IColorCodeData _data;

        public Tolerance(IColorCodeData data)
        {
            _data = data;
        }

        public double GetValue(string color)
        {
            var result = _data.GetTolerances().Where(c => c.Name == color).FirstOrDefault();

            if (result != null)
            {
                return result.Tolerance;
            }
            else
            {
                return 0;
            }
        }
    }
}