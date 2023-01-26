using System;
using System.Collections.Generic;
using static System.Math;

// HEADER
// title: Divisors
// shortcut: divisors
// description: 約数列挙
// author: keymoon

// BODY
static IEnumerable<long> Divisors(long n)
{
    var max = (int)Ceiling(Sqrt(n));
    for (int i = 1; i <= max; i++)
        if (n % i == 0) { yield return i; yield return n / i; }
}
