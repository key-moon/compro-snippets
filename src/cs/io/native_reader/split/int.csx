using System;
using System.Linq;

// HEADER
// title: ReadSplitInt
// shortcut: rsint
// description: 単一行複数データの読み込み(int型)
// author: keymoon

// BODY
Console.ReadLine().Split().Select(int.Parse).ToArray()
