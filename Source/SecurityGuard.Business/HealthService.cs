namespace SecurityGuard.Business
{
    public class HealthService : IHealthService
    {
        public bool CheckDatabase()
        {
            return true;
        }

        public bool CheckCertificate()
        {
            return true;
        }

        public string GetWebServerName(string machineName)
        {
            return "Web3";
        }
    }
}