using iQuest.Business.Exceptions;
using iQuest.Business.Models;
using iQuest.Business.Repository;
using System.Collections.Generic;

namespace iQuest.InMemoryDataLayer
{
    public class InMemoryShelfColumnRepository : IShelfColumnRepository
    {
        private List<ShelfColumn> shelfColumns;

        public InMemoryShelfColumnRepository()
        {
            shelfColumns = new List<ShelfColumn>
            {
                new ShelfColumn
                {
                    ColumnId=1,
                    Product = new Product { Name = "chocolate", Quantity = 2, Price= 5}
                },
                new ShelfColumn
                {
                    ColumnId=2,
                    Product = new Product { Name = "apple juice", Quantity = 5, Price= 10}
                },
                new ShelfColumn
                {
                    ColumnId=3,
                    Product = new Product { Name = "chips", Quantity = 8, Price= 3}
                },
                new ShelfColumn
                {
                    ColumnId=4,
                    Product = new Product { Name = "granola bar", Quantity = 7, Price= 5}
                },
                new ShelfColumn
                {
                    ColumnId=5,
                    Product = new Product { Name = "nuts mix", Quantity = 2, Price= 5}
                },
                new ShelfColumn
                {
                    ColumnId=6,
                    Product = new Product { Name = "snickers", Quantity = 9, Price= 3}
                },
                new ShelfColumn
                {
                    ColumnId=7,
                    Product = new Product { Name = "water", Quantity = 10, Price= 2.5f}
                },
                new ShelfColumn
                {
                    ColumnId=8,
                    Product = new Product { Name = "m&m's", Quantity = 6, Price= 5}
                },
            };
        }

        public List<ShelfColumn> GetAll()
        {
            return new List<ShelfColumn>(shelfColumns);
        }

        public ShelfColumn GetById(int id)
        {
            foreach (ShelfColumn shelfColumn in shelfColumns)
            {
                if (shelfColumn.ColumnId == id)
                    return shelfColumn;
            }
            throw new InvalidColumnIdException();
        }

        public void Update(Product product)
        {
            foreach (ShelfColumn shelfColumn in shelfColumns)
            {
                if (shelfColumn.Product.Id == product.Id)
                {
                    shelfColumn.Product = product;
                    break;
                }
            }
        }
    }
}