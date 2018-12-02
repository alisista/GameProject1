using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleEnemyAttackDamageCalc : SetVoid1
{
    //個別の番号
    int num1;

    public BattleEnemyAttackDamageCalc(Summary1 s1, int num1)
    {
        set1(s1);
        this.num1 = num1;
    }

    public void init1()
    {

    }
    
    public void attack_on1()
    {
     //   int enemylink = best_target_calc(0);//s.battle_enemy_group.enemy_rand_selete(0, 0);
        

        //攻撃計算開始
        {
            /*
            int damage1 = damage_calc1(enemylink);


            int week_1_and_resist_2 = 0;// s.gm.week_1_and_resist_2_call(att1, att2)

            int att1_1 = s1.battle_run.battle_member_group.battle_member[num1].call_attribute_1();
            int att2_1 = s1.battle_run.battle_enemy_group.battle_enemy[enemylink].call_attribute_1();

            s1.battle_run.battle_enemy_group.battle_enemy[enemylink].damage_set(damage1, 0, 0);
            s1.battle_run.battle_enemy_group.battle_enemy[enemylink].damage_draw_effect_set(damage1, 0, week_1_and_resist_2, 0, 0, att1_1, 0);
            */

            {
                int damage1 = damage_calc1();

                int att1_1 = s1.battle_run.battle_enemy_group.battle_enemy[num1].call_attribute_1();
                int att2_1 = s1.battle_run.battle_member_group.call_member_attribute();
                int week_1_and_resist_2 = s1.am1.week_1_and_resist_2_call(att1_1, att2_1);


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


                s1.battle_run.battle_member_group_status_control.hp_damage_set(damage1, 0, 0);
                s1.battle_run.battle_member_group_status_control.damage_draw_effect_set(damage1, week_1_and_resist_2, 0, att1_1, 1);

                //攻撃音
                {
                    if (week_1_and_resist_2 == 0) { s1.sound_effect_operation.play_se(s1.sound_effect_operation.SE_BATTLE_ATTACK_2); }
                    if (week_1_and_resist_2 == 1) { s1.sound_effect_operation.play_se(s1.sound_effect_operation.SE_BATTLE_ATTACK_1); }
                    if (week_1_and_resist_2 == 2) { s1.sound_effect_operation.play_se(s1.sound_effect_operation.SE_BATTLE_ATTACK_3); }
                }
            }

            /*
            //攻撃音
            {
                //    s.gm.character_attack_se(s.battle_member_group.battle_member[num].race, week_1_and_resist_2, 0, 0, 0, 0, 0, 0);

                //   s1.sc1.se_play(s.so.SE_BATTLE_ATTACK_2);

            //    m1.msbox();

                s1.so1.play_se(s1.so1.SE_BATTLE_ATTACK_2);
            }
            */
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
    public int damage_calc1()
    {
        int damage1 = 0;// m1.rand(100) + 50;

        damage1 = s1.battle_run.battle_enemy_group.battle_enemy[num1].call_atk();

        return damage1;
    }
}
