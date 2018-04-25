using System.Collections.Generic;
using System.Web.Mvc;

namespace BlindsResistanceCalculator.Models
{
    public class ColorCodeLists
    {
        public List<SelectListItem> BandAColorList { get; set; }
        public List<SelectListItem> BandBColorList { get; set; }
        public List<SelectListItem> BandCColorList { get; set; }
        public List<SelectListItem> BandDColorList { get; set; }
    }
}