using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkspozitaPikturave.ViewModels
{
    public class WebPikturatEkspozita
    {
        public string UrlPath { get; set; }
        public string TitulliPiktures { get; set; }
        public string Karakteristikat { get; set; }
        public DateTime DataPostimit { get; set; }
        public string LLojiPiktures { get; set; }
        public decimal CmimiPiktures { get; set; }
        public string Disponueshmeria { get; set; }
    }
}
