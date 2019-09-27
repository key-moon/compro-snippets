///Title : Extended Euclidean algorithm
///Shortcut : extgcd
///Description : gcd=ax+byなるx,yを見つける
///Author : keymoon

static long ExtGCD(long a, long b, out long x, out long y)
{
    long div;
    long x1 = 1, y1 = 0, x2 = 0, y2 = 1;
    while (true)
    {
        if (b == 0) { x = x1; y = y1; return a; }
        div = a / b; x1 -= x2 * div; y1 -= y2 * div; a %= b;
        if (a == 0) { x = x2; y = y2; return b; }
        div = b / a; x2 -= x1 * div; y2 -= y1 * div; b %= a;
    }
}