using System;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class NewtonNUnitTests
    {
        [TestCase(3,5,0.001)]
        [TestCase(27, 3, 0.001)]
        [TestCase(Int32.MaxValue, 10, 0.001)]
        [TestCase(-3, 2, 0.001)]
        [TestCase(5, -2, 0.001, ExpectedException = typeof(ArgumentException))]

        public void Do_Correct_Root_Calculations(double radicand,int degree,double eps)
        {
            
            Assert.AreEqual(Math.Pow(radicand,1.0/degree),NewtonMethod.Root(radicand,degree,eps),eps);
        }
     

    }
}
