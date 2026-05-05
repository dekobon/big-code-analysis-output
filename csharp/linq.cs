using System;
using System.Collections.Generic;
using System.Linq;

namespace Acme.Synthetic
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public decimal Total { get; set; }
        public List<string> Tags { get; set; }
    }

    public static class LinqSamples
    {
        public static IEnumerable<int> EvenSquares(IEnumerable<int> values)
        {
            return from v in values
                   where v % 2 == 0
                   select v * v;
        }

        public static IEnumerable<string> CustomerSummaries(IEnumerable<Order> orders)
        {
            var query = from order in orders
                        where order.Total > 100m
                        orderby order.Total descending
                        select $"{order.Customer}: {order.Total}";
            return query;
        }

        public static Dictionary<string, decimal> TotalsByCustomer(IEnumerable<Order> orders)
        {
            var grouped = from order in orders
                          group order by order.Customer into g
                          select new { Customer = g.Key, Sum = g.Sum(o => o.Total) };

            var result = new Dictionary<string, decimal>();
            foreach (var entry in grouped)
            {
                result[entry.Customer] = entry.Sum;
            }
            return result;
        }

        public static int? FirstTagLength(Order order)
        {
            return order?.Tags?.FirstOrDefault()?.Length;
        }

        public static string SafeCustomer(Order order)
        {
            return order?.Customer ?? "anonymous";
        }

        public static decimal HighestTotal(IEnumerable<Order> orders, decimal fallback)
        {
            var max = orders?.Select(o => o.Total).DefaultIfEmpty().Max();
            return max ?? fallback;
        }

        public static List<Order> WithTag(IEnumerable<Order> orders, string tag)
        {
            return orders
                .Where(o => o.Tags != null && o.Tags.Contains(tag))
                .OrderBy(o => o.Id)
                .ToList();
        }

        public static int CountDistinctCustomers(IEnumerable<Order> orders)
        {
            return orders
                .Select(o => o.Customer)
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct()
                .Count();
        }
    }
}
