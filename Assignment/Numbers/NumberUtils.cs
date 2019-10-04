using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Numbers
{
    public class NumberUtils
    {
        /// <summary>
        /// Gets all divisors for the number passed in.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Retuns a list of all the divisors for the number passed in.</returns>
        public List<int> GetDivisors(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException($"{nameof(number)} must be greater than zero!");

            var divisors = new List<int>() { 1 };

            if (number == 1)
                return divisors;

            var sqrt = (int)Math.Sqrt(number);
            for (int i = 2; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);

                    var other = (number / i);
                    if (!divisors.Contains(other))
                        divisors.Add(other);
                }
            }

            divisors.Add(number);

            return divisors;
        }

        /// <summary>
        /// Checks if the number passed in is a prime number or not.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>True if the number is prime, False if it is not a prime number.</returns>
        public bool IsPrime(int number)
            => number < 1 ? false : GetDivisors(number).Count() == 2;

        /// <summary>
        /// Checks if the number passed in is even or odd.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>"even" if the number is even, "odd" in case of odd numbers.</returns>
        public string EvenOrOdd(int number)
             => number == 0 | number % 2 == 0 ? "even" : "odd";
    }
}