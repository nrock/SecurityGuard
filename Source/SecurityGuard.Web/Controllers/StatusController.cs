using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityGuard.Business;
using SecurityGuard.Web.Models;

namespace SecurityGuard.Web.Controllers
{
    public class StatusController : Controller
    {

        private readonly IApplicationSettings _applicationSettings;
        private readonly IHealthService _healthService;

        public StatusController(IApplicationSettings applicationSettings, IHealthService healthService)
        {
            this._applicationSettings = applicationSettings;
            this._healthService = healthService;
        }
        public StatusController( )
        {
            this._applicationSettings = new ApplicationSettings();
            this._healthService = new HealthService();
        }

        public ActionResult Index()
        {
            var endDate = _applicationSettings.EndDate;

            if (endDate == null)
            {
                endDate = DateTime.Now;
            }

            var closeDate = endDate - DateTime.Now;
            var isDatabaseAlive = _healthService.CheckDatabase();
            var isCertificateValid = _healthService.CheckCertificate();
            var webServerName = _healthService.GetWebServerName(System.Environment.MachineName);
            var applicationStatus = (isDatabaseAlive && isCertificateValid);

            var model = new HealthViewModel { IsDatabaseAlive = isDatabaseAlive, Status = applicationStatus, IsCertificateValid = isCertificateValid, WebServerName = webServerName, CampaignClose = closeDate };
            return View(model);
        }


    }
}