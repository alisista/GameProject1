using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ApplicationMisc : SetVoid1
{
    //固定。変更禁止
    public int ATTRIBUTE_GREEN = 1;
    public int ATTRIBUTE_YELLOW = 2;
    public int ATTRIBUTE_RED = 3;
    public int ATTRIBUTE_BLUE = 4;
    public int ATTRIBUTE_WHITE = 5;
    public int ATTRIBUTE_BLACK = 6;

    public int STATUS_MHP = 10;
    public int STATUS_MMP = 11;
    public int STATUS_ATK = 12;
    public int STATUS_INT = 13;

    //固定。変更禁止
    public int MANA_GREEN = 0;
    public int MANA_YELLOW = 1;
    public int MANA_RED = 2;
    public int MANA_BLUE = 3;
    public int MANA_HP = 4;
    public int MANA_MP = 5;

    public int equipment_null_num() { return 9999; }
    public int character_null_num() { return 9999; }

    public void init_set1(Summary1 s1)
    {
        set1(s1);
        init1();
    }

    //セーブデータを作る時に必要な初期化
    public void first_savedata_create()
    {
        if (s1.auto_save == 1)
        {
            s1.save_data_control.file_save();
        }
    }



    //タッチし続ける判定の フレームの長さ x後に反応
    public int long_touch_need_tm() { return 60; }

    //ソートプログラム
    public long[] sort_start(int sort_num, long[] sort_box, int up2_or_down1)
    {
        //バブルソート開始
        {
            int count = sort_num - 1;

            for (int i = 0; i <= count; i++)
            {
                for (int j = count; j > i; j--) // 下から上に順番に比較
                {
                    if (sort_box[j] < sort_box[j - 1] && up2_or_down1 == 1
                     || sort_box[j] > sort_box[j - 1] && up2_or_down1 == 2)
                    {
                        long t = sort_box[j];
                        sort_box[j] = sort_box[j - 1];
                        sort_box[j - 1] = t;
                    }
                }
            }
        }

        return sort_box;
    }
    
    //空っぽのものを一番後ろにソート
    public long[] sort_start2(int sort_num, long[] sort_box)
    {
        //バブルソート開始
        {
            int count = sort_num - 1;

            for (int i = 0; i <= count; i++)
            {
                for (int j = count; j > i; j--) // 下から上に順番に比較
                {
                    if (sort_box[j - 1] < 10000)
                    {
                        long t = sort_box[j];
                        sort_box[j] = sort_box[j - 1];
                        sort_box[j - 1] = t;
                    }
                }
            }
        }

        return sort_box;
    }



    //弱点計算
    public int week_1_and_resist_2_call(int att1,int att2)
    {
        int week_1_and_resist_2 = 0;

        if (att1 == ATTRIBUTE_GREEN && att2 == ATTRIBUTE_YELLOW) { week_1_and_resist_2 = 1; }
        if (att1 == ATTRIBUTE_YELLOW && att2 == ATTRIBUTE_GREEN) { week_1_and_resist_2 = 1; }
        if (att1 == ATTRIBUTE_GREEN && att2 == ATTRIBUTE_GREEN) { week_1_and_resist_2 = 2; }
        if (att1 == ATTRIBUTE_YELLOW && att2 == ATTRIBUTE_YELLOW) { week_1_and_resist_2 = 2; }

        if (att1 == ATTRIBUTE_RED && att2 == ATTRIBUTE_BLUE) { week_1_and_resist_2 = 1; }
        if (att1 == ATTRIBUTE_BLUE && att2 == ATTRIBUTE_RED) { week_1_and_resist_2 = 1; }
        if (att1 == ATTRIBUTE_RED && att2 == ATTRIBUTE_RED) { week_1_and_resist_2 = 2; }
        if (att1 == ATTRIBUTE_BLUE && att2 == ATTRIBUTE_BLUE) { week_1_and_resist_2 = 2; }

        if (att1 == ATTRIBUTE_WHITE && att2 == ATTRIBUTE_BLACK) { week_1_and_resist_2 = 1; }
        if (att1 == ATTRIBUTE_BLACK && att2 == ATTRIBUTE_WHITE) { week_1_and_resist_2 = 1; }
        if (att1 == ATTRIBUTE_WHITE && att2 == ATTRIBUTE_WHITE) { week_1_and_resist_2 = 2; }
        if (att1 == ATTRIBUTE_BLACK && att2 == ATTRIBUTE_BLACK) { week_1_and_resist_2 = 2; }

        return week_1_and_resist_2;
    }

    //チームの主属性と副属性から、何の属性になるのかを教える
    public int call_member_attribute()
    {
        int attribute1 = 1;
        int first_check = 0;

        int[] attbox = new int[6];

        for (int t1 = 0; t1 < 6; t1++) { attbox[t1] = 0; }

        //戦闘中はメンバーから出力
        if (s1.mr1.game_type == s1.mr1.GAME_BATTLE)
        {
            for (int t1 = 0; t1 < 6; t1++)
            {
                if (s1.battle_run.battle_member_group.member_on_check(t1) != 0)
                {
                    int att1 = s1.battle_run.battle_member_group.battle_member[t1].call_attribute_1();
                    int att2 = s1.battle_run.battle_member_group.battle_member[t1].call_attribute_2();
                    int np1 = 2, np2 = 1;

                    if (first_check == 0) { first_check = 1; attribute1 = att1; }

                    if (att1 == 1) { attbox[0] += np1; }
                    if (att1 == 2) { attbox[1] += np1; }
                    if (att1 == 3) { attbox[2] += np1; }
                    if (att1 == 4) { attbox[3] += np1; }
                    if (att1 == 5) { attbox[4] += np1; }
                    if (att1 == 6) { attbox[5] += np1; }

                    if (att2 == 1) { attbox[0] += np2; }
                    if (att2 == 2) { attbox[1] += np2; }
                    if (att2 == 3) { attbox[2] += np2; }
                    if (att2 == 4) { attbox[3] += np2; }
                    if (att2 == 5) { attbox[4] += np2; }
                    if (att2 == 6) { attbox[5] += np2; }
                }
            }            
        }

        //一番カウントが多いものに変化
        {
            int pp = attbox[attribute1 - 1];

            for (int t1 = 0; t1 < 6; t1++)
            {
                if (attbox[t1] > pp) { pp = attbox[0]; attribute1 = t1 + 1; }
            }
        }


        return attribute1;
    }


    //プレイヤーのランクアップに必要な経験値
    public int player_levelup_need_exp()
    {
        return player_levelup_need_exp(s1.app_variable1.player_rank);
    }

    public int player_levelup_need_exp(int player_rank)
    {
        int nt = 0;

        nt = player_rank * 1000;

        return nt;
    }

    public void player_get_exp(int exp_add1)
    {
        if (s1.app_variable1.player_rank < 9999)
        {
            s1.app_variable1.player_rank_exp += exp_add1;

            /*
            if (s.tm % 2 == 0)
            {
                if (point >= 1)
                {
                    s.so.se_play(s.so.SE_EXP_GET);
                }
            }
            */

            if (s1.app_variable1.player_rank_exp >= player_levelup_need_exp())
            {
                player_rank_up();
            }
        }
        else
        {
            exp_add1 = 0;
        }
    }

    public void player_rank_up()
    {
        if (s1.app_variable1.player_rank < 9999)
        {
            s1.app_variable1.player_rank_exp -= player_levelup_need_exp();
            s1.app_variable1.player_rank_exp = m1.iover(s1.app_variable1.player_rank_exp, 0, 9999999);

            {
                s1.app_variable1.player_rank += 1;
            }

            /*
            s.so.se_play(s.so.SE_LEVEL_UP);
            */

            //    if (status_box[LEVEL] >= 100) { status_box[LEVEL] = 100; }

            //    protect_key_updata();
        }
    }


    public void init1()
    {

    }

    public void run1()
    {
    }

    public void draw1()
    {
    }
}