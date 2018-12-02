using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BaseStageResult : SetVoid1
{
    public int scene_type;
    public int scene_tm1;

    public int SCENE_START = 0;
    public int SCENE_CHARACTER_GET = 1;
    public int SCENE_EXP_GET = 2;
    public int SCENE_END = 3;

    //適当に配置できるボタン
    static int MENU_AREA5_MAX = 2;
    int[] area5_x = new int[MENU_AREA5_MAX];
    int[] area5_w = new int[MENU_AREA5_MAX];
    int[] area5_y = new int[MENU_AREA5_MAX];
    int[] area5_h = new int[MENU_AREA5_MAX];
    int[] area5_str_add_y = new int[MENU_AREA5_MAX];
    String[] area5_str = new String[MENU_AREA5_MAX];

    public int[] exp_get_num_all_memo = new int[6 + 1];
    public int[] exp_get_num = new int[6 + 1];

    public int[] get_equipment_type_num = new int[16];
    public int[] get_equipment_link_num = new int[16];

    public BaseStageResult(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        scene_type = SCENE_START;
        scene_tm1 = 0;

        for (int t2 = 0; t2 < 16; t2++)
        {
            get_equipment_type_num[t2] = 0;
            get_equipment_link_num[t2] = s1.am1.equipment_null_num();
        }



        for (int t2 = 0; t2 < MENU_AREA5_MAX; t2++)
        {
            area5_x[t2] = -5000;
            area5_str[t2] = "";
        }
        
        {
            area5_str[0] = "次に進む";

            area5_w[0] = 120;
            area5_h[0] = 40;
            area5_x[0] = 480 + 80 / 2;
            area5_y[0] = 480 - 8;//-24;
            area5_str_add_y[0] = 8;
        }

        for (int t2 = 0; t2 < 6 + 1; t2++)
        {
            exp_get_num_all_memo[t2] = 0;
            exp_get_num[t2] = exp_get_num_all_memo[t2];
        }
    }

    public int sub_push_check()
    {
        int np = 0;
        int nt = s1.touch_input.pull_check();

        if (nt == 1)// && s.base_run.base_middle_range_in_check() == 1)
        {
            np = 1;
        }

        return np;
    }

    public void result_get_create()
    {
        //経験値の入手
        {
            exp_get_num_all_memo[0] = 1500;
            exp_get_num[0] = exp_get_num_all_memo[0];
        }

        //経験値の入手
        for (int t2 = 0; t2 < 6; t2++)
        {
            exp_get_num_all_memo[t2+1] = 1000;
            exp_get_num[t2 + 1] = exp_get_num_all_memo[t2 + 1];
        }

        //アイテムの入手
        {
            get_equipment_type_num[0] = 5;
            get_equipment_type_num[1] = 5;
            get_equipment_type_num[2] = 5;

            for (int t2 = 0; t2 < 16; t2++)
            {
                if (get_equipment_type_num[t2] >= 1)
                {
                    int link_num = s1.equipment_group.equipment_create(get_equipment_type_num[t2]);
                    get_equipment_link_num[t2] = link_num;
                }
            }
        }
    }

    public int menu_ok_check()
    {
        int nt = 0;

        if (scene_type == SCENE_END)
        {
            nt = 1;
        }

        return nt;
    }

    public void next_call()
    {
        s1.base_run.menu_change_waitact_set(s1.base_run.STAGE1_SELECT);
    }



    public void run1()
    {
        //シーンの管理
        {
            if (scene_type == SCENE_START)
            {
                if (scene_tm1 >= 1)
                {
                    scene_tm1 = 0;
                    //    scene_type = SCENE_CHARACTER_GET;

                    scene_type = SCENE_EXP_GET;
                }
            }

            if (scene_type == SCENE_CHARACTER_GET)
            {
                if (scene_tm1 == 0)
                {
                    s1.dialog_window1.create1(s1.dialog_window1.CHARACTER_GET_1, 0, s1.dialog_window1.DIALOG_OK, 0);
                }
            }

            if (scene_type == SCENE_EXP_GET)
            {
                if (scene_tm1 == 0)
                {
                    result_get_create();
                }


                {
                    int tm1 = scene_tm1;

                    int time_start1 = 40, time_start1_add = 150;//40 ~ 220
                    
                    if (tm1 >= 0 && tm1 < time_start1 - 1)
                    {
                        if (sub_push_check() == 1)
                        {
                            scene_tm1 = time_start1 - 1;
                            tm1 = scene_tm1;
                        }
                    }

                    if (tm1 >= time_start1 && tm1 <= time_start1 + time_start1_add)
                    {
                        if (sub_push_check() == 1)
                        {
                            scene_tm1 = time_start1 + time_start1_add + 1;
                            tm1 = scene_tm1;
                        }
                    }


                    {
                        int exp_add1 = exp_get_num_all_memo[0] / time_start1_add + 1;

                        if (tm1 >= time_start1 && tm1 <= time_start1 + time_start1_add)
                        {
                            if (exp_get_num[0] >= exp_add1)
                            {
                                s1.am1.player_get_exp(exp_add1);

                                exp_get_num[0] -= exp_add1;
                            }
                        }


                        //スキップ機能 + 終了時に、渡せていない経験値の付与
                        if (tm1 == time_start1 + time_start1_add + 1 || exp_get_num[0] < exp_add1 && exp_get_num[0] >= 1)
                        {
                            //   if (exp_get_num_memo < nt)
                            {
                                s1.am1.player_get_exp(exp_get_num[0]);

                                exp_get_num[0] = 0;
                            }
                        }
                    }



                    //キャラクター毎のEXP管理
                    for (int t7 = 0; t7 < 6; t7++)
                    {
                        int exp_add1 = exp_get_num_all_memo[t7 + 1] / time_start1_add + 1;

                        int link_num = s1.base_run.party_select_group.party_call(t7);

                        if (tm1 >= time_start1 && tm1 <= time_start1 + time_start1_add)
                        {
                            if (exp_get_num[t7 + 1] >= exp_add1)
                            {
                                if (link_num != s1.am1.character_null_num())
                                {
                                    if (s1.character_group.character_null_check(link_num) == 0)
                                    {
                                        if (s1.character_group.character1[link_num].on != 0)
                                        {
                                            s1.character_group.character1[link_num].get_exp(exp_add1);

                                            exp_get_num[t7 + 1] -= exp_add1;
                                        }
                                    }
                                }
                            }
                        }


                        //スキップ機能 + 終了時に、渡せていない経験値の付与
                        if (tm1 == time_start1 + time_start1_add + 1 || exp_get_num[t7 + 1] < exp_add1 && exp_get_num[t7 + 1] >= 1)
                        {
                            //   if (exp_get_num_memo < nt)
                            {
                                if (link_num != s1.am1.character_null_num())
                                {
                                    if (s1.character_group.character_null_check(link_num) == 0)
                                    {
                                        if (s1.character_group.character1[link_num].on != 0)
                                        {
                                            s1.character_group.character1[link_num].get_exp(exp_get_num[t7 + 1]);

                                            exp_get_num[t7 + 1] = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }



                    /*
                    if (s.tm % 2 == 0)
                    {
                        if (pp >= 1)
                        {
                            s.so.se_play(s.so.SE_EXP_GET);
                        }
                    }
                    */

                    if (tm1 == time_start1 + time_start1_add + 2)
                    {
                        scene_tm1 = 0;
                        scene_type = SCENE_END;
                    }
                }

                /*
                if (tm >= 240)
                {
                    if (sub_push_check() == 1)
                    {
                        result_end();
                    }
                }
                */

                /*
                if (scene_tm1 == 1)
                {


                }
                */
            }
        }

        //次に進むボタン
        if (s1.base_run.base_move_no_check() == 0)
        {
            int px1 = s1.touch_input.point_x1();
            int py1 = s1.touch_input.point_y1();

            for (int t2 = 0; t2 < MENU_AREA5_MAX; t2++)
            {
                {
                    int x1 = area5_x[t2];
                    int y1 = area5_y[t2] - 2;
                    int w1 = area5_w[t2];
                    int h1 = area5_h[t2] + 4;

                    if (m1.rect_decision(px1, py1, x1, y1, w1, h1) == 1)
                    {
                        if (s1.touch_input.pull_check() == 1)
                        {
                            //    if (m1.strbyte(area5_name[t2]) >= 1)
                            if (t2 == 0)
                            {
                                s1.touch_input.wait(4);

                                next_call();
                            }
                        }
                    }
                }
            }
        }

        if (scene_tm1 <= 99999999) { scene_tm1++; }
    }


    //キャラクター×６の位置
    public float area2_x(int num1) { return 64 + 96 * num1 + 16; }
    public float area2_y(int num1) { return 0 + 0 + 36 + 30; }
    public int area2_w(int num1) { return character_window_size(); }
    public int area2_h(int num1) { return character_window_size(); }
    public int character_window_size() { return 80; }

    public float area3_x(int num1) { return 64 + 84 * num1 + 16; }
    public float area3_y(int num1) { return 0 + 0 + 36 + 16; }
    public int area3_w(int num1) { return item_window_size(); }
    public int area3_h(int num1) { return item_window_size(); }
    public int item_window_size() { return 64; }


    public void draw1()
    {
        if (scene_type == SCENE_EXP_GET || scene_type == SCENE_END)
        {
            {
                int w21 = 640;
                int h21 = 240;
                int x21 = 0 + s1.base_run.base_call_all_w1() / 2 - w21 / 2;
                int y21 = s1.base_run.base_call_y2() + 20;


                s1.dm1.boxdraw3(x21, y21, w21, h21, 0, 1);

                //一番上、プレイヤーのEXP
                {
                    //name level gage exp

                    {
                        g1.setfont(g1.FONT_1_SMALL_STR);
                    //    g1.setfont(g1.FONT_1_VERY_SMALL_STR);

                        {
                            int xn1 = -180;

                            g1.sc(255);
                            //    g1.str2("Lv 100", x21, y21 + window_size1+8);

                            //     String name1 = "あ";
                            String name1 = "プレイヤー";
                            //String name1 = "プレイヤー１７８";
                            g1.str2_center(""+name1, x21 + w21 / 2+xn1, y21 + 20);
                        }

                        int x24 = x21 + w21 / 2 - 80;

                        {
                            g1.sc(255);
                            g1.str2("Rank:"+s1.app_variable1.player_rank, x24, y21 + 20);
                        }

                        //EXPゲージ
                        {
                            int w1 = 100 - 2;
                            int exp1 = s1.app_variable1.player_rank_exp;
                            int exp2 = s1.am1.player_levelup_need_exp();

                            int per1 = 100 * exp1 / exp2;
                            int y_add1 = 96 + 12;

                            s1.dm1.gauge_window_draw1(x24+110, y21 + 20+2, w1, per1, 2, 12, 0, 0);

                            //    m1.end();
                        }

                        //EXP
                        {
                            g1.setfont(g1.FONT_1_VERY_SMALL_STR);

                            //   if (link_num != s1.am1.character_null_num())
                            {
                                int exp1 = exp_get_num_all_memo[0];

                                g1.sc(255);
                                g1.str2_center("Exp +" + exp1, x24 + 260, y21 + 20 + 1);
                            }

                            g1.setfont_re();
                        }

                        g1.setfont_re();
                    }
                }

                
                for (int t1 = 0; t1 < 6; t1++)
                {
                    int num2 = t1;

                    float x210 = 0 + area2_x(t1);//x11 + t1 * 96 + 16;
                    float y210 = y21 + area2_y(t1);//y11 + 0 * 0 + 36+16;

                    int window_size1 = 80;

                    int link_num = s1.base_run.party_select_group.party_call(num2);

                    {
                        if (link_num == s1.am1.character_null_num())
                        {
                            g1.sc(255);
                            g1.drawRect(x210, y210, window_size1, window_size1, 0, 0);
                        }
                        else
                        {
                            if (s1.character_group.character_null_check(link_num) == 0)
                            {
                                if (s1.character_group.character1[link_num].on != 0)
                                {
                                    int type1 = s1.character_group.character1[link_num].call_type1();
                                    int att1 = s1.character_group.character1[link_num].call_attribute_1();
                                    int att2 = s1.character_group.character1[link_num].call_attribute_2();

                                    s1.dm1.character_window_draw(x210, y210, type1, 0, 2, att1, att2, 0);


                                    {
                                        g1.setfont(g1.FONT_1_VERY_SMALL_STR);

                                        if (link_num != s1.am1.character_null_num())
                                        {
                                            int level1 = s1.character_group.character1[link_num].call_level();

                                            g1.sc(255);
                                            g1.str2_center("Ｌｖ." + level1, x210 + window_size1 / 2, y210 + window_size1 + 6);
                                        }

                                        g1.setfont_re();
                                    }

                                    {
                                        //EXPゲージ
                                        {
                                            int w1 = 80 - 2;
                                            int exp1 = s1.character_group.character1[link_num].call_exp1();
                                            int exp2 = s1.character_group.character1[link_num].level_up_need_exp();

                                            int per1 = 100 * exp1 / exp2;
                                            int y_add1 = 96 + 12;

                                            s1.dm1.gauge_window_draw1(x210, y210 + y_add1, w1, per1, 2, 12, 0, 0);

                                            //    m1.end();
                                        }
                                    }

                                    //EXP
                                    {
                                        g1.setfont(g1.FONT_1_VERY_SMALL_STR);

                                        if (link_num != s1.am1.character_null_num())
                                        {
                                            int exp1 = exp_get_num_all_memo[t1 + 1];

                                            g1.sc(255);
                                            g1.str2_center("Exp +" + exp1, x210 + window_size1 / 2, y210 + window_size1 + 56);
                                        }

                                        g1.setfont_re();
                                    }
                                }
                            }
                        }
                    }

                    /*

                    */
                }
            }

            {
                int w31 = 400;
                int h31 = 140;
                int x31 = 0 + s1.base_run.base_call_all_w1() / 2 - (640) / 2;
                int y31 = s1.base_run.base_call_y2() + 20 + 270;


                s1.dm1.boxdraw3(x31, y31, w31, h31, 0, 1);

                {
                    g1.setfont(g1.FONT_1_SMALL_STR);

                    {
                        g1.sc(255);
                        //    g1.str2("Lv 100", x21, y21 + window_size1+8);
                        g1.str2_center("入手した装備", x31 + w31 / 2, y31 + 16);
                    }

                    g1.setfont_re();
                }


                for (int t1 = 0; t1 < 4; t1++)
                {
                    int num2 = t1;

                    float x310 = 0 + area3_x(t1);//x11 + t1 * 96 + 16;
                    float y310 = y31 + area3_y(t1);//y11 + 0 * 0 + 36+16;

                    int window_size1 = item_window_size();

                    int link_num = get_equipment_link_num[t1];
                    
                    {
                        if (link_num == s1.am1.equipment_null_num())
                        {
                            g1.sc(255);
                            g1.drawRect(x310, y310, window_size1, window_size1, 0, 0);
                        }
                        else
                        {
                            g1.sc(255);
                            g1.drawRect(x310, y310, window_size1, window_size1, 0, 0);

                            if (s1.equipment_group.equipment_null_check(link_num) == 0)
                            {
                                if (s1.equipment_group.equipment1[link_num].on != 0)
                                {
                                    int type1 = s1.equipment_group.equipment1[link_num].call_type1();
                                    int att1 = s1.equipment_group.equipment1[link_num].call_attribute_1();
                                    int att2 = s1.equipment_group.equipment1[link_num].call_attribute_2();

                                    s1.dm1.equipment_draw(x310, y310, type1, 0, 1, att1, att2, 0);
                                }
                            }

                            /*
                            if (s1.character_group.character_null_check(link_num) == 0)
                            {
                                if (s1.character_group.character1[link_num].on != 0)
                                {
                                    int type1 = s1.character_group.character1[link_num].call_type1();
                                    int att1 = s1.character_group.character1[link_num].call_attribute_1();
                                    int att2 = s1.character_group.character1[link_num].call_attribute_2();

                                    s1.dm1.character_window_draw(x310, y310, type1, 0, 2, att1, att2, 0);
                                }
                            }
                            */
                        }
                    }
                }


                int nnm1 = 40;
                int w32 = 640 - w31 - nnm1;
                int h32 = h31 - 64;
                int x32 = x31 + w31 + nnm1;
                int y32 = y31;


                s1.dm1.boxdraw3(x32, y32, w32, h32, 0, 1);

                {
                    g1.setfont(g1.FONT_1_SMALL_STR);

                    {
                        int coin_num1 = 10000;

                        g1.sc(255);
                        g1.str2_center("コインの獲得", x32 + w32 / 2, y32 + 16);
                        g1.str2_center("" + coin_num1, x32 + w32 / 2, y32 + 16 + 32 - 2);
                    }

                    g1.setfont_re();


                    for (int t1 = 0; t1 < 1; t1++)
                    {
                        {
                            int np = 0;

                            s1.dm1.boxdraw3(area5_x[t1], area5_y[t1], area5_w[t1], area5_h[t1], np, 1);

                            g1.setfont(g1.FONT_1_MIDDLE_STR);

                            {
                                String button_name1 = area5_str[t1];
                                g1.str2_center(button_name1, area5_x[t1] + area5_w[t1] / 2, area5_y[t1] + area5_str_add_y[t1], g1.font_w_size_call(0));
                            }

                            g1.setfont_re();
                        }
                    }
                }
            }
        }
    }
}
