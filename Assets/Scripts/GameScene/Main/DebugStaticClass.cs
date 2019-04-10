using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デバッグ用のクラス
/// </summary>
public static class DebugStaticClass 
{
    static string[] names;

    /// <summary>
    /// プレイヤの名前を代入するメソッド
    /// </summary>
    public static void TakeDate()
    {
        //names = new string[] { "一郎", "次郎", "三郎", "四郎" };
        names = new string[] { "いちか", "にの", "みく" };
    }

    /// <summary>
    /// プレイヤの名前を取得するためのメソッド
    /// </summary>
    /// <returns>プレイヤの名前が格納された文字列配列</returns>
    public static string[] GiveData()
    {
        TakeDate();
        return names;
    }
}
