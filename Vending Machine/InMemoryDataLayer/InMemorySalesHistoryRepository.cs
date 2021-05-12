using iQuest.Business.Models;
using iQuest.Business.Repository;
using System;
using System.Collections.Generic;

namespace InMemoryDataLayer
{
    class InMemorySalesHistoryRepository : ISalesHistoryRepository
    {
        private readonly List<Sale> sales;

        public InMemorySalesHistoryRepository()
        {
            sales = new List<Sale>
            {
                new Sale
                {
                    Id=1,
                    ProductName =  "chocolate",
                    Price = 5,
                    TimeStamp = DateTime.Now,
                    PaymentMethod = "cash"
                },
                new Sale
                {
                    Id=2,
                    ProductName = "apple juice",
                    Price = 10,
                    TimeStamp = DateTime.Now,
                    PaymentMethod = "cash"
                },
                new Sale
                {
                    Id=3,
                    ProductName = "chips",
                    Price = 3,
                    TimeStamp = DateTime.Now,
                    PaymentMethod = "cash"
                },
                new Sale
                {
                    Id=4,
                    ProductName = "granola bar",
                    Price = 5,
                    TimeStamp = DateTime.Now,
                    PaymentMethod = "cash"
                },
                new Sale
                {
                    Id=5,
                    ProductName = "nuts mix",
                    Price = 5,
                    TimeStamp = DateTime.Now,
                    PaymentMethod = "cash"
                },
                new Sale
                {
                    Id=6,
                    ProductName = "snickers",
                    Price = 3,
                    TimeStamp = DateTime.Now,
                    PaymentMethod = "cash"
                },
                new Sale
                {
                    Id=7,
                    ProductName = "water",
                    Price = 2.5f,
                    TimeStamp = DateTime.Now,
                    PaymentMethod = "cash"
                },
                new Sale
                {
                    Id=8,
                    ProductName = "m&m's",
                    Price = 5,
                    TimeStamp = DateTime.Now,
                    PaymentMethod = "cash"
                },
            };
        }

        public void Add(Sale sale)
        {
            sales.Add(sale);
        }

        public IEnumerable<Sale> GetAll()
        {
            return sales;
        }

        public IEnumerable<Sale> GetInDateRange(DateTime start, DateTime finish)
        {
            List<Sale> salesInRange = new List<Sale>();

            foreach (Sale sale in sales)
            {
                if (start <= sale.TimeStamp && sale.TimeStamp <= finish)
                    salesInRange.Add(sale);
            }

            return salesInRange;
        }
    }
}
