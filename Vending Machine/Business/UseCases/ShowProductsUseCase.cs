using iQuest.Business.Repository;
using iQuest.Business.ViewInterfaces;
using System;

namespace iQuest.Business.UseCases
{
    public class ShowProductsUseCase : IUseCase
    {
        private readonly IShowProductsView showProductsView;
        private readonly IShelfColumnRepository shelfColumnRepository;

        public ShowProductsUseCase(IShelfColumnRepository shelfColumnRepository, IShowProductsView showProductsView)
        {
            this.shelfColumnRepository = shelfColumnRepository ?? throw new ArgumentNullException(nameof(shelfColumnRepository));
            this.showProductsView = showProductsView ?? throw new ArgumentNullException(nameof(showProductsView));
        }

        public void Execute()
        {
            showProductsView.DisplayProducts(shelfColumnRepository.GetAll());
        }
    }
}