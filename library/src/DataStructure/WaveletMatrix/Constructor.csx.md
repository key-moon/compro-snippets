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


# :warning: src/DataStructure/WaveletMatrix/Constructor.csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#3d0ac36297e222061e32f0418ff902b1">src/DataStructure/WaveletMatrix</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/DataStructure/WaveletMatrix/Constructor.csx">View this file on GitHub</a>
    - Last commit date: 2019-10-09 17:40:05+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿#load "../SuccientBitVector.csx"

///Title : Wavelet Matrix
///Shortcut : wm
///Description : Wavlet Matrixのコンストラクタ
///Author : keymoon

using System;
using System.Linq;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

class WaveletMatrix
{
    public int Length { get; private set; }
    public int Max { get; private set; }
    int Depth;
    BitVector[] BitVectors;
    int[] ZeroCount;
    int[] BlockStartIndex;

    public WaveletMatrix(int[] elem, int max)
    {
        Max = max;
        Length = elem.Length;
        Depth = MSBPos(max) + 1;
        BitVectors = new BitVector[Depth];
        ZeroCount = new int[Depth];
        BlockStartIndex = new int[max + 1];

        for (int i = 0; i < elem.Length; i++)
            for (int j = 0; j < Depth; j++)
                if ((elem[i] & (1 << j)) == 0) ZeroCount[j]++;

        elem = elem.ToArray();
        bool[] bits = new bool[Length + 1];
        int[] buf = new int[Length];
        for (int i = Depth - 1; i >= 0; i--)
        {
            int[] newElem = buf;
            int mask = 1 << i;
            int index0 = 0;
            int index1 = ZeroCount[i];
            for (int j = 0; j < elem.Length;)
            {
                if ((elem[j] & mask) == 0)
                {
                    bits[j] = false;
                    newElem[index0++] = elem[j++];
                }
                else
                {
                    bits[j] = true;
                    newElem[index1++] = elem[j++];
                }
            }
            BitVectors[i] = new BitVector(bits);
            buf = elem;
            elem = newElem;
        }
        int ptr;
        int[] reversedSequence = new int[] { 0 };
        for (int i = 1; i <= Depth; i++)
        {
            var newReversedSequence = new int[1 << i];
            var mask = 1 << (i - 1);
            ptr = 0;
            for (int j = 0; j < reversedSequence.Length; j++)
            {
                newReversedSequence[ptr++] = reversedSequence[j];
                newReversedSequence[ptr++] = reversedSequence[j] | mask;
            }
            reversedSequence = newReversedSequence;
        }
        ptr = 0;
        for (int i = 0; i < reversedSequence.Length; i++)
        {
            BlockStartIndex[reversedSequence[i]] = ptr;
            while (ptr < elem.Length && elem[ptr] == reversedSequence[i]) ptr++;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int MSBPos(int n)
    {
        int res = 0;
        if (0 != (n >> (res | 16))) res |= 16;
        if (0 != (n >> (res | 8))) res |= 8;
        if (0 != (n >> (res | 4))) res |= 4;
        if (0 != (n >> (res | 2))) res |= 2;
        if (0 != (n >> (res | 1))) res |= 1;
        return res;
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

