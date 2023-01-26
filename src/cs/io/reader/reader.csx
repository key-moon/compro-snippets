using System;
using System.IO;
using static Reader;

// HEADER
// title: Reader Core
// shortcut: reader
// description: 各種Readerを格納するためのclass
// author: keymoon

// BODY
static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }
}
