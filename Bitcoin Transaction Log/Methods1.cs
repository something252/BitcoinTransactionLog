using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitcoin_Transaction_Log
{
    class Methods1
    {
        private Methods1()
        {

        }

        public static bool IsNumeric(object s)
        {
            if (s != null) {
                Type t = s.GetType();
                if (t.Equals(typeof(string)) || t.Equals(typeof(object))) {
                    decimal output;
                    return decimal.TryParse(Convert.ToString(s), out output);
                } else {
                    return true;
                }
            } else {
                return false;
            }
        }

        /// <summary>
        /// If given string is not a number return zero.
        /// </summary>
        public static string SanitizeNumber(object o)
        {
            if (o != null) {
                string s = Convert.ToString(o);
                if (IsNumeric(s)) {
                    return s;
                } else {
                    return "0";
                }
            } else {
                return "0";
            }
           
        }
    }
}
