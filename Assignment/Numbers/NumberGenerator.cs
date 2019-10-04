using System;

namespace Assignment.Numbers
{
    public class NumberGenerator : INumberGenerator
    {
        private readonly Random random = new Random();

        ///<inheritdoc/>
        public int GenerateEven(int limit)
        {
            if (limit < 0)
                throw new ArgumentOutOfRangeException($"'{nameof(limit)}' cannot be less than '0'.");

            return random.Next(limit / 2) * 2;
        }

        ///<inheritdoc/>
        public int GenerateOdd(int limit)
        {
            if (limit < 1)
                throw new ArgumentOutOfRangeException("Limit cannot be less than 1.");

            return random.Next(limit / 2) * 2 + 1;
        }
    }
}