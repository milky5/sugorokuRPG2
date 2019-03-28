using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRollable 
{
    int remainMass { get; set; }

    void Roll();
}
