using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleable
{
    int Syuzokuchi { get; set; }
    int Level { get; set; }
    int MaxHp { get; }
    int HP { get; set; }
    int AttackPoint { get; }
    int DefencePoint { get; }
    int MagicAttackPoint { get; }
    int MagicDefencePoint { get; }
    int Speed { get; }

    string Attack();
    (List<string>, bool) BeDamaged(int damagePoint);
}
