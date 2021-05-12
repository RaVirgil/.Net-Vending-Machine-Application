using System;

namespace iQuest.Business.Exceptions
{
    public class InvalidColumnIdException : Exception
    {
        public override string Message => "This column id is invalid";
    }
}