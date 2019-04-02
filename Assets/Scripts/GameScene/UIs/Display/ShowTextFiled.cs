#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Textに文字を表示するメソッドを定義するクラス
/// </summary>
public static class ShowTextFiled
{
    /// <summary>
    /// Textコンポーネントに1文字ずつ文字を表示するコルーチン
    /// </summary>
    /// <param name="strs">表示したい文字列</param>
    /// <param name="selectedText">任意のTextコンポーネント</param>
    /// <param name="callback">コールバック</param>
    /// <returns></returns>
    public static IEnumerator ShowStorys(string[] strs, Text selectedText, UnityAction<bool> callback)
    {
        //現在のindex
        int row = 0;

        //文字列を一行ずつ表示
        foreach (var str in strs)
        {
            if (row == 0)
            {
                selectedText.text = null;
            }
            //3の倍数+1の要素だった場合はTextBoxからあふれてしまう
            if (row % 3 == 0 && row != 0)
            //if (row % 3 == 0)
            {
                //読み終わってクリックされるのを待つ
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                //下の行でGetMouseButtonを判定するが、
                //次フレームからいきなり早くなるのは嫌なので
                //GetMouseButtonUpを挟む
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                //行あふれしないようTextBoxを空にする
                selectedText.text = null;
            }

            for (int i = 0; i < str.Length; i++)
            {
                //押されっぱなしなら1フレーム毎に1文字表示
                if (Input.GetMouseButton(0))
                {
                    selectedText.text += str[i];
                    yield return null;
                }
                //0.1秒ごとに1文字表示
                else
                {
                    selectedText.text += str[i];
                    yield return new WaitForSeconds(0.1f);
                }
            }
            //1行表示し終わったら改行させる
            selectedText.text += "\n";
            //1行表示し終わったのでindexを更新
            row++;
        }
        //全ての文字列表示が終わったら、読み終わりを待つ
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        //読み終わったらTextBoxを空にしておく
        selectedText.text = null;
        //終わったことを伝えるため、コールバックを呼び出す
        callback(true);
    }
}
