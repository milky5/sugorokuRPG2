#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ○○のターンimageの表示を管理するクラス
/// </summary>
public class WhosTurn : MonoBehaviour
{
    [SerializeField] GameObject whosTurn;
    [SerializeField] Text text;
    [SerializeField] float activeTime;

    /// <summary>
    /// ○○のターンimageを表示し非表示にするコルーチン
    /// </summary>
    /// <param name="activePlayer">アクティブプレイヤ</param>
    /// <returns></returns>
    public IEnumerator ShowWhosTurn(Player activePlayer)
    {
        whosTurn.SetActive(true);
        text.text = $"{activePlayer.charactorName}の番！";
        yield return new WaitForSeconds(activeTime);
        whosTurn.SetActive(false);
    }
}
