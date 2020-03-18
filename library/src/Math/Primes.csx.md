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


# :warning: src/Math/Primes.csx

<a href="../../../index.html">Back to top page</a>

* category: <a href="../../../index.html#64f6d80a21cfb0c7e1026d02dde4f7fa">src/Math</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/Math/Primes.csx">View this file on GitHub</a>
    - Last commit date: 2020-01-25 09:20:40+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : primes
///Shortcut : Primes
///Description : 素数を列挙する
///Author : keymoon

using System;
using System.Collections.Generic;

#if !DECLARATIONS

#endif

public static IEnumerable<int> Primes(int n)
{
    if (n < 2) yield break;
    yield return 2;
    ulong[] bitArray = new ulong[(n + 1) / 2 / 64 + 1];

    int[] smallPrimes = { 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61 };
    foreach (var prime in smallPrimes)
    {
        if (n < prime) yield break;
        yield return prime;

        ulong[] mask = new ulong[prime];
        for (int j = (prime - 3) >> 1; j < (prime << 6); j += prime)
            mask[j >> 6] |= 1UL << j;

        int maskInd = 0;
        for (int i = 0; i < bitArray.Length; i++)
        {
            bitArray[i] |= mask[maskInd];
            if (++maskInd >= prime) maskInd = 0;
        }
    }

    int[] deBruijnIndex = { 0, 1, 59, 2, 60, 40, 54, 3, 61, 32, 49, 41, 55, 19, 35, 4, 62, 52, 30, 33, 50, 12, 14, 42, 56, 16, 27, 20, 36, 23, 44, 5, 63, 58, 39, 53, 31, 48, 18, 34, 51, 29, 11, 13, 15, 26, 22, 43, 57, 38, 47, 17, 28, 10, 25, 21, 37, 46, 9, 24, 45, 8, 7, 6 };
    int maxInd = n / 2;
    for (int i = 0; i < bitArray.Length; i++)
    {
        for (ulong bit = ~bitArray[i]; bit != 0; bit &= bit - 1)
        {
            int index = i << 6 | deBruijnIndex[((bit & (~bit + 1)) * 0x03F566ED27179461UL) >> 58];
            int prime = (index << 1) + 3;
            if (n < prime) yield break;
            yield return prime;
            for (int ind = index; ind <= maxInd; ind += prime)
                bitArray[ind >> 6] |= 1UL << ind;
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
  File "/opt/hostedtoolcache/Python/3.8.2/x64/lib/python3.8/site-packages/onlinejudge_verify/languages/csharpscript.py", line 108, in bundle
    raise NotImplementedError
NotImplementedError

```
{% endraw %}

<a href="../../../index.html">Back to top page</a>

