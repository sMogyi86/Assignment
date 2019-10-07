using Assignment.Numbers;
using System;
using System.Collections.Generic;

namespace Assignment.Strings
{
    public class StringGenerator
    {
        private readonly INumberGenerator numberGenerator;

        public StringGenerator(INumberGenerator numberGenerator)
        {
            this.numberGenerator = numberGenerator;
        }

        /// <summary>
        /// Generates pairs of even and odd numbers.
        /// </summary>
        /// <param name="pairCount">Number of items to generate.</param>
        /// <param name="max">Maximum value of numbers generated.</param>
        /// <returns>A list of strings, containing an even and an odd positive number, separated by a comma (,). 
        /// Any numbers are in the range of [0..max]</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws when 'pairCount' less than 1.</exception>
        public List<string> GenerateEvenOddPairs(int pairCount, int max)
        {
            if (pairCount < 1)
                throw new ArgumentOutOfRangeException($"'{nameof(pairCount)}' must be grater than zero!");

            var evenOddPairs = new List<string>();
            for (int i = 0; i < pairCount; i++)
            {
                var element = numberGenerator.GenerateEven(max) + "," + numberGenerator.GenerateOdd(max);
                evenOddPairs.Add(element);
            }

            return evenOddPairs;
        }
    }
}