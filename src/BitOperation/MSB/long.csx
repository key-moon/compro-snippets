///Title : Most Significant Bit(long)
///Shortcut : msbl
///Description : 最も上に立っているbit(0-indexed)
///Author : keymoon

using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

#if !DECLARATIONS
/*
//型
@T = long
*/
using @T = System.Int64;
#endif

[MethodImpl(MethodImplOptions.AggressiveInlining)]
static @T MSB(@T s) { s |= s >> 1; s |= s >> 2; s |= s >> 4; s |= s >> 8; s |= s >> 16; s |= s >> 32; return (s + 1) >> 1; }