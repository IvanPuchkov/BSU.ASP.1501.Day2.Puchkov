using NUnit.Framework;

namespace EuclideanAlgorithm.Tests
{
    [TestFixture]

    public class EuclideanAlgorithmTests
    {
        [TestCase(10,5,Result = 5)]
        [TestCase(5, 1,Result = 1)]
        [TestCase(964, 592,Result = 4)]
        public int EuclideanAlgorithmTests_Two_Numbers(int a,int b)
        {
            long time;
            return EuclideanAlgorithm.CalculateGcd(out time, a, b);
        }

        [TestCase(964, 592, 400, Result = 4)]
        [TestCase(100, 5, 20, Result = 5)]
        public int EuclideanAlgorithmTests_Three_Numbers(int a, int b, int c)
        {
            long time;
            return EuclideanAlgorithm.CalculateGcd(out time, a, b,c);
        }


        [TestCase(10, 20, 30, 40,Result = 10)]
        public int EuclideanAlgorithmTests_Multiple_Numbers(params int[] numbers)
        {
            long time;
            return EuclideanAlgorithm.CalculateGcd(out time, numbers);
        }


        [TestCase(10,5,Result = 5)]
        [TestCase(5, 1,Result = 1)]
        [TestCase(964, 592,Result = 4)]
        public int SteinAlgorithmTests_Two_Numbers(int a,int b)
        {
            long time;
            return EuclideanAlgorithm.CalculateSteinGcd(out time, a, b);
        }

        [TestCase(964, 592, 400, Result = 4)]
        [TestCase(100, 5, 20, Result = 5)]
        public int SteinAlgorithmTests_Three_Numbers(int a, int b, int c)
        {
            long time;
            return EuclideanAlgorithm.CalculateSteinGcd(out time, a, b,c);
        }


        [TestCase(10, 20, 30, 40,Result = 10)]
        public int SteinAlgorithmTests_Multiple_Numbers(params int[] numbers)
        {
            long time;
            return EuclideanAlgorithm.CalculateSteinGcd(out time, numbers);
        }
    }
}
