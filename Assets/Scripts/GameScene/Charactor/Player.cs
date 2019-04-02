using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーを定義するクラス
/// </summary>
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
    public EnemyList enemy { get; set; }

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

    public int Syuzokuchi { get; set; }
    public int Level { get; set; }
    public int MaxHp { get; set; }
    public int HP
    {
        get => hp;
        set => hp = value <= 0 ? 0 : value;
    }
    public int AttackPoint
    {
        get => attackPoint;
        private set => attackPoint = attackSetter(value);
    }
    public int DefencePoint
    {
        get => defencePoint;
        private set => defencePoint = defenceSetter(value);
    }
    public int MagicAttackPoint
    {
        get => magicAttackPoint;
        private set => magicAttackPoint = magicAttackSetter(value);
    }
    public int MagicDefencePoint
    {
        get => magicDefencePoint;
        private set => magicDefencePoint = magicDefenceSetter(value);
    }
    public int Speed
    {
        get => speed;
        private set => speed = speedSetter(value);
    }

    /// <summary>
    /// ゲームスタート時に値をセットするメソッド
    /// </summary>
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

        Syuzokuchi = 60;
        Level = 5;
        MaxHp = 21;
        hp = 21;
        attackPoint = 11;
        defencePoint = 11;
        magicAttackPoint = 11;
        magicDefencePoint = 11;
        speed = 11;

    }

    /// <summary>
    /// 1フレーム毎に呼ばれ、オブジェクトを動かすメソッド
    /// </summary>
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

    /// <summary>
    /// プレイヤーが攻撃するメソッド
    /// </summary>
    /// <returns>処理結果の文字列</returns>
    public string Attack()
    {
        return $"{charactorName}の攻撃";
    }

    /// <summary>
    /// プレイヤーがダメージを受けるメソッド
    /// </summary>
    /// <param name="damagePoint">受けたダメージ量</param>
    /// <returns>処理結果の文字列、戦闘終了したか(HPが0になったか)</returns>
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

    /// <summary>
    /// オブジェクトを動かせるようにするメソッド
    /// </summary>
    public void Move()
    {
        isMoving = true;
    }

    /// <summary>
    /// サイコロを振るためのメソッド
    /// </summary>
    public void Roll()
    {
        //remainMass = Random.Range(1, 7);
        remainMass = 4;
        Debug.Log($"出目は{remainMass}");
    }

    /// <summary>
    /// レベルを1上げるメソッド
    /// </summary>
    public void LevelUp()
    {
        Level++;

        (var newHp, var newAbcds) = StatusCalc.StatusCalclator(Level,Syuzokuchi);
        MaxHp = newHp;
        AttackPoint = newAbcds;
        DefencePoint = newAbcds;
        MagicAttackPoint = newAbcds;
        MagicDefencePoint = newAbcds;
        Speed = newAbcds;

        HP = MaxHp;
    }

    /// <summary>
    /// HPを更新するメソッド
    /// </summary>
    /// <param name="value">HPの増減量</param>
    public void ReplaceHP(int value)
    {
        //HPを置き換える
    }
}