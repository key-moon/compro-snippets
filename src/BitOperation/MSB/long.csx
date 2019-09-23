///Title : Most Significant Bit(long)
///Shortcut : msbl</Shortcut>
///Description : 最も上に立っているbitのindex(0-indexed)
///Author : keymoon

using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

[MethodImpl(MethodImplOptions.AggressiveInlining)]
static int MSB(long n)
{
    int res = 0;
    if (0 != (n >> (res | 32))) res |= 32;
    if (0 != (n >> (res | 16))) res |= 16;
    if (0 != (n >> (res | 8))) res |= 8;
    if (0 != (n >> (res | 4))) res |= 4;
    if (0 != (n >> (res | 2))) res |= 2;
    if (0 != (n >> (res | 1))) res |= 1;
    return res;
}
