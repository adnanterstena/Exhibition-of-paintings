﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using EkspozitaPikturave.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace EkspozitaPikturave.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public Register Input { get; set; }

        public class Register
        {

            [Required(ErrorMessage = "Duhet të plotësohet Emaili.")]
            [EmailAddress(ErrorMessage = "Emaili duhet të plotësohet ne formatin e duhur!")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Duhet të plotësohet Fjalëkalimi.")]
            [StringLength(100, ErrorMessage = "{0} duhet të jetë me {2} karaktere më së paku, dhe me maksimum {1} karaktere.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Fjalëkalimi")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Konfirmoni Fjalëkalimin")]
            [Compare("Password", ErrorMessage = "Nuk është i njejtë me passwordin paraprak!")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Duhet të plotësohet Emri.")]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "{0} duhet të jetë me {2} karaktere më së paku, dhe me maksimum {1} karaktere.", MinimumLength = 2)]
            [Display(Name = "Emri")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Duhet të plotësohet Mbiemri.")]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "{0}  duhet të jetë me {2} karaktere më së paku, dhe me maksimum {1} karaktere.", MinimumLength = 2)]
            [Display(Name = "Mbiemri")]
            public string LastName { get; set; }

            [DataType(DataType.Text)]
            [MaxLength(50)]
            [Display(Name = "Adresa e rrugës")]
            public string Street { get; set; }

            [DataType(DataType.Text)]
            [MaxLength(50)]
            [Display(Name = "Qyteti")]
            public string City { get; set; }

            [DataType(DataType.Text)]
            [MaxLength(50)]
            [Display(Name = "Krahina")]
            public string Province { get; set; }

            [DataType(DataType.Text)]
            [MaxLength(15)]
            [Display(Name = "Kodi Postar")]
            public string PostalCode { get; set; }

            [DataType(DataType.Text)]
            [MaxLength(35)]
            [Display(Name = "Shteti")]
            public string Country { get; set; }
        }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

      

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                //var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };

                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    Street = Input.Street,
                    City = Input.City,
                    Province = Input.Province,
                    PostalCode = Input.PostalCode,
                    Country = Input.Country
                };



                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
