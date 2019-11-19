///Title : ReadLineDouble
///Shortcut : rldouble
///Description : 複数行単一データの読み込み(double型)
///Author : keymoon

using System;
using System.Linq;

#if !DECLARATIONS
//行数
int @n;
#endif


Enumerable.Repeat(0, @n).Select(_ => double.Parse(Console.ReadLine())).ToArray()