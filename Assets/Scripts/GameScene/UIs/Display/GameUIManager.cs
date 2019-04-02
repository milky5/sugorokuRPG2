#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

/// <summary>
/// プレイヤーが行動を選択するためのUIを管理するクラス
/// </summary>
public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject choiceActionCanvas;
    [SerializeField] GameObject mapButton;
    [SerializeField] GameObject itemButton;
    [SerializeField] GameObject diceButton;
    [SerializeField] GameObject statusButton;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject dice;

    [SerializeField] ShowStatusText showStatusText;
    [SerializeField] GameObject statusText;

    /// <summary>
    /// キャンバスのボタンをアクティブにするメソッド
    /// </summary>
    public void ShowCanvas()
    {
        mapButton.SetActive(true);
        itemButton.SetActive(true);
        diceButton.SetActive(true);
        statusButton.SetActive(true);
        backButton.SetActive(false);
    }

    /// <summary>
    /// キャンバスのボタンを非アクティブにするメソッド
    /// </summary>
    public void HideCanvas()
    {
        mapButton.SetActive(false);
        itemButton.SetActive(false);
        diceButton.SetActive(false);
        statusButton.SetActive(false);
        backButton.SetActive(false);
    }

    /// <summary>
    /// キャンバスのボタンがクリックされたときに呼ばれるメソッド
    /// </summary>
    /// <param name="clicked">クリックされたゲームオブジェクト</param>
    public void OnBeClickedTest(GameObject clicked)
    {
        if (clicked.CompareTag("mapButton"))
        {
            Debug.Log("マップボタンが押されました");
            mapButton.SetActive(false);
            itemButton.SetActive(false);
            diceButton.SetActive(false);
            statusButton.SetActive(false);
            backButton.SetActive(true);
        }
        else if (clicked.CompareTag("itemButton"))
        {
            Debug.Log("アイテムボタンが押されました");
            mapButton.SetActive(false);
            itemButton.SetActive(false);
            diceButton.SetActive(false);
            statusButton.SetActive(false);
            backButton.SetActive(true);
        }
        else if (clicked.CompareTag("diceButton"))
        {
            Debug.Log("ダイスボタンが押されました");
            mapButton.SetActive(false);
            itemButton.SetActive(false);
            diceButton.SetActive(false);
            statusButton.SetActive(false);
            backButton.SetActive(true);
            dice.SetActive(true);
        }
        else if (clicked.CompareTag("statusButton"))
        {
            Debug.Log("ステータスボタンが押されました");
            showStatusText.WriteText();
            statusText.SetActive(true);

            mapButton.SetActive(false);
            itemButton.SetActive(false);
            diceButton.SetActive(false);
            statusButton.SetActive(false);
            backButton.SetActive(true);
        }
        else if (clicked.CompareTag("backButton"))
        {
            Debug.Log("バックボタンが押されました");
            mapButton.SetActive(true);
            itemButton.SetActive(true);
            diceButton.SetActive(true);
            statusButton.SetActive(true);
            backButton.SetActive(false);

            statusText.SetActive(false);
        }
    }
}
