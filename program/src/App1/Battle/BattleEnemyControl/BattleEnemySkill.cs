using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//敵キャラの中に３つ保存されているスキルの変数管理クラス
public class BattleEnemySkill : SetVoid1
{
    //個別の番号
    int num1;

    public int on;

    public String skill_name;
    public int skill_wait_time;

    public int normal_attack_flag;

    public int attack_count;
    public int attack_num_wait_time;//複数回攻撃の場合の待ち時間


    public int action_type1;
    public int[] action_free_box = new int[9];
    public String action_str;





    public BattleEnemySkill(Summary1 s1, int num1)
    {
        set1(s1);
        this.num1 = num1;
    }

    public void init1()
    {
        on = 0;

        skill_name = "";
        skill_wait_time = 0;

        attack_count = 0;
        attack_num_wait_time = 0;

        normal_attack_flag = 0;

        {
            action_type1 = 0;

            for (int t1 = 0; t1 < 9; t1++)
            {
                action_free_box[t1] = 0;
            }

            action_str = "";
        }
    }

    public void skill_set(String name)
    {
        skill_set(name, 60);
    }

    public void skill_set(String name,int skill_wait_time)
    {
        init1();

        on = 1;

        skill_name = name;
        this.skill_wait_time = skill_wait_time;

        attack_count = 1;
        attack_num_wait_time = 8;
    }

    public int attack_num_wait_time_call()
    {
        return attack_num_wait_time;
    }

    public void normal_attack_set()
    {
        init1();

        on = 1;

        normal_attack_flag = 1;

        skill_name = "";
        skill_wait_time = 0;
    }

    public int normal_attack_check()
    {
        int nt = 0;

        if (normal_attack_flag != 0) { nt = 1; }

        return nt;
    }

    public int skill_attack_check()
    {
        int nt = 1 - normal_attack_check();
        if (on == 0) nt = 0;
        return nt;
    }


    //特殊な行動---------------------------------------------------

    //実行は、「battle_enemy_skill_run」
    public void null1() { s1.battle_run.battle_enemy_skill_run.init1(); }

    //１つのマナの色を特定のマナの色に変換
    public void mana_change1_set(int mana_type1_1, int mana_type1_2, int per1)
    {
        action_type1 = s1.battle_run.battle_enemy_skill_run.ACTION_MANA_CHANGE1;

        action_free_box[0] = mana_type1_1;
        action_free_box[1] = mana_type1_2;
        action_free_box[2] = per1;

        //    s1.battle_run.battle_enemy_group.battle_enemy[link1].battle_enemy_skill[slot_memo].mana_type1_change_set(mana_type1_1, mana_type1_2, per1);
    }

    //---------------------------------------------------

}
