﻿using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

// HEADER
// title: Matrix
// shortcut: matrix
// description: 行列
// author: keymoon

// DECLARATIONS
// _T: ModInt

// BODY
class Matrix
{
    public readonly int Height;
    public readonly int Width;
    _T[] data;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Matrix(int height, int width)
    {
        data = new _T[height * width];
        Height = height;
        Width = width;
    }
    public _T this[int i, int j]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return data[i * Width + j]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { data[i * Width + j] = value; }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix Add(Matrix a, Matrix b)
    {
        var res = new Matrix(a.Height, a.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < a.Width; j++) res[i, j] = a[i, j] + b[i, j];
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix Sub(Matrix a, Matrix b)
    {
        var res = new Matrix(a.Height, a.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < a.Width; j++) res[i, j] = a[i, j] - b[i, j];
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix Mul(Matrix a, Matrix b)
    {
        var res = new Matrix(a.Height, b.Width);
        for (int i = 0; i < a.Height; i++) for (int j = 0; j < b.Width; j++) for (int k = 0; k < a.Width; k++) res[i, j] += a[i, k] * b[k, j];
        return res;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix operator +(Matrix a, Matrix b) => Add(a, b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix operator -(Matrix a, Matrix b) => Sub(a, b);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix operator *(Matrix a, Matrix b) => Mul(a, b);
}
