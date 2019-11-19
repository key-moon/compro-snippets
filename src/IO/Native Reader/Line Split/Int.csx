///Title : ReadLineSplitInt
///Shortcut : rlsint
///Description : 複数行複数データの読み込み(int型)
///Author : keymoon

using System;
using System.Linq;

#if !DECLARATIONS
//行数
int @n;
#endif


Enumerable.Repeat(0, @n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray()