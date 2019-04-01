#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 残り○マスというimageの表示を管理するクラス
/// </summary>
public class ShowRemainMass : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] GameObject remainMass;
    [SerializeField] CharactorStatusKeeper keeper;
    int updateRemainMass;
    bool isActive;

    /// <summary>
    /// 1フレーム毎に呼ばれ、残りマス数を表示するメソッド
    /// </summary>
    private void Update()
    {
        if (!isActive) return;

        //PlayerのRemainMassを取得
        updateRemainMass = keeper.remainMass;
        text.text = $"あと {updateRemainMass}マス";
    }

    /// <summary>
    /// あと○マスのimageをアクティブにするメソッド
    /// </summary>
    public void Show()
    {
        remainMass.SetActive(true);
        isActive = true;
    }

    /// <summary>
    /// あと○マスのimageを非アクティブにするメソッド
    /// </summary>
    public void Hide()
    {
        remainMass.SetActive(false);
        isActive = false;
    }
}
