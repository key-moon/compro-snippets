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
<script type="text/javascript" src="../../../../assets/js/copy-button.js"></script>
<link rel="stylesheet" href="../../../../assets/css/copy-button.css" />


# :warning: src/DataStructure/SegmentTree/RangeUpdate-PointQuery(Non-Commutative).csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#5953e6c7c1ed72d211284e9a01174d16">src/DataStructure/SegmentTree</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/DataStructure/SegmentTree/RangeUpdate-PointQuery(Non-Commutative).csx">View this file on GitHub</a>
    - Last commit date: 2019-12-19 15:13:24+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : SegmentTree(Range Update/Point Query, Non-Commutative operation)
///Shortcut : segtreerpnc
///Description : 区間更新一点取得(非可換作用)
///Author : keymoon

using System;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

class SegmentTree<T>
{
    public readonly int Size;
    T Identity;
    Func<T, T, T> Merge;
    int LeafCount;
    int Height;
    T[] Operators;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        Height = 1;
        LeafCount = 1;
        while (LeafCount < size) { Height++; LeafCount <<= 1; }
        Operators = new T[LeafCount << 1];
        for (int i = 0; i < Operators.Length; i++) Operators[i] = identity;
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Query(index); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Propagate(index += LeafCount); Operators[index] = value; }
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x) { Propagate(i += LeafCount); Operators[i] = Merge(Operators[i], x); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        l += LeafCount;
        r += LeafCount;
        Propagate(l);
        Propagate(r);
        while (l <= r)
        {
            if ((l & 1) == 1) Operators[l] = Merge(Operators[l], x);
            if ((r & 1) == 0) Operators[r] = Merge(Operators[r], x);
            l = (l + 1) / 2;
            r = (r - 1) / 2;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int index)
    {
        index += LeafCount;
        Propagate(index);
        return Operators[index];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int sectionIndex)
    {
        for (int i = Height - 1; i >= 1; i--)
        {
            var section = sectionIndex >> i;
            var leftChild = sectionIndex >> (i - 1);
            var rightChild = leftChild ^ 1;
            Operators[leftChild] = Merge(Operators[leftChild], Operators[section]);
            Operators[rightChild] = Merge(Operators[rightChild], Operators[section]);
            Operators[section] = Identity;
        }
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

<a href="../../../../index.html">Back to top page</a>

