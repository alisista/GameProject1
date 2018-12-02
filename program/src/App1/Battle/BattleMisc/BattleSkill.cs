using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleSkill : SetVoid1
{
    public BattleSkillSupport battle_skill_support;

    public BattleSkill(Summary1 s1)
    {
        set1(s1);

        battle_skill_support = new BattleSkillSupport(s1);
    }

    public void init1()
    {
        battle_skill_support.init1();
    }

    public void skill_use(int use_character_link,int skill_num1)
    {
        battle_skill_support.skill_use(use_character_link, skill_num1);
    }

    public void run1()
    {
    }

    public void draw1()
    {
    }
}
