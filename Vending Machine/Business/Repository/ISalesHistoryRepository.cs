using iQuest.Business.Models;
using System;
using System.Collections.Generic;

namespace iQuest.Business.Repository
{
    public interface ISalesHistoryRepository
    {
        IEnumerable<Sale> GetAll();

        IEnumerable<Sale> GetInDateRange(DateTime start, DateTime finish);

        void Add(Sale sale);
    }
}