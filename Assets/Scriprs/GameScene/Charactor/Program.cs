using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public partial class Program : MonoBehaviour
{
    //次の順番のプレイヤーに、順番を回す
    void TurnOrder()
    {
        int nextIndex = 0;

        //今の順番のプレイヤーのインデックスを探す
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].isActive)
            {
                //今のプレイヤーをアクティブプレイヤーから外す
                players[i].isActive = false;

                /* 一時しのぎ　　今のプレイヤーのコライダーを非アクティブにする */
                players[i].GetComponent<Collider>().enabled = false;

                //次のプレイヤーのインデックスを保持
                nextIndex = ++i;
                //アクティブプレイヤーは1人しかいないのでこれ以上探す必要はない
                break;
            }
        }
        //もし、次のプレイヤーのインデックスが境界の範囲外だったら
        if (players.Count <= nextIndex)
        {
            //一番最初のプレイヤーに戻す
            nextIndex = 0;
        }
        //次のプレイヤーをアクティブプレイヤーにする
        players[nextIndex].isActive = true;
        /* 一時しのぎ　　次のプレイヤーのコライダーをアクティブにする */
        players[nextIndex].GetComponent<Collider>().enabled = true;
    }

    //アクティブプレイヤーを取得
    void GetActivePlayer()
    {
        foreach (var p in players)
        {
            if (p.isActive)
            {
                activePlayer = p;
            }
        }
    }

    //アクティブプレイヤーのオブジェクトを取得
    void GetActivePlayerObj()
    {
        var playerObjs = GameObject.FindGameObjectsWithTag("Player");
        var activePlayerObj = playerObjs.Where(n => n.GetComponent<Player>().isActive);
        if (activePlayerObj.Count() == 1)
        {
            foreach (var ac in activePlayerObj)
            {
                this.activePlayerObj = ac;
            }
        }
        else
        {
            Debug.Log("ActivePlayerが2人以上います");

            foreach (var ac in activePlayerObj)
            {
                Debug.Log(ac.GetComponent<Player>().charactorName.ToString());
            }
        }
    }

    //CharactorStatusKeeperで保持している内容を更新する
    void RenewalData()
    {
        keeper.RenewalData(activePlayer,activePlayerObj);
    }
}
