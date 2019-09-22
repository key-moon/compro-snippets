///<Title>PopCount(signed)</Title>
///<Shortcut>popcountu</Shortcut>
///<Description>符号つき整数のビットの立っている数</Description>
///<Author>keymoon</Author>

using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

#if !DECLARATIONS
using @T = System.Int32;
/*
@T = int
*/
#endif

[MethodImpl(MethodImplOptions.AggressiveInlining)]
static int PopCount(@T n)
{
    int msb = 0;
    if (n < 0) { n &= int.MaxValue; msb = 1; }
    n = n - ((n >> 1) & 0x55555555);
    n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
    return (int)(((n + (n >> 4) & 0xF0F0F0F) * 0x1010101) >> 24) + msb;
}