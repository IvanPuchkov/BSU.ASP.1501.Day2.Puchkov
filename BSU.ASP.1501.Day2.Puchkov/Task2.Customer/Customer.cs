using System;
using System.Globalization;

namespace Task2.Customer
{
    public class Customer
    {
        public string Name { get; }
        public string ContactPhone { get; }
        public decimal Revenue { get; }

        public Customer(string name, string phone, decimal revenue)
        {
            Revenue = revenue;
            ContactPhone = phone;
            Name = name;
        }

        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        public override string ToString()=>ToString("G", CultureInfo.CurrentCulture);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";
            formatProvider = formatProvider ?? CultureInfo.CurrentCulture;
            switch (format.ToUpperInvariant())
            {
                case "G":
                case "NCR":
                    return $"Customer record: {Name}, {Revenue.ToString("F2", formatProvider)}, {ContactPhone}";
                case "C":
                    return $"Customer record: {ContactPhone}";
                case "NR":
                    return $"Customer record: {Name}, {Revenue.ToString("F2", formatProvider)}";
                case "N":
                    return $"Customer record: {Name}";
                case "R":
                    return $"Customer record: {Revenue.ToString("F2", formatProvider)}";
                default:
                    throw new FormatException("Unsupported format!");
            }
        }
    }
}