using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : IBattleable
{
    int hp;

    public int Level { get; set; }
    public int MaxHp { get; set; }
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            if (value <= 0)
            {
                hp = 0;
            }
            else
            {
                hp = value;
            }
        }
    }
    public int AttackPoint { get; set; }
    public int DefencePoint { get; set; }
    public int MagicAttackPoint { get; set; }
    public int MagicDefencePoint { get; set; }
    public int Speed { get; set; }
    public int syuzokuchi;

    public string Attack()
    {
        return "敵の攻撃！";
    }

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
