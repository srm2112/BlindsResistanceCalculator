using BlindsResistanceCalculator.Calculator;
using BlindsResistanceCalculator.Data;
using BlindsResistanceCalculator.ViewModels;
using System.Web.Mvc;

namespace BlindsResistanceCalculator.Controllers
{
    public class OhmCalculatorController : Controller
    {
        private readonly IColorCodeData _colorData;
        private readonly IOhmValueCalculator _calculator;

        public OhmCalculatorController(IColorCodeData colorData, IOhmValueCalculator calculator)
        {
            _colorData = colorData;
            _calculator = calculator;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewData["ColorLists"] = _colorData.GetColorCodeLists();
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(ColorCodeInput selectedColorCodes)
        {
            if (ModelState.IsValid)
            {
                var result = _calculator.CalculateOhmValue(selectedColorCodes.BandAColor, 
                                                           selectedColorCodes.BandBColor, 
                                                           selectedColorCodes.BandCColor, 
                                                           selectedColorCodes.BandDColor);

                return View("_Results", result);
            }
            else
            {
                return View("_Errors", ModelState);
            }
        }
    }
}