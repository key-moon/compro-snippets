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


# :warning: src/DataStructure/UnionFind/PotentializedUnionFind.csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#657c57e2fafbaee71dc36bfd3721bb15">src/DataStructure/UnionFind</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/DataStructure/UnionFind/PotentializedUnionFind.csx">View this file on GitHub</a>
    - Last commit date: 2019-10-06 03:51:14+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : PotentializedUnionFind
///Shortcut : puf
///Description : ポテンシャル付き素集合データ構造
///Author : keymoon

using System;
using System.Linq;
using System.Collections.Generic;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

class PotentializedUnionFind<T> where T : IEquatable<T>
{
    public int Size { get; private set; }
    public int GroupCount { get; private set; }
    public IEnumerable<int> AllRepresents => Parent.Where((x, y) => x == y);
    int[] Sizes;
    int[] Parent;
    T[] Value;
    Func<T, T, T> Operate;
    Func<T, T> Inverse;
    T Identity;

    public PotentializedUnionFind(int count, Func<T, T, T> operate, Func<T, T> inverse, T identity)
    {
        Size = count;
        GroupCount = count;
        Parent = new int[count];
        Sizes = new int[count];
        Value = new T[count];
        for (int i = 0; i < count; i++) { Sizes[Parent[i] = i] = 1; Value[i] = identity; }
        Operate = operate;
        Inverse = inverse;
        Identity = identity;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryUnite(int x, int y, T distance)
    {
        T xd, yd;
        int xp = Find(x, out xd);
        int yp = Find(y, out yd);

        if (yp == xp) return Operate(distance, yd).Equals(xd);

        GroupCount--;
        if (Sizes[xp] < Sizes[yp])
        {
            Value[xp] = Operate(Operate(Inverse(xd), distance), yd);
            Parent[xp] = yp;
            Sizes[yp] += Sizes[xp];
        }
        else
        {
            Value[yp] = Operate(Operate(Inverse(yd), Inverse(distance)), xd);
            Parent[yp] = xp;
            Sizes[xp] += Sizes[yp];
        }
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetSize(int x) => Sizes[Find(x)];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T GetPotential(int x, int y)
    {
        T xd, yd;
        int xp = Find(x, out xd);
        int yp = Find(y, out yd);
        if (yp == xp) return Operate(Inverse(xd), yd);
        else return Identity;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        while (x != Parent[x]) { Value[x] = Operate(Value[x], Value[Parent[x]]); Parent[x] = Parent[Parent[x]]; x = Parent[x]; }
        return x;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int Find(int x, out T potential)
    {
        potential = Identity;
        while (x != Parent[x])
        {
            Value[x] = Operate(Value[x], Value[Parent[x]]);
            Parent[x] = Parent[Parent[x]];
            potential = Operate(potential, Value[x]);
            x = Parent[x];
        }
        return x;
    }
}
```
{% endraw %}

<a id="bundled"></a>
{% raw %}
```cpp
Traceback (most recent call last):
  File "/opt/hostedtoolcache/Python/3.8.1/x64/lib/python3.8/site-packages/onlinejudge_verify/docs.py", line 347, in write_contents
    bundled_code = language.bundle(self.file_class.file_path, basedir=self.cpp_source_path)
  File "/opt/hostedtoolcache/Python/3.8.1/x64/lib/python3.8/site-packages/onlinejudge_verify/languages/csharpscript.py", line 108, in bundle
    raise NotImplementedError
NotImplementedError

```
{% endraw %}

<a href="../../../../index.html">Back to top page</a>

