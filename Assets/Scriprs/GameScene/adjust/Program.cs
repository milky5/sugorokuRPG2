#pragma warning disable 0649 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// 宣言, Start(), Update()
public　partial class Program : MonoBehaviour
{
    [SerializeField] CharactorStatusKeeper keeper;
    [SerializeField] GameUIManager gameUIManager;
    [SerializeField] ShowInStoryCanvas showInStoryCanvas;
    [SerializeField] Dice diceClass;
    [SerializeField] ShowRemainMass showRemainMass;
    [SerializeField] WhosTurn whosTurn;
    [SerializeField] PlayerMover playerMover;
    [SerializeField] BeRolledDice beRolledDice;

    [SerializeField] GameObject playerPrefab;


    [SerializeField] GameObject[] playerPrefabs;
    List<Player> players = new List<Player>();

    Player activePlayer;
    GameObject activePlayerObj;

    StoryList story;

    bool isFirstTurn;

    bool isOneTurnStart;
    bool isPlayerChoicing;
    public bool isDiceBeganToFall;      //Diceクラスから代入される
    public bool isDiceFinishedFalling;  //Diceクラスから代入される
    bool isRemainJudging;
    bool isPlayerFinishedMoving;
    bool isTextEndJudging;

    private void Awake()
    {
        //
        var names = DebugStaticClass.GiveData();
        //var names = StaticClassTest.GiveData();

        for (int i = 0; i < names.Length; i++)
        {
            var obj = Instantiate(playerPrefabs[i]);
            //var playerComponent = obj.AddComponent<Player>();
            var playerComponent = obj.GetComponent<Player>();
            playerComponent.charactorName = names[i];
            players.Add(playerComponent);
        }

        players[0].isActive = true;
        isFirstTurn = true;
        isOneTurnStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (keeper.remainMass == 0 && isRemainJudging)
        {
            isRemainJudging = false;
            isPlayerFinishedMoving = true;
            story = keeper.story;
        }

        if (showInStoryCanvas.isTextEnd && isTextEndJudging)
        {
            isTextEndJudging = false;
            isOneTurnStart = true;
        }

        //誰かのターンが終わって誰かのターンが始まる時
        if (isOneTurnStart)
        {
            isOneTurnStart = false;

            if (!isFirstTurn)
            {
                TurnOrder();
            }
            isFirstTurn = false;

            GetActivePlayer();
            GetActivePlayerObj();
            RenewalData();
            StartCoroutine(whosTurn.ShowWhosTurn(activePlayer));

            beRolledDice.OnActivePlayerChanged(activePlayerObj);

            isPlayerChoicing = true;
        }

        //プレイヤーがこのターン何をするかを選択している時
        if (isPlayerChoicing)
        {
            isPlayerChoicing = false;

            gameUIManager.ShowCanvas();
        }

        //サイコロが落ち始めた時
        if (isDiceBeganToFall)
        {
            isDiceBeganToFall = false;

            gameUIManager.HideCanvas();
        }

        //サイコロの落ち終わりをフラグ管理、
        //落ち終わり = dicePosition y <= 1
        //落ち終わったら、出目を伝える、本物偽物を入れ替える、プレイヤーを動かす(PlayerMoverクラス)
        if (isDiceFinishedFalling)
        {
            isDiceFinishedFalling = false;

            //サイコロを振る
            int diceNumber = 4;
            //int diceNumber = UnityEngine.Random.Range(1, 7);
            Debug.Log($"出た目は {diceNumber}");
            beRolledDice.OnRollingExit(diceNumber);

            beRolledDice.OnRollingExit(diceNumber);
            playerMover.Move(activePlayer,diceNumber);
            showRemainMass.Show();

            isRemainJudging = true;
        }

        //プレイヤーの動き終わりをフラグ管理
        if (isPlayerFinishedMoving)
        {
            isPlayerFinishedMoving = false;

            beRolledDice.OnMoveExit();
            showRemainMass.Hide();
            showInStoryCanvas.Show(story,activePlayer);
            isTextEndJudging = true;
        }

    }
}
