using System;
using System.Linq;
using System.Collections.Generic;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

// HEADER
// title: PotentializedUnionFind
// shortcut: puf
// description: ポテンシャル付き素集合データ構造
// author: keymoon

// BODY
class PotentializedUnionFind<T> where T : IEquatable<T>
{
    public int Size { get; private set; }
    public int GroupCount { get; private set; }
    public IEnumerable<int> AllRepresents => Parent.Where((x, y) => x == y);
    int[] Sizes;
    int[] Parent;
    T[] Value;
    Func<T, T, T> Operate;
    Func<T, T> Inverse;
    T Identity;

    public PotentializedUnionFind(int count, Func<T, T, T> operate, Func<T, T> inverse, T identity)
    {
        Size = count;
        GroupCount = count;
        Parent = new int[count];
        Sizes = new int[count];
        Value = new T[count];
        for (int i = 0; i < count; i++) { Sizes[Parent[i] = i] = 1; Value[i] = identity; }
        Operate = operate;
        Inverse = inverse;
        Identity = identity;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryUnite(int x, int y, T distance)
    {
        T xd, yd;
        int xp = Find(x, out xd);
        int yp = Find(y, out yd);

        if (yp == xp) return Operate(distance, yd).Equals(xd);

        GroupCount--;
        if (Sizes[xp] < Sizes[yp])
        {
            Value[xp] = Operate(Operate(Inverse(xd), distance), yd);
            Parent[xp] = yp;
            Sizes[yp] += Sizes[xp];
        }
        else
        {
            Value[yp] = Operate(Operate(Inverse(yd), Inverse(distance)), xd);
            Parent[yp] = xp;
            Sizes[xp] += Sizes[yp];
        }
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetSize(int x) => Sizes[Find(x)];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T GetPotential(int x, int y)
    {
        T xd, yd;
        int xp = Find(x, out xd);
        int yp = Find(y, out yd);
        if (yp == xp) return Operate(Inverse(xd), yd);
        else return Identity;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        while (x != Parent[x]) { Value[x] = Operate(Value[x], Value[Parent[x]]); Parent[x] = Parent[Parent[x]]; x = Parent[x]; }
        return x;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int Find(int x, out T potential)
    {
        potential = Identity;
        while (x != Parent[x])
        {
            Value[x] = Operate(Value[x], Value[Parent[x]]);
            Parent[x] = Parent[Parent[x]];
            potential = Operate(potential, Value[x]);
            x = Parent[x];
        }
        return x;
    }
}
