///Title : ReadLineString
///Shortcut : rlstr</Shortcut>
///Description : 複数行単一データの読み込み(string型)
///Author : keymoon

using System;
using System.Linq;

#if !DECLARATIONS
int height;
/*
//行数
height = h
*/
#endif


Enumerable.Repeat(0, height).Select(_ => Console.ReadLine()).ToArray()