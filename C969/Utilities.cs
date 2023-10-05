using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969
{
    internal class Utilities
    {
        internal static string getPrimaryCulture()
        {
            return System.Globalization.CultureInfo.CurrentCulture.ToString();
        }

        internal static string getSecondaryCulture()
        {
            if (System.Globalization.CultureInfo.CurrentCulture.ToString() == "en-US") {
                return "es-MX";
            }
            else {
                return "en-us";
            }
        }
    }
}
