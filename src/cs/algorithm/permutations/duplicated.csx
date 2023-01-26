using System;
using System.Collections.Generic;

// HEADER
// title: Permutations(duplicated elements)
// shortcut: permsd
// description: 重複あり配列要素の並び替えを生成
// author: keymoon

// BODY
static IEnumerable<T[]> Permutations<T>(T[] array) where T : IComparable<T>
{
    int index = 0;
    yield return array;
    while (true)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            if (array[i - 1].CompareTo(array[i]) >= 0) continue;
            int j = Array.FindLastIndex(array, x => array[i - 1].CompareTo(x) < 0);
            T tmp = array[i - 1]; array[i - 1] = array[j]; array[j] = tmp;
            Array.Reverse(array, i, array.Length - i);
            yield return array;
            goto end;
        }
        Array.Reverse(array, index, array.Length);
        yield break;
    end:;
    }
}
