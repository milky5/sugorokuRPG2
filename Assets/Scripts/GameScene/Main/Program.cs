#pragma warning disable 0649 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// ゲームの流れを管理するクラス。
/// 部分クラスになっており、このファイルでは、
/// 変数の宣言、Awakeメソッド、Updateメソッドのみを記載。
/// </summary>
public　partial class Program : MonoBehaviour
{
    [SerializeField] CharactorStatusKeeper keeper;
    [SerializeField] UIsFacade uisFacade;
    //[SerializeField] GameUIManager gameUIManager;
    [SerializeField] ShowInStoryCanvas showInStoryCanvas;
    //[SerializeField] ShowRemainMass showRemainMass;
    //[SerializeField] WhosTurn whosTurn;
    [SerializeField] PlayerMover playerMover;
    [SerializeField] BeRolledDice beRolledDice;
    [SerializeField] GameObject playerPrefabsParent;
    [SerializeField] GameObject[] playerPrefabs;    List<Player> players = new List<Player>();

    Player activePlayer;
    GameObject activePlayerObj;

    StoryList story;
    //EnemyList enemy;

    bool isGameStart;
    bool isFirstTurn;
    bool isOneTurnStart;
    bool isPlayerChoicing;
    public bool isDiceBeganToFall;      //Diceクラスから代入される
    public bool isDiceFinishedFalling;  //Diceクラスから代入される
    bool isRemainJudging;
    bool isPlayerFinishedMoving;
    bool isTextEndJudging;

    /// <summary>
    /// プログラム開始直後に呼ばれるメソッド
    /// </summary>
    private void Awake()
    {
        //
        var names = DebugStaticClass.GiveData();
        //var names = StaticClassTest.GiveData();

        for (int i = 0; i < names.Length; i++)
        {
            var obj = Instantiate(playerPrefabs[i],playerPrefabsParent.transform);
            var playerComponent = obj.GetComponent<Player>();
            playerComponent.charactorName = names[i];
            players.Add(playerComponent);
        }

        players[0].isActive = true;
        isFirstTurn = true;
        isOneTurnStart = true;

        
    }

    /// <summary>
    /// 1フレームに1度呼ばれるメソッド
    /// </summary>
    void Update()
    {
        if (isGameStart)
        {
            isGameStart = false;
            //あなた達は町へ出かけることになりました
        }
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
            uisFacade.WhosTurnShow(activePlayer);

            beRolledDice.OnActivePlayerChanged(activePlayerObj);

            isPlayerChoicing = true;
        }

        //プレイヤーがこのターン何をするかを選択している時
        if (isPlayerChoicing)
        {
            isPlayerChoicing = false;

            uisFacade.ChoiceCanvasShow();
        }

        //サイコロが落ち始めた時
        if (isDiceBeganToFall)
        {
            isDiceBeganToFall = false;

            uisFacade.ChoiceCanvasHide();
        }

        //サイコロの落ち終わりをフラグ管理、
        //落ち終わり = dicePosition y <= 1
        //落ち終わったら、出目を伝える、本物偽物を入れ替える、プレイヤーを動かす(PlayerMoverクラス)
        if (isDiceFinishedFalling)
        {
            isDiceFinishedFalling = false;

            //サイコロを振る
            //int diceNumber = 4;
            int diceNumber = UnityEngine.Random.Range(1, 7);
            Debug.Log($"出た目は {diceNumber}");
            beRolledDice.OnRollingExit(diceNumber);

            beRolledDice.OnRollingExit(diceNumber);
            playerMover.Move(activePlayer,diceNumber);
            uisFacade.RemainMassShow();

            isRemainJudging = true;
        }

        //プレイヤーの動き終わりをフラグ管理
        if (isPlayerFinishedMoving)
        {
            isPlayerFinishedMoving = false;

            beRolledDice.OnMoveExit();
            uisFacade.RemainMassHide();
            uisFacade.StoryCanvasShow(story, activePlayer);
            isTextEndJudging = true;
        }

    }
}
