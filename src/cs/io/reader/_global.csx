using System;
using System.IO;

const int BUF_SIZE = 1 << 12;
static Stream Stream = Console.OpenStandardInput();
static byte[] Buffer = new byte[BUF_SIZE];
static int ptr = 0;
static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }
