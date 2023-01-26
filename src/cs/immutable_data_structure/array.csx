using System;
using System.Collections;
using System.Collections.Generic;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

// HEADER
// title: Immutable Array
// shortcut: iarray
// description: 永続配列
// author: keymoon

// BODY
class ImmutableArray<T> : IEnumerable<T>
{
    public int Length { get; private set; }
    Node Root;

    private ImmutableArray() { }
    public ImmutableArray(int length)
    {
        Length = length;

        int RootIndex = 1;
        while (RootIndex <= length) RootIndex <<= 1;
        RootIndex >>= 1;

        Stack<Node> stack = new Stack<Node>();
        stack.Push(Root = new Node() { Index = RootIndex - 1 });
        while (stack.Count > 0)
        {
            var item = stack.Pop();
            var parentIndex = item.Index;
            var lsb = -(parentIndex + 1) & (parentIndex + 1);
            if (lsb == 1) continue;
            lsb >>= 1;
            stack.Push(item.Left = new Node() { Index = parentIndex - lsb });

            while (parentIndex + lsb >= Length) lsb >>= 1;
            stack.Push(item.Right = new Node() { Index = parentIndex + lsb });
        }
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return GetValue(index); }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableArray<T> SetValue(int index, T value)
    {
        Node node = Root.GetCopy();
        var newList = new ImmutableArray<T>() { Root = node, Length = Length };
        while (index != node.Index)
        {
            if (index < node.Index) node = (node.Left = node.Left.GetCopy());
            else node = (node.Right = node.Right.GetCopy());
        }
        node.Value = value;
        return newList;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T GetValue(int index)
    {
        Node node = Root;
        while (index != node.Index)
        {
            if (index < node.Index) node = node.Left;
            else node = node.Right;
        }
        return node.Value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerator<T> GetEnumerator()
    {
        Stack<Node> stack = new Stack<Node>();
        Node item = Root;
        stack.Push(item);
        while (item.Left != null) stack.Push(item = item.Left);
        while (stack.Count > 0)
        {
            yield return (item = stack.Pop()).Value;
            if (item.Right != null)
            {
                stack.Push(item = item.Right);
                while (item.Left != null) stack.Push(item = item.Left);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T[] ToArray()
    {
        T[] res = new T[Length];
        Stack<Node> stack = new Stack<Node>();
        stack.Push(Root);
        while (stack.Count > 0)
        {
            var item = stack.Pop();
            if (item.Left != null)
            {
                stack.Push(item.Left);
                if (item.Right != null) stack.Push(item.Right);
            }
            res[item.Index] = item.Value;
        }
        return res;
    }

    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

    class Node
    {
        public int Index;
        public T Value;
        public Node Left;
        public Node Right;
        public Node GetCopy() => new Node() { Index = Index, Value = Value, Left = Left, Right = Right };
        public override string ToString() => Value.ToString();
    }
}
