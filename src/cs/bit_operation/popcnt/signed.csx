using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

// HEADER
// title: PopCount(signed)
// shortcut: popcounts
// description: 符号つき整数のビットの立っている数
// author: keymoon

// DECLARATIONS
// _T: int

// BODY
[MethodImpl(MethodImplOptions.AggressiveInlining)]
static int PopCount(_T n)
{
    int msb = 0;
    if (n < 0) { n &= int.MaxValue; msb = 1; }
    n = n - ((n >> 1) & 0x55555555);
    n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
    return (int)(((n + (n >> 4) & 0xF0F0F0F) * 0x1010101) >> 24) + msb;
}
