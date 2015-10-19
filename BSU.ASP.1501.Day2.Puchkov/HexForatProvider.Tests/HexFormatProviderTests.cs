using System;
using NUnit.Framework;

namespace HexFormatProvider.Tests
{
    [TestFixture]
    public class HexFormatProviderTests
    {
        [TestCase("{0:H}", 13, Result = "d")]
        [TestCase("{0:E}", 13, Result = "1,300000E+001")]
        [TestCase("{0:R}", 13, ExpectedException=typeof(FormatException))]
        [TestCase("{0:H}", null, ExpectedException = typeof(ArgumentNullException))]
        public string MakeTests(String format,object number)
        {
            IFormatProvider provider = new HexFormatProvider();
            return string.Format(provider, format, number);
        }
    }
}