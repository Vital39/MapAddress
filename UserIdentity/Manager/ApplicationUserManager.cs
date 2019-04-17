using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserIdentity.Model;
using UserIdentity.Store;

namespace UserIdentity.Manager
{
    public class ApplicationUserManager : UserManager<AppUser, int>
    {
        public ApplicationUserManager(IUserStore<AppUser, int> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(
            IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(
                new CustomUserStore(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames 
            manager.UserValidator = new UserValidator<AppUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords 
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Register two factor authentication providers. This application uses Phone 
            // and Emails as a step of receiving a code for verifying the user 
            // You can write your own provider and plug in here. 
            manager.RegisterTwoFactorProvider("PhoneCode",
                new PhoneNumberTokenProvider<AppUser, int>
                {
                    MessageFormat = "Your security code is: {0}"
                });
            manager.RegisterTwoFactorProvider("EmailCode",
                new EmailTokenProvider<AppUser, int>
                {
                    Subject = "Security Code",
                    BodyFormat = "Your security code is: {0}"
                });
            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<AppUser, int>(
                        dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
