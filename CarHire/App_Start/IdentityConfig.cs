namespace CarHire
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CarHireDataAccess;
    using CarHireDataAccess.Models.User_Classes;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application UserAccount manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<UserAccount>
    {
        public ApplicationUserManager(IUserStore<UserAccount> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<UserAccount>(context.Get<CarHireContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<UserAccount>(manager) { AllowOnlyAlphanumericUserNames = false, RequireUniqueEmail = true };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator { RequiredLength = 6, RequireNonLetterOrDigit = true, RequireDigit = true, RequireLowercase = true, RequireUppercase = true };

            // Configure UserAccount lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the UserAccount
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<UserAccount> { MessageFormat = "Your security code is {0}" });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<UserAccount> { Subject = "Security Code", BodyFormat = "Your security code is {0}" });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<UserAccount>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<UserAccount, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(UserAccount userAccount)
        {
            return userAccount.GenerateUserIdentityAsync((ApplicationUserManager)this.UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}