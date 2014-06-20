using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityGuard.Web.Controllers
{
    public class UsersController : AccountBaseController
    {
        // GET: Users
        public ActionResult Index(string username)
        {

            return View();
        }  


        public ActionResult List()
        {
            var list = this.UserManager.Users.Select(x=> new UserViewModel
            {
                Username = x.UserName,
                Email = x.Email,
                Roles = x.Roles
            }).ToList(); 

            
            return View(list);
        }
    }


    public class UserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }

}