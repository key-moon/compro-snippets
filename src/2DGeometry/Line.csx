#load "FloatVector.csx"

///Title : Line2D
///Shortcut : line
///Description : 線分
///Author : keymoon

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

struct Line
{
    public Vector a;
    public Vector b;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Line(Vector a, Vector b) { this.a = a; this.b = b; }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector? Cross(Line a, Line b, bool allowOutOfRegion = true)
    {
        double delta = (a.b.x - a.a.x) * (b.b.y - b.a.y) - (a.b.y - a.a.y) * (b.b.x - b.a.x);
        if (delta == 0) return null;
        double ramda = ((b.b.y - b.a.y) * (b.b.x - a.a.x) - (b.b.x - b.a.x) * (b.b.y - a.a.y)) / delta;
        if (!allowOutOfRegion)
        {
            double mu = ((a.b.x - a.a.x) * (b.b.y - a.a.y) - (a.b.y - a.a.y) * (b.b.x - a.a.x)) / delta;
            if (mu < 0 || 1 < mu || ramda < 0 || 1 < ramda) return null;
        }
        return new Vector(a.a.x + ramda * (a.b.x - a.a.x), a.a.y + ramda * (a.b.y - a.a.y));
    }
    public override string ToString() => $"{a} {b}";
}