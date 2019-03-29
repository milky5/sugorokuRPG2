#pragma warning disable 0649  

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShowInBattleCanvas : MonoBehaviour
{
    [SerializeField] ShowTextFiled showTextFiled;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject battleCanvas;
    [SerializeField] ShowInStoryCanvas showInStoryCanvas;
    [SerializeField] Text text;
    Player acPlayer;
    Enemy enemy;
    List<IBattleable> battlers = new List<IBattleable>();
    bool isTextCoroutineRunning;

    //Battle開始時に呼ばれるメソッド
    public void OnBattleStart(Player acPlayer)
    {
        this.acPlayer = acPlayer;

        battleCanvas.SetActive(true);

        text.text = "敵が現れた。\nどうしますか？";

        SetStatus();
        Sort();

        buttons.SetActive(true);
    }

    public void OnAttackButtonsClicked(GameObject clicked)
    {
        //if (clicked.CompareTag("nomal"))
        //{

        //}
        //else if (clicked.CompareTag("magic"))
        //{

        //}
        //攻撃する・防御する　をやる
        //どちらかが倒れるまで繰り返す
        StartCoroutine(Fighting());
        buttons.SetActive(false);
    }

    public IEnumerator Fighting()
    {
        {
            //早いほうに攻撃させ、遅いほうに防御させる
            //バトル結果の文字列と、終了のフラグを受け取る
            (var battleStr, var isEnd) = Direct(battlers[0], battlers[1]);
            //文字を画面に出力
            isTextCoroutineRunning = true;
            var battleStrArray = battleStr.ToArray();
            StartCoroutine(showTextFiled.ShowStorys(battleStrArray, JugdeIsCoroutineFinish, text));
            //文字表示終了待ち
            yield return new WaitUntil(() => !isTextCoroutineRunning);
            //もし戦闘が終わっているのならループ終了
            if (isEnd) Hide();

            //遅いほうに攻撃させ、早いほうに防御させる
            //バトル結果の文字列と、終了のフラグを受け取る
            (battleStr, isEnd) = Direct(battlers[1], battlers[0]);
            //文字を画面に出力
            isTextCoroutineRunning = true;
            battleStrArray = battleStr.ToArray();
            StartCoroutine(showTextFiled.ShowStorys(battleStrArray, JugdeIsCoroutineFinish, text));
            //文字表示終了待ち
            yield return new WaitUntil(() => !isTextCoroutineRunning);
            //もし戦闘が終わっているのならループ終了
            if (isEnd) Hide();
        }
        text.text = "どうしますか？";
        buttons.SetActive(true);
    }


    void Hide()
    {
        battleCanvas.SetActive(false);
        showInStoryCanvas.Hide(true);
    }

    void JugdeIsCoroutineFinish(bool finish)
    {
        if (finish)
        {
            isTextCoroutineRunning = false;
        }
    }




    //本番では、ステータスを取ってくる
    void SetStatus()
    {
        enemy = new Enemy();

        enemy.level = 5;
        enemy.hp = 20;
        enemy.attackPoint = 8;
        enemy.defencePoint = 8;
        enemy.magicAttackPoint = 8;
        enemy.magicDefencePoint = 8;
        enemy.speed = 10;
    }


    //取得したプレイヤーをリストに追加し、ソート
    void Sort()
    {
        battlers.Clear();

        battlers.Add(acPlayer);
        battlers.Add(enemy);

        battlers.Sort((a, b) => b.speed - a.speed);
    }


    //攻撃・防御をさせ、結果を返す
    (List<string>, bool) Direct(IBattleable attacker, IBattleable defencer)
    {
        var attackStr = attacker.Attack();
        var damagePoint = DamagePointCalc(attacker, defencer);
        (var damageStr, var isEnd) = defencer.BeDamaged(damagePoint);

        var returnList = new List<string>();
        returnList.Add(attackStr);
        damageStr.ForEach(n => returnList.Add(n));

        if (isEnd && attacker is Player)
        {
            Player winner = attacker as Player;
            returnList.Add($"{winner.charactorName}の勝利！");
            winner.level++;
            returnList.Add($"{winner.charactorName}はレベルが1上がった！");
            returnList.Add($"{winner.charactorName}は報奨金として{UnityEngine.Random.Range(100, 1000)}円もらった！");
        }
        if (isEnd && attacker is Enemy)
        {
            Player loser = defencer as Player;
            returnList.Add($"{loser.charactorName}の敗北…");
            loser.money /= 2;
            returnList.Add($"{loser.charactorName}は混乱してお金を落とした");
            returnList.Add($"{loser.charactorName}の所持金が半分の{loser.money}円になった");
        }

        return (returnList, isEnd);
    }

    //攻撃と防御でいくつダメージが入るか計算
    public int DamagePointCalc(IBattleable attacker, IBattleable defencer)
    {
        int iryoku = 50;
        float ransu = DamageRatioGenerator();

        var damagePoint = ((attacker.level * 2 / 5 + 2) * (iryoku * attacker.attackPoint / defencer.defencePoint) / 50 + 2) * ransu;

        return (int)damagePoint;
    }

    //戦闘時の乱数を作成
    public float DamageRatioGenerator()
    {
        int ransu = UnityEngine.Random.Range(0, 100);

        float ratio = 1.0f;

        if (0 <= ransu && ransu < 8)
        {
            ratio = 1.2f;
        }
        else if (8 <= ransu && ransu < 25)
        {
            ratio = 1.1f;
        }
        else if (25 <= ransu && ransu < 75)
        {
            ratio = 1.0f;
        }
        else if (75 <= ransu && ransu < 92)
        {
            ratio = 0.9f;
        }
        else if (92 <= ransu && ransu < 100)
        {
            ratio = 0.8f;
        }

        return ratio;
    }



}
