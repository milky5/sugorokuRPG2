using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatusCalc
{
    public static (int, int) StatusCalclator(int level,int syuzokuchi)
    {
        var HP = syuzokuchi * 2.0f * (level / 100.0f) + (10.0f + level);
        var hp = (int)HP;
        var ABCDS = syuzokuchi * 2.0f * (level / 100.0f) + 5.0f;
        var abcds = (int)ABCDS;
        return (hp, abcds);
    }
}
