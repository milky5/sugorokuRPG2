#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRemainMass : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] GameObject remainMass;
    [SerializeField] CharactorStatusKeeper keeper;
    int updateRemainMass;
    bool isActive;

    private void Update()
    {
        if (!isActive) return;

        //PlayerのRemainMassを取得
        updateRemainMass = keeper.remainMass;
        text.text = $"あと {updateRemainMass}マス";
    }

    public void Show()
    {
        remainMass.SetActive(true);
        isActive = true;
    }

    public void Hide()
    {
        remainMass.SetActive(false);
        isActive = false;
    }
}
