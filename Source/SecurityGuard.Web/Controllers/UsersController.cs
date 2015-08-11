using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Owin;
using SecurityGuard.Web.Models;

namespace SecurityGuard.Web.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class UsersController : AccountBaseController
    { 
        public async Task<ActionResult> Index(string username) 
        { 
            var user = await UserManager.FindByNameAsync(HttpUtility.UrlDecode(username));

            //var user = await  this.UserManager.FindByNameAsync(username);
            var viewModel = new UserViewModel
            {
                Username = user.UserName,
                Email = user.Email,
                Roles = user.Roles,
                LockedOut = user.LockoutEnabled,
                LockedOutEndDate = user.LockoutEndDate
            };

            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(HttpUtility.UrlDecode(userViewModel.Username));
                if (user != null)
                {
                    await UserManager.SetLockoutEnabledAsync(user.Id, userViewModel.LockedOut);

                    return RedirectToAction("List", "Users");
                }
                else
                { 
                    ModelState.AddModelError("", "User was not found.");
                }
            }
            return View(userViewModel);
        }




        public ActionResult List()
        {
            var list = this.UserManager.Users.Select(user=> new UserViewModel
            {
                Username = user.UserName,
                Email = user.Email,
                Roles = user.Roles,
                LockedOut = user.LockoutEnabled,
                LockedOutEndDate = user.LockoutEndDate
            }).ToList(); 

            
            return View(list);
        }
    }


    public class UserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTimeOffset LockedOutEndDate { get; set; }
        public bool LockedOut { get; set; }
        public IList<string> Roles { get; set; }
    }

}
