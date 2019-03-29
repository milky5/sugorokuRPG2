#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate string[] MassContents(Player player);

class ReturnDelegate : MonoBehaviour
{
    [SerializeField] ShowInBattleCanvas showInBattleCanvas;

    public string[] HealHP(Player player)
    {
        player.hp += 500; //maxHpプロパティを作る。。。
        string[] healHPStr =
                {
                    "教会の神父さんと出会いました。",
                    "「疲れていないかい？少し休んでいきなよ。」",
                    $"{player.charactorName}の体力が全回復した。"
                };
        return healHPStr;
    }

    public string[] CallBattle(Player player)
    {
        showInBattleCanvas.OnBattleStart(player);
        string[] callBattleStr =
        {
            "敵が現れた！"
        };
        return callBattleStr;
    }

    public string[] Shopping(Player player)
    {
        string[] shoppingStr =
        {
           "ショップメソッドを呼びました"
        };
        return shoppingStr;
    }

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

    public string[] nullStory(Player player)
    {
        string[] nullStoryStr =
        {
            "ぬるぬる"
        };
        return nullStoryStr;
    }
}