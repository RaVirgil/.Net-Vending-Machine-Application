using Dapper;
using DatabaseDataLayer.DbModel;
using iQuest.Business.Models;
using iQuest.Business.Repository;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;

namespace iQuest.DatabaseDataLayer
{
    public class DatabaseShelfColumnRepository : IShelfColumnRepository
    {
        private SQLiteConnectionStringBuilder connectionStringBuilder;

        public DatabaseShelfColumnRepository()
        {
            LoadConnectionString();
        }

        public List<ShelfColumn> GetAll()
        {
            List<ShelfColumnDb> shelfColumns;

            using (SQLiteConnection connection = new SQLiteConnection(connectionStringBuilder.ConnectionString))
            {
                string sqlQuery = "select * from shelfcolumn inner join product on product.id = shelfcolumn.id_product";

                shelfColumns = connection
                    .Query<ShelfColumnDb, Product, ShelfColumnDb>(sqlQuery, (shelfColumn, product) =>
                    {
                        shelfColumn.Product = product;
                        return shelfColumn;
                    })
                    .ToList();
            }

            return shelfColumns
                .Select(x => new ShelfColumn
                {
                    ColumnId = x.Id,
                    Product = x.Product
                })
                .ToList();
        }

        public ShelfColumn GetById(int id)
        {
            ShelfColumnDb shelfColumnDb;

            using (SQLiteConnection connection = new SQLiteConnection(connectionStringBuilder.ConnectionString))
            {
                string sqlQuery = "select * from shelfcolumn inner join product on product.id = shelfcolumn.id_product and shelfcolumn.id = @id";

                shelfColumnDb = connection
                    .Query<ShelfColumnDb, Product, ShelfColumnDb>(sqlQuery, (shelfColumn, product) =>
                     {
                         shelfColumn.Product = product;
                         return shelfColumn;
                     }, param: new { id })
                    .First();
            }

            return new ShelfColumn
            {
                ColumnId = shelfColumnDb.Id,
                Product = shelfColumnDb.Product
            };
        }

        public void Update(Product product)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionStringBuilder.ConnectionString))
            {
                string sqlQuery = "update Product set name = @Name, price = @Price, quantity = @Quantity where id = @Id";

                Product productParam = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity
                };
                connection.Execute(sqlQuery, productParam);
            }
        }

        private void LoadConnectionString()
        {
            connectionStringBuilder = new SQLiteConnectionStringBuilder();
            connectionStringBuilder.DataSource = ConfigurationManager.ConnectionStrings["SQLiteDb"].ConnectionString;
        }
    }
}