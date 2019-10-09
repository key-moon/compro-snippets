#load "_global.csx"

///Title : Rank([start, end))
///Shortcut : wmrank
///Description : [start, end)に含まれるkindの個数を返す
///Author : keymoon

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

[MethodImpl(MethodImplOptions.AggressiveInlining)]
public int Rank(int start, int end, int kind)
{
    for (int i = Depth - 1; i >= 0; i--)
    {
        bool param = (kind & (1 << i)) != 0;
        start = BitVectors[i].Rank(start, param);
        end = BitVectors[i].Rank(end, param);
        if (param) { start += ZeroCount[i]; end += ZeroCount[i]; }
    }
    return end - start;
}