using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIsFacade : MonoBehaviour
{
    [SerializeField] GameUIManager gameUIManager;
    [SerializeField] ShowInBattleCanvas showInBattleCanvas;
    [SerializeField] ShowInStoryCanvas showInStoryCanvas;
    [SerializeField] ShowRemainMass showRemainMass;
    [SerializeField] WhosTurn whosTurn;

    /// <summary>
    /// ChoiceCanvasをアクティブにするメソッド
    /// </summary>
    public void ChoiceCanvasShow()
    {
        gameUIManager.ShowCanvas();
    }

    /// <summary>
    /// ChoiceCanvasを非アクティブにするメソッド
    /// </summary>
    public void ChoiceCanvasHide()
    {
        gameUIManager.HideCanvas();
    }

    /// <summary>
    /// Battleパートをスタートさせるメソッド
    /// </summary>
    /// <param name="activePlayer">アクティブプレイヤー</param>
    public void StartBattle(Player activePlayer)
    {
        showInBattleCanvas.OnBattleStart(activePlayer);
    }

    /// <summary>
    /// StoryCanvasをアクティブにするメソッド
    /// </summary>
    /// <param name="story">止まったマスのストーリー</param>
    /// <param name="activePlayer">アクティブプレイヤー</param>
    public void StoryCanvasShow(StoryList story, Player activePlayer)
    {
        showInStoryCanvas.Show(story, activePlayer);
    }

    /// <summary>
    /// StoryCanvasを非アクティブにするメソッド
    /// </summary>
    public void StoryCanvasHide()
    {
        showInStoryCanvas.Hide(true);
    }

    /// <summary>
    /// あと○マスのimageをアクティブにするメソッド
    /// </summary>
    public void RemainMassShow()
    {
        showRemainMass.Show();
    }

    /// <summary>
    /// あと○マスのimageを非アクティブにするメソッド
    /// </summary>
    public void RemainMassHide()
    {
        showRemainMass.Hide();
    }

    /// <summary>
    /// ○○のターンのimageを表示するメソッド
    /// </summary>
    /// <param name="activePlayer"></param>
    public void WhosTurnShow(Player activePlayer)
    {
        StartCoroutine(whosTurn.ShowWhosTurn(activePlayer));
    }

}
