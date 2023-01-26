// HEADER
// title: Greatest Common Divisor
// shortcut: gcd
// description: 最大公約数を見つける
// author: keymoon

// BODY
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
