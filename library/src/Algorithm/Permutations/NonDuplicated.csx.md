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


# :warning: src/Algorithm/Permutations/NonDuplicated.csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#c0d46748ab0ef9ac3af45875ffca8d20">src/Algorithm/Permutations</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/Algorithm/Permutations/NonDuplicated.csx">View this file on GitHub</a>
    - Last commit date: 2019-11-20 21:36:55+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : Permutations(non-duplicated elements)
///Shortcut : permsnd
///Description : 重複なし配列要素の並び替えを生成(Johnson–Trotter algorithm)
///Author : keymoon

using System.Collections.Generic;

static IEnumerable<T[]> Permutations<T>(T[] array)
{
    long total = 1;
    for (int i = 2; i < array.Length; i++) total *= i;
    for (total >>= 1; total >= 1; total -= 1)
    {
        for (int j = 0; j < array.Length - 1; j++)  { yield return array;  Swap(ref array[j], ref array[j + 1]); }
        yield return array; Swap(ref array[0], ref array[1]);
        for (int j = array.Length - 2; j >= 0; j--)  { yield return array; Swap(ref array[j], ref array[j + 1]); }
        yield return array; Swap(ref array[array.Length - 1], ref array[array.Length - 2]);
    }
}
static void Swap<T>(ref T a, ref T b) { T tmp = a; a = b; b = tmp; }

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

