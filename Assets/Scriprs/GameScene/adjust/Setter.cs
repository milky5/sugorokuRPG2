using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate int PropatySetter(int value);

public class Setter 
{
    public int SetSetter(int value)
    {
        return value;
    }
    public int SetStrong(int value)
    {
        float temp = value;
        temp *= 1.1f;
        return (int)temp;
    }
}
