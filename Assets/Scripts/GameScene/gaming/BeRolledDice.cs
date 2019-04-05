#pragma warning disable 0649 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サイコロを振った時に処理するメソッドを定義するクラス
/// </summary>
public class BeRolledDice : MonoBehaviour
{
    [SerializeField] GameObject realDice;
    [SerializeField] GameObject fakeDice1;
    [SerializeField] GameObject fakeDice2;
    [SerializeField] GameObject fakeDice3;
    [SerializeField] GameObject fakeDice4;
    [SerializeField] GameObject fakeDice5;
    [SerializeField] GameObject fakeDice6;
    GameObject displayedDice;
    Vector3 dicePosition;
    float realDiceDefaltPosY = 4.0f;

    /// <summary>
    /// サイコロの目に合わせてオブジェクトを置き換えるメソッド
    /// </summary>
    /// <param name="diceNumber">サイコロの出目</param>
    public void OnRollingExit(int diceNumber)
    {
        realDice.SetActive(false);

        switch (diceNumber)
        {
            case 1:
                fakeDice1.SetActive(true);
                fakeDice1.transform.Rotate(new Vector3(0, Random.Range(0, 361), 0),Space.World);
                displayedDice = fakeDice1;
                break;
            case 2:
                fakeDice2.SetActive(true);
                fakeDice2.transform.Rotate(new Vector3(0, Random.Range(0, 361), 0), Space.World);
                displayedDice = fakeDice2;
                break;
            case 3:
                fakeDice3.SetActive(true);
                fakeDice3.transform.Rotate(new Vector3(0, Random.Range(0, 361), 0), Space.World);
                displayedDice = fakeDice3;
                break;
            case 4:
                fakeDice4.SetActive(true);
                fakeDice4.transform.Rotate(new Vector3(0, Random.Range(0, 361), 0), Space.World);
                displayedDice = fakeDice4;
                break;
            case 5:
                fakeDice5.SetActive(true);
                fakeDice5.transform.Rotate(new Vector3(0, Random.Range(0, 361), 0), Space.World);
                displayedDice = fakeDice5;
                break;
            case 6:
                fakeDice6.SetActive(true);
                fakeDice6.transform.Rotate(new Vector3(0, Random.Range(0, 361), 0), Space.World);
                displayedDice = fakeDice6;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// プレイヤが動き終わったらサイコロを非アクティブにするメソッド
    /// </summary>
    public void OnMoveExit()
    {
        displayedDice.SetActive(false);
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
