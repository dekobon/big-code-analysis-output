using System;
using System.Threading.Tasks;

namespace Corpus
{
    // Parameter modifiers, extension receivers and lambda modifiers:
    // every keyword the grammar aliases onto a childless `modifier`.
    public static class Extensions
    {
        public static int Twice(this int value) => value * 2;

        public static void Swap(ref int left, ref int right)
        {
            int tmp = left;
            left = right;
            right = tmp;
        }

        public static bool TryHalve(int value, out int half)
        {
            half = value / 2;
            return value % 2 == 0;
        }

        public static int Sum(in int a, ref readonly int b) => a + b;

        public static int Peek(scoped ref int slot) => slot;

        public static int Total(params int[] values)
        {
            int total = 0;
            foreach (var v in values)
            {
                total += v;
            }
            return total;
        }
    }

    public class Runner
    {
        private static readonly int Seed = 3;

        public static async Task<int> RunAsync()
        {
            Func<int, int> square = static (int x) => x * x;
            Func<int, Task<int>> later = async (int y) =>
            {
                await Task.Delay(1);
                return y + Seed;
            };
            Func<int, int> negate = static delegate (int z) { return -z; };
            Func<Task> tick = async delegate { await Task.Yield(); };

            int a = 1, b = 2;
            Extensions.Swap(ref a, ref b);
            if (Extensions.TryHalve(a.Twice(), out int half))
            {
                a = half;
            }
            await tick();
            return square(a) + negate(b) + await later(Extensions.Sum(in a, in b));
        }
    }
}
