#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 止まったマスで何の処理をするのかを保持するデリゲート
/// </summary>
/// <param name="player">そのマスに止まったプレイヤー</param>
/// <returns>処理結果の文字列</returns>
public delegate string[] MassContents(Player player);

/// <summary>
/// 止まったマスでの処理内容を記載したメソッドが定義されているクラス
/// </summary>
class ReturnDelegate : MonoBehaviour
{
    [SerializeField] ShowInBattleCanvas showInBattleCanvas;

    /// <summary>
    /// 体力回復マスに止まった時の処理を実行し、結果の文字列を返します
    /// </summary>
    /// <param name="player">そのマスに止まったプレイヤー</param>
    /// <returns>処理結果の文字列</returns>
    public string[] HealHP(Player player)
    {
        player.HP = player.MaxHp;
        string[] healHPStr =
                {
                    "教会の神父さんと出会いました。",
                    "「疲れていないかい？少し休んでいきなよ。」",
                    $"{player.charactorName}の体力が全回復した。"
                };
        return healHPStr;
    }

    /// <summary>
    /// バトルマスに止まった時の処理を実行し、結果の文字列を返します
    /// </summary>
    /// <param name="player">そのマスに止まったプレイヤー</param>
    /// <returns>処理結果の文字列</returns>
    public string[] CallBattle(Player player)
    {
        showInBattleCanvas.OnBattleStart(player);
        string[] callBattleStr =
        {
            "敵が現れた！"
        };
        return callBattleStr;
    }

    /// <summary>
    /// ショップマスに止まった時の処理を実行し、結果の文字列を返します
    /// </summary>
    /// <param name="player">そのマスに止まったプレイヤー</param>
    /// <returns>処理結果の文字列</returns>
    public string[] Shopping(Player player)
    {
        string[] shoppingStr =
        {
           "ショップメソッドを呼びました"
        };
        return shoppingStr;
    }

    /// <summary>
    /// 人助けマスに止まった時の処理を実行し、結果の文字列を返します
    /// </summary>
    /// <param name="player">そのマスに止まったプレイヤー</param>
    /// <returns>処理結果の文字列</returns>
    public string[] HelpPeople(Player player)
    {
        int recivedMoney = Random.Range(100, 501);
        player.money += recivedMoney;

        string[] helpPeopleStr =
        {
            "「そこの若い子！ちょっと手伝ってくれないかい？」",
            $"{player.charactorName}は町の人を手伝いました。",
            $"お礼に{recivedMoney}円もらった"
        };
        return helpPeopleStr;
    }

    /// <summary>
    /// 未設定のマスに止まった時の処理を実行し、結果の文字列を返します
    /// </summary>
    /// <param name="player">そのマスに止まったプレイヤー</param>
    /// <returns>処理結果の文字列</returns>
    public string[] NullStory(Player player)
    {
        string[] nullStoryStr =
        {
            "ぬるぬる"
        };
        return nullStoryStr;
    }
}