using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

// HEADER
// title: Most Significant Bit(long)
// shortcut: msbl
// description: 最も上に立っているbit(0-indexed)
// author: keymoon

// DECLARATIONS
// _T: long

// BODY
[MethodImpl(MethodImplOptions.AggressiveInlining)]
static _T MSB(_T s) { s |= s >> 1; s |= s >> 2; s |= s >> 4; s |= s >> 8; s |= s >> 16; s |= s >> 32; return (s + 1) >> 1; }
