///Title : SegmentTree(Range Update/Point Query, Non-Commutative operation)
///Shortcut : segtreerpnc
///Description : 区間更新一点取得(非可換作用)
///Author : keymoon

using System;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

class SegmentTree<T>
{
    public readonly int Size;
    T Identity;
    Func<T, T, T> Merge;
    int LeafCount;
    int Height;
    T[] Operators;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        Height = 1;
        LeafCount = 1;
        while (LeafCount < size) { Height++; LeafCount <<= 1; }
        Operators = new T[LeafCount << 1];
        for (int i = 0; i < Operators.Length; i++) Operators[i] = identity;
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Query(index); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Propagate(index += LeafCount); Operators[index] = value; }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        l += LeafCount;
        r += LeafCount;
        Propagate(l);
        Propagate(r);
        while (l <= r)
        {
            if ((l & 1) == 1) Operators[l] = Merge(Operators[l], x);
            if ((r & 1) == 0) Operators[r] = Merge(Operators[r], x);
            l = (l + 1) / 2;
            r = (r - 1) / 2;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int index)
    {
        index += LeafCount;
        Propagate(index);
        return Operators[index];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int sectionIndex)
    {
        for (int i = Height - 1; i >= 1; i--)
        {
            var section = sectionIndex >> i;
            var leftChild = sectionIndex >> (i - 1);
            var rightChild = leftChild ^ 1;
            Operators[leftChild] = Merge(Operators[leftChild], Operators[section]);
            Operators[rightChild] = Merge(Operators[rightChild], Operators[section]);
            Operators[section] = Identity;
        }
    }
}