#load "_global.csx"

///Title : Quantile
///Shortcut : wmquantile
///Description : [start, end)のうちk番目に大きい数を返す
///Author : keymoon

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

[MethodImpl(MethodImplOptions.AggressiveInlining)]
public int Quantile(int start, int end, int k)
{
    int res = 0;
    for (int i = Depth - 1; i >= 0; i--)
    {
        var startRank = BitVectors[i].Rank(start);
        var endRank = BitVectors[i].Rank(end);
        var oneCount = endRank - startRank;
        if (oneCount <= k)
        {
            k -= oneCount;
            start -= startRank;
            end -= endRank;
        }
        else
        {
            res |= 1 << i;
            start = ZeroCount[i] + startRank;
            end = ZeroCount[i] + endRank;
        }
    }
    return res;
}