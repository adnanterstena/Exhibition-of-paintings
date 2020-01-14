using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EkspozitaPikturave.Data;
using EkspozitaPikturave.Models;
using EkspozitaPikturave.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReflectionIT.Mvc.Paging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EkspozitaPikturave.Controllers
{
    public class WebPikturatController : Controller
    {

        private readonly ILogger<WebPikturatController> _logger;
        private readonly PikturatEKSContents _context;
        private readonly ApplicationDbContext _appContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private IConfiguration _configuration;

        public WebPikturatController(ILogger<WebPikturatController> logger,PikturatEKSContents context, ApplicationDbContext appContext, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _appContext = appContext;
            _userManager = userManager;
            _configuration = configuration;
        }



        #region BALLINA

        public async Task<IActionResult> Ballina()
        {

            var queryPics = _context.Pikturat.AsNoTracking().OrderByDescending(s => s.IdPiktura);
            var modelPics = await PagingList.CreateAsync(queryPics, 4, 1);
            ViewBag.PikturatBallina = modelPics;

            var queryEkspozitat = _context.Ekspozitat.AsNoTracking().OrderByDescending(s => s.Id_Ekspozites);
            var modelEkspozitat = await PagingList.CreateAsync(queryEkspozitat, 4, 1);
            ViewBag.EkspozitatBallina = modelEkspozitat;

            var queryPanoramike = _context.Pikturat.AsNoTracking().Where(a => a.Karakteristikat == "PANORAMIKE").OrderByDescending(s => s.IdPiktura);
            var modelPanoramike = await PagingList.CreateAsync(queryPanoramike, 4, 1);
            modelPanoramike.Action = "Ballina";
            modelPanoramike.PageParameterName = "PanPage";
            ViewBag.PanoramikeBallina = modelPanoramike;

            var queryNatyre = _context.Pikturat.AsNoTracking().Where(a => a.Karakteristikat == "NATYRE").OrderByDescending(s => s.IdPiktura);
            var modelNatyre = await PagingList.CreateAsync(queryNatyre, 4, 1);
            ViewBag.NatyreBallina = modelNatyre;

            var queryAbstrakte = _context.Pikturat.AsNoTracking().Where(a => a.Karakteristikat == "ABSTRAKTE").OrderByDescending(s => s.IdPiktura);
            var modelAbstrakte = await PagingList.CreateAsync(queryAbstrakte, 4, 1);
            ViewBag.AbstrakteBallina = modelAbstrakte;

            var queryBardhEZi = _context.Pikturat.AsNoTracking().Where(a => a.Karakteristikat == "BARDH DHE ZI").OrderByDescending(s => s.IdPiktura);
            var modelBardhEZi = await PagingList.CreateAsync(queryBardhEZi, 4, 1);
            ViewBag.BardhDheZiBallina = modelBardhEZi;

            return View();
        }



        #region PartialView
        public async Task<IActionResult> PikturatBallina(int picsPage = 1)
        {
            var queryPics = _context.Pikturat.AsNoTracking().OrderByDescending(s => s.IdPiktura);
            var modelPics = await PagingList.CreateAsync(queryPics, 4, picsPage);
            modelPics.Action = "PikturatBallina";
            modelPics.PageParameterName = "picsPage";
            ViewBag.PikturatBallina = modelPics;

            return View();
        }

        public async Task<IActionResult> EkspozitatBallina(int eksPage = 1)
        {
            var queryEkspozitat = _context.Ekspozitat.AsNoTracking().OrderByDescending(s => s.Id_Ekspozites);
            var modelEkspozitat = await PagingList.CreateAsync(queryEkspozitat, 4, eksPage);
            modelEkspozitat.Action = "EkspozitatBallina";
            modelEkspozitat.PageParameterName = "eksPage";
            ViewBag.EkspozitatBallina = modelEkspozitat;

            return View();
        }

        public async Task<IActionResult> PanoramikeBallina(int PanPage = 1)
        {
            var queryPanoramike = _context.Pikturat.AsNoTracking().Where(a => a.Karakteristikat == "PANORAMIKE").OrderByDescending(s => s.IdPiktura);
            var modelPanoramike = await PagingList.CreateAsync(queryPanoramike, 4, PanPage);
            modelPanoramike.Action = "PanoramikeBallina";
            modelPanoramike.PageParameterName = "PanPage";
            ViewBag.PanoramikeBallina = modelPanoramike;

            return View();
        }
        public async Task<IActionResult> NatyreBallina(int NatPage = 1)
        {

            var queryNatyre = _context.Pikturat.AsNoTracking().Where(a => a.Karakteristikat == "NATYRE").OrderByDescending(s => s.IdPiktura);
            var modelNatyre = await PagingList.CreateAsync(queryNatyre, 4, NatPage);
            modelNatyre.Action = "NatyreBallina";
            modelNatyre.PageParameterName = "NatPage";
            ViewBag.NatyreBallina = modelNatyre;
            return View();
        }

        public async Task<IActionResult> AbstrakteBallina(int AbstPage = 1)
        {

            var queryAbstrakte = _context.Pikturat.AsNoTracking().Where(a => a.Karakteristikat == "ABSTRAKTE").OrderByDescending(s => s.IdPiktura);
            var modelAbstrakte = await PagingList.CreateAsync(queryAbstrakte, 4, AbstPage);
            modelAbstrakte.Action = "AbstrakteBallina";
            modelAbstrakte.PageParameterName = "AbstPage";
            ViewBag.AbstrakteBallina = modelAbstrakte;
            return View();
        }


        public async Task<IActionResult> BardhDheZiBallina(int BZPage = 1)
        {
            var queryBardhEZi = _context.Pikturat.AsNoTracking().Where(a => a.Karakteristikat == "BARDH DHE ZI").OrderByDescending(s => s.IdPiktura);
            var modelBardhEZi = await PagingList.CreateAsync(queryBardhEZi, 4, BZPage);
            modelBardhEZi.Action = "BardhDheZiBallina";
            modelBardhEZi.PageParameterName = "BZPage";
            ViewBag.BardhDheZiBallina = modelBardhEZi;

            return View();
        }
        #endregion


        #endregion





        #region PIKTURAT

        public async Task<IActionResult> Pikturat(int page = 1)
        {
            var query = _context.Pikturat.AsNoTracking().OrderByDescending(s => s.IdPiktura);
            var model = await PagingList.CreateAsync(query, 9, page);
            model.Action = "Pikturat";

            return View(model);
        }

        #endregion]


        #region EKSPOZITAT

        public async Task<IActionResult> Ekspozitat(int page = 1)
        {

            var query = _context.Ekspozitat.AsNoTracking().OrderByDescending(s => s.Id_Ekspozites);
            var model = await PagingList.CreateAsync(query, 4, page);
            model.Action = "Ekspozitat";



            return View(model);
        }

        //Ne faqen ekspozitat kur te klikojm shiko pikturat, te ekspozites se caktuar
        public async Task<IActionResult> Ekspozita(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var pikturat = await _context.Pikturat.Where(a  => a.Ekspozitat == id).ToListAsync();


            WebPikturatEkspozita _pikturat;

            //Lista qe ktheht te klienti, me pikturat qe kane id e ekespozites
            List<WebPikturatEkspozita> _pics = new List<WebPikturatEkspozita>();

            foreach (Pikturat item in pikturat)
            {
                _pikturat = new WebPikturatEkspozita();
                _pikturat.UrlPath = item.UrlPath.Substring(2);
                _pikturat.TitulliPiktures = item.TitulliPiktures;
                _pikturat.Karakteristikat = item.Karakteristikat;
                _pikturat.DataPostimit = item.DataPostimit;
                _pikturat.LLojiPiktures = item.LLojiPiktures;
                _pikturat.CmimiPiktures = item.CmimiPiktures;
                _pikturat.Disponueshmeria = item.Disponueshmeria;
                _pics.Add(_pikturat);
            }


            if (_pics == null)
            {
                return NotFound();
            }
            return View(_pics);
        }


        #endregion


        #region PERDORUESIT

        private List<WebPikturatArtistet> _usersTrashegimtaret = new List<WebPikturatArtistet>();
        private int TrashegimtaretPageSize = 8;
        public async Task<IActionResult> Trashegimtaret(int page = 1)
        {

            _usersTrashegimtaret = new List<WebPikturatArtistet>();
            var query = _appContext.Users.AsNoTracking().OrderByDescending(s => s.Id);
            PagingList<ApplicationUser> model = await PagingList.CreateAsync(query, TrashegimtaretPageSize, page);




            WebPikturatArtistet _usr;

            foreach (var item in model)
            {
                var roliUzerit = _userManager.GetRolesAsync(item);
                if (roliUzerit.Result.Count == 1 && roliUzerit.Result[0] == "Trashegimtar")
                {
                    _usr = new WebPikturatArtistet();

                    _usr.Roli = roliUzerit.Result[0];

                    if (item.PhotoPath == null) _usr.UrlPhoto = "/Upload/Images/withoutProfilPhoto.jpg";
                    else _usr.UrlPhoto = item.PhotoPath;
                    _usr.Emri = item.FirstName;
                    _usr.Mbiemri = item.LastName;
                    _usr.NrTelefonit = item.PhoneNumber;
                    _usr.Email = item.Email;
                    _usersTrashegimtaret.Add(_usr);
                }

            }

            if (_usersTrashegimtaret.Count < 8 && page * TrashegimtaretPageSize <= query.Count())
            {

                TrashegimtaretPageSize *= 2;
                return await Trashegimtaret(page);
            }


            TrashegimtaretPageSize = 8;
            ViewBag.modelTrashegimtaret = model;
            model.Action = "Trashegimtaret";




            WebPikturatArtistet[] userTrashegimtaret = new WebPikturatArtistet[8];

            for (int i = 0; i < 8; i++)
            {
                if (_usersTrashegimtaret.Count >= 1)
                {
                    userTrashegimtaret[i] = _usersTrashegimtaret.First();
                    _usersTrashegimtaret.RemoveAt(0);
                }
            }

            return View(userTrashegimtaret);
        }


        private List<WebPikturatArtistet> _usersKlientet = new List<WebPikturatArtistet>();
        private int klientPageSize = 8;
        public async Task<IActionResult> Klientet(int page = 1)
        {

            _usersKlientet = new List<WebPikturatArtistet>();
            var query = _appContext.Users.AsNoTracking().OrderByDescending(s => s.Id);
            PagingList<ApplicationUser> model = await PagingList.CreateAsync(query, klientPageSize, page);
         

            

            WebPikturatArtistet _usr;
           
            foreach (var item in model)
            {
                var roliUzerit = _userManager.GetRolesAsync(item);
                if (roliUzerit.Result.Count == 1 && roliUzerit.Result[0] == "Klient")
                {
                    _usr = new WebPikturatArtistet();

                    _usr.Roli = roliUzerit.Result[0];

                    if (item.PhotoPath == null) _usr.UrlPhoto = "/Upload/Images/withoutProfilPhoto.jpg";
                    else _usr.UrlPhoto = item.PhotoPath;
                    _usr.Emri = item.FirstName;
                    _usr.Mbiemri = item.LastName;
                    _usr.NrTelefonit = item.PhoneNumber;
                    _usr.Email = item.Email;
                    _usersKlientet.Add(_usr);
                }
                if (roliUzerit.Result.Count < 1) 
                { 
                    _usr = new WebPikturatArtistet();

                    _usr.Roli = "Klient";

                    if (item.PhotoPath == null) _usr.UrlPhoto = "/Upload/Images/withoutProfilPhoto.jpg";
                    else _usr.UrlPhoto = item.PhotoPath;
                    _usr.Emri = item.FirstName;
                    _usr.Mbiemri = item.LastName;
                    _usr.NrTelefonit = item.PhoneNumber;
                    _usr.Email = item.Email;
                    _usersKlientet.Add(_usr);
                }
            }

            if (_usersKlientet.Count < 8 && page * klientPageSize <= query.Count())
            {

                klientPageSize *= 2;
                return await Klientet(page);
            }


            klientPageSize = 8;
            ViewBag.modelKlientet = model;
            model.Action = "Klientet";




            WebPikturatArtistet[] userKlientet = new WebPikturatArtistet[8];

            for (int i = 0; i < 8; i++)
            {
                if (_usersKlientet.Count >= 1)
                {
                    userKlientet[i] = _usersKlientet.First();
                    _usersKlientet.RemoveAt(0);
                }
            }

            return View(userKlientet);
        }



        private List<WebPikturatArtistet> _usersArtistet = new List<WebPikturatArtistet>();
        private int ArtistetPageSize = 8;
        public async Task<IActionResult> Artistet(int page = 1)
        {
            _usersArtistet = new List<WebPikturatArtistet>();
            var query = _appContext.Users.AsNoTracking().OrderByDescending(s => s.Id);
            PagingList<ApplicationUser> model = await PagingList.CreateAsync(query, ArtistetPageSize, page);




            WebPikturatArtistet _usr;

            foreach (var item in model)
            {
                var roliUzerit = _userManager.GetRolesAsync(item);
                if (roliUzerit.Result.Count == 1 && roliUzerit.Result[0] == "Piktor")
                {
                    _usr = new WebPikturatArtistet();

                    _usr.Roli = roliUzerit.Result[0];

                    if (item.PhotoPath == null) _usr.UrlPhoto = "/Upload/Images/withoutProfilPhoto.jpg";
                    else _usr.UrlPhoto = item.PhotoPath;
                    _usr.Emri = item.FirstName;
                    _usr.Mbiemri = item.LastName;
                    _usr.NrTelefonit = item.PhoneNumber;
                    _usr.Email = item.Email;
                    _usersArtistet.Add(_usr);
                }
                
            }


            if (_usersArtistet.Count < 8 && page * ArtistetPageSize <= query.Count())
            {

                ArtistetPageSize *= 2;
                return await Artistet(page);
            }

           


            WebPikturatArtistet[] userArtistet = new WebPikturatArtistet[8];

            for (int i = 0; i < 8; i++)
            {
                if (_usersArtistet.Count >= 1)
                {
                    userArtistet[i] = _usersArtistet.First();
                    _usersArtistet.RemoveAt(0);
                }
            }


            ArtistetPageSize = 8;
            ViewBag.modelArtistet = model;
            model.Action = "Artistet";

            return View(userArtistet);
        }

        #endregion


        #region KRITIKAT


        [Authorize]
        public async Task<IActionResult> Kritika(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            WebPikturatKritika webPikturatKritika = new WebPikturatKritika();

            //Piktura qe do te komentohet
            Pikturat piktura = await _context.Pikturat.FindAsync(id);


            //Komentet e piktures
            webPikturatKritika.komentet = await _context.Kritikat.Where(x => x.Id_Piktura == id).ToListAsync();


           
            webPikturatKritika.UrlPath = piktura.UrlPath.Substring(2);
            webPikturatKritika.TitulliPiktures = piktura.TitulliPiktures;
            webPikturatKritika.Disponueshmeria = piktura.Disponueshmeria;
            webPikturatKritika.Pershkrimi = piktura.Pershkrimi;


            ViewBag.IDPiktura = id;
            return View(webPikturatKritika);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Kritika([Bind("Id_Kritika,Id_Useri,Id_Piktura,TekstiKritikes")] Kritikat kritikat)
        {
            if(kritikat.TekstiKritikes == null)
            {
                return RedirectToAction(nameof(Pikturat));
                
            }
            else
            {
                kritikat.Id_Useri = User.Identity.Name;

                if (!TryValidateModel(kritikat))
                {
                    _context.Add(kritikat);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Kritika));
                }

                return RedirectToAction(nameof(Pikturat));
            }
           
        }


        #endregion


        #region ShportaBlerja


        [Authorize]
        public async Task<IActionResult> ShportaBlerja(int? id, decimal? cmimi)
        {
            if (id == null || cmimi == null)
            {
                return NotFound();
            }

            //piktura
            var piktura = await _context.Pikturat.FindAsync(id);

            if(piktura.Disponueshmeria == "Jo e Shitur")
            {

                //modeli per insertimin e te dhenave ne tabelen Shporta
                Shporta shporta = new Shporta();

                //email i uzerit
                shporta.Id_UseriKlient = User.Identity.Name;

                shporta.Id_Piktura = (int)id;
                shporta.Cmimi = (decimal)cmimi;
                shporta.Blerja = false;

                //Ruajtja e porosise ne shport
                _context.Add(shporta);
                await _context.SaveChangesAsync();

                //vendosja e te dhenave per rezervim dhe id te shportes ne tabelen Pikturat
                piktura.Disponueshmeria = "Rezervuar";
                piktura.Shporta = shporta.Id_Shporta;
                _context.Update(piktura);
                await _context.SaveChangesAsync();


                //vendosja e id dhe kohes se rezervimit ne objekt.
                KronologjiaShportes kronologjiaKerkeses = new KronologjiaShportes(shporta.Id_Shporta);
            }



            return RedirectToAction("ShportaBlerjeve", "Administrimi");



           
        }


        #endregion


        #region KONTAKTO

        [Authorize]
        public IActionResult KontaktoArtistin(string email)
        {
            if (email.Length <= 0)
            {
                return NotFound();
            }


            WebPikturatKontakto webPikturatKontakto = new WebPikturatKontakto();
            webPikturatKontakto.from = User.Identity.Name;

            webPikturatKontakto.to = email;


            return View(webPikturatKontakto);
        }

        [Authorize]
        public IActionResult Kontakto()
        { 
            WebPikturatKontakto webPikturatKontakto = new WebPikturatKontakto();
            webPikturatKontakto.from = User.Identity.Name;
            return View(webPikturatKontakto);
        }

        [HttpPost]
        public async Task<IActionResult> Kontakto([Bind("from,to,subject,mesazhi")] WebPikturatKontakto webPikturatKontakto)
        {
            if (ModelState.IsValid)
            {

                //emri derguesit
                string nameFrom = _appContext.Users.FirstOrDefault(e => e.Email == webPikturatKontakto.from).FirstName;

                //emri pranuesit te mesazhit
                string nameTo = _appContext.Users.FirstOrDefault(e => e.Email == webPikturatKontakto.to).FirstName;



                var apiKey = _configuration.GetValue<string>("Sendgrid-ApiKey:applicationKey");
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(webPikturatKontakto.from, nameFrom);
                var to = new EmailAddress(webPikturatKontakto.to, nameTo);
                var subject = webPikturatKontakto.subject;
                var plainTextContent = "";
                var htmlContent = "<strong> "+ webPikturatKontakto.mesazhi + " </strong>";
                var msg = MailHelper.CreateSingleEmail(
                    from,
                    to,
                    subject,
                    plainTextContent,
                    htmlContent
                    );

                var response = await client.SendEmailAsync(msg);


            }
            return RedirectToAction(nameof(KontaktoC));
        }

        public IActionResult KontaktoC()
        {
            return View();
        }


        #endregion



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}