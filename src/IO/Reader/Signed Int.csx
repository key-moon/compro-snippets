#load "_global.csx"

///Title : Signed Integer Reader
///Shortcut : sreader
///Description : 符号付き整数を読み込む
///Author : keymoon

using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

#if !DECLARATIONS
/*
//型
@T = int;
Name = Int;
*/
using @T = System.Int32;
#endif

public static @T NextName
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get
    {
        @T res = 0; int sign = 1; while (Buffer[ptr] < 45) Move();
        if (Buffer[ptr] == 45) { Move(); sign = -1; }
        do { res = res * 10 + (Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
        return res * sign;
    }
}