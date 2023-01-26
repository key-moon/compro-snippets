using System;
using System.IO;

// HEADER
// title: DisableFlush
// shortcut: fasto
// description: Flushを無効化して高速化する
// author: keymoon

// BODY
Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
