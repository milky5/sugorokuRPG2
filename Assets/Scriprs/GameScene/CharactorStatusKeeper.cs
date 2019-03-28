using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharactorStatusKeeper : MonoBehaviour
{
    //各プレイヤーのステータスを取ってくる
    //{ get; set;}を活用

    public GameObject playerObj;
    public Player player;
    public int remainMass = int.MinValue;
    public Vector3 playerPos;
    public StoryList story;
    public bool isPlayerMoving;

    private void Awake()
    {
        //playerObj = GameObject.Find("Eevee");
        ////player = GameObject.Find("Player");
        //player = playerObj.GetComponent<Player>();
        //remainMass = int.MinValue;
        
    }

    private void Update()
    {
        remainMass = player.remainMass;
        playerPos = playerObj.transform.position;
        story = player.story;
        isPlayerMoving = player.isMoving;
    }

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
