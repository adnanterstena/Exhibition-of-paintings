using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EkspozitaPikturave.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace EkspozitaPikturave.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        [Obsolete]
        IHostingEnvironment _env;

     
        [Obsolete]
        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHostingEnvironment environment
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _env = environment;
        }
        [Display(Name = "Useri")]
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }


        public class InputModel
        {
            [Phone]
            [Display(Name = "Numri telefonit")]
            public string PhoneNumber { get; set; }
        }

        [BindProperty]
        public InputRolesModel InputRoles { get; set; }


        public class InputRolesModel
        {
            
            [Display(Name = "Roli")]
            public string Roles { get; set; }
        }



        public string profilePhoto = "/Upload/Images/withoutProfilPhoto.jpg";


        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var roleU = await _userManager.GetRolesAsync(user);


            if(user.PhotoPath != null)
            {
                profilePhoto = user.PhotoPath.Substring(2);
            }


            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };


            if (roleU.Any()) { 
                InputRoles = new InputRolesModel
                {
                    Roles = roleU[0]

                };
            }  




        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        [Obsolete]
        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            //-------------------
            var roleU = await _userManager.GetRolesAsync(user);
            if(roleU.Count > 0)
            {
                for (int i = 0; i < roleU.Count; i++)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleU[i]);
                }
            }
            
            string varIR = InputRoles.Roles;
            await _userManager.AddToRoleAsync(user, varIR);

            //-------------------


            //FileUpload

            if (file != null && file.Length > 0)
            {
                var imagePath = @"\Upload\Images\ProfilPics\";
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





                var app_user = await _userManager.GetUserAsync(User);
                app_user.PhotoPath = filePath;

                await _userManager.UpdateAsync(app_user);



            }




            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Profili juaj u perditesua me sukses";
            return RedirectToPage();
        }
    }
}
