﻿#pragma warning disable 0649  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrepareEventManager : MonoBehaviour
{
    [SerializeField] GameObject firstCanvas;
    [SerializeField] GameObject nextCanvas;
    [SerializeField] Dropdown dropdown;
    [SerializeField] GameObject no1;
    [SerializeField] GameObject no2;
    [SerializeField] GameObject no3;
    [SerializeField] GameObject no4;
    [SerializeField] InputField[] inputFields;


    //StartButtonが押されたら呼ばれるメソッド
    public void OnStartButtonDown()
    {
        firstCanvas.SetActive(false);
        nextCanvas.SetActive(true);
    }

    //DropDownListの値が変わったら呼ばれるメソッド
    public void OnDropDownValueChanged()
    {
        var drop = dropdown.GetComponent<Dropdown>();
        //InputFieldとlabel?を増減させる

        switch (drop.value)
        {
            case 0:
                no1.SetActive(true);
                no2.SetActive(false);
                no3.SetActive(false);
                no4.SetActive(false);
                break;
            case 1:
                no1.SetActive(true);
                no2.SetActive(true);
                no3.SetActive(false);
                no4.SetActive(false);
                break;
            case 2:
                no1.SetActive(true);
                no2.SetActive(true);
                no3.SetActive(true);
                no4.SetActive(false);
                break;
            case 3:
                no1.SetActive(true);
                no2.SetActive(true);
                no3.SetActive(true);
                no4.SetActive(true);
                break;
            default:
                break;
        }
    }

    //GOButtonが押されたら呼ばれるメソッド
    public void OnGOButtonDown()
    {
        var numberOfPlayer = dropdown.value;
        numberOfPlayer++;
        var playersName = new List<string>();

        for (int i = 0; i < numberOfPlayer; i++)
        {
            playersName.Add(inputFields[i].text);
        }

        StaticClassTest.TakeData(playersName);

        SceneManager.LoadScene("Game");
    }
}
