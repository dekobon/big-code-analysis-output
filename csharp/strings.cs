using System;

namespace Acme.Synthetic
{
    public static class StringSamples
    {
        public static string Plain()
        {
            return "hello world";
        }

        public static string Verbatim()
        {
            return @"C:\Users\Public\file.txt";
        }

        public static string MultiLineVerbatim()
        {
            return @"line one
line two
line three";
        }

        public static string Interpolated(string name, int count)
        {
            return $"User {name} has {count} items";
        }

        public static string InterpolatedVerbatim(string root, string file)
        {
            return $@"{root}\folder\{file}";
        }

        public static string FormatBytes(long bytes)
        {
            if (bytes < 1024)
            {
                return $"{bytes} B";
            }
            if (bytes < 1024 * 1024)
            {
                return $"{bytes / 1024.0:F2} KiB";
            }
            return $"{bytes / (1024.0 * 1024.0):F2} MiB";
        }

        public static string Greet(string name)
        {
            var trimmed = name?.Trim();
            if (string.IsNullOrEmpty(trimmed))
            {
                return "Hello, friend";
            }
            return $"Hello, {trimmed}!";
        }

        public static string Concatenate(string a, string b)
        {
            return a + " " + b;
        }

        public static string Repeat(string fragment, int times)
        {
            var result = string.Empty;
            for (var i = 0; i < times; i++)
            {
                result += fragment;
            }
            return result;
        }

        public static string DescribeChar(char c)
        {
            if (char.IsWhiteSpace(c))
            {
                return "whitespace";
            }
            if (char.IsDigit(c))
            {
                return "digit";
            }
            if (char.IsLetter(c))
            {
                return "letter";
            }
            return "other";
        }
    }
}
