﻿///<Title>ReadLineSplitString</Title>
///<Shortcut>rlsstr</Shortcut>
///<Description>複数行複数データの読み込み(string型)</Description>
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


Enumerable.Repeat(0, height).Select(_ => Console.ReadLine().Split()).ToArray()