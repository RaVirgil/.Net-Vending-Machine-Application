using iQuest.Business.Models;
using iQuest.Business.ViewInterfaces;
using System;
using System.Collections.Generic;

namespace iQuest.Presentation.Views
{
    public class ShowProductsView : IShowProductsView
    {
        public void DisplayProducts(List<ShelfColumn> shelfColumns)
        {
            foreach (ShelfColumn shelfColumn in shelfColumns)
            {
                Console.WriteLine("\n" + "Column " + shelfColumn.ColumnId + " has " + shelfColumn.Product.Name + " with a quantity of " + shelfColumn.Product.Quantity + " and 1 piece costs " + shelfColumn.Product.Price);
            }
        }
    }
}