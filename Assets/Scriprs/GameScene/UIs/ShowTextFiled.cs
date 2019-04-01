#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Textに文字を表示するメソッドを定義するクラス
/// </summary>
public class ShowTextFiled : MonoBehaviour
{
    [SerializeField] Text text;
    bool isCoroutineEnd;

    /// <summary>
    /// Textコンポーネントに1文字ずつ文字を表示するコルーチン
    /// </summary>
    /// <param name="strs">表示したい文字列</param>
    /// <param name="callback">コールバック</param>
    /// <returns></returns>
    public IEnumerator ShowStorys(string[] strs ,UnityAction<bool> callback)
    {
        //現在のindex
        int row = 0;

        //文字列を一行ずつ表示
        foreach (var str in strs)
        {
            if (row == 0)
            {
                text.text = null;
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
                text.text = null;
            }

            for (int i = 0; i < str.Length; i++)
            {
                //押されっぱなしなら1フレーム毎に1文字表示
                if (Input.GetMouseButton(0))
                {
                    text.text += str[i];
                    yield return null;
                }
                //0.1秒ごとに1文字表示
                else
                {
                    text.text += str[i];
                    yield return new WaitForSeconds(0.1f);
                }
            }
            //1行表示し終わったら改行させる
            text.text += "\n";
            //1行表示し終わったのでindexを更新
            row++;
        }
        //全ての文字列表示が終わったら、読み終わりを待つ
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        //読み終わったらTextBoxを空にしておく
        text.text = null;
        //終わったことを伝えるため、コールバックを呼び出す
        callback(true);
    }

    /// <summary>
    /// 任意のTextコンポーネントに1文字ずつ文字を表示するコルーチン
    /// </summary>
    /// <param name="strs">表示したい文字列</param>
    /// <param name="callback">コールバック</param>
    /// <param name="selectedText">任意のTextコンポーネント</param>
    /// <returns></returns>
    public IEnumerator ShowStorys(string[] strs, UnityAction<bool> callback,Text selectedText)
    {
        //既定のtextを避難させる
        Text tempText = this.text;
        //フィールドのTextを引数のものと置き換える
        this.text = selectedText;
        //ShowStorysに引数と終わったかどうかを判定するメソッドを渡す
        StartCoroutine(ShowStorys(strs, CoroutineEnd));

        //ShowStoryが終わるまで待つ
        yield return new WaitUntil(() => isCoroutineEnd);
        //変数の初期化
        isCoroutineEnd = false;
        //フィールドのTextを既定のものに戻す
        this.text = tempText;
        //呼出元に終わったことを伝えるため、コールバックを呼び出す
        callback(true);
    }

    /// <summary>
    /// コルーチンの終了を判定するメソッド
    /// </summary>
    /// <param name="ended">コルーチンが終了したかどうか</param>
    void CoroutineEnd(bool ended)
    {
        isCoroutineEnd = ended;
    }
}
