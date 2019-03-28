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

    // Start is called before the first frame update
    //void Start()
    //{
    //    //Staticクラスから読み出す
    //    //Awakeのほうがいいのかも
    //    //というかPlayerクラスにコンストラクタ作ってほしい
    //    players.Add(keeper.player);
    //    players[0].playerName = "イーブイ";
    //    activePlayer = keeper.player;

    //    isOneTurnStart = true;
    //    //players.Add(Instantiate(playerPrefab).GetComponent<Player>());
    //    //players[0].playerName = "テストさん";
    //    //activePlayer = keeper.player;
    //}

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
            int diceNumber = UnityEngine.Random.Range(1, 7);
            Debug.Log($"出た目は {diceNumber}");
            beRolledDice.OnRollingExit(diceNumber);

            beRolledDice.OnRollingExit(diceNumber);
            playerMover.Move(activePlayer,diceNumber);
            showRemainMass.Show();

            isRemainJudging = true;
        }

        //プレイヤーの動き終わりをフラグ管理
        //現在      //動き終わったら、(BeRolledDiceクラス)の、フェイクダイスを非表示、
        //現在      //サイコロポジションの最適化(空のオブジェクト・リアルダイスの高さ)
        if (isPlayerFinishedMoving)
        {
            isPlayerFinishedMoving = false;

            beRolledDice.OnMoveExit();
            showRemainMass.Hide();
            showInStoryCanvas.Show(story);
            isTextEndJudging = true;
        }



    }













    private void PlayerOneTurn()
    {
        //今誰のターンなのか判定する
        var playersObj = GameObject.FindGameObjectsWithTag("Player");
        var activePlayerObj = playersObj.Where(n => n.GetComponent<Player>().isActive);
        foreach (var acObj in activePlayerObj)
        {
            //手番の人のステータスをStatusKeeperで保持するようにする
            keeper.playerObj = acObj;
            keeper.player = acObj.GetComponent<Player>();
        }

        //○○のターン！というイメージを表示
        StartCoroutine(whosTurn.ShowWhosTurn(activePlayer));

        //[マップ][サイコロ][アイテム][ステータス]のボタンを表示する
        gameUIManager.ShowCanvas();
        //ボタンが押されたら、gameUIManagerがそれぞれの処理をする

        //現在        //サイコロボタンが押されたらサイコロが動く＆ backButtonがfalseに
        //サイコロの落ち始めをフラグ管理、落ち始めたらgameUIManager.HideCanvas()
        if (isDiceBeganToFall)
        {
            gameUIManager.HideCanvas();
        }

        //サイコロの落ち終わりをフラグ管理、
        //落ち終わったら、出目を伝える、本物偽物を入れ替える、プレイヤーを動かす(PlayerMoverクラス)
        if (isDiceFinishedFalling)
        {

        }

        //showRemainMassをアクティブに。

        //プレイヤーの動き終わりをフラグ管理
        //現在      //動き終わったら、(BeRolledDiceクラス)の、フェイクダイスを非表示、
        //現在      //サイコロポジションの最適化(空のオブジェクト・リアルダイスの高さ)
        if (isPlayerFinishedMoving)
        {

        }

        //動き終わったら、showRemainMassを非アクティブに。
        //動き終わったら、StoryCanvasをactiveに
        showInStoryCanvas.Show(story);
        //文章を読み終わったら、Storycanvasをfalseに
        showInStoryCanvas.Hide(true);
    }

    void Memo()
    {
        /*
         * GameSceneが読み込まれる
         *      プレイ人数に応じてPlayerを生成(名前も代入)
         * 最初の導入ストーリーが開始(StoryCanvasにて描画)
         *      導入ストーリー中にて、アイテムを取得、ステータスに反映
         * StoryCanvasを非アクティブ化
         * 
         * 
         * 【LoopB】
         * プレイヤーの数だけLoopAを繰り返す
         * 【LoopA】
         * プレイヤー(Player[0])のステータスをアクティブに
         * ChoiceCanvasをアクティブ化
         * アクティブなプレイヤーのアイテムやステータスを取得
         * アクティブなプレイヤーにカメラを合わせる
         * サイコロ振る
         * プレイヤーが動いてTriggerにて処理
         * 止まったらStoryCanvasにてイベント再生
         * 
         *      ＜もし強制イベントが入ったら＞
         *          StoryCanvasをアクティブ化
         *          1人目に説明終わったよっていうフラグ
         *          最後は○人目だよっていうフラグ
         * 
         * プレイヤーのステータスを変更
         * StoryCanvasを非アクティブ化
         * アクティブなプレイヤーのステータスを非アクティブに
         * 【End LoopA】
         * 【End LoopB】
         * 
         * 
         * 全員がゴールに着いたらStoryCanvasをアクティブ化
         * 戦闘開始
         * 戦闘終了
         * ゲームエンド
         * 
         */
    }
}
