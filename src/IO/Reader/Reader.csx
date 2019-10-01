///Title : Signed Integer Reader
///Shortcut : sreader
///Description : 符号付き整数を読み込む
///Author : keymoon

using System;
using System.IO;

static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = 0;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }
}