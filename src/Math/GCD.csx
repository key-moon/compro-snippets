///Title : Greatest Common Divisor
///Shortcut : gcd
///Description : 最大公約数を見つける
///Author : keymoon

static long GCD(long a, long b)
{
    while (true)
    {
        if (b == 0) return a;
        a %= b;
        if (a == 0) return b;
        b %= a;
    }
}