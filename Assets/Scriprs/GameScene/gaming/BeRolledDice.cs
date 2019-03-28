#pragma warning disable 0649 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeRolledDice : MonoBehaviour
{
    [SerializeField] GameObject fakeDice;
    [SerializeField] GameObject realDice;
    Vector3 dicePosition;
    float realDiceDefaltPosY = 4.0f;


    public void OnRollingExit(int diceNumber)
    {
        realDice.SetActive(false);
        fakeDice.SetActive(true);
    }

    public void OnMoveExit()
    {
        fakeDice.SetActive(false);
    }

    public void OnActivePlayerChanged(GameObject playerObj)
    {
        float posX = playerObj.transform.position.x;
        float posY = transform.position.y;
        float posZ = transform.position.z;
        gameObject.transform.position = new Vector3(posX, posY, posZ);
        realDice.transform.position = new Vector3(posX, realDiceDefaltPosY, posZ);
    }
}
