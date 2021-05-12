using Business.ViewInterfaces;
using iQuest.Business.Authentication;
using iQuest.Business.UseCases;
using iQuest.Business.UseCases.ReportUseCases;
using Presentation.Factories;

namespace Presentation.Commands
{
    internal class StockReportCommand : IConsoleCommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;

        public string Name => "stock report";
        public string Description => "report of all the stocks available";
        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public StockReportCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory;
            this.authenticationService = authenticationService;
        }

        public void Execute()
        {
            IUseCase useCase = useCaseFactory.GetUseCase<StockReportUseCase>();
            useCase.Execute();
        }
    }
}