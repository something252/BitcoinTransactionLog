using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bitcoin_Transaction_Log
{
    public static class Methods1
    {
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

        public static void RemoveTrailingZeroes(this TextBox target)
        {
            if (target != null) {
                string strValue = target.Text;

                // if there is a decimal point present
                string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                if (strValue.Contains(decimalSeparator)) {
                    // remove all trailing zeros
                    strValue = strValue.TrimEnd('0');

                    // if all we are left with is a decimal point
                    if (strValue.EndsWith(decimalSeparator)) // then remove it
                        strValue = strValue.TrimEnd(Convert.ToChar(decimalSeparator));
                }

                target.Text = strValue;
            }
        }

        public static object RemoveTrailingZeroes(this object target)
        {
            try {
                string strValue = Convert.ToString(target);

                // if there is a decimal point present
                string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                if (strValue.Contains(decimalSeparator)) {
                    // remove all trailing zeros
                    strValue = strValue.TrimEnd('0');

                    // if all we are left with is a decimal point
                    if (strValue.EndsWith(decimalSeparator)) // then remove it
                        strValue = strValue.TrimEnd(Convert.ToChar(decimalSeparator));
                }

                return strValue;
            } catch {
                return target;
            }
        }
    }
}
