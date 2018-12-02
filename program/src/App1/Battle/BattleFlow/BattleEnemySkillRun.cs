using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleEnemySkillRun : SetVoid1
{
    public int slot_memo;

    public int ACTION_MANA_CHANGE1 = 1;

    public BattleEnemySkillRun(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        slot_memo = 0;
    }

    public void skill_call1(int bclink1, int slot1)
    {
        slot_memo = slot1;
        int action_type1 = s1.battle_run.battle_enemy_group.battle_enemy[bclink1].battle_enemy_skill[slot1].action_type1;
        int[] action_free_box= s1.battle_run.battle_enemy_group.battle_enemy[bclink1].battle_enemy_skill[slot1].action_free_box;

        //通常のマナ変換
        if (action_type1 == ACTION_MANA_CHANGE1)
        {
            int att1_1 = action_free_box[0];
            int att1_2 = action_free_box[1];
            int per1 = action_free_box[2];

            s1.battle_run.battle_mana.enemy_mana_change(att1_1, att1_2, per1);

            //    m1.msbox("1");
        }



    }//skill_call1()


    public void run1()
    {
    }

    public void draw1()
    {
    }
}
