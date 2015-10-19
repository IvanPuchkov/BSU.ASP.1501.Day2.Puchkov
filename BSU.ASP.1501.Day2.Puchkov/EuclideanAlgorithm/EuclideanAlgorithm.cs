using System;
using System.Linq;

namespace EuclideanAlgorithm
{
    public static class EuclideanAlgorithm
    {
        public static int CalculateGcd(out long time, int a, int b)
        {
            time = 0;
            long curtime = DateTime.Now.Ticks;
            if ((a == 0) || (b == 0))
            {
                return Math.Max(a, b);
            }
            int output;
            if (a > b)
            {
                output = CalculateGcd(out time,a % b, b );
                time = curtime - DateTime.Now.Ticks;
                return output;
            }
            else
            {
                output = CalculateGcd(out time,a, b%a );
                time = curtime - DateTime.Now.Ticks;
                return output;
            }
        }

        public static int CalculateGcd(out long time,int a, int b, int c)
        {
            long curtime = DateTime.Now.Ticks;
            int output = CalculateGcd(out time,a, CalculateGcd(out time,b,c));
            time = DateTime.Now.Ticks - curtime;
            return output;
        }

        public static int CalculateGcd(out long time,params int[] numbers)
        {
            
            if (numbers==null)
                throw new ArgumentNullException();
            if (numbers.Count()<2)
                throw new ArgumentException();
            long curtime = DateTime.Now.Ticks;
            int output = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                output = CalculateGcd(out time, output, numbers[i]);
            }
            time = DateTime.Now.Ticks - curtime;
            return output;
        }

        public static int CalculateSteinGcd(out long time, int a, int b)
        {
            time = 0;
            int output;
            long curtime = DateTime.Now.Ticks;
            if ((a == 0) && (b == 0))
                return 0;
            if ((a == 0) || (b == 0))
                return Math.Max(a, b);
            if ((a%2 == 0) && (b%2 == 0))
            {
                output = CalculateSteinGcd(out time, a/2, b/2)*2;
                time = DateTime.Now.Ticks - time;
                return output;
            }
            if (a%2 == 0)
            {
                output = CalculateSteinGcd(out time, a / 2, b);
                time = DateTime.Now.Ticks - time;
                return output;
            }
            if (b%2 == 0)
            {
                output = CalculateSteinGcd(out time, a, b/2);
                time = DateTime.Now.Ticks - time;
                return output;
            }
            int greatest = Math.Max(a, b);
            int lowest = Math.Min(a, b);
            output = CalculateSteinGcd(out time, (greatest - lowest)/2, lowest);
            time = curtime - DateTime.Now.Ticks;
            return output;
        }

        public static int CalculateSteinGcd(out long time, int a, int b, int c)
        {
            time = 0;
            long curtime = DateTime.Now.Ticks;
            int output = CalculateSteinGcd(out time, a, CalculateSteinGcd(out time,b, c));
            time = DateTime.Now.Ticks - curtime;
            return output;
        }

        public static int CalculateSteinGcd(out long time, params int[] numbers)
        {
            time = 0;
            if (numbers==null)
                throw new ArgumentNullException();
            if (numbers.Length<2)
                throw new ArgumentException();
            long curtime = DateTime.Now.Ticks;
            int output = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                output = CalculateSteinGcd(out time, output, numbers[i]);
            }
            time = DateTime.Now.Ticks - curtime;
            return output;
        }
    }
}
