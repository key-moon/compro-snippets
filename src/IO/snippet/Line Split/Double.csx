///Title : ReadLineSplitDouble
///Shortcut : rlsdouble</Shortcut>
///Description : 複数行複数データの読み込み(double型)
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


Enumerable.Repeat(0, height).Select(_ => Console.ReadLine().Split().Select(double.Parse).ToArray()).ToArray()