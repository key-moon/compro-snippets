///Title : Immutable Array
///Shortcut : iarray
///Description : 永続配列
///Author : keymoon

using System;
using System.Collections.Generic;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;


class ImmutableArray<T>
{
    int Size;
    Node Root;

    private ImmutableArray() { }
    public ImmutableArray(int size)
    {
        Size = size;

        int RootIndex = 1;
        while (RootIndex <= size) RootIndex <<= 1;
        RootIndex >>= 1;

        Root = new Node() { Index = RootIndex - 1 };

        Stack<Node> stack = new Stack<Node>();
        stack.Push(Root);
        while (stack.Count > 0)
        {
            var item = stack.Pop();
            var parentIndex = item.Index;
            var lsb = -(parentIndex + 1) & (parentIndex + 1);
            if (lsb == 1) continue;
            lsb >>= 1;
            var left = new Node() { Index = parentIndex - lsb };
            item.Left = left;
            stack.Push(left);

            if (parentIndex >= Size - 1) continue;
            while (parentIndex + lsb > Size) lsb >>= 1;
            var right = new Node() { Index = parentIndex + lsb };
            item.Right = right;
            stack.Push(right);
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
        AssertIndex(index);
        Node node = Root.GetCopy();
        var newList = new ImmutableArray<T>() { Root = node, Size = Size };
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
        AssertIndex(index);
        Node node = Root;
        while (index != node.Index)
        {
            if (index < node.Index) node = node.Left;
            else node = node.Right;
        }
        return node.Value;
    }

    private void AssertIndex(int index)
    {
        if (index < 0 || Size <= index) throw new IndexOutOfRangeException();
    }

    public T[] ToArray()
    {
        T[] res = new T[Size];
        Stack<Node> stack = new Stack<Node>();
        stack.Push(Root);
        while (stack.Count > 0)
        {
            var item = stack.Pop();
            if (!(item.Left is null))
            {
                stack.Push(item.Left);
                if (!(item.Right is null)) stack.Push(item.Right);
            }
            res[item.Index] = item.Value;
        }
        return res;
    }

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