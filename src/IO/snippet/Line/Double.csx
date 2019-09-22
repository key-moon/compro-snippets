///<Title>ReadLineDouble</Title>
///<Shortcut>rldouble</Shortcut>
///<Description>複数行単一データの読み込み(double型)</Description>
///<Author>keymoon</Author>

using System;
using System.Linq;

#if !DECLARATIONS
int height;
/*
//行数
height = h
*/
#endif


Enumerable.Repeat(0, height).Select(_ => double.Parse(Console.ReadLine())).ToArray()