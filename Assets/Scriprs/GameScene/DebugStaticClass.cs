using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugStaticClass 
{
    static string[] names;

    public static void TakeDate()
    {
        names = new string[] { "一郎", "次郎", "三郎", "四郎" };
    }

    public static string[] GiveData()
    {
        TakeDate();
        return names;
    }
}
