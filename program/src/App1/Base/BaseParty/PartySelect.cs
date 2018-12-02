using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class PartySelect : SetVoid1
{
    //個別の番号
    int num1;

    public int on;
//    public int party_num;

//    public int type;
    public int px;
    public int py;
    public int pw;
    public int ph;

    public int[] freei = new int[9];

    public int character_window_size() { return 80; }

    public PartySelect(Summary1 s1, int num1)
    {
        set1(s1);
        this.num1 = num1;
    }

    public void init1()
    {
        on = 0;
//        type = 0;
        px = 0;
        py = 0;
        pw = 0;
        ph = 0;

        for (int t1 = 0; t1 < 9; t1++)
        {
            freei[t1] = 0;
        }

        


        
    }

    

    public void create1(int x1, int y1)
    {
        on = 1;
        
        px = x1;//w1 / 2 - w2 / 2;
        py = y1;
        pw = s1.base_run.base_call_all_w1() - 32 * 2;
        ph = 328 - 38;
        
    //    party_ability_type();
    }


    //キャラクター×６の位置
    public float area2_x(int num1) { return 64 + 96 * num1 + 16; }
    public float area2_y(int num1) { return 60 + 0 + 36 + 16; }
    public int area2_w(int num1) { return character_window_size(); }
    public int area2_h(int num1) { return character_window_size(); }


    public void window_select()
    {
        {
            s1.base_run.character_organization_group.back_base_type = s1.base_run.base_type;

            s1.base_run.menu_change_waitact_set(s1.base_run.CHARACTER_PARTY_SELECT);
        }
    }
    
    public void call_character_status()
    {
        int num2 = s1.base_run.party_select_group.select_character_num;
        int link_num = s1.base_run.party_select_group.party_call(num1, num2);

        s1.base_run.base_function.character_status_draw_call();

        s1.base_run.character_status.character_link = link_num;

        s1.base_run.character_status.back_base_type = s1.base_run.base_type;
    }





    public void run1()
    {
        if (on != 0)
        {
            int x1 = px - (int)s1.cam_2d.call_x_positioin();
            int y1 = py - (int)s1.cam_2d.call_y_positioin();

            if (x1 + pw >= 0 - 0 && x1 <= s1.display_w_call() - 2)
            {
                if (s1.base_run.base_move_no_check() == 0)
                {
                    float px3 = s1.touch_input.point_x1();
                    float py3 = s1.touch_input.point_y1();

                    for (int t1 = 0; t1 < 6; t1++)
                    {
                        int num2 = t1;

                        float x3 = x1 + area2_x(t1);
                        float y3 = y1 + area2_y(t1);
                        int w3 = area2_w(t1);
                        int h3 = area2_h(t1);

                        //画面範囲内
                        if (s1.base_run.base_y1_and_h1_range_in_check(px3, py3) == 1)
                        {
                            //ボタン内
                            if (m1.rect_decision(px3, py3, x3, y3, w3, h3) == 1)
                            {
                                int np = s1.am1.long_touch_need_tm();

                                s1.base_run.party_select_group.party_use_num = num1;
                                s1.base_run.party_select_group.select_character_num = num2;

                                //キャラが存在している場合のみ
                                int link_num = s1.base_run.party_select_group.party_call(num1, num2);//s1.base_run.character_organization_group.link_sort_box_call(num1);

                                if (s1.character_group.character_null_check(link_num) == 0)
                                {
                                    if (s1.character_group.character1[link_num].on != 0)
                                    {
                                        //一定時間立たない場合で離した時(通常)
                                        if (s1.touch_input.pull_check() == 1)
                                        {
                                            if (s1.cam_2d.move_check() == 0)
                                            {
                                                if (s1.touch_input.touch_tm_call() < np)
                                                {
                                                    if (s1.touch_input.input_wait <= 0)
                                                    {
                                                        //  m1.msbox("short");

                                                        window_select();
                                                    }
                                                }
                                            }
                                        }

                                        //押しっぱなしで一定時間
                                        if (s1.touch_input.touch_check() == 1)
                                        {
                                            if (s1.cam_2d.move_check() == 0)
                                            {
                                                if (s1.touch_input.touch_tm_call() >= np)
                                                {
                                                    //    m1.msbox("long");

                                                    call_character_status();

                                                    s1.touch_input.wait(40);
                                                }
                                            }
                                        }
                                    }
                                }else
                                {
                                    if (s1.touch_input.pull_check() == 1)
                                    {
                                        if (s1.cam_2d.move_check() == 0)
                                        {
                                            if (s1.touch_input.touch_tm_call() < np)
                                            {
                                                if (s1.touch_input.input_wait <= 0)
                                                {
                                                    window_select();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }//run()

    public void draw1()
    {
        if (on != 0)
        {
            int x1 = px - (int)s1.cam_2d.call_x_positioin();
            int y1 = py - (int)s1.cam_2d.call_y_positioin();

            /*
            if (s.base_run.base_type == s.base_run.PARTY_SELECT_GOTO_DUNGEON)
            {
                y1 += 120;
            }

            if (s.base_run.base_type == s.base_run.PARTY_SELECT_COPY)
            {
                y1 += 120;
            }
            */

            if (x1 + pw >= 0 - 0 && x1 <= s1.display_w_call() - 2)
            {
                

                //キャラクター管理ウインドウ
                {
                    int space1 = 64;
                    int space2 = 16;

                    int w11 = s1.base_run.base_call_all_w1() - space1 * 2;
                    int h11 = 270 - space2 * 2;
                    int h12 = h11;

                    float x11 = x1 + space1;
                    float y11 = y1 + 60;//+ s1.base_run.base_call_h2() / 2 - h12 / 2;

                    s1.dm1.boxdraw3(x11, y11, w11, h11, 0, 1);

                    {
                        float x31 = x11 + 12;
                        float y31 = y11 + 16;

                        g1.setfont(g1.FONT_1_SMALL_STR);

                        g1.sc(255);
                        g1.str2("○ パーティ " + m1.num_half_full_change(num1 + 1), x31, y31);

                        g1.setfont_re();
                    }

                    for (int t1 = 0; t1 < 6; t1++)
                    {
                        int num2 = t1;

                        //                        int space_x22 = 150;
                        //                        int nnt2 = 72 + 8;

                        float x21 = x1 + area2_x(t1);//x11 + t1 * 96 + 16;
                        float y21 = y1 + area2_y(t1);//y11 + 0 * 0 + 36+16;

                        int window_size1 = 80;

                        int link_num = s1.base_run.party_select_group.party_call(num1, num2);

                        {
                            //    s1.base_run.party_select_group.party_save[0][0] = 5;

                            //     g1.sc(255);
                            //     g1.str2("" + link_num, x21, y21);

                            if (link_num == s1.am1.character_null_num())
                            {
                                g1.sc(255);
                                g1.drawRect(x21, y21, window_size1, window_size1, 0, 0);
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

                                        s1.dm1.character_window_draw(x21, y21, type1, 0, 2, att1, att2, 0);
                                    }
                                }
                            }
                        }

                        g1.setfont(g1.FONT_1_VERY_SMALL_STR);

                        if (link_num != s1.am1.character_null_num())
                        {
                            int level1 = s1.character_group.character1[link_num].call_level();

                            g1.sc(255);
                            //    g1.str2("Lv 100", x21, y21 + window_size1+8);
                            g1.str2_center("Ｌｖ."+level1, x21 + window_size1 / 2, y21 + window_size1 + 10);
                        }

                        g1.setfont_re();
                    }

                    {
                        float x52 = x11 + 16+110;
                        float y52 = y11 + 172;

                        //    g1.str2("Ｌｖ　：１００　ＨＰ　：１０００　ＭＰ　：　１００", x52, y52 + line_h() * 0);
                        //    g1.str2("ＴＥＣ：１００　ＡＴＫ：　１００　ＩＮＴ：　１００", x52, y52 + line_h() * 1);

                        int[] numbox1 = { 0, 0, 0, 0, 0, 0 };
                        String[] strbox1 = { "", "", "", "", "", "" };

                        {
                            int party_num = num1;

                            //    numbox1[0] = s1.character_group.character1[character_link].call_level();
                            numbox1[1] = s1.base_run.party_select_group.party_status_call(party_num,s1.character_group.STATUS_MHP);//s1.character_group.character1[character_link].call_mhp();
                            numbox1[2] = s1.base_run.party_select_group.party_status_call(party_num, s1.character_group.STATUS_MMP);//s1.character_group.character1[character_link].call_mmp();
                        //    numbox1[3] = 10000;//s1.character_group.character1[character_link].call_tec();
                            numbox1[4] = s1.base_run.party_select_group.party_status_call(party_num, s1.character_group.STATUS_ATK); //s1.character_group.character1[character_link].call_atk();
                            numbox1[5] = s1.base_run.party_select_group.party_status_call(party_num, s1.character_group.STATUS_INT); //s1.character_group.character1[character_link].call_int();
                        }

                        for (int t1 = 0; t1 < 6; t1++)
                        {
                            numbox1[t1] = m1.iover(numbox1[t1], 0, 9999);
                        }

                        for (int t1 = 0; t1 < 6; t1++)
                        {
                            strbox1[t1] = m1.num_half_full_change(numbox1[t1]);

                            {
                                strbox1[t1] = m1.add_space_str1(strbox1[t1], 4, 0, "　");
                            }
                        }


                        g1.setfont(g1.FONT_1_SMALL_STR);

                        int nn1 = 19;
                        int line_h1 = 32;

                        g1.str2("ＨＰ　：" + strbox1[1], x52 + 0 * nn1, y52 + line_h1 * 0);
                        g1.str2("ＭＰ　：" + strbox1[2], x52 + 10 * nn1, y52 + line_h1 * 0);
                        
                        g1.str2("ＡＴＫ：" + strbox1[4], x52 + 0 * nn1, y52 + line_h1 * 1);
                        g1.str2("ＩＮＴ：" + strbox1[5], x52 + 10 * nn1, y52 + line_h1 * 1);

                        g1.setfont_re();
                    }
                }

               
            }
        }
    }
}
