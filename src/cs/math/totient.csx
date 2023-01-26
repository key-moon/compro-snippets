using System;
using System.Collections.Generic;
using static System.Math;

// HEADER
// title: Totient
// shortcut: totient
// description: φ(n) := |{1<=i<=n | i|n==1}|
// author: keymoon

// BODY
static long Totient(long n)
{
    long res = n;
    if ((n & 1) == 0)
    {
        res >>= 1;
        do { n >>= 1; } while ((n & 1) == 0);
    }
    for (long i = 3; i * i <= n; i += 2)
    {
        long rem, div = Math.DivRem(n, i, out rem);
        if (rem == 0)
        {
            res = (res / i) * (i - 1);
            do { n = div; div = Math.DivRem(n, i, out rem); } while (rem == 0);
        }
    }
    if (n != 1) res = (res / n) * (n - 1);
    return res;
}
