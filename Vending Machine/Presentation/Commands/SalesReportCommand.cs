using Business.ViewInterfaces;
using iQuest.Business.Authentication;
using iQuest.Business.UseCases;
using iQuest.Business.UseCases.ReportUseCases;
using Presentation.Factories;

namespace Presentation.Commands
{
    internal class SalesReportCommand : IConsoleCommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;

        public string Name => "sales report";
        public string Description => "sales history";
        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public SalesReportCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory;
            this.authenticationService = authenticationService;
        }

        public void Execute()
        {
            IUseCase useCase = useCaseFactory.GetUseCase<SalesReportUseCase>();
            useCase.Execute();
        }
    }
}