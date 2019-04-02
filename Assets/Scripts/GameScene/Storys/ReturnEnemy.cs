using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy型インスタンスを返すメソッドが定義されているクラス
/// </summary>
public class ReturnEnemy : MonoBehaviour
{
    Enemy enemy;

    /// <summary>
    /// EnemyListを基にEnemy型インスタンスを返します
    /// </summary>
    /// <param name="enemyType">選択された敵の強さ</param>
    /// <returns>引数を基に作成したEnemy型インスタンス</returns>
    public Enemy ReturnEnemmy(EnemyList enemyType)
    {
        switch (enemyType)
        {
            case EnemyList.enemy1:
                //種族値30,レベル5
                enemy = new Enemy
                {
                    Syuzokuchi = 30,
                    Level = 5,
                    HP = 18,
                    AttackPoint = 8,
                    DefencePoint = 8,
                    MagicAttackPoint = 8,
                    MagicDefencePoint = 8,
                    Speed = 8
                };
                return enemy;

            case EnemyList.enemy2:
                //種族値30,レベル10
                enemy = new Enemy
                {
                    Syuzokuchi = 30,
                    Level = 10,
                    HP = 26,
                    AttackPoint = 11,
                    DefencePoint = 11,
                    MagicAttackPoint =11,
                    MagicDefencePoint = 11,
                    Speed = 11
                };
                return enemy;

            case EnemyList.enemy3:
                //種族値30,レベル20
                enemy = new Enemy
                {
                    Syuzokuchi = 30,
                    Level = 20,
                    HP = 42,
                    AttackPoint = 17,
                    DefencePoint = 17,
                    MagicAttackPoint = 17,
                    MagicDefencePoint = 17,
                    Speed = 17
                };
                return enemy;

            case EnemyList.enemy4:
                //種族値30,レベル25
                enemy = new Enemy
                {
                    Syuzokuchi = 30,
                    Level = 25,
                    HP = 50,
                    AttackPoint = 20,
                    DefencePoint = 20,
                    MagicAttackPoint = 20,
                    MagicDefencePoint = 20,
                    Speed = 20
                };
                return enemy;

            case EnemyList.enemy5:
                //種族値30,レベル30
                enemy = new Enemy
                {
                    Syuzokuchi = 30,
                    Level = 30,
                    HP = 58,
                    AttackPoint = 23,
                    DefencePoint = 23,
                    MagicAttackPoint = 23,
                    MagicDefencePoint = 23,
                    Speed = 23
                };
                return enemy;

            case EnemyList.enemy6:
                //種族値30,レベル35
                enemy = new Enemy
                {
                    Syuzokuchi = 30,
                    Level = 35,
                    HP = 66,
                    AttackPoint = 26,
                    DefencePoint = 26,
                    MagicAttackPoint = 26,
                    MagicDefencePoint = 26,
                    Speed = 26
                };
                return enemy;

            default:
                enemy = new Enemy
                {
                    Syuzokuchi = 30,
                    Level = 5,
                    HP = 20,
                    AttackPoint = 8,
                    DefencePoint = 8,
                    MagicAttackPoint = 8,
                    MagicDefencePoint = 8,
                    Speed = 10
                };
                return enemy;
        }
    }
}

/// <summary>
/// 敵の強さを選択するための列挙型
/// </summary>
public enum EnemyList
{
    enemy1,
    enemy2,
    enemy3,
    enemy4,
    enemy5,
    enemy6
}
