///Title : primes
///Shortcut : Primes
///Description : 素数を列挙する
///Author : keymoon

using System;
using System.Collections.Generic;

#if !DECLARATIONS

#endif

public static IEnumerable<int> Primes(int n)
{
    if (n < 2) yield break;
    yield return 2;
    ulong[] bitArray = new ulong[(n + 1) / 64 / 2 + 1];

    int[] smallPrimes = { 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61 };
    foreach (var prime in smallPrimes)
    {
        if (n < prime) yield break;
        yield return prime;

        ulong[] primeMask = new ulong[prime];
        for (int j = (prime - 3) / 2; j < (prime << 6); j += prime)
            primeMask[j >> 6] |= 1UL << (j & 63);

        int maskInd = 0;
        for (int i = 0; i < bitArray.Length; i++)
        {
            bitArray[i] |= primeMask[maskInd];
            if (++maskInd == prime) maskInd = 0;
        }
    }

    int[] deBruijnIndex = { 0, 1, 59, 2, 60, 40, 54, 3, 61, 32, 49, 41, 55, 19, 35, 4, 62, 52, 30, 33, 50, 12, 14, 42, 56, 16, 27, 20, 36, 23, 44, 5, 63, 58, 39, 53, 31, 48, 18, 34, 51, 29, 11, 13, 15, 26, 22, 43, 57, 38, 47, 17, 28, 10, 25, 21, 37, 46, 9, 24, 45, 8, 7, 6 };
    int maxInd = n / 2;
    for (int i = 0; i < bitArray.Length; i++)
    {
        for (ulong bit = ~bitArray[i]; bit != 0; bit &= bit - 1)
        {
            int index = i << 6 | deBruijnIndex[((bit & (~bit + 1)) * 0x03F566ED27179461UL) >> 58];
            int prime = (index << 1) + 3;
            if (n < prime) yield break;
            yield return prime;
            for (int ind = index; ind <= maxInd; ind += prime)
                bitArray[ind >> 6] |= 1UL << (ind & 63);
        }
    }
}