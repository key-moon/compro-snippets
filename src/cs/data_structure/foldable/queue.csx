using System;
using System.Collections.Generic;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

// HEADER
// title: FoldableQueue
// shortcut: fqueue
// description: 要素のfoldが可能なQueue
// author: keymoon

// BODY
class FoldableQueue<T>
{
    public int Count { get; private set; }
    public T Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return
                TailValueStack.Count == 0 ? FrontValue :
                FrontIsEmpty ? TailValueStack.Peek() :
                Merge(TailValueStack.Peek(), FrontValue);
        }
    }

    bool FrontIsEmpty = true;
    T FrontValue;
    Stack<T> Fronts = new Stack<T>();
    Stack<T> TailValueStack = new Stack<T>();

    Func<T, T, T> Merge;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FoldableQueue(Func<T, T, T> merge) { Merge = merge; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Pop()
    {
        Validate();
        if (TailValueStack.Count == 0) Move();
        TailValueStack.Pop();
        Count--;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(T item)
    {
        Fronts.Push(item);
        Count++;
        FrontValue = FrontIsEmpty ? item : Merge(FrontValue, item);
        FrontIsEmpty = false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Move()
    {
        TailValueStack.Push(Fronts.Pop());
        while (0 < Fronts.Count)
            TailValueStack.Push(Merge(Fronts.Pop(), TailValueStack.Peek()));
        FrontIsEmpty = true;
    }

    private void Validate() { if (Count == 0) throw new Exception(); }
}
