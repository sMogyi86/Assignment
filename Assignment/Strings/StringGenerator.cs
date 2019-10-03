using Assignment.Numbers;
using System.Collections.Generic;

namespace Assignment.Strings
{
    public class StringGenerator
    {
        private readonly NumberGenerator _numberGenerator;

        public StringGenerator(NumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }

        /// <summary>
        /// Generates pairs of even and odd numbers.
        /// </summary>
        /// <param name="pairCount">Number of items to generate.</param>
        /// <param name="max">Maximum value of numbers generated.</param>
        /// <returns>A list of strings, containing an even and an odd positive number, separated by a comma (,). 
        /// All numbers are in the range of [0..max]</returns>
        public List<string> GenerateEvenOddPairs(int pairCount, int max)
        {
            var EvenOddPairs = new List<string>();
            for (int i = 1; i < pairCount; i++)
            {
                var element = _numberGenerator.GenerateEven(max) + "," + _numberGenerator.GenerateOdd(max);
                EvenOddPairs.Add(element);
            }

            return EvenOddPairs;
        }
    }
}
