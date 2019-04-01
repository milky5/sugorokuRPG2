using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// アクティブプレイヤのステータスを取得し保持するクラス
/// </summary>
public class CharactorStatusKeeper : MonoBehaviour
{
    public GameObject playerObj;
    public Player player;
    public int remainMass = int.MinValue;
    public Vector3 playerPos;
    public StoryList story;
    public bool isPlayerMoving;

    /// <summary>
    /// 1フレーム毎に呼ばれ、アクティブプレイヤのステータスを取得するメソッド
    /// </summary>
    private void Update()
    {
        remainMass = player.remainMass;
        playerPos = playerObj.transform.position;
        story = player.story;
        isPlayerMoving = player.isMoving;
    }

    /// <summary>
    /// アクティブプレイヤが変更される際に、ステータスを更新するメソッド
    /// </summary>
    /// <param name="acPlayer">新アクティブプレイヤ</param>
    /// <param name="acPlayerObj">新アクティブプレイヤのオブジェクト</param>
    public void RenewalData(Player acPlayer,GameObject acPlayerObj)
    {
        //データを初期化
        playerObj = null;
        player = null;
        remainMass = 0;
        playerPos = Vector3.zero;
        story = 0;
        isPlayerMoving = false;

        //新規データを代入
        playerObj = acPlayerObj;
        player = acPlayer;
    }
}
