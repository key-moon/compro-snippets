#load "_global.csx"

///Title : Select
///Shortcut : wmselect
///Description : k番目に登場するkindのindexを返す
///Author : keymoon

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

[MethodImpl(MethodImplOptions.AggressiveInlining)]
public int Select(int k, int kind)
{
    var place = BlockStartIndex[kind] + k;
    for (int i = 0; i < Depth; i++)
    {
        bool param = (kind & (1 << i)) != 0;
        if (param) place = BitVectors[i].Select1(place - ZeroCount[i]);
        else place = BitVectors[i].Select0(place);
    }
    return place;
}