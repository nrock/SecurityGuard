using System;

namespace SecurityGuard.Web.Models
{
    public class HealthViewModel
    {
        #region Public Properties

        public bool IsDatabaseAlive { get; set; }

        public bool Status { get; set; }

        public bool IsCertificateValid { get; set; }

        public string WebServerName { get; set; }

        public TimeSpan CampaignClose { get; set; }

        #endregion

    }
}