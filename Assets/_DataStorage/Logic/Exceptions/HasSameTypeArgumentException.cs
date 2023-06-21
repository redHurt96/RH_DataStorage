using System;

namespace _DataStorage.Logic.Core
{
    internal class HasSameTypeArgumentException : Exception
    {
        public HasSameTypeArgumentException(string type) 
            : base($"Storage already contains data with type {type}")
        {}
    }
}