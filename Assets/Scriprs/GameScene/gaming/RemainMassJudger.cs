#pragma warning disable 0649 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainMassJudger : MonoBehaviour
{
    [SerializeField] StoryList thisStory;

    private void OnTriggerEnter(Collider other)
    {
        //衝突相手がIRollableを持っていなければ何もしない
        var rolling = other.GetComponent<IRollable>();
        if (rolling == null) return;

        //衝突相手がIMoveableを持っていなければ何もしない
        var moving = other.GetComponent<IMoveable>();
        if (moving == null) return;

        //進む残りマス数を更新
        rolling.remainMass--;
        Debug.Log($"残りマスが{rolling.remainMass}になりました");

        //まだ進む必要があるなら
        if (rolling.remainMass > 0)
        {
            moving.isMoving = true;
        }
        //残りマスが0だったら
        else
        {
            //このマスのストーリーを教える
            moving.story = thisStory;

            //これ以上動かないようにする
            moving.isMoving = false;
            //マス中央にキャラクターを動かす
            var posX = transform.position.x;
            var posY = other.transform.position.y;
            var posZ = transform.position.z;
            other.transform.position = new Vector3(posX, posY, posZ);
        }
    }
}
