using BlindsResistanceCalculator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlindsResistanceCalculator.Data
{
    public class ColorCodeData : IColorCodeData
    {
        List<ColorCode> _colorCodes;

        public ColorCodeData()
        {
            Initialize();
        }

        public List<ColorCode> GetMultipliers()
        {
            return _colorCodes.Where(colorCodes => colorCodes.Multiplier != -1f).ToList();
        }

        public List<ColorCode> GetSignificantFigures()
        {
            return _colorCodes.Where(colorCodes => colorCodes.SignificantFigure != -1f).ToList();
        }

        public List<ColorCode> GetTolerances()
        {
            return _colorCodes.Where(colorCodes => colorCodes.Tolerance != -1f).ToList();
        }

        public ColorCodeLists GetColorCodeLists()
        {
            var colorLists = new ColorCodeLists();

            colorLists.BandAColorList = GetSignificantFigures()
                                            .Select(color => new SelectListItem() { Text = color.Name, Value = color.Name }).ToList();

            colorLists.BandBColorList = GetSignificantFigures()
                                            .Select(color => new SelectListItem() { Text = color.Name, Value = color.Name }).ToList();

            colorLists.BandCColorList = GetMultipliers()
                                            .Select(color => new SelectListItem() { Text = color.Name, Value = color.Name }).ToList();

            colorLists.BandDColorList = GetTolerances()
                                            .Select(color => new SelectListItem() { Text = color.Name, Value = color.Name, Selected = (color.Name == "None") }).ToList();

            return colorLists;
        }

        private void Initialize()
        {
            _colorCodes = new List<ColorCode>();

            _colorCodes.Add(new ColorCode() { Name = "None", SignificantFigure = -1, Multiplier = -1, Tolerance = 20f });
            _colorCodes.Add(new ColorCode() { Name = "Pink", SignificantFigure = -1, Multiplier = .001f, Tolerance = -1 });
            _colorCodes.Add(new ColorCode() { Name = "Silver", SignificantFigure = -1, Multiplier = .01f, Tolerance = 10f });
            _colorCodes.Add(new ColorCode() { Name = "Gold", SignificantFigure = -1, Multiplier = .1f, Tolerance = 5f });
            _colorCodes.Add(new ColorCode() { Name = "Black", SignificantFigure = 0, Multiplier = 1f, Tolerance = -1 });
            _colorCodes.Add(new ColorCode() { Name = "Brown", SignificantFigure = 1, Multiplier = 10f, Tolerance = 1f });
            _colorCodes.Add(new ColorCode() { Name = "Red", SignificantFigure = 2, Multiplier = 100f, Tolerance = 2f });
            _colorCodes.Add(new ColorCode() { Name = "Orange", SignificantFigure = 3, Multiplier = 10001f, Tolerance = -1 });
            _colorCodes.Add(new ColorCode() { Name = "Yellow", SignificantFigure = 4, Multiplier = 10000f, Tolerance = 5f });
            _colorCodes.Add(new ColorCode() { Name = "Green", SignificantFigure = 5, Multiplier = 100000f, Tolerance = .5f });
            _colorCodes.Add(new ColorCode() { Name = "Blue", SignificantFigure = 6, Multiplier = .1000000f, Tolerance = .25f });
            _colorCodes.Add(new ColorCode() { Name = "Violet", SignificantFigure = 7, Multiplier = 10000000f, Tolerance = .1f });
            _colorCodes.Add(new ColorCode() { Name = "Gray", SignificantFigure = 8, Multiplier = 100000000f, Tolerance = .05f });
            _colorCodes.Add(new ColorCode() { Name = "White", SignificantFigure = 9, Multiplier = 1000000000f, Tolerance = -1 });
        }
    }

}