using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵を定義するクラス
/// </summary>
public class Enemy : IBattleable
{
    int hp;

    public int Syuzokuchi { get; set; }
    public int Level { get; set; }
    public int MaxHp { get; set; }
    public int HP
    {
        get => hp;
        set => hp = value <= 0 ? 0 : value;
    }
    public int AttackPoint { get; set; }
    public int DefencePoint { get; set; }
    public int MagicAttackPoint { get; set; }
    public int MagicDefencePoint { get; set; }
    public int Speed { get; set; }

    /// <summary>
    /// 敵が攻撃するメソッド
    /// </summary>
    /// <returns>処理結果の文字列</returns>
    public string Attack()
    {
        return "敵の攻撃！";
    }

    /// <summary>
    /// 敵にダメージを与えるメソッド
    /// </summary>
    /// <param name="damagePoint">受けたダメージ量</param>
    /// <returns>処理結果の文字列、戦闘終了したか(HPが0を下回ったかどうか)</returns>
    public (List<string>, bool) BeDamaged(int damagePoint)
    {
        var returnList = new List<string>();
        returnList.Add($"敵に{damagePoint}のダメージ");
        HP -= damagePoint;
        returnList.Add($"敵のHPが{HP}になった。");
        if (HP <= 0)
        {
            returnList.Add($"敵は倒れた");
            return (returnList, true);
        }
        return (returnList, false);
    }
}
