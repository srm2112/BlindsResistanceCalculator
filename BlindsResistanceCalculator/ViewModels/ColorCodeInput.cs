using System.ComponentModel.DataAnnotations;

namespace BlindsResistanceCalculator.ViewModels
{
    public class ColorCodeInput
    {
        [Required(ErrorMessage = "Band A is required")]
        [Display(Name ="Band A:")]
        public string BandAColor {get; set; }

        [Required(ErrorMessage = "Band B is required")]
        [Display(Name = "Band B:")]
        public string BandBColor { get; set; }

        [Required(ErrorMessage = "Band C is required")]
        [Display(Name = "Band C:")]
        public string BandCColor { get; set; }

        [Display(Name = "Band D:")]
        public string BandDColor { get; set; }
    }
}