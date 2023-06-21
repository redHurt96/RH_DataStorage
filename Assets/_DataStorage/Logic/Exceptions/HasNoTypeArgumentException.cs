using System;

namespace _DataStorage.Logic.Core
{
    internal class HasNoTypeArgumentException : Exception
    {
        public HasNoTypeArgumentException(string type) 
            : base($"Storage doesn't contains data with type {type}")
        {}
    }
}