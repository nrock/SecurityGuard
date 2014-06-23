using System;
using System.Net.Mail;
using System.Threading.Tasks;
using AspNet.Identity.MongoDb;
using Microsoft.AspNet.Identity; 
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SecurityGuard.Web.Models;
using System.Net;

namespace SecurityGuard.Web
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>( ));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is: {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("body:{0}  Subject:{1}", message.Body, message.Subject));
            return Task.FromResult(0);

            // convert IdentityMessage to a MailMessage
            //var email =
            //   new MailMessage(new MailAddress("noreply@mydomain.com", "(do not reply)"),
            //   new MailAddress(message.Destination))
            //   {
            //       Subject = message.Subject,
            //       Body = message.Body,
            //       IsBodyHtml = true
            //   };  
            //var client = new SmtpClient("smtp.gmail.com", 587);  
            //client.SendCompleted += (s, e) =>
            //{
            //    client.Dispose();       
            //};
            //client.Credentials = new NetworkCredential("xxxxxxx@gmail.com", "xxxxxxxxxx");
            //client.EnableSsl = true; 
            //return client.SendMailAsync(email); 
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
