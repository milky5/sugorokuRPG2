using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticClassTest 
{
    static string[] names;

    public static void TakeData(List<string> names)
    {
        StaticClassTest.names = names.ToArray();
    }

    public static string[] GiveData()
    {
        return names;
    }
}
