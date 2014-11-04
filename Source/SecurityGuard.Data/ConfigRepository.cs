using SecurityGuard.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityGuard.Data
{

    public interface IConfigRepository
    {
        string GetSmtpServer();
        string GetGetMailgunApiKey();
        string GetMailgunApiUrl();
        string GetMailgunDomain();
        string GetShowVideo();
        bool GetEmailTestMode();
        string GetForgotPasswordEmailTemplate();
        string GetForgotPasswordEmailSubject(); 

        void SetSmtpServer(string smtpServer);
        void SetGetMailgunApiKey(string smtpServer);
        void SetMailgunApiUrl(string smtpServer);
        void SetMailgunDomain(string smtpServer);
        void SetShowVideo(string smtpServer);
        void SetEmailTestMode(string smtpServer);
        void SetForgotPasswordEmailTemplate(string smtpServer);
        void SetForgotPasswordEmailSubject(string smtpServer); 
    }

    public class ConfigRepostiory : IConfigRepository
    {
        public ConfigRepostiory(string connectionString)
        {


        }
        public string GetSmtpServer()
        {
            throw new NotImplementedException();
        }

        public string GetGetMailgunApiKey()
        {
            throw new NotImplementedException();
        }

        public string GetMailgunApiUrl()
        {
            throw new NotImplementedException();
        }

        public string GetMailgunDomain()
        {
            throw new NotImplementedException();
        }

        public string GetShowVideo()
        {
            throw new NotImplementedException();
        }

        public bool GetEmailTestMode()
        {
            throw new NotImplementedException();
        }

        public string GetForgotPasswordEmailTemplate()
        {
            throw new NotImplementedException();
        }

        public string GetForgotPasswordEmailSubject()
        {
            throw new NotImplementedException();
        }

        public void SetSmtpServer(string smtpServer)
        {
            throw new NotImplementedException();
        }

        public void SetGetMailgunApiKey(string smtpServer)
        {
            throw new NotImplementedException();
        }

        public void SetMailgunApiUrl(string smtpServer)
        {
            throw new NotImplementedException();
        }

        public void SetMailgunDomain(string smtpServer)
        {
            throw new NotImplementedException();
        }

        public void SetShowVideo(string smtpServer)
        {
            throw new NotImplementedException();
        }

        public void SetEmailTestMode(string smtpServer)
        {
            throw new NotImplementedException();
        }

        public void SetForgotPasswordEmailTemplate(string smtpServer)
        {
            throw new NotImplementedException();
        }

        public void SetForgotPasswordEmailSubject(string smtpServer)
        {
            throw new NotImplementedException();
        }
    }
}
