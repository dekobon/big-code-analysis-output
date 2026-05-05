using System;

namespace Acme.Synthetic
{
    public class Counter
    {
        private int _count;
        public string Label { get; }

        public Counter(string label)
        {
            Label = label;
            _count = 0;
        }

        public Counter(string label, int initial)
        {
            Label = label;
            _count = initial;
        }

        public int Count => _count;

        public void Increment()
        {
            _count++;
        }

        public void IncrementBy(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            _count += amount;
        }

        public void Reset()
        {
            _count = 0;
        }
    }

    public struct Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point other)
        {
            var dx = X - other.X;
            var dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }

    public record Person(string Name, int Age)
    {
        public bool IsAdult => Age >= 18;

        public string Greeting()
        {
            return "Hello, " + Name;
        }
    }

    public abstract class Shape
    {
        public abstract double Area();

        public virtual string Describe()
        {
            return "Shape with area " + Area();
        }
    }

    public sealed class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
