///Title : Permutations(non-duplicated elements)
///Shortcut : permsnd
///Description : 重複なし配列要素の並び替えを生成(Johnson–Trotter algorithm)
///Author : keymoon

using System.Collections.Generic;

static IEnumerable<T[]> Permutations<T>(T[] array)
{
    long total = 1;
    for (int i = 2; i < array.Length; i++) total *= i;
    for (total >>= 1; total >= 1; total -= 1)
    {
        for (int j = 0; j < array.Length - 1; j++)  { yield return array;  Swap(ref array[j], ref array[j + 1]); }
        yield return array; Swap(ref array[0], ref array[1]);
        for (int j = array.Length - 2; j >= 0; j--)  { yield return array; Swap(ref array[j], ref array[j + 1]); }
        yield return array; Swap(ref array[array.Length - 1], ref array[array.Length - 2]);
    }
}
static void Swap<T>(ref T a, ref T b) { T tmp = a; a = b; b = tmp; }
