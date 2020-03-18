---
layout: default
---

<!-- mathjax config similar to math.stackexchange -->
<script type="text/javascript" async
  src="https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/MathJax.js?config=TeX-MML-AM_CHTML">
</script>
<script type="text/x-mathjax-config">
  MathJax.Hub.Config({
    TeX: { equationNumbers: { autoNumber: "AMS" }},
    tex2jax: {
      inlineMath: [ ['$','$'] ],
      processEscapes: true
    },
    "HTML-CSS": { matchFontHeight: false },
    displayAlign: "left",
    displayIndent: "2em"
  });
</script>

<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/jquery-balloon-js@1.1.2/jquery.balloon.min.js" integrity="sha256-ZEYs9VrgAeNuPvs15E39OsyOJaIkXEEt10fzxJ20+2I=" crossorigin="anonymous"></script>
<script type="text/javascript" src="../../../assets/js/copy-button.js"></script>
<link rel="stylesheet" href="../../../assets/css/copy-button.css" />


# :warning: src/ImmutableDataStructure/Array.csx

<a href="../../../index.html">Back to top page</a>

* category: <a href="../../../index.html#365a8aa61600deac547fb3d08f779047">src/ImmutableDataStructure</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/ImmutableDataStructure/Array.csx">View this file on GitHub</a>
    - Last commit date: 2019-10-02 12:39:35+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : Immutable Array
///Shortcut : iarray
///Description : 永続配列
///Author : keymoon

using System;
using System.Collections;
using System.Collections.Generic;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;


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
```
{% endraw %}

<a id="bundled"></a>
{% raw %}
```cpp
Traceback (most recent call last):
  File "/opt/hostedtoolcache/Python/3.8.2/x64/lib/python3.8/site-packages/onlinejudge_verify/docs.py", line 340, in write_contents
    bundled_code = language.bundle(self.file_class.file_path, basedir=pathlib.Path.cwd())
  File "/opt/hostedtoolcache/Python/3.8.2/x64/lib/python3.8/site-packages/onlinejudge_verify/languages/csharpscript.py", line 110, in bundle
    raise NotImplementedError
NotImplementedError

```
{% endraw %}

<a href="../../../index.html">Back to top page</a>

