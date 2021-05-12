using System;

namespace iQuest.Business.Exceptions
{
    public class InsufficientStockException : Exception
    {
        public override string Message => "This stock is empty, please come back later or contact our admin";
    }
}