using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleEnemyAttackRun : SetVoid1
{
    //個別の番号 仲間のバトルキャラの番号リンクに連動
    int num1;

    public int on;

    public int attack_wait_time;

    BattleEnemyAttackDamageCalc battle_enemy_attack_damage_calc;


    public BattleEnemyAttackRun(Summary1 s1, int num1)
    {
        set1(s1);
        this.num1 = num1;

        battle_enemy_attack_damage_calc = new BattleEnemyAttackDamageCalc(s1, num1);
    }

    public void init1()
    {
        on = 0;

        attack_wait_time = 0;

        battle_enemy_attack_damage_calc.init1();
    }

    public void attack_wait_set()
    {
        on = 1;

        attack_wait_time = 8;

        //スキルを使用する場合は、ここで名前の表示
        {
            int slot1 = s1.battle_run.battle_enemy_group.battle_enemy[num1].skill_slot;

            if (s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].on != 0
             && s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].skill_attack_check() != 0
                )
            {
                String st1 = s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].skill_name;

                s1.battle_run.battle_message_window.message_stock(st1);
                s1.battle_run.battle_message_window.draw_wait_set(76);

                attack_wait_time = 12;
            }
        }
    }

    /*
    public void skill_wait_set()
    {
        attack_wait_set();


    }*/

    public void attack_on1()
    {
    //    m1.msbox();
        battle_enemy_attack_damage_calc.attack_on1();

        //ここで所有しているスキルの効果発動
        {
            int slot1 = s1.battle_run.battle_enemy_group.battle_enemy[num1].skill_slot;

            s1.battle_run.battle_enemy_skill_run.skill_call1(num1,slot1);
        }
    }

    public void run1()
    {
        if (attack_wait_time >= 1)
        {
            if (attack_wait_time == 1)
            {
                int end_flag = 1;

                //同時連続攻撃がある場合はループ
                {
                    for (int t1 = 0; t1 <= 0; t1++)
                    {
                        attack_on1();
                    }
                }

                //スキルによる連続攻撃がある場合は、カウンターを再びチャージ
                {
                    int slot1 = s1.battle_run.battle_enemy_group.battle_enemy[num1].skill_slot;

                    if (s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].on != 0)
                    {
                        int count1 = s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].attack_count;

                        if (count1 >= 1 + 1)
                        {
                            s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].attack_count -= 1;

                            attack_wait_time = s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].attack_num_wait_time_call();
                        }
                    }
                }

                if (end_flag == 1)
                {
                    on = 0;
                }
            }

            attack_wait_time--;
        }
    }

    public void draw1()
    {
    }
}
