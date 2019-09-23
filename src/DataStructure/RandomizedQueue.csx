///Title : Randomized Queue
///Shortcut : rqueue</Shortcut>
///Description : ランダムに要素をPopするQueue
///Author : keymoon

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

class RandomizedQueue<T>
{
    int front;
    T[] datas;
    Random RNG = new Random();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public RandomizedQueue(int defaultSize = 512) { datas = new T[defaultSize]; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Push(T data)
    {
        if (front >= datas.Length) Extend(datas.Length << 1);
        datas[front++] = data;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Pop()
    {
        ValidateNonEmpty();
        var index = RNG.Next() % front;
        var data = datas[index];
        datas[index] = datas[front--];
        return data;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Extend(int newSize)
    {
        T[] newDatas = new T[newSize];
        datas.CopyTo(newDatas, 0);
        datas = newDatas;
    }
    private void ValidateNonEmpty() { if (front == 0) throw new Exception(); }
}