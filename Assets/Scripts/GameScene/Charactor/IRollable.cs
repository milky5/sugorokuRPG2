using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サイコロを振るためのインターフェイス
/// </summary>
public interface IRollable 
{
    int remainMass { get; set; }

    /// <summary>
    /// サイコロを振るためのメソッド
    /// </summary>
    void Roll();
}
