using System;
using System.Collections.Generic;

namespace Acme.Synthetic
{
    public static class AnonymousSamples
    {
        public static Func<int, int> MakeMultiplier(int factor)
        {
            return value => value * factor;
        }

        public static Func<int, int> MakeAdder(int offset)
        {
            Func<int, int> adder = delegate(int value) { return value + offset; };
            return adder;
        }

        public static List<int> ApplyAll(List<int> values, Func<int, int> transform)
        {
            var output = new List<int>();
            foreach (var value in values)
            {
                output.Add(transform(value));
            }
            return output;
        }

        public static Func<int, int> Compose(params Func<int, int>[] callables)
        {
            return input =>
            {
                var result = input;
                foreach (var callable in callables)
                {
                    result = callable(result);
                }
                return result;
            };
        }

        public static int SumWithLocal(List<int> values)
        {
            int Add(int a, int b) => a + b;

            int Total(IEnumerable<int> xs)
            {
                var acc = 0;
                foreach (var x in xs)
                {
                    acc = Add(acc, x);
                }
                return acc;
            }

            return Total(values);
        }

        public static (List<int> matched, List<int> rest) PartitionBy(
            List<int> values,
            Func<int, bool> predicate)
        {
            var matched = new List<int>();
            var rest = new List<int>();
            foreach (var value in values)
            {
                if (predicate(value))
                {
                    matched.Add(value);
                }
                else
                {
                    rest.Add(value);
                }
            }
            return (matched, rest);
        }
    }
}
