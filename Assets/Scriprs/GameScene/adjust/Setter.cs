using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステータス上昇効果を反映するメソッドを保持するデリゲート
/// </summary>
/// <param name="value">プロパティの値</param>
/// <returns>補正後のプロパティの値</returns>
public delegate int PropatySetter(int value);

/// <summary>
/// ステータス上昇効果を反映するメソッドを定義するクラス
/// </summary>
public class Setter 
{
    /// <summary>
    /// ステータスをそのまま反映するメソッド
    /// </summary>
    /// <param name="value">プロパティの値</param>
    /// <returns>補正後のプロパティの値</returns>
    public int SetSetter(int value)
    {
        return value;
    }

    /// <summary>
    /// ステータス上昇効果を反映するメソッド
    /// </summary>
    /// <param name="value">プロパティの値</param>
    /// <returns>補正後のプロパティの値</returns>
    public int SetStrong(int value)
    {
        float temp = value;
        temp *= 1.1f;
        return (int)temp;
    }
}
