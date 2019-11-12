///Title : Divisors
///Shortcut : divisors
///Description : 約数列挙
///Author : keymoon

using System;
using System.Collections.Generic;
using static System.Math;

static IEnumerable<long> Divisors(long n)
{
    var max = (int)Ceiling(Sqrt(n));
    for (int i = 1; i <= max; i++)
        if (n % i == 0) { yield return i; yield return n / i; }
}