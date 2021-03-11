using System;
using System.Collections.Generic;
using System.Numerics;
using static FibonacciResearch.FibonacciGenerator;

namespace FibonacciResearch
{
    public static class FibonacciCodeGenerator
    {
        public static string Encode(BigInteger number)
        {
            List<BigInteger> fibCache = new List<BigInteger>(32);
            List<byte> code = new List<byte>(32);

            BigInteger n = 0;
            int i = 0;
            while ((n = Fibonacci(i)) <= number)
            {
                fibCache.Add(n);
                i++;
            }

            for (int j = fibCache.Count - 1; j >= 0; j--)
            {
                if (fibCache[j] <= number)
                {
                    number -= fibCache[j];
                    code.Add(1);
                }
                else
                    code.Add(0);
            }

            return string.Join(string.Empty, code);
        }

        public static BigInteger Decode(string code)
        {
            List<BigInteger> fibCache = new List<BigInteger>(32);
            
            byte[] codeArray = Array.ConvertAll<char, byte>(code.ToCharArray(), 
                converter: (digit) => byte.Parse(digit.ToString()));

            BigInteger value = new BigInteger(0);

            int i = 0, j = codeArray.Length - 1;
            while (i < codeArray.Length - 1)
            {
                fibCache.Add(Fibonacci(j));
                if (codeArray[i] == 1)
                    value += fibCache[i];

                i++;
                j--;
            }

            return value;
        }
    }
}
