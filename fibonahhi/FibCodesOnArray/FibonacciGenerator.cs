using System.Numerics;

namespace FibonacciResearch
{
    public static class FibonacciGenerator
    {
        public static BigInteger Fibonacci(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            BigInteger current = 0ul;
            BigInteger next = 1ul;
            BigInteger result = 0ul;

            int count = 2;
            while (count <= n)
            {
                result = checked(current + next);
                current = next;
                next = result;

                count++;
            }

            return result;
        }
    }
}
