using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//ダメージ計算とかのクラス
public class BattleMemberAttackDamageCalc : SetVoid1
{
    //個別の番号
    int num1;

    public BattleMemberAttackDamageCalc(Summary1 s1, int num1)
    {
        set1(s1);
        this.num1 = num1;
    }

    public void init1()
    {

    }

    //理想の敵への攻撃を探す
    public int best_target_calc()
    {
        int target = 0;//-1;
        
        //ターゲットは評価が一番高いキャラに行う
        //
        {
            int[] damage_box = new int[s1.battle_run.battle_enemy_group.max()];

            for (int t1 = 0; t1 < s1.battle_run.battle_enemy_group.max(); t1++)
            {
                damage_box[t1] = 0;
            }

            for (int t1 = 0; t1 < s1.battle_run.battle_enemy_group.max(); t1++)
            {
                if (s1.battle_run.battle_enemy_group.battle_enemy[t1].alive_check() == 1)
                {
                    int max_hp = s1.battle_run.battle_enemy_group.battle_enemy[t1].call_mhp();
                    int hp = s1.battle_run.battle_enemy_group.battle_enemy[t1].call_hp();
                    int damage_var1 = damage_calc1(t1);

                    if (max_hp <= 0) { max_hp = 1; }

                    int per1 = m1.iover(100 * damage_var1 / max_hp, 1, 100);

                    damage_box[t1] = per1 * 10 + t1;
                }
            }

            int max = -1;

            for (int t1 = 0; t1 < s1.battle_run.battle_enemy_group.max(); t1++)
            {
                if (max < damage_box[t1] / 10)
                {
                    max = damage_box[t1] / 10;

                    target = damage_box[t1] % 10;
                }
            }
        }
        

        /*
        //とりあえず、生存している中で順番に
        {
            for (int t1 = 0; t1 < s1.battle_run.battle_enemy_group.max(); t1++)
            {
                if (s1.battle_run.battle_enemy_group.battle_enemy[t1].alive_check() == 1)
                {
                    target = t1;
                    break;
                }
            }
        }*/

        return target;
    }

    public void attack_on1()
    {
        int enemy_link = best_target_calc();//s.battle_enemy_group.enemy_rand_selete(0, 0);
        
        //ロック中は強制ターゲット
        if (s1.battle_run.battle_enemy_group.target_lock_num >= 0)
        {
            enemy_link = s1.battle_run.battle_enemy_group.target_lock_num;
        }

        //攻撃計算開始
        {
            int damage1 = damage_calc1(enemy_link);
            
            int att1_1 = s1.battle_run.battle_member_group.battle_member[num1].call_attribute_1();
            int att2_1 = s1.battle_run.battle_enemy_group.battle_enemy[enemy_link].call_now_attribute();
            int week_1_and_resist_2 = s1.am1.week_1_and_resist_2_call(att1_1, att2_1);          

            s1.battle_run.battle_enemy_group.battle_enemy[enemy_link].damage_set(damage1, 0, 0);
            s1.battle_run.battle_enemy_group.battle_enemy[enemy_link].damage_draw_effect_set(damage1, 0, week_1_and_resist_2, 0, 0, att1_1, 0);

            /*
            int att1 = s.battle_member_group.battle_member[num].battle_member_status.call_attribute_1();
            int att2 = s.battle_enemy_group.battle_enemy[enemylink].battle_enemy_status.call_attribute_1();
            int week_1_and_resist_2 = s.gm.week_1_and_resist_2_call(att1, att2);

            //敵にダメージを発生させる
            s.battle_enemy_group.battle_enemy[enemylink].damage_set(damage1, 1);
            s.battle_enemy_group.battle_enemy[enemylink].damage_draw_effect_set(damage1, 0, week_1_and_resist_2, 0, 0, att1, 0);
            */

            //攻撃音
            {
                //    s.gm.character_attack_se(s.battle_member_group.battle_member[num].race, week_1_and_resist_2, 0, 0, 0, 0, 0, 0);

                //   s1.sc1.se_play(s.so.SE_BATTLE_ATTACK_2);

                if (week_1_and_resist_2 == 0) { s1.sound_effect_operation.play_se(s1.sound_effect_operation.SE_BATTLE_ATTACK_2); }
                if (week_1_and_resist_2 == 1) { s1.sound_effect_operation.play_se(s1.sound_effect_operation.SE_BATTLE_ATTACK_1); }
                if (week_1_and_resist_2 == 2) { s1.sound_effect_operation.play_se(s1.sound_effect_operation.SE_BATTLE_ATTACK_3); }
            }
        }


        /*
        {
            int curse_type = 0;

            for (int t1 = 0; t1 < 6; t1++)
            {
                int num1 = s.battle_member_group.ability_num_call_only(num, 79 + t1);
                if (num1 >= 1)
                {
                    if (m.rand(99) + 1 <= 7 * num)
                    {
                        curse_type = s.battle_enemy_group.battle_enemy[enemylink].CURSE_SLEEP + t1;
                        break;
                    }
                }
            }

            //呪いがある場合は呪いも発生
            if (curse_type >= 1)
            {
                int int_1 = s.battle_member_group.battle_member[num].battle_member_status.call_battle_status(s.battle_member_group.battle_member[num].battle_member_status.STATUS_INT);
                s.battle_enemy_group.battle_enemy[enemylink].battle_enemy_status.curse_set_3(curse_type, int_1);
            }
        }
        */
    }//attack_on1()

    //ダメージ計算
    public int damage_calc1(int enemy_link)
    {
        int damage1 = 0;// m1.rand(100) + 50;

        int att1_1 = s1.battle_run.battle_member_group.battle_member[num1].call_attribute_1();
        int att2_1 = s1.battle_run.battle_enemy_group.battle_enemy[enemy_link].call_now_attribute();
        int week_1_and_resist_2 = s1.am1.week_1_and_resist_2_call(att1_1, att2_1);

        {
            damage1 = s1.battle_run.battle_member_group.battle_member[num1].call_atk();

            damage1 = damage1 * s1.battle_run.battle_member_group.battle_member[num1].call_mana_power() / 3 * 2 / 100;

            //弱点や抵抗の計算
            {
                if (week_1_and_resist_2 == 1)
                {
                    damage1 *= 2;
                }

                if (week_1_and_resist_2 == 2)
                {
                    damage1 /= 2;
                }
            }
        }

        return damage1;
    }
}
