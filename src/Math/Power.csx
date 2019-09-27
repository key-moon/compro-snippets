///Title : Power
///Shortcut : pow
///Description : モノイドの冪演算
///Author : keymoon

#if !DECLARATIONS
#load "ModInt.csx"
///型
using @T = ModInt;
///単位元
static @T @IdentityElement = 1;
#endif

static @T Power(@T n, long m)
{
    @T pow = n;
    @T res = @IdentityElement;
    while (m > 0)
    {
        if ((m & 1) == 1) res *= pow;
        pow *= pow;
        m >>= 1;
    }
    return res;
}
