///Title : Signed Integer Reader
///Shortcut : sreader
///Description : 符号付き整数を読み込む
///Author : keymoon

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

#if !DECLARATIONS
/*
//型
@T = int
Name = Int
*/
using @T = System.Int32;
#endif

static @T NextName
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get
    {
        @T res = 0;
        int next = Console.In.Read();
        int sign = 1;
        while (45 > next || next > 57) next = Console.In.Read();
        if (next == 45) { next = Console.In.Read(); sign = -1; }
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = Console.In.Read();
        }
        return res * sign;
    }
}