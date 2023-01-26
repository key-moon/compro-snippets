#load "_global.csx"

using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

// HEADER
// title: Signed Integer Reader
// shortcut: sreader
// description: 符号付き整数を読み込む
// author: keymoon

// DECLARATIONS
//   _T: int
// Name: Int

// BODY
public static _T NextName
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get
    {
        _T res = 0; int sign = 1; while (Buffer[ptr] < 45) Move();
        if (Buffer[ptr] == 45) { Move(); sign = -1; }
        do { res = res * 10 + (Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
        return res * sign;
    }
}
