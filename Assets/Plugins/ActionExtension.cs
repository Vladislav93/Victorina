using System;

public static class ActionExtension
{

    public static void Raise(this Action handler)
    {
        if (handler != null)
            handler();
    }

    public static void Raise<T>(this Action<T> handler, T arg)
    {
        if (handler != null)
            handler(arg);
    }

    public static void Raise<T1, T2>(this Action<T1, T2> handler, T1 arg1, T2 arg2)
    {
        if (handler != null)
            handler(arg1, arg2);
    }

    public static void Raise<T1, T2, T3>(this Action<T1, T2, T3> handler, T1 arg1, T2 arg2, T3 arg3)
    {
        if (handler != null)
            handler(arg1, arg2, arg3);
    }

    public static void Raise<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> handler, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        if (handler != null)
            handler(arg1, arg2, arg3, arg4);
    }

}