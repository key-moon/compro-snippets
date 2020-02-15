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


# :warning: src/Misc/Top2.csx

<a href="../../../index.html">Back to top page</a>

* category: <a href="../../../index.html#eec951bcc9ce32cbbb047da637079723">src/Misc</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/Misc/Top2.csx">View this file on GitHub</a>
    - Last commit date: 2020-01-06 02:45:37+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : Top2
///Shortcut : Top2
///Description : 最上位2つの要素を返す
///Author : keymoon

using System;

struct Top2<T> where T : IComparable<T>
{
    public T First;
    public T Second;
    public Top2(T first, T second) { First = first; Second = second; }
    public static Top2<T> Merge(Top2<T> a, Top2<T> b)
    {
        if (a.First.CompareTo(b.First) > 0)
            return new Top2<T>(a.First, a.Second.CompareTo(b.First) > 0 ? a.Second : b.First);
        else
            return new Top2<T>(b.First, b.Second.CompareTo(a.First) > 0 ? b.Second : a.First);
    }
    public static Top2<T> Merge(Top2<T> a, T b)
    {
        if (a.Second.CompareTo(b) > 0) return a;
        if (a.First.CompareTo(b) > 0) return new Top2<T>(a.First, b);
        return new Top2<T>(b, a.First);
    }
    public static Top2<T> operator |(Top2<T> a, Top2<T> b) => Merge(a, b);
    public static Top2<T> operator |(Top2<T> a, T b) => Merge(a, b);
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

<a href="../../../index.html">Back to top page</a>

