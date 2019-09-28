///Title : Immutable Stack
///Shortcut : istack
///Description : 永続Stack
///Author : keymoon

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

class ImmutableStack<T>
{
    readonly ImmutableStack<T> previousStack;
    public readonly T Top;
    public readonly int Count;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableStack() : this(null, default, 0) { }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ImmutableStack(ImmutableStack<T> prev, T top, int count)
    {
        previousStack = prev;
        Top = top;
        Count = count;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableStack<T> Push(T value) => new ImmutableStack<T>(this, value, Count + 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableStack<T> Pop() => previousStack == null ? null : previousStack;
}