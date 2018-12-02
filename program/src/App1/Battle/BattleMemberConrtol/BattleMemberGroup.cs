using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleMemberGroup : SetVoid1
{
    static int BATTLE_MEMBER_MAX2 = 6;
//    public int max() { return BATTLE_MEMBER_MAX2; }

    public BattleMember[] battle_member = new BattleMember[BATTLE_MEMBER_MAX2];

    public int member_data_max() { return BATTLE_MEMBER_MAX2; }


    public int turn_end_status_change_flag;


    public BattleMemberGroup(Summary1 s1)
    {
        set1(s1);
        
        for (int t1 = 0; t1 < member_data_max(); t1++)
        {
            battle_member[t1] = new BattleMember(s1, t1);
        }
    }

    public void init1()
    {
        for (int t1 = 0; t1 < member_data_max(); t1++)
        {
            battle_member[t1].init1();

            
        }

        /*
        {
          //  battle_member[0].character_link_set_and_create(0);
            
            battle_member[0].character_link_set_and_create(0);
            battle_member[1].character_link_set_and_create(1);
            battle_member[2].character_link_set_and_create(2);
            battle_member[3].character_link_set_and_create(3);
            battle_member[4].character_link_set_and_create(4);
            battle_member[5].character_link_set_and_create(5);            
        }
        */

        if (s1.base_run != null)
        {
            if (s1.base_run.party_select_group != null)
            {
                for (int t1 = 0; t1 < 6; t1++)
                {
                    int link_num = s1.base_run.party_select_group.party_call(t1);

                    if (link_num != s1.am1.character_null_num())
                    {
                        battle_member[t1].character_link_set_and_create(link_num);
                    }
                }
            }
            else
            {
                for (int t1 = 0; t1 < 6; t1++)
                {
                    battle_member[t1].character_link_set_and_create(t1);
                }
            }
        }

        /*
        {
            battle_member[0].create1(1, 1, 0, 0, 0, 0);
            battle_member[1].create1(2, 1, 0, 0, 0, 0);

            battle_member[3].create1(3, 1, 0, 0, 0, 0);
            battle_member[4].create1(1, 1, 0, 0, 0, 0);
        }
        */

        turn_end_status_change_flag = 0;
    }


    public int member_on_check(int num1)
    {
        int nt1 = 0;

        nt1= battle_member[num1].on;

        return nt1;
    }

    public int enchantment_use_ok(int num1)
    {
        int nt1 = 0;

        if (member_on_check(num1) != 0)
        {
            nt1 = 1;
        }

        return nt1;
    }

    public int skill_use_ok(int num1)
    {
        int nt1 = 0;

        if (member_on_check(num1) != 0)
        {
            nt1 = 1;
        }

        return nt1;
    }

    public int attack_ok(int num1)
    {
        int nt1 = 0;

        if (member_on_check(num1) != 0)
        {
            nt1 = 1;
        }

        return nt1;
    }

    public String enchantment_name_call(int num1)
    {
        String name1 = "";

        if (member_on_check(num1) != 0)
        {
            int type1 = battle_member[num1].call_type1();

            name1 = s1.data_magagement.enchantment_data.enchantment_name(type1);
        }

        return name1;
    }


    public void battle_continue1()
    {
        m1.msbox("all_cure!");
    }

    public void all_use_skill_flag_cure()
    {
        for (int t1 = 0; t1 < member_data_max(); t1++)
        {
            battle_member[t1].use_skill_flag = 0;
        }
    }

    public int call_member_attribute()
    {
        int nt = s1.am1.call_member_attribute();

        return nt;
    }

    //ターン終了時に呼び出し
    public void turn_end_call()
    {
        s1.battle_run.battle_member_group_status_control.battle_command = 0;

        all_use_skill_flag_cure();

        s1.battle_run.battle_mana.turn_end_mana_cure();
    }

    public void member_turn_end_call()
    {
        //HPとMPを回復
        {
            int cure1 = member_cure_point(0);
            int cure2 = member_cure_point(1);

            s1.battle_run.battle_member_group_status_control.hp_add2(cure1);
            s1.battle_run.battle_member_group_status_control.mp_add2(cure2);

            if (cure1 != 0 || cure2 != 0) { turn_end_status_change_flag = 1; }
        }
    }

    public int member_cure_point(int hp_0__mp_1)
    {
        int nt = 0;

        for (int t1 = 0; t1 < member_data_max(); t1++)
        {
            if (member_on_check(t1) != 0)
            {
                nt += battle_member[t1].call_cure_point(hp_0__mp_1);
            }
        }

        return nt;
    }

    public void run1()
    {
        for (int t1 = 0; t1 < member_data_max(); t1++)
        {
            battle_member[t1].run1();
        }
    }

    public void draw1()
    {
        for (int t1 = 0; t1 < member_data_max(); t1++)
        {
            battle_member[t1].draw1();
        }
    }
}
