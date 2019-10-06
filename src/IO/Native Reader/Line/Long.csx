///Title : ReadLineLong
///Shortcut : rllong
///Description : 複数行単一データの読み込み(long型)
///Author : keymoon

using System;
using System.Linq;

#if !DECLARATIONS
/*
//行数
height = h
*/
int height;
#endif


Enumerable.Repeat(0, height).Select(_ => long.Parse(Console.ReadLine())).ToArray()