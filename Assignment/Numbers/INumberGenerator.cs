namespace Assignment.Numbers
{
    public interface INumberGenerator
    {
        /// <summary>
        /// Generates a random positive even number.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>A random positive even number between [0..limit]</returns>
        int GenerateEven(int limit);

        /// <summary>
        /// Generates a random positive odd number.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns>A random positive odd number between [1..limit]</returns>
        int GenerateOdd(int limit);
    }
}