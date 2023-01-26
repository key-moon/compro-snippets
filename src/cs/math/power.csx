// HEADER
// title: Power
// shortcut: pow
// description: モノイドの冪演算
// author: keymoon

// DECLARATIONS
//              _T: ModInt
// IdentityElement: 1

// BODY
static _T Power(_T n, long m)
{
    _T pow = n;
    _T res = IdentityElement;
    while (m > 0)
    {
        if ((m & 1) == 1) res *= pow;
        pow *= pow;
        m >>= 1;
    }
    return res;
}
