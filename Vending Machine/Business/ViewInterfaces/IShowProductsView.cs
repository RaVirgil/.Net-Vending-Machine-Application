using iQuest.Business.Models;
using System.Collections.Generic;

namespace iQuest.Business.ViewInterfaces
{
    public interface IShowProductsView
    {
        void DisplayProducts(List<ShelfColumn> shelfColumns);
    }
}