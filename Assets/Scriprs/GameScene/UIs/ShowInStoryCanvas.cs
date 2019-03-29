﻿#pragma warning disable 0649  

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //StoryCanvasを表示させる
    public void Show(StoryList story, Player activePlayer)
    {
        //var massdelegate = メソッドからの戻り値();
        //massdelegate(player);

        //もしStoryではなくBattleなら
        //if (story == StoryList.battle)
        //{
        //    //BattleCanvasを表示させる
        //    showInBattleCanvas.OnBattleStart();
        //    return;
        //}

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

    public void Hide(bool end)
    {
        canvas.SetActive(false);
        isTextEnd = true;
    }

}
