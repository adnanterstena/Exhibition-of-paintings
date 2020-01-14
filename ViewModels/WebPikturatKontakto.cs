using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EkspozitaPikturave.ViewModels
{
    public class WebPikturatKontakto
    {
        [Required(ErrorMessage = "Duhet të plotësohet Emaili.")]
        [EmailAddress]
        public string from { get; set; }

        [Required(ErrorMessage = "Duhet të plotësohet Emaili.")]
        [EmailAddress]
        public string to { get; set; }

        [Required(ErrorMessage = "Duhet të shënohet subjekti mesazhit.")]
        public string subject { get; set; }

        [Required(ErrorMessage = "Duhet të Ketë përmbajtje mesazhi.")]
        public string mesazhi { get; set; }
    }
}
