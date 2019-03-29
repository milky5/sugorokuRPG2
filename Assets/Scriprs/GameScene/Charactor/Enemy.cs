using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : IBattleable
{
    public int level { get; set; }
    public int hp { get; set; }
    public int attackPoint { get; set; }
    public int defencePoint { get; set; }
    public int magicAttackPoint { get; set; }
    public int magicDefencePoint { get; set; }
    public int speed { get; set; }
    public int syuzokuchi;

    public string Attack()
    {
        return "敵の攻撃！";
    }

    public (List<string>, bool) BeDamaged(int damagePoint)
    {
        var returnList = new List<string>();
        returnList.Add($"敵に{damagePoint}のダメージ");
        hp -= damagePoint;
        returnList.Add($"敵のHPが{hp}になった。");
        if (hp <= 0)
        {
            returnList.Add($"敵は倒れた");
            return (returnList, true);
        }
        return (returnList, false);
    }
}
