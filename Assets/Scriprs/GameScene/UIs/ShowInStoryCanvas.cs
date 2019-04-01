#pragma warning disable 0649  

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// マス目の内容を表示するキャンバスを管理するクラス
/// </summary>
public class ShowInStoryCanvas : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Image image;
    [SerializeField] Sprite battle;
    [SerializeField] Sprite help;
    [SerializeField] StoryMemo storyMemo;
    [SerializeField] ShowTextFiled showTextFiled;
    [SerializeField] StoryContents storyContents;

    public bool isTextEnd;

    /// <summary>
    /// StoryCanbasにマス目の内容を表示させるメソッド
    /// </summary>
    /// <param name="story">マス目の内容</param>
    /// <param name="activePlayer">アクティブプレイヤ</param>
    public void Show(StoryList story, Player activePlayer)
    {
        //StoryCanvasを表示させる
        canvas.SetActive(true);
        //テキスト表示をスタートさせるフラグを立てる
        isTextEnd = false;
        //image.sprite = battle;
        //ストーリーの内容を取得する
        var storyDelegate = storyContents.ReturnContents(story);
        var storyStr = storyDelegate(activePlayer);
        if (story == StoryList.callbattle)
        {
            return;
        }
        //ストーリーの内容をテキスト表示させる
        StartCoroutine(showTextFiled.ShowStorys(storyStr, Hide));
    }

    /// <summary>
    /// StoryCanvasを非アクティブにするメソッド
    /// </summary>
    /// <param name="end">文字表示コルーチンが終了したかどうか</param>
    public void Hide(bool end)
    {
        canvas.SetActive(false);
        isTextEnd = true;
    }

}
