using System;
using System.Collections.Generic;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

// HEADER
// title: FoldableDeque
// shortcut: fdeque
// description: Sliding-Window Aggregationが可能なQueue
// author: keymoon

// BODY
class FoldableDeque<T>
{
    public int Count { get; private set; }
    T[] data; int FrontInd, BackInd;
    Stack<T> FrontValues = new Stack<T>();
    Stack<T> BackValues = new Stack<T>();
    Func<T, T, T> Merge;

    public T Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return
                FrontValues.Count == 0 ? BackValues.Peek() :
                BackValues.Count == 0 ? FrontValues.Peek() :
                Merge(FrontValues.Peek(), BackValues.Peek());
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FoldableDeque(Func<T, T, T> merge)
    {
        data = new T[1 << 16];
        FrontInd = 0;
        BackInd = data.Length - 1;
        Count = 0;
        Merge = merge;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PushFront(T item)
    {
        if (Count == data.Length) Extend(data.Length << 1);
        data[FrontInd = (FrontInd - 1) & data.Length - 1] = item; Count++;
        FrontValues.Push(FrontValues.Count == 0 ? item : Merge(item, FrontValues.Peek()));
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PushBack(T item)
    {
        if (Count == data.Length) Extend(data.Length << 1);
        data[BackInd = (BackInd + 1) & data.Length - 1] = item; Count++;
        BackValues.Push(BackValues.Count == 0 ? item : Merge(BackValues.Peek(), item));
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PopFront()
    {
        Validate();
        FrontInd = (FrontInd + 1) & data.Length - 1; Count--;
        if (FrontValues.Count == 0) Reconstruct();
        else FrontValues.Pop();
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PopBack()
    {
        Validate();
        BackInd = (BackInd - 1) & data.Length - 1; Count--;
        if (BackValues.Count == 0) Reconstruct();
        else BackValues.Pop();
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Reconstruct()
    {
        int ind;
        FrontValues.Clear();
        BackValues.Clear();
        if (Count == 0) return;
        ind = (FrontInd + (Count >> 1)) & data.Length - 1;
        BackValues.Push(data[ind]);
        if (ind <= BackInd)
        {
            for (ind++; ind <= BackInd; ind++)
                BackValues.Push(Merge(BackValues.Peek(), data[ind]));
        }
        else
        {
            for (ind++; ind < data.Length; ind++)
                BackValues.Push(Merge(BackValues.Peek(), data[ind]));
            for (ind = 0; ind <= BackInd; ind++)
                BackValues.Push(Merge(BackValues.Peek(), data[ind]));
        }
        if (Count == 1) return;
        ind = (FrontInd + (Count >> 1) - 1) & data.Length - 1;
        FrontValues.Push(data[ind]);
        if (FrontInd <= ind)
        {
            for (ind--; FrontInd <= ind; ind--)
                FrontValues.Push(Merge(data[ind], FrontValues.Peek()));
        }
        else
        {
            for (ind--; 0 <= ind; ind--)
                FrontValues.Push(Merge(data[ind], FrontValues.Peek()));
            for (ind = data.Length - 1; FrontInd <= ind; ind--)
                FrontValues.Push(Merge(data[ind], FrontValues.Peek()));
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        T[] newData = new T[newSize];
        if (0 < Count)
        {
            if (FrontInd <= BackInd) Array.Copy(data, FrontInd, newData, 0, Count);
            else
            {
                Array.Copy(data, FrontInd, newData, 0, data.Length - FrontInd);
                Array.Copy(data, 0, newData, data.Length - FrontInd, BackInd + 1);
            }
        }
        data = newData; FrontInd = 0; BackInd = Count - 1;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Validate() { if (Count == 0) throw new Exception(); }
}
