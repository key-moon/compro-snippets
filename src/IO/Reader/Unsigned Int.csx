#load "_global.csx"

///Title : Unsigned Integer Reader
///Shortcut : ureader
///Description : 符号なし整数を読み込む
///Author : keymoon

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

public static @T NextName
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get
    {
        @T res = 0; while (Buffer[ptr] < 48) Move();
        do { res = res * 10 + (@T)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
        return res;
    }
}