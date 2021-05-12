using iQuest.Business.Models;
using System.Collections.Generic;

namespace iQuest.Business.Repository
{
    public interface IShelfColumnRepository
    {
        List<ShelfColumn> GetAll();

        ShelfColumn GetById(int id);

        void Update(Product product);
    }
}