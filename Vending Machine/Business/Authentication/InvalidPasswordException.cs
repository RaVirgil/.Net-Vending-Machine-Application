using System;

namespace iQuest.Business.Authentication
{
    public class InvalidPasswordException : Exception
    {
        private const string DefaultMessage = "Invalid password";

        public InvalidPasswordException()
            : base(DefaultMessage)
        {
        }
    }
}