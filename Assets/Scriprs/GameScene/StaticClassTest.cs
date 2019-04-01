using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PrepareシーンからGameシーンへ値を引き渡すためのクラス
/// </summary>
public static class StaticClassTest 
{
    static string[] names;

    /// <summary>
    /// プレイヤの名前を代入するリスト
    /// </summary>
    /// <param name="names">プレイヤの名前が格納された文字列配列</param>
    public static void TakeData(List<string> names)
    {
        StaticClassTest.names = names.ToArray();
    }

    /// <summary>
    /// プレイヤの名前を取得するためのメソッド
    /// </summary>
    /// <returns>プレイヤの名前が格納された文字列配列</returns>
    public static string[] GiveData()
    {
        return names;
    }
}
