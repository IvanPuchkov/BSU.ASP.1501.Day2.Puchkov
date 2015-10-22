using System;
using System.Globalization;
using NUnit.Framework;

namespace Task2.Customer.Tests
{
    [TestFixture]
    public class Task2CustomerTests
    {
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, null,Result = "Customer record: Jeffrey Richter, 1000000,00, +1 (425) 555-0100")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "N",Result = "Customer record: Jeffrey Richter")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "NCR",Result = "Customer record: Jeffrey Richter, 1000000,00, +1 (425) 555-0100")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "K",ExpectedException = typeof(FormatException))]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "C", Result = "Customer record: +1 (425) 555-0100")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "NR", Result = "Customer record: Jeffrey Richter, 1000000.00")]
        public string Test_Without_Format_Provider(string name, string phoneNumber, decimal revenue,string format)
        {
            Customer customer=new Customer(name,phoneNumber,revenue);
            return customer.ToString(format);
        }

        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "NCR","en-US", Result = "Customer record: Jeffrey Richter, 1000000,00, +1 (425) 555-0100")]
        public string Test_With_Format_Provider(string name, string phoneNumber, decimal revenue, string format,string cultureName)
        {
            CultureInfo ci=new CultureInfo(cultureName);
            Customer customer = new Customer(name, phoneNumber, revenue);
            return customer.ToString(format,ci);
        }
    }
}
