using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleSkillSupport : SetVoid1
{
    public int skill_type1;
    public int link1;

    public BattleSkillSupport(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        skill_type1 = 0;
    }

    public int skill_type1_check(int type1)
    {
        int nt1 = 0;
        if (skill_type1 == type1) { nt1 = 1; }
        return nt1;
    }

    public void hp_add2(int num1)
    {
        s1.battle_run.battle_member_group_status_control.hp_add(num1);

        int week_1_and_resist_2 = 0;
        s1.battle_run.battle_member_group_status_control.damage_draw_effect_set(-num1, week_1_and_resist_2, 0, 100, 0);
    }

    public void mp_add2(int num1)
    {
        s1.battle_run.battle_member_group_status_control.mp_add(num1);

        int week_1_and_resist_2 = 0;
        s1.battle_run.battle_member_group_status_control.damage_draw_effect_set(-num1, week_1_and_resist_2, 1, 101, 0);
    }

    public void skill_use(int use_character_link,int skill_num)
    {
        this.skill_type1 = skill_num;
        this.link1 = use_character_link;

        if (skill_type1_check(1) != 0)
        {
            int nt1 = 1000;
            mp_add2(nt1);
        }

        if (skill_type1_check(2) != 0)
        {
            int nt1 = -1000;
            mp_add2(nt1);
        }
    }


    public void run1()
    {
    }

    public void draw1()
    {
    }
}
