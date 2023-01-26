using System;

// HEADER
// title: MinMax
// shortcut: minmax
// description: 最小・最大を返す
// author: keymoon

// BODY
struct MinMax<T> where T : IComparable<T>
{
    public T Min;
    public T Max;
    public MinMax(T n) : this(n, n) { }
    public MinMax(T min, T max) { Min = min; Max = max; }
    public static MinMax<T> Merge(MinMax<T> a, MinMax<T> b) => new MinMax<T>(a.Min.CompareTo(b.Min) < 0 ? a.Min : b.Min, a.Max.CompareTo(b.Max) > 0 ? a.Max : b.Max);
    public static MinMax<T> operator |(MinMax<T> a, MinMax<T> b) => Merge(a, b);
    public static MinMax<T> operator |(MinMax<T> minMax, T value)
    {
        var res = minMax;
        if (value.CompareTo(minMax.Min) < 0) res.Min = value;
        else if (minMax.Max.CompareTo(value) < 0) res.Max = value;
        return res;
    }
}
