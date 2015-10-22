using System;
using System.Globalization;
using System.Text;

namespace HexFormatProvider
{
    public class HexFormatProvider : IFormatProvider, ICustomFormatter
    {
        private string numbers = "0123456789abcdef";

        public HexFormatProvider() { }

        public object GetFormat(Type typeFormatter)
        {
            if (typeFormatter == typeof (ICustomFormatter))
                return this;
            return null;
            
        }

        

        public string Format(string format, object arg, IFormatProvider formatProvider)

        {
            if (arg==null)
                throw new ArgumentNullException();


            if (((format != "H") && (format != "h") || (arg.GetType() != typeof (int))))
            {
                IFormattable iFormattable= arg as IFormattable;
                if (iFormattable != null)
                    return iFormattable.ToString(format, CultureInfo.CurrentCulture);
                return arg.ToString();
            }
            int number = (int) arg;
            StringBuilder sb=new StringBuilder();
            while (number > 0)
            {
                int remainder = number%16;
                sb.Insert(0, numbers[remainder]);
                number /= 16;
            }
            return sb.ToString();
        }

    }
}
