#load "_global.csx"

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

// HEADER
// title: Rank([0, end))
// shortcut: wmranksf
// description: [0, end)に含まれるkindの個数を返す
// author: keymoon

// BODY
[MethodImpl(MethodImplOptions.AggressiveInlining)]
public int Rank(int end, int kind)
{
    for (int i = Depth - 1; i >= 0; i--)
    {
        bool param = (kind & (1 << i)) != 0;
        end = BitVectors[i].Rank(end, param);
        if (param) end += ZeroCount[i];
    }
    return end - BlockStartIndex[kind];
}
