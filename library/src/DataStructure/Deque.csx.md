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


# :warning: src/DataStructure/Deque.csx

<a href="../../../index.html">Back to top page</a>

* category: <a href="../../../index.html#e73c6b5872115ad0f2896f8e8476ef39">src/DataStructure</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/DataStructure/Deque.csx">View this file on GitHub</a>
    - Last commit date: 2019-09-23 15:24:39+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : Double-Ended Queue
///Shortcut : deque
///Description : 両端Queue
///Author : keymoon

using System;
using System.Collections;
using System.Collections.Generic;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

class Deque<T> : IEnumerable<T>
{
    public int Count;
    T[] data; int FrontInd, BackInd;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Deque() { data = new T[1 << 16]; FrontInd = 0; BackInd = data.Length - 1; Count = 0; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Deque(T[] elem)
    {
        int s = elem.Length; s |= s >> 1; s |= s >> 2; s |= s >> 4; s |= s >> 8; s |= s >> 16;
        data = new T[++s]; elem.CopyTo(data, 0);
        FrontInd = 0; BackInd = elem.Length - 1; Count = elem.Length;
    }

    public T Front
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNoEmpty(); return data[FrontInd]; }
    }
    public T Back
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { ValidateNoEmpty(); return data[BackInd]; }
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { if (index >= Count) throw new Exception(); return data[FrontInd + index & data.Length - 1]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { if (index >= Count) throw new Exception(); data[FrontInd + index & data.Length - 1] = value; }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PushFront(T elem) { if (Count == data.Length) Extend(data.Length << 1); Count++; data[FrontInd = (FrontInd - 1) & data.Length - 1] = elem; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T PopFront() { var res = Front; FrontInd = (FrontInd + 1) & data.Length - 1; Count--; return res; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void PushBack(T elem) { if (Count == data.Length) Extend(data.Length << 1); Count++; data[BackInd = (BackInd + 1) & data.Length - 1] = elem; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T PopBack() { var res = Back; BackInd = (BackInd - 1) & data.Length - 1; Count--; return res; }
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
    private void ValidateNoEmpty() { if (Count == 0) throw new Exception(); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerator<T> GetEnumerator() { for (int i = FrontInd; i != BackInd; i = i + 1 & data.Length - 1) yield return data[i]; yield return data[BackInd]; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
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

