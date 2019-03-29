using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StoryList
{
    nullStory = 0,
    story1,
    story2,
    story3,
    story4,
    battle
}


public class StoryContents
{
    public string[] ReturnContents(StoryList story)
    {
        switch (story)
        {
            case StoryList.nullStory:
                string[] temp = { "ぬるぬる" };
                //return new MassContents();
                return temp;

            case StoryList.story1:
                string[] preEvent1 =
                {
                     "町の人と出会い、声をかけられました。",
                     "「ありがとう、頑張ってね。応援してるよ。」",
                     "頑張ろう！と気合が入りました。"
                };
                return preEvent1;

            case StoryList.story2:
                string[] preEvent2 =
                {
                    "教会の神父さんと出会いました。",
                    "「疲れていないかい？少し休んでいきなよ。」",
                    "少し休んだので、力がみなぎってきました。"
                };
                return preEvent2;

            case StoryList.story3:
                string[] preEvent3 =
                {
                    "パン屋さんと出会いました。",
                    "「頑張ってね！これ持ってって！」",
                    "パンをもらい、美味しく頂きました。"
                };
                return preEvent3;

            case StoryList.story4:
                string[] preEvent4 =
                {
                    "町の中にモンスターが出現しました。",
                    "バトル開始！",
                    "あなたはモンスターを退治しました。"
                };
                return preEvent4;

            case StoryList.battle:
                //メソッドを呼ぶ
                string[] preBattle =
                {
                    "バトルしました"
                };
                return preBattle;

            default:
                string[] tempo = { "ぬるぬる" };
                return tempo;
        }
    }
}

delegate void MassContents(Player player);

class ReturnDelegate
{
   public void HealHP(Player player)
    {
        player.hp += 500; //maxHpプロパティを作る。。。
    }

    public void CallBattle(Player player)
    {
        ShowInBattleCanvas showInBattleCanvas = new ShowInBattleCanvas();
        showInBattleCanvas.OnBattleStart();
    }

    public void Shopping(Player player)
    {
        //ショップメソッドを呼ぶ
        Debug.Log("ショップメソッドを呼びました");
    }

    public void HelpPeople(Player player)
    {
        player.money += Random.Range(100, 501);
    }
}