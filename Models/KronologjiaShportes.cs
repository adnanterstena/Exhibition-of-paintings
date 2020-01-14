using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkspozitaPikturave.Models
{
    public class KronologjiaShportes
    {

        public static List<KerkesaShportes> GjendjaKerkesave = new List<KerkesaShportes>();

        //Per te vendos kerkesat nga klienti
        public KronologjiaShportes(int _IdShportes)
        {
            KerkesaShportes kerkesaShportes = new KerkesaShportes()
            {
                IdShportes = _IdShportes,
                Koha = DateTime.Now
            };


            GjendjaKerkesave.Add(kerkesaShportes);
        }

        //Per te kontrollu gjendjen e kerkesave
        public KronologjiaShportes()
        {

        }


        //Fshirja kerkeses
        public KronologjiaShportes(KerkesaShportes item)
        {
            GjendjaKerkesave.Remove(item);
        }

        //Marja e listes statike 'GjendjaKerkesave'
        public List<KerkesaShportes> getGjendjaKerkesave()
        {
            return GjendjaKerkesave;
        }

    }
    public class KerkesaShportes
    {
        public int IdShportes { get; set; }
        public DateTime Koha;

    }
}
