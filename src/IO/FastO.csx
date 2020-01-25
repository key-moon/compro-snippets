///Title : DisableFlush
///Shortcut : fasto
///Description : Flushを無効化して高速化する
///Author : keymoon

using System;
using System.IO;

Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
