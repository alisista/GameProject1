using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DungeonData : SetVoid1
{
    public int dungeon_type1;

    public int dungeon_battle_num;







    int row_move_num = 1;
    int row_move1() { return row_move_num; }

    public int DUNGEON_NAME = 2;

    public int DUNGEON_BACK_IMAGE = 6;

    public int DUNGEON_BATTLE_NUM = 11;

    public int DUNGEON_NORMAL_ENEMY_TYPE = 32;


    public DungeonData(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        dungeon_type1 = 1;
        dungeon_battle_num = 0;//1;
    }

    

    public String battle_name_call()
    {
        String name1 = "BATTLE " + (dungeon_battle_num) + " / " + (dungeon_battle_num_max());
        return name1;
    }

    public int battle_num_last_check()
    {
        int nt = 0;

        if (dungeon_battle_num>= dungeon_battle_num_max()) { nt = 1; }

        return nt;
    }

    public int dungeon_normal_battle_bgm_num()
    {
        int nt1 = 0;

        nt1 = s1.bgm_operation.BGM_BATTLE_1;

        return nt1;
    }

    public int dungeon_boss_battle_bgm_num()
    {
        int nt1 = 0;

        nt1 = s1.bgm_operation.BGM_BATTLE_2;

        return nt1;
    }



    public String str_call(int type1, int column_length1)
    {
        int t1 = type1 + row_move1();
        String st1 = "";

        {
            st1 = s1.csv_manager.call_str1(s1.csv_manager.DUNGEON_DATA, t1, column_length1);
        }

        //   m1.msbox(st1);

        //   m1.end();

        return st1;
    }

    public int int_call(int type1, int column_length1)
    {
        int t1 = type1 + row_move1();
        int t2 = 0;

        {
            t2 = s1.csv_manager.call_int1(s1.csv_manager.DUNGEON_DATA, t1, column_length1);
        }

        return t2;
    }


    public String dungeon_name(int type1) { return str_call(type1, DUNGEON_NAME); }

    public int dungeon_back_image(int type1) { return int_call(type1, DUNGEON_BACK_IMAGE); }

    public int dungeon_battle_num_max() { return dungeon_battle_num_max(dungeon_type1); }
    public int dungeon_battle_num_max(int type1) { return int_call(type1, DUNGEON_BATTLE_NUM); }

    public int dungeon_normal_enemy_type(int type1,int num1) { return int_call(type1, DUNGEON_NORMAL_ENEMY_TYPE + num1); }
}

