#load "../../src/Math/Primes.csx"
#pragma PROBLEM https://judge.yosupo.jp/problem/enumerate_primes

using System;
using System.Linq;
using System.Text;

var nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (n, a, b) = (nab[0], nab[1], nab[2]);

var next = b;

int count = 0;
int outCount = 0;

StringBuilder builder = new StringBuilder();
foreach (var prime in Primes(n))
{
    if (count == next)
    {
        builder.Append(prime);
        builder.Append(' ');
        outCount++;
        next += a;
    }
    count++;
}

Console.WriteLine($"{count} {outCount}");
Console.WriteLine(builder.ToString());
