///<Title>Binary-Indexed Tree</Title>
///<Shortcut>bit</Shortcut>
///<Description>Binary-Indexed Tree</Description>
///<Author>keymoon</Author>

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

class BIT<T>
{
    public readonly int Size;
    T Identity;
    T[] Elements;
    Func<T, T, T> Merge;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BIT(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        Elements = new T[Size + 1];
        for (int i = 0; i < Elements.Length; i++) Elements[i] = identity;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int r)
    {
        T res = Identity;
        for (r++; r > 0; r -= r & -r) res = Merge(res, Elements[r]);
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x)
    {
        for (i++; i < Elements.Length; i += i & -i) Elements[i] = Merge(Elements[i], x);
    }
}