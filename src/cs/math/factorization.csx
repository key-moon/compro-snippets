using System.Collections.Generic;
using static System.Math;

// HEADER
// title: Prime Factorization
// shortcut: primefactori
// description: 素因数分解
// author: keymoon

// BODY
static IEnumerable<long> PrimeFactors(long n)
{
    while ((n & 1) == 0) { n >>= 1; yield return 2; }
    for (long i = 3; i * i <= n; i += 2)
    {
        long rem, div = DivRem(n, i, out rem);
        while (rem == 0)
        {
            n = div;
            div = DivRem(n, i, out rem);
            yield return i;
        }
    }
    if (n != 1) yield return n;
}
