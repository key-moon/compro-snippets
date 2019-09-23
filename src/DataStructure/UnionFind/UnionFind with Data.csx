///Title : UnionFind with Data
///Shortcut : ufd
///Description : データ保持可能Union-Find
///Author : keymoon

using System;
using System.Linq;
using System.Collections.Generic;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

class UnionFind<T>
{
    public readonly int Size;
    public int GroupCount { get; private set; }
    public IEnumerable<int> AllRepresents => Parent.Where((x, y) => x == y);
    int[] Sizes;
    int[] Parent;
    T[] Data;
    Func<T, T, T> MergeData;
    public UnionFind(int count)
    {
        Size = count;
        GroupCount = count;
        Parent = new int[count];
        Sizes = new int[count];
        Data = new T[count];
        for (int i = 0; i < count; i++)
        {
            Parent[i] = i;
            Sizes[i] = 1;
            Data[i] = default(T);
        }
    }
    public T this[int index]
    {
        get { return Data[Find(index)]; }
        set { Data[Find(index)] = value; }
    }

    public bool TryUnite(int x, int y)
    {
        int xp = Find(x);
        int yp = Find(y);
        if (yp == xp) return false;
        if (Sizes[xp] < Sizes[yp])
        {
            var tmp = xp;
            xp = yp;
            yp = tmp;
        }
        GroupCount--;
        Parent[yp] = xp;
        Data[xp] = MergeData(Data[xp], Data[yp]);
        Sizes[xp] += Sizes[yp];
        return true;
    }
    public int GetSize(int x) => Sizes[Find(x)];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        while (x != Parent[x])
        {
            Parent[x] = Parent[Parent[x]];
            x = Parent[x];
        }
        return x;
    }
}