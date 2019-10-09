#load "../SuccientBitVector.csx"

using System;
using System.Linq;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public int Length { get; private set; }
public int Max { get; private set; }
int Depth;
BitVector[] BitVectors;
int[] ZeroCount;
int[] BlockStartIndex;

public void Build(int[] elem, int max)
{
    Max = max;
    Length = elem.Length;
    Depth = MSBPos(max) + 1;
    BitVectors = new BitVector[Depth];
    ZeroCount = new int[Depth];
    BlockStartIndex = new int[max + 1];

    for (int i = 0; i < elem.Length; i++)
        for (int j = 0; j < Depth; j++)
            if ((elem[i] & (1 << j)) == 0) ZeroCount[j]++;

    elem = elem.ToArray();
    bool[] bits = new bool[Length + 1];
    int[] buf = new int[Length];
    for (int i = Depth - 1; i >= 0; i--)
    {
        int[] newElem = buf;
        int mask = 1 << i;
        int index0 = 0;
        int index1 = ZeroCount[i];
        for (int j = 0; j < elem.Length;)
        {
            if ((elem[j] & mask) == 0)
            {
                bits[j] = false;
                newElem[index0++] = elem[j++];
            }
            else
            {
                bits[j] = true;
                newElem[index1++] = elem[j++];
            }
        }
        BitVectors[i] = new BitVector(bits);
        buf = elem;
        elem = newElem;
    }
    int ptr;
    int[] reversedSequence = new int[] { 0 };
    for (int i = 1; i <= Depth; i++)
    {
        var newReversedSequence = new int[1 << i];
        var mask = 1 << (i - 1);
        ptr = 0;
        for (int j = 0; j < reversedSequence.Length; j++)
        {
            newReversedSequence[ptr++] = reversedSequence[j];
            newReversedSequence[ptr++] = reversedSequence[j] | mask;
        }
        reversedSequence = newReversedSequence;
    }
    ptr = 0;
    for (int i = 0; i < reversedSequence.Length; i++)
    {
        BlockStartIndex[reversedSequence[i]] = ptr;
        while (ptr < elem.Length && elem[ptr] == reversedSequence[i]) ptr++;
    }
}

[MethodImpl(MethodImplOptions.AggressiveInlining)]
static int MSBPos(int n)
{
    int res = 0;
    if (0 != (n >> (res | 16))) res |= 16;
    if (0 != (n >> (res | 8))) res |= 8;
    if (0 != (n >> (res | 4))) res |= 4;
    if (0 != (n >> (res | 2))) res |= 2;
    if (0 != (n >> (res | 1))) res |= 1;
    return res;
}