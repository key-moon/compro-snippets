#load "_global.csx"

using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

// HEADER
// title: Unsigned Integer Reader
// shortcut: ureader
// description: 符号なし整数を読み込む
// author: keymoon

// DECLARATIONS
//   _T: uint
// Name: UInt

// BODY
public static _T NextName
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get
    {
        _T res = 0; while (Buffer[ptr] < 48) Move();
        do { res = res * 10 + (_T)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
        return res;
    }
}
