///<Title>ReadLineLong</Title>
///<Shortcut>rllong</Shortcut>
///<Description>複数行単一データの読み込み(long型)</Description>
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


Enumerable.Repeat(0, height).Select(_ => long.Parse(Console.ReadLine())).ToArray()