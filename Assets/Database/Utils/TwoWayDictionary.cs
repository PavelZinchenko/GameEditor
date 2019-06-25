using System;
using System.Collections;
using System.Collections.Generic;

namespace Database.Utils
{
    public class TwoWayDictionary<T1, T2> : IDictionary<T1, T2>
    {
        public void Add(T1 key, T2 value)
        {
            _forward.Add(key, value);
            _reverse.Add(value, key);
        }

        public bool ContainsKey(T1 key)
        {
            return _forward.ContainsKey(key);
        }

        public bool ContainsValue(T2 value)
        {
            return _reverse.ContainsKey(value);
        }

        public bool Remove(T1 key)
        {
            T2 value;
            if (!_forward.TryGetValue(key, out value))
                return false;

            _forward.Remove(key);
            _reverse.Remove(value);
            return true;
        }

        public bool RemoveValue(T2 value)
        {
            T1 key;
            if (!_reverse.TryGetValue(value, out key))
                return false;

            _forward.Remove(key);
            _reverse.Remove(value);
            return true;
        }

        public bool TryGetValue(T1 key, out T2 value)
        {
            return _forward.TryGetValue(key, out value);
        }

        public bool TryGetKey(T2 value, out T1 key)
        {
            return _reverse.TryGetValue(value, out key);
        }

        public T2 this[T1 key]
        {
            get
            {
                return _forward[key];
            }
            set
            {
                T2 oldvalue;
                if (_forward.TryGetValue(key, out oldvalue))
                    _reverse.Remove(oldvalue);

                _forward[key] = value;
                _reverse[value] = key;
            }
        }

        public ICollection<T1> Keys { get { return _forward.Keys; } }
        public ICollection<T2> Values { get { return _forward.Values; } }

        public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
        {
            return _forward.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<T1, T2> item)
        {
            _forward.Add(item.Key, item.Value);
            _reverse.Add(item.Value, item.Key);
        }

        public void Clear()
        {
            _forward.Clear();
            _reverse.Clear();
        }

        public bool Contains(KeyValuePair<T1, T2> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<T1, T2>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<T1, T2> item)
        {
            throw new NotImplementedException();
        }

        public int Count { get { return _forward.Count; } }
        public bool IsReadOnly { get { return false; } }

        private readonly Dictionary<T1, T2> _forward = new Dictionary<T1, T2>();
        private readonly Dictionary<T2, T1> _reverse = new Dictionary<T2, T1>();
    }
}
