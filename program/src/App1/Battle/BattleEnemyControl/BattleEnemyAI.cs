using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleEnemyAI : BattleEnemyAIExtend
{
    public BattleEnemyAI(Summary1 s1)
    {
        set1(s1);
    }
    
    //行動の設定
    public void skill_decide(int link1)
    {
        this.link1 = link1;
        this.type1 = s1.battle_run.battle_enemy_group.battle_enemy[link1].call_type1();

        skill_slot_count = 0;
        normal_attack2();

        if (type1_check(1) != 0)
        {
            skill_set("マナ変換");
            mana_change1_set(s1.am1.MANA_GREEN, s1.am1.MANA_YELLOW, 50);

            //    normal_attack();
            //   skill_set("テスト", 60);
            //    normal_attack();
            //    normal_attack();

            //                skill_set("テスト", 60);

            //    normal_attack();

            //skill_set("", 0);

            /*
            normal_attack();

            skill_set("テスト", 60);
            skill_set("テスト", 60);
            */
        }

        if (type1_check(3) != 0)
        {
        //    m1.msbox(""+link1);
         //   skill_set("テスト", 60);
        }

    }//skill_decide

    public void run1()
    {
    }

    public void draw1()
    {
    }
}
