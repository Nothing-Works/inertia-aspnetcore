using System;
using System.Collections.Generic;
using System.Linq;
using InertiaAdapter.Exceptions;

namespace InertiaAdapter.Core
{
    internal class SharedProps
    {
        private readonly Dictionary<string, object> _stringWithObjects = new();

        private readonly Dictionary<string, Func<object>> _stringWithDelegates = new();

        private bool KeyExists(string key) =>
            _stringWithObjects.ContainsKey(key) || _stringWithDelegates.ContainsKey(key);

        private void RemoveAllKeysIfExist(string key)
        {
            if (!KeyExists(key)) return;

            _stringWithDelegates.Remove(key);
            _stringWithObjects.Remove(key);
        }

        public void AddOrUpdate(string key, object o)
        {
            RemoveAllKeysIfExist(key);

            _stringWithObjects.Add(key, o);
        }

        public void AddOrUpdate(string key, Func<object> func)
        {
            RemoveAllKeysIfExist(key);

            _stringWithDelegates.Add(key, func);
        }

        public object GetValue(string s)
        {
            if (_stringWithObjects.TryGetValue(s, out var o)) return o;

            if (_stringWithDelegates.TryGetValue(s, out var f)) return f();

            throw new KeyDoesNotExistException("The key for shared props does not exist.");
        }

        public IDictionary<string, object> Value =>
            _stringWithObjects
                .Concat(_stringWithDelegates
                    .ToDictionary(c => c.Key, c => c.Value()))
                .ToDictionary(c => c.Key, c => c.Value);
    }
}
