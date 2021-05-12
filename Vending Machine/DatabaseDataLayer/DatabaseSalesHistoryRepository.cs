using Dapper;
using iQuest.Business.Models;
using iQuest.Business.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;

namespace DatabaseDataLayer
{
    public class DatabaseSalesHistoryRepository : ISalesHistoryRepository
    {
        private SQLiteConnectionStringBuilder connectionStringBuilder;

        public DatabaseSalesHistoryRepository()
        {
            LoadConnectionString();
        }

        public IEnumerable<Sale> GetAll()
        {
            IEnumerable<Sale> productLogs;

            using (SQLiteConnection connection = new SQLiteConnection(connectionStringBuilder.ConnectionString))
            {
                string sqlQuery = "select * from salesHistory ";

                productLogs = connection
                    .Query<Sale>(sqlQuery)
                    .ToList();
            }

            return productLogs;
        }

        public IEnumerable<Sale> GetInDateRange(DateTime startTime, DateTime endDate)
        {
            IEnumerable<Sale> productLogs;

            using (SQLiteConnection connection = new SQLiteConnection(connectionStringBuilder.ConnectionString))
            {
                string sqlQuery = "select * from salesHistory";

                productLogs = connection
                    .Query<Sale>(sqlQuery, new { StartTime = startTime, EndTime = endDate })
                    .Where(x => startTime <= x.TimeStamp && x.TimeStamp <= endDate)
                    .ToList();
            }

            return productLogs;
        }

        public void Add(Sale sale)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionStringBuilder.ConnectionString))
            {
                string sqlQuery = @"insert into salesHistory(timeStamp, productName, price, paymentMethod)" +
                    " values(@TimeStamp, @ProductName, @Price, @PaymentMethod);";

                connection.Execute(sqlQuery, sale);
            }
        }

        private void LoadConnectionString()
        {
            connectionStringBuilder = new SQLiteConnectionStringBuilder();
            connectionStringBuilder.DataSource = ConfigurationManager.ConnectionStrings["SQLiteDb"].ConnectionString;
        }
    }
}