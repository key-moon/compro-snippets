///Title : Prime Factorization
///Shortcut : primefactori
///Description : 素因数分解
///Author : keymoon

using System.Collections.Generic;

static IEnumerable<long> PrimeFactors(long n)
{
    while ((n & 1) == 0)
    {
        n >>= 1;
        yield return 2;
    }
    for (long i = 3; i * i <= n; i += 2)
    {
        while (n % i == 0)
        {
            n /= i;
            yield return i;
        }
    }
    if (n != 1) yield return n;
}