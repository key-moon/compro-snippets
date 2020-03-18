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


# :warning: src/DataStructure/Foldable/Queue.csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#8dd6b2455be32b8e4976b52f46dd6b9c">src/DataStructure/Foldable</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/DataStructure/Foldable/Queue.csx">View this file on GitHub</a>
    - Last commit date: 2019-11-26 23:46:51+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : FoldableQueue
///Shortcut : fqueue
///Description : 要素のfoldが可能なQueue
///Author : keymoon

using System;
using System.Collections.Generic;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

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

