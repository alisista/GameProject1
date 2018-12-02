using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleEnemyGroupAttackRun : SetVoid1
{
    public int attack_tm;//攻撃の時間管理 1になると加算を始める
    public int attack_count;

    static int MAX1 = 6;
    public int max1() { return MAX1; }

    public BattleEnemyAttackRun[] battle_enemy_attack_run = new BattleEnemyAttackRun[MAX1];

    public int skill_end_flag; //最後の攻撃が、通常かスキルかを判断するもの


    public BattleEnemyGroupAttackRun(Summary1 s1)
    {
        set1(s1);

        for (int t1 = 0; t1 < max1(); t1++)
        {
            battle_enemy_attack_run[t1] = new BattleEnemyAttackRun(s1, t1);
        }
    }

    public void init1()
    {
        attack_tm = 0;
        attack_count = 0;
        skill_end_flag = 0;

        for (int t1 = 0; t1 < max1(); t1++)
        {
            battle_enemy_attack_run[t1].init1();
        }
    }




    public void enemy_all_attack_set()
    {
        attack_tm = 1;
        attack_count = 0;

        s1.battle_run.battle_enemy_group.skill_decide();
    }
    
    public void attack_end()
    {
        attack_tm = 0;

        s1.battle_run.battle_enemy_group.skill_reset();

        s1.battle_run.battle_member_group.turn_end_call();

        skill_end_flag = 0;

        s1.battle_run.battle_flow1.next_call();
    }

    //単体での攻撃動作
    public void attack_set_enemy(int num)
    {
        s1.battle_run.battle_enemy_group.battle_enemy[num].attack_move_set();

        battle_enemy_attack_run[num].attack_wait_set();
    }
    


    public void run1()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
            battle_enemy_attack_run[t1].run1();
        }

        //まず自身が攻撃できるか確認
        if (attack_tm == 2)
        {
            int nm = attack_count;

            for (int t9 = nm; t9 < max1(); t9++)
            {
                int t1 = attack_count;

                int nt = 0;

                if (s1.battle_run.battle_enemy_group.battle_enemy[t1].alive_check() != 0
                //    && s1.battle_run.battle_enemy_group.battle_enemy[t1].move_ok_check() == 1
                //    && s1.battle_run.battle_member_group.battle_member[t1].battle_member_status.curse_check(s.battle_member_group.battle_member[t1].battle_member_status.CURSE_PARALYZE) == 0
                )
                {
                    int att1 = s1.battle_run.battle_enemy_group.battle_enemy[t1].call_attribute_1();

                    //    m.msbox(att1);

                    //    if (attack_power_call(att1) >= 1)

                    //    if (s.battle_member_group.battle_member[t1].battle_member_status.call_attack_power() >= 1)
                    {
                        nt = 1;
                        //    m.end();
                    }
                }

                if (nt == 1)
                {
                    break;
                }
                else
                {
                    attack_count++;
                    //    m.end();
                }
            }
        }

        int start_tm = 2;//10;

        if (attack_tm == start_tm)
        {
            //    defeat_check();
        }

        if (attack_tm >= start_tm + 1)
        {
            int attack_no_move_flag = 0;
            int skill_tm = 0;

            //スキルを使用する場合は、スキルになっている分を遅延させる
            if (attack_count <= 5)
            {
                {
                    int num1 = attack_count;
                    int slot1 = s1.battle_run.battle_enemy_group.battle_enemy[num1].skill_slot;

                    if (s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].on != 0)
                    {
                        if (s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].normal_attack_check() == 0)
                        {
                            skill_tm = s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].skill_wait_time;

                            skill_end_flag = 1;
                        }
                        else
                        {
                            skill_end_flag = 0;
                        }

                        if (slot1 <= 1)
                        {
                            if (skill_end_flag == 0
                             && s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1 + 1].on != 0
                             )
                            {
                                if (s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1 + 1].normal_attack_check() == 0)
                                {
                                    skill_tm = 30;
                                }
                                else
                                {
                                    skill_tm = 8;
                                }
                            }
                        }
                    }

                        /*
                        if (s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].on != 0)
                        {
                            skill_tm = s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].skill_wait_time;

                            skill_end_flag = 1;
                        }

                        if (s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].on == 0 || s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].normal_attack_check() == 1)
                        {
                            skill_end_flag = 0;
                        }

                        if (s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[0].on == 0
                         && s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[1].on != 0
                         && slot1 == 0
                            )
                        {
                            skill_tm = 40;
                        }
                        */
                    }
            }


            if (attack_count <= 5 && s1.battle_run.battle_enemy_group.alive_num_check() >= 1)
            {
                if (attack_tm == start_tm + 1)
                {
                    attack_set_enemy(attack_count);

                    //    if (skill_use_flag == 0) { attack_set_enemy(attack_count); }
                    //    if (skill_use_flag != 0) { skill_set_enemy(attack_count); }

                }
            }
            else
            {
                attack_no_move_flag = 1;

                //敵の通常の攻撃ターンの終了
                {
                    int np = 11 + 30 * 1;// + skill_tm;
                                         //    if (skill_tm >= 1) { np -= 130; }

                    if (skill_end_flag == 1) { np = 1; }

                    if (attack_tm >= np)
                    {
                        attack_end();
                    }
                }
            }


            if (attack_no_move_flag == 0 && attack_tm >= start_tm + 11+ skill_tm)
            {
                {
                    int nt3 = 1;

                    int num1 = attack_count;                    
                    s1.battle_run.battle_enemy_group.battle_enemy[num1].skill_slot_next();

                    int slot1 = s1.battle_run.battle_enemy_group.battle_enemy[num1].skill_slot;

                    if (slot1 >= 3)
                    {

                    }
                    else
                    {
                        //skillslotが2、もしくは、次のスキルがない場合は次の敵へ。そうでないなら、もう１回行動                        
                        if (s1.battle_run.battle_enemy_group.battle_enemy[num1].battle_enemy_skill[slot1].on != 0)
                        {
                            nt3 = 0;
                        }
                    }

                    if (nt3 == 1)
                    {
                        //攻撃するキャラクターの変更
                        attack_count++;
                    }
                }

                attack_tm = 1;
            }
        }


        if (attack_tm >= 1 && attack_tm <= 999999)
        {
            attack_tm++;
        }
    }

    public void draw1()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
            battle_enemy_attack_run[t1].draw1();
        }

    }
}
