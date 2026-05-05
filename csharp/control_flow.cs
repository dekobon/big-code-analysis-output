using System;

namespace Acme.Synthetic
{
    public static class ControlFlow
    {
        public static string Classify(int value)
        {
            if (value < 0)
            {
                return "negative";
            }
            else if (value == 0)
            {
                return "zero";
            }
            else if (value < 10)
            {
                return "small";
            }
            else
            {
                return "large";
            }
        }

        public static string DescribeDay(int day)
        {
            switch (day)
            {
                case 0:
                case 6:
                    return "weekend";
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return "weekday";
                default:
                    return "unknown";
            }
        }

        public static string Bucket(int value) => value switch
        {
            < 0 => "negative",
            0 => "zero",
            > 0 and < 10 when value % 2 == 0 => "small even",
            > 0 and < 10 => "small odd",
            >= 10 and < 100 => "medium",
            _ => "large",
        };

        public static int SafeDivide(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
            catch (Exception ex) when (ex.Message.Length > 0)
            {
                return -1;
            }
            finally
            {
                Console.WriteLine("done");
            }
        }

        public static int FirstNonZero(int[] values)
        {
            for (var i = 0; i < values.Length; i++)
            {
                if (values[i] == 0)
                {
                    continue;
                }
                if (values[i] < 0)
                {
                    break;
                }
                return values[i];
            }
            return 0;
        }

        public static int CountDown(int start)
        {
            var n = start;
            while (n > 0) { n--; }
            return n;
        }
    }
}
