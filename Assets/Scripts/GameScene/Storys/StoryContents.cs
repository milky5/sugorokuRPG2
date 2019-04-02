#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 止まったマスの処理内容をデリゲートとして返すメソッドを実装するクラス
/// </summary>
public class StoryContents : MonoBehaviour
{
    [SerializeField] ReturnDelegate rd;

    /// <summary>
    /// 止まったマスの処理内容をデリゲートとして返すメソッド
    /// </summary>
    /// <param name="story">どの種類のマスに止まったか</param>
    /// <returns>止まったマスの処理メソッドが代入されたデリゲート</returns>
    public MassContents ReturnContents(StoryList story)
    {
        switch (story)
        {
            case StoryList.nullStory:
                return new MassContents(rd.NullStory);
            case StoryList.healHP:
                return new MassContents(rd.HealHP);
            case StoryList.shopping:
                return new MassContents(rd.Shopping);
            case StoryList.helpPeople:
                return new MassContents(rd.HelpPeople);
            case StoryList.callbattle:
                return new MassContents(rd.CallBattle);
            case StoryList.first:
                return new MassContents(rd.First);
            default:
                return new MassContents(rd.NullStory);
        }
    }
}
