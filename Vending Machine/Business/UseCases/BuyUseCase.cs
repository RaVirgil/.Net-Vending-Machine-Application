using iQuest.Business.Exceptions;
using iQuest.Business.Models;
using iQuest.Business.Repository;
using iQuest.Business.ViewInterfaces;
using System;

namespace iQuest.Business.UseCases
{
    public class BuyUseCase : IUseCase
    {
        private readonly IShelfColumnRepository shelfColumnRepository;
        private readonly ISalesHistoryRepository logsRepository;
        private readonly IBuyView buyView;
        private readonly IPayUseCase payUseCase;

        public BuyUseCase(IShelfColumnRepository shelfColumnRepository, ISalesHistoryRepository logsRepository, IBuyView buyView, IPayUseCase payUseCase)
        {
            this.shelfColumnRepository = shelfColumnRepository ?? throw new ArgumentNullException(nameof(shelfColumnRepository));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.payUseCase = payUseCase ?? throw new ArgumentNullException(nameof(payUseCase));
            this.logsRepository = logsRepository ?? throw new ArgumentNullException(nameof(logsRepository));
        }

        public void Execute()
        {
            int requestedColumn = buyView.AskForColumnId();
            ShelfColumn shelfColumn = shelfColumnRepository.GetById(requestedColumn);
            if (shelfColumn.Product.Quantity == 0)
            {
                throw new InsufficientStockException();
            }

            payUseCase.PriceToPay = shelfColumn.Product.Price;
            string paymenthMethod = payUseCase.Execute();

            shelfColumn.Product.Quantity--;
            shelfColumnRepository.Update(shelfColumn.Product);
            buyView.DispenseProduct(shelfColumn.Product.Name);

            Sale sale = new Sale
            {
                ProductName = shelfColumn.Product.Name,
                Price = shelfColumn.Product.Price,
                TimeStamp = DateTime.Now,
                PaymentMethod = paymenthMethod
            };
            logsRepository.Add(sale);
        }
    }
}