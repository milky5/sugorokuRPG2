using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトをScene上で動かすためのインターフェイス
/// </summary>
public interface IMoveable
{
    bool isMoving { get; set; }
    bool firstMass { get; set; }
    StoryList story { get; set; }
    EnemyList enemy { get; set; }

    /// <summary>
    /// 動かすための処理を記載するメソッド
    /// </summary>
    void Move();
}
