///Title : Most Significant Bit(int)
///Shortcut : msbi
///Description : 最も上に立っているbit(0-indexed)
///Author : keymoon

using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

#if !DECLARATIONS
/*
//型
@T = int;
*/
using @T = System.Int32;
#endif

[MethodImpl(MethodImplOptions.AggressiveInlining)]
static @T MSB(@T s) { s |= s >> 1; s |= s >> 2; s |= s >> 4; s |= s >> 8; s |= s >> 16; return (s + 1) >> 1; }