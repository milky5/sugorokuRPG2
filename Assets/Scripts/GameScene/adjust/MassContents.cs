using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 止まったマスで何の処理をするのかを保持するデリゲート
/// </summary>
/// <param name="player">そのマスに止まったプレイヤー</param>
/// <returns>処理結果の文字列</returns>
public delegate string[] MassContents(Player player);