///Title : ReadLineSplitDouble
///Shortcut : rlsdouble
///Description : 複数行複数データの読み込み(double型)
///Author : keymoon

using System;
using System.Linq;

#if !DECLARATIONS
//行数
int @n;
#endif


Enumerable.Repeat(0, @n).Select(_ => Console.ReadLine().Split().Select(double.Parse).ToArray()).ToArray()