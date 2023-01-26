using System;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

// HEADER
// title: SuccientBitVector
// shortcut: sucbv
// description: 簡潔ビットベクトル
// author: keymoon

// BODY
class BitVector
{
    const int BITBLOCK_LENGTH = 32;
    const int BITBLOCK_LENGTH_BITS = 5;

    const int LARGEBLOCK_LENGTH = 256;
    const int LARGEBLOCK_LENGTH_BITS = 8;

    const int BLOCK_PER_LARGEBLOCK = 8;
    const int BLOCK_PER_LARGEBLOCK_BITS = 3;

    public readonly int Length;
    uint[] bits;
    byte[] count;
    int[] largeCount;
    int count0;
    int count1;

    public BitVector(uint[] bits) : this(bits, bits.Length * BITBLOCK_LENGTH) { }
    public BitVector(bool[] bits) : this(BoolsToUInts(bits), bits.Length) { }
    private BitVector(uint[] bits, int length)
    {
        Length = length;
        this.bits = bits;
        count = new byte[bits.Length];
        largeCount = new int[(bits.Length + BLOCK_PER_LARGEBLOCK - 1) >> BLOCK_PER_LARGEBLOCK_BITS];
        byte sum = 0;
        for (int i = 0; i < bits.Length - 1; i++)
        {
            var popcnt = PopCount(bits[i]);
            if (((i + 1) & (BLOCK_PER_LARGEBLOCK - 1)) == 0)
            {
                int ind = (i + 1) >> BLOCK_PER_LARGEBLOCK_BITS;
                largeCount[ind] = largeCount[ind - 1] + sum + popcnt;
                sum = 0;
            }
            else
            {
                sum += popcnt;
                count[i + 1] = sum;
            }
            count0 += BITBLOCK_LENGTH - popcnt;
            count1 += popcnt;
        }
        var lastpopcnt = PopCount(bits[bits.Length - 1]);
        count0 += BITBLOCK_LENGTH - lastpopcnt;
        count1 += lastpopcnt;
    }
    public bool this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Access(index); }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Access(int index) => (bits[index >> BITBLOCK_LENGTH_BITS] & (1U << index)) != 0;
    /// <summary>[0,index)のkindの個数</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Rank(int index, bool kind) => kind ? Rank(index) : index - Rank(index);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Rank(int index)
    {
        int bitblockind = index >> BITBLOCK_LENGTH_BITS;
        return largeCount[bitblockind >> BLOCK_PER_LARGEBLOCK_BITS] + count[bitblockind] + PopCount(bits[bitblockind] & ((1U << index) - 1));
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Select(int index, bool kind) => kind ? Select1(index) : Select0(index);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Select0(int index)
    {
        if (index >= count0) return Length;
        int ok = 0;
        int ng = largeCount.Length;
        while (ng - ok > 1)
        {
            int mid = (ng + ok) >> 1;
            if (((mid << LARGEBLOCK_LENGTH_BITS) - largeCount[mid]) <= index) ok = mid;
            else ng = mid;
        }
        int bitind;
        int remain = index - ((ok << LARGEBLOCK_LENGTH_BITS) - largeCount[ok]);
        int offset = ok << BLOCK_PER_LARGEBLOCK_BITS;
        for (bitind = Math.Min(BLOCK_PER_LARGEBLOCK, count.Length - offset) - 1; bitind >= 1; bitind--) if (((bitind << BITBLOCK_LENGTH_BITS) - count[offset + bitind]) <= remain) break;
        return (ok << LARGEBLOCK_LENGTH_BITS) + (bitind << BITBLOCK_LENGTH_BITS) + Select(~bits[offset + bitind], (uint)(remain - (bitind * BITBLOCK_LENGTH - count[offset + bitind])));
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Select1(int index)
    {
        if (index >= count1) return Length;
        int ok = 0;
        int ng = largeCount.Length;
        while (ng - ok > 1)
        {
            int mid = (ng + ok) >> 1;
            if (largeCount[mid] <= index) ok = mid;
            else ng = mid;
        }
        int bitind;
        int remain = index - largeCount[ok];
        int offset = ok << BLOCK_PER_LARGEBLOCK_BITS;
        for (bitind = Math.Min(BLOCK_PER_LARGEBLOCK, count.Length - offset) - 1; bitind >= 1; bitind--) if (count[offset + bitind] <= remain) break;
        return (ok << LARGEBLOCK_LENGTH_BITS) + (bitind << BITBLOCK_LENGTH_BITS) + Select(bits[offset + bitind], (uint)(remain - count[offset + bitind]));
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint[] BoolsToUInts(bool[] bits)
    {
        var ulongbits = new uint[(bits.Length + BITBLOCK_LENGTH) >> BITBLOCK_LENGTH_BITS];
        for (int i = 0; i < ulongbits.Length; i++)
        {
            int offset = i * BITBLOCK_LENGTH;
            int max = Math.Min(BITBLOCK_LENGTH, bits.Length - offset);
            for (int j = 0; j < max; j++) if (bits[offset + j]) ulongbits[i] |= (1U << j);
        }
        return ulongbits;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte Select(uint n, uint rank)
    {
        uint a = (n & 0x55555555u) + ((n >> 1) & 0x55555555u);
        uint b = (a & 0x33333333u) + ((a >> 2) & 0x33333333u);
        uint c = (b & 0x0f0f0f0fu) + ((b >> 4) & 0x0f0f0f0fu);
        uint t = (c & 0xffu) + ((c >> 8) & 0xffu);
        byte s = 0;
        if (rank >= t) { s += 16; rank -= t; }
        t = (c >> s) & 0xf;
        if (rank >= t) { s += 8; rank -= t; }
        t = (b >> s) & 0x7;
        if (rank >= t) { s += 4; rank -= t; }
        t = (a >> s) & 0x3;
        if (rank >= t) { s += 2; rank -= t; }
        t = (n >> s) & 0x1;
        if (rank >= t) s++;
        return s;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte PopCount(uint n)
    {
        n -= ((n >> 1) & 0x55555555U);
        n = (n & 0x33333333U) + ((n >> 2) & 0x33333333U);
        return (byte)(((n + (n >> 4) & 0xF0F0F0FU) * 0x1010101U) >> 24);
    }
}
