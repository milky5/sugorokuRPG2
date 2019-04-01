using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// プレイヤーを動かすメソッドを定義するクラス
/// </summary>
public class PlayerMover : MonoBehaviour
{
    /// <summary>
    /// プレイヤーを動かすメソッド
    /// </summary>
    /// <param name="player">アクティブプレイヤ</param>
    /// <param name="diceNumber">サイコロの出目</param>
    public void Move(Player player ,int diceNumber)
    {
        player.remainMass = diceNumber;
        player.Move();
    }
}
