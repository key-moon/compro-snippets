///<Title>Unsigned Integer Reader</Title>
///<Shortcut>ureader</Shortcut>
///<Description>符号なし整数を読み込む</Description>
///<Author>keymoon</Author>

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

#if !DECLARATIONS
//型
using @T = System.UInt32;
/*
@T = uint
Name = UInt
*/
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