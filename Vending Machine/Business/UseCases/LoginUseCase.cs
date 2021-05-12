using iQuest.Business.Authentication;
using iQuest.Business.ViewInterfaces;
using System;

namespace iQuest.Business.UseCases
{
    public class LoginUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ILoginView loginView;

        public LoginUseCase(IAuthenticationService authenticationService, ILoginView loginView)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
        }

        public void Execute()
        {
            string password = loginView.AskForPassword();
            authenticationService.Login(password);
        }
    }
}