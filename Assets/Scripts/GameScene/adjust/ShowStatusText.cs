using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStatusText : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] CharactorStatusKeeper keeper;

    public void WriteText()
    {
        text.text =
            $"名前         : {keeper.player.charactorName}\n" +
            $"所持金       : {keeper.player.money}円\n" +
            $"\n" +
            $"レベル       : {keeper.player.Level}\n" +
            $"HP           : {keeper.player.HP}\n" +
            $"攻撃         : {keeper.player.AttackPoint}\n" +
            $"防御         : {keeper.player.DefencePoint}\n" +
            $"魔法攻撃     : {keeper.player.MagicAttackPoint}\n" +
            $"魔法防御     : {keeper.player.MagicDefencePoint}\n" +
            $"素早さ       : {keeper.player.Speed}\n";
    }
}
