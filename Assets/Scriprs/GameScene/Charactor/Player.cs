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

    public int level { get; set; }
    public int hp { get; set; }
    public int attackPoint { get; set; }
    public int defencePoint { get; set; }
    public int magicAttackPoint { get; set; }
    public int magicDefencePoint { get; set; }
    public int speed { get; set; }

    private void Start()
    {
        isMoving = false;
        //firstMass = true;
        //Roll();
        //Move();

        level = 5;
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
}