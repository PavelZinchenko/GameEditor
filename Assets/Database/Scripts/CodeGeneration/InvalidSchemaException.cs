using System;

namespace GameDatabase.CodeGeneration
{
    public class InvalidSchemaException : Exception
    {
        public InvalidSchemaException()
        {
        }

        public InvalidSchemaException(string message)
            : base(message)
        {
        }

        public InvalidSchemaException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
