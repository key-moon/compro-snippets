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


# :warning: src/Algorithm/Permutations/Duplicated.csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#c0d46748ab0ef9ac3af45875ffca8d20">src/Algorithm/Permutations</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/Algorithm/Permutations/Duplicated.csx">View this file on GitHub</a>
    - Last commit date: 2019-11-20 21:36:55+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : Permutations(duplicated elements)
///Shortcut : permsd
///Description : 重複あり配列要素の並び替えを生成
///Author : keymoon

using System;
using System.Collections.Generic;

static IEnumerable<T[]> Permutations<T>(T[] array) where T : IComparable<T>
{
    int index = 0;
    yield return array;
    while (true)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            if (array[i - 1].CompareTo(array[i]) >= 0) continue;
            int j = Array.FindLastIndex(array, x => array[i - 1].CompareTo(x) < 0);
            T tmp = array[i - 1]; array[i - 1] = array[j]; array[j] = tmp;
            Array.Reverse(array, i, array.Length - i);
            yield return array;
            goto end;
        }
        Array.Reverse(array, index, array.Length);
        yield break;
    end:;
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

