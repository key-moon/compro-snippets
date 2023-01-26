using System;

// HEADER
// title: Top2
// shortcut: Top2
// description: 最上位2つの要素を返す
// author: keymoon

// BODY
struct Top2<T> where T : IComparable<T>
{
    public T First;
    public T Second;
    public Top2(T first, T second) { First = first; Second = second; }
    public static Top2<T> Merge(Top2<T> a, Top2<T> b)
    {
        if (a.First.CompareTo(b.First) > 0)
            return new Top2<T>(a.First, a.Second.CompareTo(b.First) > 0 ? a.Second : b.First);
        else
            return new Top2<T>(b.First, b.Second.CompareTo(a.First) > 0 ? b.Second : a.First);
    }
    public static Top2<T> Merge(Top2<T> a, T b)
    {
        if (a.Second.CompareTo(b) > 0) return a;
        if (a.First.CompareTo(b) > 0) return new Top2<T>(a.First, b);
        return new Top2<T>(b, a.First);
    }
    public static Top2<T> operator |(Top2<T> a, Top2<T> b) => Merge(a, b);
    public static Top2<T> operator |(Top2<T> a, T b) => Merge(a, b);
}
