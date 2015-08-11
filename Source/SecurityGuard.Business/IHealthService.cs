namespace SecurityGuard.Business
{
    public interface IHealthService
    {
        bool CheckDatabase();
        bool CheckCertificate();
        string GetWebServerName(string machineName);
    }
}