using EkspozitaPikturave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkspozitaPikturave.ViewModels
{
    public class CreateEkspozitaModel
    {
        public Ekspozitat _ekspozita { get; set; }
        public List<Pikturat> _pikturat { get; set; }
    }
}
