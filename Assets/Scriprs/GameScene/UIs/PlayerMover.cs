using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMover : MonoBehaviour
{
    public void Move(Player player ,int diceNumber)
    {
        player.remainMass = diceNumber;
        player.Move();
    }
}
