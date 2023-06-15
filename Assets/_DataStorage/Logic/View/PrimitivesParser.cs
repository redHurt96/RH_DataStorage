using System;
using System.Collections.Generic;

namespace _DataStorage.Logic.View
{
    internal class PrimitivesParser
    {
        private static readonly Dictionary<Type, Func<object, object>> _primitiveParsers = new()
        {
            [typeof(bool)] = raw => Convert.ToBoolean(raw),
            [typeof(int)] = raw => Convert.ToInt32(raw),
            [typeof(float)] = raw => Convert.ToSingle(raw),
            [typeof(string)] = Convert.ToString,
        };

        internal bool ContainsType(Type type) => 
            _primitiveParsers.ContainsKey(type);

        public object Execute(Type type, string rawValue) => 
            _primitiveParsers[type](rawValue);
    }
}