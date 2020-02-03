using System;

namespace ECSGame.Exceptions
{
    public class InvalidSpawnException : Exception
    {
        public InvalidSpawnException()
        {

        }

        public InvalidSpawnException(string message)
        : base(message)
    {
        }

        public InvalidSpawnException(string message, Exception inner)
        : base(message, inner)
    {
        }
    }
}
