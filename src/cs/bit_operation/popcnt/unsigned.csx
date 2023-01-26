using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

// HEADER
// title: PopCount(unsigned)
// shortcut: popcountu
// description: 符号なし整数のビットの立っている数
// author: keymoon

// DECLARATIONS
// _T: uint

// BODY
[MethodImpl(MethodImplOptions.AggressiveInlining)]
static int PopCount(_T n)
{
    n = n - ((n >> 1) & 0x55555555);
    n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
    return (int)(((n + (n >> 4) & 0xF0F0F0F) * 0x1010101) >> 24);
}
