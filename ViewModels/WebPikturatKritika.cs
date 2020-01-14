using EkspozitaPikturave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkspozitaPikturave.ViewModels
{
    public class WebPikturatKritika
    {
        public List<Kritikat> komentet { get; set; }
        public string UrlPath { get; set; }
        public string Disponueshmeria { get; set; }
        public string TitulliPiktures { get; set; }
        public string Pershkrimi { get; set; }
        public Kritikat Kritikat { get; set; }


    }
}
