///<Title>Euclidean algorithm</Title>
///<Shortcut>gcd</Shortcut>
///<Description>最大公約数を見つける</Description>
///<Author>keymoon</Author>

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