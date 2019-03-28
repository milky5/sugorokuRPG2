using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleable
{

    int level { get; set; }
    int hp { get; set; }
    int attackPoint { get; set; }
    int defencePoint { get; set; }
    int magicAttackPoint { get; set; }
    int magicDefencePoint { get; set; }
    int speed { get; set; }

    string Attack();
    (List<string>, bool) BeDamaged(int damagePoint);

}
