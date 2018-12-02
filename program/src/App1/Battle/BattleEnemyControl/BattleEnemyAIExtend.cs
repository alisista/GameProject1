using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleEnemyAIExtend : SetVoid1
{
    public int slot_memo;
    public int skill_slot_count;
    public int link1;
    public int type1;

    public void init1()
    {
        slot_memo = 0;
        skill_slot_count = 0;
        link1 = 0;
    }

    public void normal_attack_set()
    {
        //    m1.msbox("link:" + link1+" , " +skill_slot_count);
        s1.battle_run.battle_enemy_group.battle_enemy[link1].battle_enemy_skill[skill_slot_count].normal_attack_set();
    }

    public int skill_set(String name)
    {
        int nt = skill_slot_count;

        if (skill_slot_count <= 2)
        {
            s1.battle_run.battle_enemy_group.battle_enemy[link1].battle_enemy_skill[skill_slot_count].skill_set(name);

            slot_memo = skill_slot_count;
            skill_slot_count++;
        }

        return skill_slot_count;
    }

    public int skill_set(String name, int skill_wait_time)
    {
        int nt = skill_slot_count;

        if (skill_slot_count <= 2)
        {
            s1.battle_run.battle_enemy_group.battle_enemy[link1].battle_enemy_skill[skill_slot_count].skill_set(name, skill_wait_time);

            slot_memo = skill_slot_count;
            skill_slot_count++;
        }

        return skill_slot_count;
    }


    //特殊な行動---------------------------------------------------

    //１つのマナの色を特定のマナの色に変換
    public void mana_change1_set(int mana_type1_1,int mana_type1_2,int per1)
    {
        s1.battle_run.battle_enemy_group.battle_enemy[link1].battle_enemy_skill[slot_memo].mana_change1_set(mana_type1_1, mana_type1_2, per1);
    }

    /*
    //２つのマナの色を特定のマナの色に変換
    public void mana_type1_change_set(int mana_type1_1, int mana_type1_2, int per1)
    {

    }
    */

    //---------------------------------------------------


    public int type1_check(int type1)
    {
        int nt = 0;
        if (this.type1 == type1) { nt = 1; }
        return nt;
    }

    public void normal_attack()
    {
        normal_attack_set();

        skill_slot_count++;
    }

    public void normal_attack2()
    {
        normal_attack_set();
    }
}
