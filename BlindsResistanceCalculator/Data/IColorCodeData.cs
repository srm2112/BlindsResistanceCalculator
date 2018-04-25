using BlindsResistanceCalculator.Models;
using System.Collections.Generic;

namespace BlindsResistanceCalculator.Data
{
    public interface IColorCodeData
    {
        List<ColorCode> GetSignificantFigures();
        List<ColorCode> GetMultipliers();
        List<ColorCode> GetTolerances();
        ColorCodeLists GetColorCodeLists();
    }
}
