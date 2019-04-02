#pragma warning disable 0649  

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// バトル中のキャンバスを管理するクラス
/// </summary>
public class ShowInBattleCanvas : MonoBehaviour
{
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject battleCanvas;
    [SerializeField] ShowInStoryCanvas showInStoryCanvas;
    [SerializeField] Text text;
    Player acPlayer;
    Enemy enemy;
    List<IBattleable> battlers = new List<IBattleable>();
    bool isTextCoroutineRunning;

    /// <summary>
    /// バトル開始時に呼ばれ、行動を選択させるメソッド
    /// </summary>
    /// <param name="acPlayer">アクティブプレイヤ</param>
    public void OnBattleStart(Player acPlayer)
    {
        this.acPlayer = acPlayer;

        battleCanvas.SetActive(true);

        text.text = "敵が現れた。\nどうしますか？";

        SetStatus();
        Sort();

        buttons.SetActive(true);
    }

    /// <summary>
    /// ボタンが押されたときに呼ばれるメソッド
    /// </summary>
    /// <param name="clicked">クリックされたゲームオブジェクト</param>
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

    /// <summary>
    /// 選択された行動を基に、敵とバトルをするコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator Fighting()
    {
        {
            //早いほうに攻撃させ、遅いほうに防御させる
            //バトル結果の文字列と、終了のフラグを受け取る
            (var battleStr, var isEnd) = Direct(battlers[0], battlers[1]);
            //文字を画面に出力
            isTextCoroutineRunning = true;
            var battleStrArray = battleStr.ToArray();
            StartCoroutine(ShowTextFiled.ShowStorys(battleStrArray, text, JugdeIsCoroutineFinish));
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
            StartCoroutine(ShowTextFiled.ShowStorys(battleStrArray, text, JugdeIsCoroutineFinish));
            //文字表示終了待ち
            yield return new WaitUntil(() => !isTextCoroutineRunning);
            //もし戦闘が終わっているのならループ終了
            if (isEnd) Hide();
        }
        text.text = "どうしますか？";
        buttons.SetActive(true);
    }

    /// <summary>
    /// バトルが終了(片方が倒れた時に呼ばれるメソッド)
    /// </summary>
    void Hide()
    {
        battleCanvas.SetActive(false);
        showInStoryCanvas.Hide(true);
    }

    /// <summary>
    /// 文字表示コルーチンのコールバック
    /// </summary>
    /// <param name="finish"></param>
    void JugdeIsCoroutineFinish(bool finish)
    {
        if (finish)
        {
            isTextCoroutineRunning = false;
        }
    }

    /// <summary>
    /// 敵のステータスを取得するメソッド
    /// </summary>
    //本番ではEnum使う
    void SetStatus()
    {
        enemy = new Enemy
        {
            Level = 5,
            HP = 20,
            AttackPoint = 8,
            DefencePoint = 8,
            MagicAttackPoint = 8,
            MagicDefencePoint = 8,
            Speed = 10
        };
    }

    /// <summary>
    /// 取得した戦闘者をリストに追加し、ソートするメソッド
    /// </summary>
    void Sort()
    {
        battlers.Clear();

        battlers.Add(acPlayer);
        battlers.Add(enemy);

        battlers.Sort((a, b) => b.Speed - a.Speed);
    }

    /// <summary>
    /// 攻撃と防御のステータス計算後に処理をし、処理結果の文字列を返すメソッド
    /// </summary>
    /// <param name="attacker">攻撃側</param>
    /// <param name="defencer">防御側</param>
    /// <returns>処理結果の文字列</returns>
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
            winner.Level++;
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

    /// <summary>
    /// 攻撃と防御のステータスを取得し、ダメージ量を計算するメソッド
    /// </summary>
    /// <param name="attacker">攻撃側</param>
    /// <param name="defencer">防御側</param>
    /// <returns>ダメージ量</returns>
    int DamagePointCalc(IBattleable attacker, IBattleable defencer)
    {
        int iryoku = 50;
        float ransu = DamageRatioGenerator();

        var damagePoint = ((attacker.Level * 2 / 5 + 2) * (iryoku * attacker.AttackPoint / defencer.DefencePoint) / 50 + 2) * ransu;

        return (int)damagePoint;
    }

    /// <summary>
    /// 戦闘時の乱数を生成するメソッド
    /// </summary>
    /// <returns>戦闘時の乱数</returns>
    float DamageRatioGenerator()
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
