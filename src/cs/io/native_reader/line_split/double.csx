using System;
using System.Linq;

// HEADER
// title: ReadLineSplitDouble
// shortcut: rlsdouble
// description: 複数行複数データの読み込み(double型)
// author: keymoon

// DECLARATIONS
// _n: n

// BODY
Enumerable.Repeat(0, _n).Select(_ => Console.ReadLine().Split().Select(double.Parse).ToArray()).ToArray()
