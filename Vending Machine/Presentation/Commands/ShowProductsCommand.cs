using Business.ViewInterfaces;
using iQuest.Business.UseCases;
using Presentation.Factories;

namespace Presentation.Commands
{
    public class ShowProductsCommand : IConsoleCommand
    {
        private readonly IUseCaseFactory useCaseFactory;

        public string Name => "show products";
        public string Description => "show the products from the vending machine";
        public bool CanExecute => true;

        public ShowProductsCommand(IUseCaseFactory useCaseFactory)
        {
            this.useCaseFactory = useCaseFactory;
        }

        public void Execute()
        {
            IUseCase useCase = useCaseFactory.GetUseCase<ShowProductsUseCase>();
            useCase.Execute();
        }
    }
}