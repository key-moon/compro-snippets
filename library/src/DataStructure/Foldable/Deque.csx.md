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


# :warning: src/DataStructure/Foldable/Deque.csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#8dd6b2455be32b8e4976b52f46dd6b9c">src/DataStructure/Foldable</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/DataStructure/Foldable/Deque.csx">View this file on GitHub</a>
    - Last commit date: 2019-12-27 11:07:00+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : FoldableDeque
///Shortcut : fdeque
///Description : Sliding-Window Aggregationが可能なQueue
///Author : keymoon

using System;
using System.Collections.Generic;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

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

```
{% endraw %}

<a id="bundled"></a>
{% raw %}
```cpp
Traceback (most recent call last):
  File "/opt/hostedtoolcache/Python/3.8.2/x64/lib/python3.8/site-packages/onlinejudge_verify/docs.py", line 340, in write_contents
    bundled_code = language.bundle(self.file_class.file_path, basedir=pathlib.Path.cwd())
  File "/opt/hostedtoolcache/Python/3.8.2/x64/lib/python3.8/site-packages/onlinejudge_verify/languages/csharpscript.py", line 108, in bundle
    raise NotImplementedError
NotImplementedError

```
{% endraw %}

<a href="../../../../index.html">Back to top page</a>

