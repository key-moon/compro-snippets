///Title : ReadLineLong
///Shortcut : rllong
///Description : 複数行単一データの読み込み(long型)
///Author : keymoon

using System;
using System.Linq;

#if !DECLARATIONS
//行数
int @n;
#endif


Enumerable.Repeat(0, @n).Select(_ => long.Parse(Console.ReadLine())).ToArray()