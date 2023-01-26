using System;
using System.Linq;

// HEADER
// title: ReadSplitDouble
// shortcut: rsdouble
// description: 単一行複数データの読み込み(double型)
// author: keymoon

// BODY
Console.ReadLine().Split().Select(double.Parse).ToArray()
