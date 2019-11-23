///Title : WriteLine(Multi Line)
///Shortcut : cwl
///Description : 複数行に出力
///Author : keymoon

using System;

#if !DECLARATIONS
//コレクション
int[] collection;
#endif

Console.WriteLine(string.Join("\n", collection));