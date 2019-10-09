#load "_global.csx"

///Title : Rank([0, end))
///Shortcut : wmranksf
///Description : [0, end)に含まれるkindの個数を返す
///Author : keymoon

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

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