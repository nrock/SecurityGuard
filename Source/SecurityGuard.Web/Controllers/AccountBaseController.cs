using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace SecurityGuard.Web.Controllers
{
    public class AccountBaseController : Controller
    {
        
        private ApplicationUserManager _userManager;

        public AccountBaseController()
        {
        }

        public AccountBaseController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            protected set
            {
                _userManager = value;
            }
        }
         
    }
}