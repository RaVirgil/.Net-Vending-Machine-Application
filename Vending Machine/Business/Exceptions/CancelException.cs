using System;

namespace iQuest.Business.Exceptions
{
    public class CancelException : Exception
    {
        public override string Message => "Operation canceled";
    }
}