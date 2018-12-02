using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleMemberGroupAttackRun : SetVoid1
{
    public int attack_tm;//攻撃の時間管理 1になると加算を始める
    public int attack_count;

    static int MAX1 = 6;
    public int max1() { return MAX1; }

    public BattleMemberAttackRun[] battle_member_attack_run = new BattleMemberAttackRun[MAX1];


    public BattleMemberGroupAttackRun(Summary1 s1)
    {
        set1(s1);

        for (int t1 = 0; t1 < max1(); t1++)
        {
            battle_member_attack_run[t1] = new BattleMemberAttackRun(s1, t1);
        }
    }

    public void init1()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
            battle_member_attack_run[t1].init1();
        }
    }

    public void member_all_attack_set()
    {
        attack_tm = 1;
        attack_count = 0;

        s1.battle_run.battle_mana.battle_mana_use_calc();

        s1.battle_run.battle_member_group.turn_end_status_change_flag = 0;
    }

    public void attack_end()
    {
        attack_tm = 0;

        

        s1.battle_run.battle_enemy_group.now_attribute_check();

        s1.battle_run.battle_flow1.next_call();
    }

    //単体での攻撃動作
    public void attack_set_member(int num)
    {
        s1.battle_run.battle_member_group.battle_member[num].attack_move_set();

        battle_member_attack_run[num].attack_wait_set();
    }


    public void run1()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
            battle_member_attack_run[t1].run1();
        }

        //まず自身が攻撃できるか確認
        if (attack_tm == 2)
        {
            int nm = attack_count;

            for (int t9 = nm; t9 < max1(); t9++)
            {
                int t1 = attack_count;

                int nt = 0;

                if (s1.battle_run.battle_member_group.battle_member[t1].alive_check() != 0
                 && s1.battle_run.battle_member_group.battle_member[t1].move_ok_check() == 1
                 && s1.battle_run.battle_member_group.battle_member[t1].attack_ok_check() == 1
                //    && s1.battle_run.battle_member_group.battle_member[t1].battle_member_status.curse_check(s.battle_member_group.battle_member[t1].battle_member_status.CURSE_PARALYZE) == 0
                )
                {
                    int att1 = s1.battle_run.battle_member_group.battle_member[t1].call_attribute_1();

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

            if (attack_count <= 5 && s1.battle_run.battle_enemy_group.alive_num_check() >= 1)
            {
                if (attack_tm == start_tm + 1)
                {
                    //    m.end();
                    attack_set_member(attack_count);

                    //    m1.msbox(attack_count);
                }
            }
            else
            {
                attack_no_move_flag = 1;

                //味方の通常の攻撃ターンの終了
                {
                    int np = 11 + 30;

                    if (attack_tm == 20)
                    {
                        s1.battle_run.battle_member_group.member_turn_end_call();
                    }

                    if (s1.battle_run.battle_member_group.turn_end_status_change_flag != 0)
                    {
                        np = 80;                        
                    }


                    /*
                    if (attack_tm == 30)
                    {
                        member_all_cure_act();
                    }
                
                    if (cure_check() == 1)
                    {
                        np = 45;
                    }
                    */

                    if (attack_tm >= np)
                    {
                        attack_end();
                    }
                }
            }


            if (attack_no_move_flag == 0 && attack_tm >= start_tm + 11)
            {
                attack_count++;
                attack_tm = 1;
            }
        }


        if (attack_tm >= 1 && attack_tm <= 999999)
        {
            attack_tm++;
        }
    }//run1()

    public void draw1()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
            battle_member_attack_run[t1].draw1();
        }
    }
}
