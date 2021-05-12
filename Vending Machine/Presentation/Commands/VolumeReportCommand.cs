using Business.ViewInterfaces;
using iQuest.Business.Authentication;
using iQuest.Business.UseCases;
using iQuest.Business.UseCases.ReportUseCases;
using Presentation.Factories;

namespace Presentation.Commands
{
    internal class VolumeReportCommand : IConsoleCommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;

        public string Name => "volume report";
        public string Description => "report of all sold products in a period of time";
        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public VolumeReportCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory;
            this.authenticationService = authenticationService;
        }

        public void Execute()
        {
            IUseCase useCase = useCaseFactory.GetUseCase<VolumeReportUseCase>();
            useCase.Execute();
        }
    }
}