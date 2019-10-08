using System;
using System.Linq;

/**
 * https://hu.wikipedia.org/wiki/Palindrom
 */
namespace Assignment.Strings
{
    /// <summary>
    /// Checks if the string passed in is a palindrom or not.
    /// </summary>
    /// <param name="str"></param>
    /// <returns>True if the passed in string is a palindrom, otherwise false.</returns>
    public interface IStringUtil
    {
        bool IsPalindrom(string str);
    }

    class StringUtil : IStringUtil
    {
        ///<inheritdoc/>
        public bool IsPalindrom(string str)
        {
            if (str is null)
                throw new ArgumentNullException(nameof(str));

            return str == new String(str.ToCharArray().Reverse().ToArray());
        }
    }

    public class StringUtilFactory
    {
        public IStringUtil Create()
            => new StringUtil();
    }
}