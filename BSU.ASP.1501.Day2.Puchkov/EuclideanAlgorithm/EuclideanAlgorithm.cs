using System;
using System.Diagnostics;
using System.Linq;

namespace EuclideanAlgorithm
{
    public static class EuclideanAlgorithm
    {
        private static int CalculateGeneralGcd(int a, int b)
        {
            if ((a == 0) || (b == 0))
            {
                return Math.Max(a, b);
            }
            int output =  a > b? CalculateGeneralGcd(a % b, b): CalculateGeneralGcd(a, b % a);
            return output;
        }

        public static int CalculateGcd(int a, int b)
        {
            if ((a == 0) || (b == 0))
                throw new ArgumentException("None of numbers should be equal to zero");
            return CalculateGeneralGcd(a, b);
        }

        public static int CalculateGcd(int a, int b, int c)
        {
            return CalculateGeneralGcd(a, CalculateGeneralGcd(b, c));
        }

        public static int CalculateGcd(params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();
            if (numbers.Count() < 2)
                throw new ArgumentException();
            int output = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                output = CalculateGeneralGcd(output, numbers[i]);
            }
            return output;
        }

        public static int CalculateGcd(out long time, int a, int b)
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int output = CalculateGcd(a, b);
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return output;
        }

        public static int CalculateGcd(out long time,int a, int b, int c)
        {
            Stopwatch sw=new Stopwatch();
            sw.Start();
            int output = CalculateGcd(a, b,c);
            sw.Stop();
            time =sw.ElapsedMilliseconds;
            return output;
        }

        public static int CalculateGcd(out long time,params int[] numbers)
        {
            
            Stopwatch sw=new Stopwatch();
            sw.Start();
            int output = CalculateGcd(numbers);
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return output;
        }

        public static int CalculateGeneralSteinGcd(int a, int b)
        {
            if ((a == 0) && (b == 0))
                return 0;
            if ((a == 0) || (b == 0))
                return Math.Max(a, b);
            if ((a%2 == 0) && (b%2 == 0))
                return CalculateGeneralSteinGcd(a/2, b/2)*2;
            if (a%2 == 0)
                return CalculateGeneralSteinGcd(a / 2, b);
            if (b%2 == 0)
                return CalculateGeneralSteinGcd( a, b/2);
            int greatest = Math.Max(a, b);
            int lowest = Math.Min(a, b);
            return CalculateGeneralSteinGcd((greatest - lowest)/2, lowest);
        }

        public static int CalculateSteinGcd(int a, int b)
        {
            if ((a == 0) || (b == 0))
                throw new ArgumentException("None of numbers should be equal to zero");
            return CalculateGeneralGcd(a,b);
        }

        public static int CalculateSteinGcd(int a, int b, int c)
        {
            return CalculateSteinGcd(a, CalculateGeneralSteinGcd(b, c));
        }

        public static int CalculateSteinGcd(params int[] numbers)
        {
            if (numbers==null)
                throw new ArgumentNullException();
            if (numbers.Length<2)
                throw new ArgumentException();
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = CalculateSteinGcd(result, numbers[i]);
            }
            return result;
        }
    

        public static int CalculateSteinGcd(out long time,int a, int b)
        {
            Stopwatch sw=new Stopwatch();
            int result = CalculateGcd(a, b);
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return result;
        }

        public static int CalculateSteinGcd(out long time,int a, int b, int c)
        {
            Stopwatch sw=new Stopwatch();
            sw.Start();
            int result = CalculateSteinGcd(a,b,c);
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return result;
        }

        public static int CalculateSteinGcd(out long time,params int[] numbers)
        {
            Stopwatch sw=new Stopwatch();
            sw.Start();
            int result = CalculateSteinGcd(numbers);
            sw.Stop();
            time = sw.ElapsedMilliseconds;
            return result;
        }
    }
}
