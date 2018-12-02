using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EnemyData : SetVoid1
{
    int row_move_num = 1;
    int row_move1() { return row_move_num; }

    int read_data;

    public int ENEMY_NAME = 2;
    //    public int ENCHANTMENT_EXPLANATION_1 = 9;
    //    public int ENCHANTMENT_EXPLANATION_2 = 10;

    public int ENEMY_BOSS_TYPE = 4;

    public int ENEMY_MHP = 13;
    public int ENEMY_ATK = 14;

    public int ENEMY_ATTRIBUTE1 = 9;
    public int ENEMY_ATTRIBUTE2 = 10;


    public EnemyData(Summary1 s1)
    {
        set1(s1);

        read_data = s1.csv_manager.ENEMY_DATA;
    }
    
    public void init1()
    {
    }

    public String str_call(int type1, int column_length1)
    {
        int t1 = type1 + row_move1();
        String st1 = "";

        st1 = s1.csv_manager.call_str1(read_data, t1, column_length1);

        return st1;
    }

    public int int_call(int type1, int column_length1)
    {
        int t1 = type1 + row_move1();
        int t2 = 0;

        t2 = s1.csv_manager.call_int1(read_data, t1, column_length1);

        return t2;
    }


    //そのキャラクターの横の長さを要求
    public int call_enemy_size_w(int type1)
    {
        int nt = 0;

        nt = 200;

        ImageData1 id1 = s1.battle_run.battle_enemy_group.image_save_enemy.loadcheck1(type1);
        
        int w2 = id1.call_w();
        nt = w2;

        //    nt = s.dm.call_chara_position(race1, 2);

        return nt;
    }


    public String enemy_name(int type1) { return str_call(type1, ENEMY_NAME); }

    public int enemy_boss_type(int type1) { return int_call(type1, ENEMY_BOSS_TYPE); }

    public int enemy_attribute1(int type1) { return int_call(type1, ENEMY_ATTRIBUTE1); }
    public int enemy_attribute2(int type1) { return int_call(type1, ENEMY_ATTRIBUTE2); }

    public int enemy_mhp(int type1) { return int_call(type1, ENEMY_MHP); }
    public int enemy_atk(int type1) { return int_call(type1, ENEMY_ATK); }
    
    //    public String enchantment_explanation1(int type1) { return str_call(type1, ENCHANTMENT_EXPLANATION_1); }
    //    public String enchantment_explanation2(int type1) { return str_call(type1, ENCHANTMENT_EXPLANATION_2); }
}