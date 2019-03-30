using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Charactor, IRollable, IMoveable, IBattleable
{
    //public string playerName;
    string haveitem;
    List<ItemList> items;
    public int money;

    public bool isActive;
    public int remainMass { get; set; }
    public bool isMoving { get; set; }
    public bool firstMass { get; set; }
    public StoryList story { get; set; }

    public Setter setter = new Setter();
    public PropatySetter hpSetter;
    public PropatySetter attackSetter;
    public PropatySetter defenceSetter;
    public PropatySetter magicAttackSetter;
    public PropatySetter magicDefenceSetter;
    public PropatySetter speedSetter;

    int hp;
    int attackPoint;
    int defencePoint;
    int magicAttackPoint;
    int magicDefencePoint;
    int speed;

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
    public int AttackPoint
    {
        get
        {
            return attackPoint;
        }
        private set
        {
            attackPoint = attackSetter(value);
        }
    }
    public int DefencePoint
    {
        get
        {
            return defencePoint;
        }
        private set
        {
            defencePoint = defenceSetter(value);
        }
    }
    public int MagicAttackPoint
    {
        get
        {
            return magicAttackPoint;
        }
        private set
        {
            magicAttackPoint = magicAttackSetter(value);
        }
    }
    public int MagicDefencePoint
    {
        get
        {
            return magicDefencePoint;
        }
        private set
        {
            magicDefencePoint = magicDefenceSetter(value);
        }
    }
    public int Speed
    {
        get
        {
            return speed;
        }
        private set
        {
            speed = speedSetter(value);
        }
    }

    private void Start()
    {
        isMoving = false;
        //firstMass = true;
        //Roll();
        //Move();

        hpSetter = new PropatySetter(setter.SetSetter);
        attackSetter = new PropatySetter(setter.SetSetter);
        defenceSetter = new PropatySetter(setter.SetSetter);
        magicAttackSetter = new PropatySetter(setter.SetSetter);
        magicDefenceSetter = new PropatySetter(setter.SetSetter);
        speedSetter = new PropatySetter(setter.SetSetter);

        Level = 5;
        MaxHp = 21;
        hp = 21;
        attackPoint = 11;
        defencePoint = 11;
        magicAttackPoint = 11;
        magicDefencePoint = 11;
        speed = 11;

    }

    private void Update()
    {
        if (isMoving)
        {
            //通常用
            //transform.Translate(new Vector3(1f, 0, 0)*Time.deltaTime);
            //イーブイ用
            transform.Translate(new Vector3(0, 0, 2f) * Time.deltaTime);
        }
    }

    public string Attack()
    {
        return $"{charactorName}の攻撃";
    }

    public (List<string>, bool) BeDamaged(int damagePoint)
    {
        var returnList = new List<string>();
        returnList.Add($"{charactorName}に{damagePoint}のダメージ");
        hp -= damagePoint;
        returnList.Add($"{charactorName}のHPが{hp}になった。");
        if (hp <= 0)
        {
            returnList.Add($"{charactorName}は倒れた");
            return (returnList, true);
        }
        return (returnList, false);
    }

    public void Move()
    {
        //firstMass = true;
        isMoving = true;
    }

    public void Roll()
    {
        //remainMass = Random.Range(1, 7);
        remainMass = 4;
        Debug.Log($"出目は{remainMass}");
    }

    public void LevelUp()
    {
        //レベルを1上げて、ステータスの計算をし、代入
        //その際、maxhpとhpも上書きする
    }

    public void ReplaceHP(int value)
    {
        //HPを置き換える
    }
}