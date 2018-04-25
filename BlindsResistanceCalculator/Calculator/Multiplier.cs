using BlindsResistanceCalculator.Data;
using System.Linq;

namespace BlindsResistanceCalculator.Calculator
{
    public class Multiplier : IBandValue
    {
        private readonly IColorCodeData _data;

        public Multiplier(IColorCodeData data)
        {
            _data = data;
        }

        public double GetValue(string color)
        {
            var result = _data.GetMultipliers().Where(c => c.Name == color).FirstOrDefault();

            if (result != null)
            {
                return result.Multiplier;
            }
            else
            {
                return 0;
            }
        }
    }
}