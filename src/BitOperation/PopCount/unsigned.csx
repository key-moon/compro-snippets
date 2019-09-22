///<Title>PopCount(unsigned)</Title>
///<Shortcut>popcountu</Shortcut>
///<Description>符号なし整数のビットの立っている数</Description>
///<Author>keymoon</Author>

using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

#if !DECLARATIONS
using @T = System.UInt32;
/*
@T = uint
*/
#endif

[MethodImpl(MethodImplOptions.AggressiveInlining)]
static int PopCount(@T n)
{
    n = n - ((n >> 1) & 0x55555555);
    n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
    return (int)(((n + (n >> 4) & 0xF0F0F0F) * 0x1010101) >> 24);
}