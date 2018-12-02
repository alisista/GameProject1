using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleEnemyStatus : SetVoid1
{
    //自分自身の変数番号 BattleEnemyの引用
    int num1;

    static int STATUS_MAX = 10;
    public int[] status_box = new int[STATUS_MAX];

    public int STATUS_HP = 0;

    public int NOW_ATTRIBUTE = 3;


    //    public int ATTRIBUTE_1 = 2;
    //    public int ATTRIBUTE_2 = 3;


    //保存はしない変数
    public int STATUS_MHP = 100010;
//    public int STATUS_MMP = 100020;
    public int STATUS_ATK = 100030;
//    public int STATUS_INT = 100040;

    public int STATUS_ATTRIBUTE_1 = 100110;
    public int STATUS_ATTRIBUTE_2 = 100120;


    public BattleEnemyStatus(Summary1 s1,int num1)
    {
        set1(s1);
        this.num1 = num1;
    }

    public void init1()
    {
        for (int t1 = 0; t1 < STATUS_MAX; t1++)
        {
            status_box[t1] = 0;
        }



        //    status_box[STATUS_HP] = 300; status_box[STATUS_MHP] = status_box[STATUS_HP];

        //    status_box[STATUS_HP] = 500 * 2 + 1;

        status_box[STATUS_HP] = call_battle_status(STATUS_MHP);// / 2;// * 0 + 1;

        status_box[NOW_ATTRIBUTE] = call_battle_status(STATUS_ATTRIBUTE_1);

    //    m1.msbox("" + status_box[NOW_ATTRIBUTE]);

    //    status_box[ATTRIBUTE_1] = 1; status_box[ATTRIBUTE_2] = 1;
    }

    /*
    public int call_status(int status_type)
    {
        int nt = 0;

        nt = call_battle_status(status_type);

        return nt;
    }
    */

    public int call_battle_status_box(int status_type)
    {
        int nt = 0;

        nt = status_box[status_type];

    //    nt = curse_status_change(nt, status_type);

        return nt;
    }

    public int call_battle_status(int status_type)
    {
        int nt1 = 0;

        if (status_type < STATUS_MHP)
        {
            nt1 = call_battle_status_box(status_type);
        }
        else
        {
            int link_num1 = num1;//;s1.battle_run.battle_enemy_group.battle_enemy[num1].link;
            int type1 = s1.battle_run.battle_enemy_group.battle_enemy[num1].call_type1();

            if (status_type == STATUS_MHP)
            {
                nt1 = s1.data_magagement.enemy_data.enemy_mhp(type1);
            }

            if (status_type == STATUS_ATK)
            {
                nt1 = s1.data_magagement.enemy_data.enemy_atk(type1);
            }

            if (status_type == STATUS_ATTRIBUTE_1)
            {
                nt1 = s1.data_magagement.enemy_data.enemy_attribute1(type1);//s1.character_group.call_character_status(link_num1, s1.character_group.STATUS_ATTRIBUTE_1);
            }

            if (status_type == STATUS_ATTRIBUTE_2)
            {
                nt1 = s1.data_magagement.enemy_data.enemy_attribute2(type1);

                if (nt1 == 0) { nt1 = call_battle_status(STATUS_ATTRIBUTE_1); }
            }
        }

        return nt1;
    }

    public void damage_set(int damage_num)
    {
        status_box[STATUS_HP] -= damage_num;
    }

    public int call_boss_type()
    {
        int nt = 0;
        int type1 = s1.battle_run.battle_enemy_group.battle_enemy[num1].call_type1();

        nt = s1.data_magagement.enemy_data.enemy_boss_type(type1);

        return nt;
    }

    public void defeat_set()
    {
        //ロックの解除
        {
            if (s1.battle_run.battle_enemy_group.target_lock_num == num1)
            {
                s1.battle_run.battle_enemy_group.target_lock_num = -1;
            }
        }
    }

    public void run1()
    {
    }

    public void draw1()
    {
    }
}
