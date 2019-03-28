#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhosTurn : MonoBehaviour
{
    [SerializeField] GameObject whosTurn;
    [SerializeField] Text text;
    [SerializeField] float activeTime;

    //「○○のターン！」というイメージを表示し非表示にする
    public IEnumerator ShowWhosTurn(Player activePlayer)
    {
        //呼出元に　StartCoroutine(ShowWhosTurn());
        whosTurn.SetActive(true);
        text.text = $"{activePlayer.charactorName}の番！";
        yield return new WaitForSeconds(activeTime);
        whosTurn.SetActive(false);
    }
}
