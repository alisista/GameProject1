using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleEnemyGroup : SetVoid1
{
    public ImageSaveEnemy image_save_enemy;

    static int BATTLE_ENEMY_MAX2 = 6;
    public int max() { return BATTLE_ENEMY_MAX2; }

    public BattleEnemy[] battle_enemy = new BattleEnemy[BATTLE_ENEMY_MAX2];

    
    
    public BattleEnemyAppearControl battle_enemy_appear_control;

    public BattleEnemyAI battle_enemy_ai;


    public int target_lock_num;


    public BattleEnemyGroup(Summary1 s1)
    {
        set1(s1);

        for (int t1 = 0; t1 < max(); t1++)
        {
            battle_enemy[t1] = new BattleEnemy(s1, t1);
        }

        {
            image_save_enemy = new ImageSaveEnemy(s1);
            image_save_enemy.init1();
        }

        battle_enemy_appear_control = new BattleEnemyAppearControl(s1);

        battle_enemy_ai = new BattleEnemyAI(s1);
    }

    public void init1()
    {
        for (int t1 = 0; t1 < max(); t1++)
        {
            battle_enemy[t1].init1();
        }


        battle_enemy_appear_control.init1();

        battle_enemy_ai.init1();





        {
            target_lock_num = -1;
        }
        

    //    s1.function_script_reader_control.test1();
    }

    



    
    

    public int alive_num_check()
    {
        int nt = 0;

        {
            for (int t1 = 0; t1 < max(); t1++)
            {
                if (battle_enemy[t1].alive_check() == 1)
                {
                    nt += 1;
                }
            }
        }

        return nt;
    }

    



    //敵キャラクターの表示位置
    public int battle_enemy_dy()
    {
        int nt = 330;//316;//332;//340;

        return nt;
    }


    //HPの割合を教える 割合にしたい場合はw1=100;
    public int hp_gage_call(int bclink1, int w1)
    {
        int nt = 0;

        int n1 = battle_enemy[bclink1].battle_enemy_status.call_battle_status(battle_enemy[bclink1].battle_enemy_status.STATUS_HP) + battle_enemy[bclink1].value_change.call_value1();
        int n2 = m1.iover(battle_enemy[bclink1].battle_enemy_status.call_battle_status(battle_enemy[bclink1].battle_enemy_status.STATUS_MHP), 1, 99999999);
        
        int w11 = w1 * n1 / n2;

        nt = w11;

        return nt;
    }

    public void skill_reset()
    {
        for (int t1 = 0; t1 < max(); t1++)
        {
            battle_enemy[t1].skill_reset();
        }
    }

    public void now_attribute_check()
    {
        for (int t1 = 0; t1 < max(); t1++)
        {
            if (battle_enemy[t1].alive_check() != 0)
            {
                battle_enemy[t1].now_attribute_check();
            }
        }
    }

    public void skill_decide()
    {
        for (int t1 = 0; t1 < max(); t1++)
        {
            if (battle_enemy[t1].on != 0)
            {
                battle_enemy_ai.skill_decide(t1);
            }
        }
    }


    public void run1()
    {
        for (int t1 = 0; t1 < max(); t1++)
        {
            battle_enemy[t1].run1();
        }
    }

    public void draw1()
    {
        for (int t1 = 0; t1 < max(); t1++)
        {
            battle_enemy[t1].draw1();
        }

        //      g1.sc(255);

        //        g1.str2("test", 300, 300);
    }
}
