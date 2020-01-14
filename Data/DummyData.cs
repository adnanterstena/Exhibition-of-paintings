using EkspozitaPikturave.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkspozitaPikturave.Data
{
    public class DummyData
    {

        public static async Task Initialize(ApplicationDbContext context,
                             UserManager<ApplicationUser> userManager,
                             RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";
            String adminId2 = "";

            string role1 = "Admin";
            string desc1 = "Ky eshte roli administratiorit";

            string role2 = "Klient";
            string desc2 = "Ky eshte roli qe e posedojne klientet";

            string role3 = "Piktor";
            string desc3 = "Ky eshte roli per artistet qe jane piktor";

            string role4 = "Trashegimtar";
            string desc4 = "Ky eshte roli per ata qe posedojne piktura, trasheguesit e pikturave";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role3) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role3, desc3, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role4) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role4, desc4, DateTime.Now));
            }

            /*
            if (await userManager.FindByNameAsync("aa@dd.dd") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "aa@dd.dd",
                    Email = "a@dd.dd",
                    FirstName = "ADonald",
                    LastName = "ADuck",
                    Street = "AWell St",
                    City = "AVancouver",
                    Province = "ABC",
                    PostalCode = "AV8U R9Y",
                    Country = "Kosova",
                    PhoneNumber = "66041234567"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role4);
                }
            }
            */
        }
    }
}
