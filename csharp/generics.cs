using System;
using System.Collections.Generic;

namespace Acme.Synthetic
{
    public interface IRepository<T>
    {
        void Add(T item);
        T Get(int id);
    }

    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly Dictionary<int, T> _items = new Dictionary<int, T>();
        private int _next;

        public void Add(T item)
        {
            _items[_next++] = item;
        }

        public T Get(int id)
        {
            if (_items.TryGetValue(id, out var value))
            {
                return value;
            }
            return new T();
        }
    }

    public class Pair<TKey, TValue>
        where TKey : IComparable<TKey>
        where TValue : struct
    {
        public TKey Key { get; }
        public TValue Value { get; }

        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public int CompareTo(Pair<TKey, TValue> other)
        {
            return Key.CompareTo(other.Key);
        }
    }

    public static class GenericHelpers
    {
        public static List<TOut> MapAll<TIn, TOut>(List<TIn> input, Func<TIn, TOut> selector)
        {
            var output = new List<TOut>(input.Count);
            foreach (var item in input)
            {
                output.Add(selector(item));
            }
            return output;
        }

        public static TValue GetOrDefault<TKey, TValue>(
            Dictionary<TKey, TValue> map,
            TKey key,
            TValue fallback)
            where TKey : notnull
        {
            return map.TryGetValue(key, out var found) ? found : fallback;
        }

        public static Dictionary<string, List<Tuple<int, int>>> BuildIndex(
            List<Tuple<string, int, int>> rows)
        {
            var index = new Dictionary<string, List<Tuple<int, int>>>();
            foreach (var row in rows)
            {
                if (!index.TryGetValue(row.Item1, out var bucket))
                {
                    bucket = new List<Tuple<int, int>>();
                    index[row.Item1] = bucket;
                }
                bucket.Add(Tuple.Create(row.Item2, row.Item3));
            }
            return index;
        }

        public static List<List<T>> Chunk<T>(List<T> values, int size)
        {
            var result = new List<List<T>>();
            for (var i = 0; i < values.Count; i += size)
            {
                var chunk = new List<T>();
                for (var j = i; j < Math.Min(i + size, values.Count); j++) { chunk.Add(values[j]); }
                result.Add(chunk);
            }
            return result;
        }
    }
}
