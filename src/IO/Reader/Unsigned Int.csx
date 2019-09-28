///Title : Unsigned Integer Reader
///Shortcut : ureader
///Description : 符号なし整数を読み込む
///Author : keymoon

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

#if !DECLARATIONS
/*
//型
@T = uint
Name = UInt
*/
using @T = System.UInt32;
#endif

static @T NextName
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get
    {
        @T res = 0;
        int next = Console.In.Read();
        while (48 > next || next > 57) next = Console.In.Read();
        while (48 <= next && next <= 57)
        {
            res = res * 10 + (@T)next - 48;
            next = Console.In.Read();
        }
        return res;
    }
}