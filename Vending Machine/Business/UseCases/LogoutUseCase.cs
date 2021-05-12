using iQuest.Business.Authentication;
using System;

namespace iQuest.Business.UseCases
{
    public class LogoutUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;

        public LogoutUseCase(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            authenticationService.Logout();
        }
    }
}