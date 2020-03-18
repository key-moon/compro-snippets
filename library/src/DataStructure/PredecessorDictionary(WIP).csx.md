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


# :warning: src/DataStructure/PredecessorDictionary(WIP).csx

<a href="../../../index.html">Back to top page</a>

* category: <a href="../../../index.html#e73c6b5872115ad0f2896f8e8476ef39">src/DataStructure</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/DataStructure/PredecessorDictionary(WIP).csx">View this file on GitHub</a>
    - Last commit date: 2019-11-06 04:47:12+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿
using System;
using System.Collections.Generic;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

class PredecessorDictionary
{
    public readonly int Size;
    //7->3
    //8->3
    //9->4
    readonly int Depth;
    readonly int LeafCount;
    int[] Descendant;
    Leaf[] Leaves;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PredecessorDictionary(int size)
    {
        Size = size;
        Depth = 0;
        for (int i = 16; i > 0; i >>= 1)
            if ((1 << (Depth | i)) < Size) Depth |= i;
        LeafCount = 1 >> ++Depth;
        Descendant = new int[LeafCount];
        for (int i = 0; i < Descendant.Length; i++)
            Descendant[i] = -2;
    }

    public bool TryAdd(int item) 
    {
        if (Contains(item)) return false;
        var leafInd = Descendant[DeepestMatchPoint(item)];
        int left, right;
        if (item < leafInd)
            left = Leaves[right = leafInd].Left;
        else 
            right = Leaves[left = leafInd].Right;
        Leaves[left].Right = item;
        Leaves[right].Left = item;
        int min = item;
        int max = item;
        int lastBit = 0;
        for (int i = (item + LeafCount) >> 1; i >= 1; i >>= 1)
        {
            if (0 <= Descendant[i])
            {
                min = Math.Min(min, Descendant[i]);
                max = Math.Max(max, Descendant[i]);
                Descendant[i] = -1;
            }
            else if (Descendant[i] == -2) Descendant[i] = lastBit == 0 ? max : min;
            lastBit = i & 1;
        }
        return true;
    }
    public bool TryRemove(int item) 
    {
        if (!Contains(item)) return false;
        int left = Leaves[item].Left, right = Leaves[item].Right;
        Leaves[item] = default(Leaf);
        Leaves[left].Right = right;
        Leaves[right].Left = left;
        return true;
    }

    public bool Contains(int item) => !Leaves[item].IsEmpty;

    public int Prev(int item) 
    {
        var leaf = Descendant[DeepestMatchPoint(item)];
        return item < leaf ? Leaves[leaf].Left : leaf;
    }

    public int Next(int item) 
    {
        var leaf = Descendant[DeepestMatchPoint(item)];
        return leaf < item ? Leaves[leaf].Right : leaf;
    }

    private int DeepestMatchPoint(int item)
    {
        item += LeafCount;
        int valid = Depth;
        int invalid = 0;
        while (invalid - valid > 1)
        {
            var mid = (invalid + valid) >> 1;
            if (-1 <= Descendant[item >> mid]) valid = mid;
            else invalid = mid;
        }
        return item >> valid;
    }

    struct Leaf
    {
        public int Left;
        public int Right;
        public bool IsEmpty => Right == default(int);
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

