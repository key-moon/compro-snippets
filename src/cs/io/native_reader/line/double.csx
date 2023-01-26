using System;
using System.Linq;

// HEADER
// title: ReadLineDouble
// shortcut: rldouble
// description: 複数行単一データの読み込み(double型)
// author: keymoon

// DECLARATIONS
// _n: n

// BODY
Enumerable.Repeat(0, _n).Select(_ => double.Parse(Console.ReadLine())).ToArray()
