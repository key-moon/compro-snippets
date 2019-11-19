///Title : ReadLineSplitString
///Shortcut : rlsstr
///Description : 複数行複数データの読み込み(string型)
///Author : keymoon

using System;
using System.Linq;

#if !DECLARATIONS
//行数
int @n;
#endif


Enumerable.Repeat(0, @n).Select(_ => Console.ReadLine().Split()).ToArray()