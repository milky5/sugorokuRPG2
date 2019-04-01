#pragma warning disable 0649 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サイコロを振った時に処理するメソッドを定義するクラス
/// </summary>
public class BeRolledDice : MonoBehaviour
{
    [SerializeField] GameObject fakeDice;
    [SerializeField] GameObject realDice;
    Vector3 dicePosition;
    float realDiceDefaltPosY = 4.0f;

    /// <summary>
    /// サイコロの目に合わせてオブジェクトを置き換えるメソッド
    /// </summary>
    /// <param name="diceNumber">サイコロの出目</param>
    public void OnRollingExit(int diceNumber)
    {
        realDice.SetActive(false);
        fakeDice.SetActive(true);
    }

    /// <summary>
    /// プレイヤが動き終わったらサイコロを非アクティブにするメソッド
    /// </summary>
    public void OnMoveExit()
    {
        fakeDice.SetActive(false);
    }

    /// <summary>
    /// アクティブプレイヤが変わった時にサイコロの位置を最適化するメソッド
    /// </summary>
    /// <param name="playerObj">ActivePlayerのオブジェクト</param>
    public void OnActivePlayerChanged(GameObject playerObj)
    {
        float posX = playerObj.transform.position.x;
        float posY = transform.position.y;
        float posZ = transform.position.z;
        gameObject.transform.position = new Vector3(posX, posY, posZ);
        realDice.transform.position = new Vector3(posX, realDiceDefaltPosY, posZ);
    }
}
