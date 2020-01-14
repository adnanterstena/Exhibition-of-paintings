using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EkspozitaPikturave.Data;
using EkspozitaPikturave.Models;
using EkspozitaPikturave.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace EkspozitaPikturave.Controllers
{
    [Authorize]
    public class AdministrimiController : Controller
    {
        private readonly PikturatEKSContents _context;
        private readonly UserManager<ApplicationUser> _userManager;
        [Obsolete]
        readonly IHostingEnvironment _env;


        [Obsolete]
        public AdministrimiController(PikturatEKSContents context, UserManager<ApplicationUser> userManager, IHostingEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }



        #region POSTIMI

        public IActionResult Postimi()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Postimi([Bind("IdPiktura,UrlPath,TitulliPiktures,ID_Useri,Pershkrimi,Karakteristikat,DataPostimit,Ekspozitat,LLojiPiktures,CmimiPiktures,Disponueshmeria,Shporta")] Pikturat pikturat, IFormFile file)
        {

            //FileUpload
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\Upload\Images\Pikturat\";
                var uploadPath = _env.WebRootPath + imagePath;

                //Create Directory
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                //Create Uniq file name
                var uniqFileName = Guid.NewGuid().ToString();
                var filename = Path.GetFileName(uniqFileName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + filename;


                var filePath = @".." + Path.Combine(imagePath, filename);

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                //urlPathi i piktures
                pikturat.UrlPath = filePath;
            }


            //id e uzerit te tabelen e pikutrave
            var user = await _userManager.GetUserAsync(User);
            pikturat.ID_Useri = user.Id;

            DateTime localDate = DateTime.Now;
            pikturat.DataPostimit = localDate;


            if (!TryValidateModel(pikturat, nameof(pikturat)))
            {
                _context.Add(pikturat);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(PostimiC));


        }

        public IActionResult PostimiC()
        {
            return View();
        }

        #endregion


        #region PIKTURAT E MIA


        public async Task<IActionResult> EditPikturat(int page = 1)
        {

            string idUser = _userManager.GetUserId(User);

            //query me kushtin kolona UD_Useri i piktures te kete id e Uzerit!
            var query = _context.Pikturat.AsNoTracking().Where(a => a.ID_Useri == idUser).OrderByDescending(s => s.IdPiktura);

            var model = await PagingList.CreateAsync(query, 4, page);
            model.Action = "EditPikturat";

          
            return View(model);

              

        }
        public async Task<IActionResult> EditPikturatID(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pikturat = await _context.Pikturat.FindAsync(id);
            if (pikturat == null)
            {
                return NotFound();
            }
            return View(pikturat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPikturatID(int id, [Bind("IdPiktura,UrlPath,TitulliPiktures,Pershkrimi,Karakteristikat,DataPostimit,Ekspozitat,LLojiPiktures,CmimiPiktures,Disponueshmeria,Shporta")] Pikturat pikturat)
        {


            var user = await _userManager.GetUserAsync(User);
            pikturat.ID_Useri = user.Id;

            if (id != pikturat.IdPiktura)
            {
                return NotFound();
            }

            if (!TryValidateModel(pikturat, nameof(pikturat)))
            {
                try
                {
                    _context.Update(pikturat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PikturatExists(pikturat.IdPiktura))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EditPikturat));
            }
            return View(pikturat);
        }
        private bool PikturatExists(int id)
        {
            return _context.Pikturat.Any(e => e.IdPiktura == id);
        }
        
        public async Task<IActionResult> DeletePicture(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pikturat = await _context.Pikturat.FindAsync(id);

            if (pikturat == null)
            {
                return NotFound();
            }

            var komentetPerPikturen = await _context.Kritikat.Where(x => x.Id_Piktura == pikturat.IdPiktura).ToListAsync();
            foreach (var item in komentetPerPikturen)
            {
                _context.Kritikat.Remove(item);
            }
            await _context.SaveChangesAsync();

            _context.Pikturat.Remove(pikturat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EditPikturat));
        }

        #endregion


        #region EKSPOZITAT

        public async Task<IActionResult> Ekspozitat(int page = 1)
        {
            string emailUser = User.Identity.Name;

            var query = _context.Ekspozitat.AsNoTracking().Where(a => a.uzerEmail == emailUser).OrderByDescending(s => s.Id_Ekspozites);

            var model = await PagingList.CreateAsync(query, 3, page);
            model.Action = "Ekspozitat";

          
            return View(model);
        }

        public async Task<IActionResult> CreateEkspozita()
        {

            var pics = await _context.Pikturat.ToListAsync();

            string idUser = _userManager.GetUserId(User);
            List<Pikturat> UserPictures = new List<Pikturat>();

            foreach (var item in pics)
            {
                if (item.ID_Useri == idUser)
                {
                    UserPictures.Add(item);
                }
            }


            UserPictures.Reverse();

            CreateEkspozitaModel createEkspozitaModel = new CreateEkspozitaModel();

            createEkspozitaModel._pikturat = UserPictures;

            return View(createEkspozitaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> CreateEkspozita([Bind("_ekspozita")] CreateEkspozitaModel ekspozitat, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\Upload\Images\Pikturat\";
                var uploadPath = _env.WebRootPath + imagePath;

                //Create Directory
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                //Create Uniq file name
                var uniqFileName = Guid.NewGuid().ToString();
                var filename = Path.GetFileName(uniqFileName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + filename;


                var filePath = @".." + Path.Combine(imagePath, filename);

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                //urlPathi i piktures
                ekspozitat._ekspozita.FotojaURL = filePath;
            }

            if (!TryValidateModel(ekspozitat, nameof(ekspozitat)))
            {

                ekspozitat._ekspozita.uzerEmail = User.Identity.Name;
                _context.Add(ekspozitat._ekspozita);
                await _context.SaveChangesAsync();


                //Per te pastru listen statike (_idPikturattt), nga grupimi per fotot e ekspozites
                List<KeyValuePair<string, int>> fototPerEkspoziten = new List<KeyValuePair<string, int>>();
                //lista me idUserin dhe idFotografine
                foreach (KeyValuePair<string, int> item in _idPikturattt)
                {
                    if (item.Key == User.Identity.Name)
                    {
                        //rreshti ne tabeles pikturat qe ka id-n e fotos
                        var pikturat = await _context.Pikturat.FindAsync(item.Value);

                        //vendosja ids se ekspozites, te tabela Pikturat -> kolona 'ekspozita' 
                        pikturat.Ekspozitat = ekspozitat._ekspozita.Id_Ekspozites;

                        try
                        {
                            _context.Update(pikturat);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!PikturatExists(pikturat.IdPiktura))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                        fototPerEkspoziten.Add(item);
                    }
                }
                foreach (var item in fototPerEkspoziten)
                {
                    _idPikturattt.Remove(item);
                }
                
              
                return RedirectToAction(nameof(Ekspozitat));
            }
            return View(ekspozitat);
        }


        //Lista per grupimet e fotove ne nje ekspozite, duke ruajtur id e uzerit dhe id e fotografise
        static List<KeyValuePair<string, int>> _idPikturattt = new List<KeyValuePair<string, int>>();

        [HttpPost]
        public void addIdPictures(int idPiktura)
        {
            //imella e uzerit
            string uEmail = User.Identity.Name;
            //vendos ne listen statike id e uzerit dhe ate te piktures
            _idPikturattt.Add(new KeyValuePair<string, int>(uEmail, idPiktura));
        }


        public async Task<IActionResult> DeleteEkspozita(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekspozita = await _context.Ekspozitat.FindAsync(id);

            if (ekspozita == null)
            {
                return NotFound();
            }
            _context.Ekspozitat.Remove(ekspozita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Ekspozitat));
        }



        #endregion


        #region ShportaBlerjeve

        //Shporta per klientet
        public async Task<IActionResult> ShportaBlerjeve()
        {

            //Filrimi kerkesave
            AfatiKerkesavePrej5Diteve();


            var rezervimet = await _context.Shporta.Where(a => a.Id_UseriKlient == User.Identity.Name).ToListAsync();


            List<AdministrimiShportaBlerjeve> administrimiShportaBlerjeve = new List<AdministrimiShportaBlerjeve>();

            AdministrimiShportaBlerjeve admBlerjeve;

            foreach (var item in rezervimet)
            {
                var pikturat = await _context.Pikturat.FindAsync(item.Id_Piktura);

               
                if(pikturat != null) //Kur piktura nuk esht fshire
                {

                    admBlerjeve = new AdministrimiShportaBlerjeve();
                    admBlerjeve.titulliPiktures = pikturat.TitulliPiktures;
                    admBlerjeve.urlPiktura = pikturat.UrlPath;
                    admBlerjeve.cmimi = item.Cmimi;
                    if (item.Blerja == true) admBlerjeve.Blerja = "E konfirmuar";
                    else admBlerjeve.Blerja = "Në pritje";


                    administrimiShportaBlerjeve.Add(admBlerjeve);
                }
               
            }

            administrimiShportaBlerjeve.Reverse();

            return View(administrimiShportaBlerjeve);

        }

        //Paraqitja e kerkesave te klienteve per blerjen e pikturave
        public async Task<IActionResult> MenagjimiBlerjeve()
        {
            //Filrimi kerkesave
            AfatiKerkesavePrej5Diteve();
        
            // id e uzerit te Piktorit ose trashegimtarit
            var user = await _userManager.GetUserAsync(User);

            //lista e pikturave qe kane id e uzerit dhe qe nuk kane vleren e shportes null, (pikturat qe jane ne shporte)
            var pikturat = await _context.Pikturat.Where(pic => pic.ID_Useri == user.Id && pic.Shporta != null).ToListAsync();


            List<AdministrimiMenagjimiBlerjeve> _administrimiMenagjimiBlerjeve = new List<AdministrimiMenagjimiBlerjeve>();
            AdministrimiMenagjimiBlerjeve administrimiMenagjimiBlerjeve;

            foreach (var item in pikturat)
            {
                administrimiMenagjimiBlerjeve = new AdministrimiMenagjimiBlerjeve()
                {
                    UrlPiktura = item.UrlPath,
                    Titulli = item.TitulliPiktures,
                    Cmimi = item.CmimiPiktures,
                    idShporta = (int)item.Shporta
                };

                _administrimiMenagjimiBlerjeve.Add(administrimiMenagjimiBlerjeve);

            }

            return View(_administrimiMenagjimiBlerjeve);
        }

        public async Task<IActionResult> KonfirmimiBlerjeve(int? id)
        {


            //kolona blerja behet true, ne tabelen Shporta
            Shporta shporta = await _context.Shporta.FindAsync(id);
            shporta.Blerja = true;

            _context.Update(shporta);


            //Kolona Shporta, ne tabelen Pikturat behet null
            var piktura = await _context.Pikturat.Where(a => a.Shporta == id).ToListAsync();
            piktura[0].Shporta = null;
            piktura[0].Disponueshmeria = "Shitur";
            _context.Update(piktura[0]);


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MenagjimiBlerjeve));

        }

        public async Task<IActionResult>  FshirjaKerkesesPerBlerje(int? id)
        {

            //Fshirja e porosise ne tabelen Shporta
            Shporta item = await _context.Shporta.FindAsync(id);
            _context.Shporta.Remove(item);


            //Kolona Shporta, ne tabelen Pikturat behet null, dhe disponueshmeria 'jo e shitur'
            var piktura = await _context.Pikturat.Where(a => a.Shporta == id).ToListAsync();
            piktura[0].Shporta = null;
            piktura[0].Disponueshmeria = "Jo e Shitur";
            _context.Update(piktura[0]);


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MenagjimiBlerjeve));

        }



        private async void AfatiKerkesavePrej5Diteve()
        {
            // -------------- Kalimi i afatit te kerkesave per blerjen e pikturave ------
            KronologjiaShportes kronologjiaKerkeses = new KronologjiaShportes();
            var kerkesat = kronologjiaKerkeses.getGjendjaKerkesave();

            foreach (var item in kerkesat)
            {
                if (DateTime.Now - item.Koha > TimeSpan.FromDays(5))
                {
                    //Fshirja e lista e kerkesave
                    KronologjiaShportes fshirjaKerkeses = new KronologjiaShportes(item);


                    //Fshirja e porosise ne tabelen Shporta
                    Shporta row = await _context.Shporta.FindAsync(item.IdShportes);
                    _context.Shporta.Remove(row);


                    //Kolona Shporta, ne tabelen Pikturat behet null, dhe disponueshmeria 'jo e shitur'
                    var piktura = await _context.Pikturat.Where(a => a.Shporta == item.IdShportes).ToListAsync();
                    piktura[0].Shporta = null;
                    piktura[0].Disponueshmeria = "Jo e Shitur";
                    _context.Update(piktura[0]);


                    await _context.SaveChangesAsync();
                }
            }
        }


        #endregion

    }

}