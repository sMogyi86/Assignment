using System.Linq;
using System.Text;

/**
 * https://hu.wikipedia.org/wiki/Palindrom
 */
namespace Assignment.Strings
{
    class StringUtil
    {
        /// <summary>
        /// Checks if the string passed in is a palindrom or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>True if the passed in string is a palindrom, otherwise false.</returns>
        public bool IsPalindrom(string str)
        {
            var reverse = new StringBuilder(str).ToString().Reverse<char>().ToString();
            return str.Equals(str);
        }
    }
}
