using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EquipmentOrganization : SetVoid1
{
    int num1;

    public int on;
    float x1;
    float y1;

    public EquipmentOrganization(Summary1 s1, int num1)
    {
        set1(s1);

        this.num1 = num1;
    }



    public void init1()
    {
        on = 0;
        x1 = 0;
        y1 = 0;
    }


    public float call_y()
    {
        float fl = y1 - s1.cam_2d.call_y_positioin();

        return fl;
    }

    public void create1(float x1, float y1)
    {
        on = 1;
        this.x1 = x1;
        this.y1 = y1;
    }


    public void window_select()
    {
        int link_num = s1.base_run.equipment_organization_group.link_sort_box_call(num1);

        {
            int wait_time1 = 10;

            if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_ORGANIZATION) == 1)
            {
                call_equipment_status(0);
            }

            if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_CHARACTER_EQ_CHANGE) == 1)
            {
                call_equipment_status(1);
            }

            if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_SHOP_SELL) == 1)
            {
                if (s1.equipment_group.equipment1[link_num].call_character_link() == s1.am1.character_null_num())
                {
                    if (s1.equipment_group.equipment1[link_num].sell_flag == 0) { s1.equipment_group.equipment1[link_num].sell_flag = 1; }
                    else { s1.equipment_group.equipment1[link_num].sell_flag = 0; }

                    wait_time1 = 2;
                }
                else
                {
                    call_equipment_status(0);
                }
            }

            if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_SHOP_BUY) == 1)
            {
                if (s1.base_run.equipment_organization_group.box_over_check() == 0)
                {
                    int coin1 = s1.equipment_group.equipment1[link_num].call_buy_coin_num();

                    if (s1.app_variable1.coin_num_call()<coin1){
                        s1.dialog_window1.create1(s1.dialog_window1.LITTLE_COIN, 0, s1.dialog_window1.DIALOG_OK, 0);
                    }
                    else
                    {
                        s1.dialog_window1.create1(s1.dialog_window1.EQUIPMENT_BUY, link_num, s1.dialog_window1.DIALOG_YESNO, 0);
                    }
                }
                else
                {
                    s1.dialog_window1.create1(s1.dialog_window1.EQUIPMENT_OVER, 0, s1.dialog_window1.DIALOG_OK, 0);
                }
            }


            s1.touch_input.wait(wait_time1);
        }
    }

    public void call_equipment_status(int eq_type)
    {
        int link_num = s1.base_run.equipment_organization_group.link_sort_box_call(num1);
        int character_link = s1.equipment_group.equipment1[link_num].call_character_link();

        if (character_link != s1.am1.character_null_num())
        {
            eq_type = 0;
        }

        if (eq_type == 0)
        {
            s1.dialog_window1.create1(s1.dialog_window1.DIALOG_EQUIPMENT_CHECK, link_num, 0, 0);
        }

        if (eq_type == 1)
        {
            s1.dialog_window1.create1(s1.dialog_window1.DIALOG_EQUIPMENT_CHARACTER_EQ_CHANGE, link_num, 0, 0);
        }
    }

    public void call_character_status()
    {
        s1.base_run.base_function.character_status_draw_call();
    }



    public void run1()
    {
        if (on != 0)
        {
            if (on != 0)
            {
                float y81 = call_y();

                if (y81 >= 0 && y81 <= 800)
                {
                    float px3 = s1.touch_input.point_x1();
                    float py3 = s1.touch_input.point_y1();

                    float x3 = x1;
                    float y3 = call_y();
                    int w3 = s1.base_run.character_organization_group.window_size();
                    int h3 = s1.base_run.character_organization_group.window_size();


                    //画面範囲内
                    if (s1.base_run.base_y1_and_h1_range_in_check(px3, py3) == 1)
                    {
                        //ボタン内
                        if (m1.rect_decision(px3, py3, x3, y3, w3, h3) == 1)
                        {
                            int np = s1.am1.long_touch_need_tm();

                            //キャラが存在している場合のみ
                            int link_num = s1.base_run.equipment_organization_group.link_sort_box_call(num1);

                            if (link_num != s1.am1.character_null_num())
                            {
                                if (s1.equipment_group.equipment_null_check(link_num) == 0)
                                {
                                    if (s1.equipment_group.equipment1[link_num].on != 0)
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
                                                        //    m1.msbox("short:" + num1);

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
                                                    call_equipment_status(0);

                                                    s1.touch_input.wait(40);
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
    }

    public void draw1()
    {
        if (on != 0)
        {
            {
                float y1 = call_y();
                int nt2 = s1.base_run.equipment_organization_group.window_size();
                int ntt1 = 120;

                if (y1 >= -ntt1 && y1 <= s1.display_h_call() + ntt1)
                {
                    int link_num = s1.base_run.equipment_organization_group.link_sort_box_call(num1);

                    int draw_flag1 = 0;
                    if (link_num != s1.am1.character_null_num())
                    {
                        if (s1.equipment_group.equipment_null_check(link_num) == 0)
                        {
                            int character_link = s1.equipment_group.equipment1[link_num].call_character_link();

                            {
                                //    g1.sc(255);
                                //    g1.drawRect(x1, y1, nt2, nt2, 0, 0);
                            }

                            int clear_flag = 0;

                            if (s1.equipment_group.equipment1[link_num].sell_flag == 1)
                            {
                                clear_flag = 1;
                            }

                            if (clear_flag == 1) { g1.setClear2(96); }


                            int type1 = s1.equipment_group.equipment1[link_num].call_type1();
                            if (s1.equipment_group.equipment1[link_num].on == 0) { type1 = -1; }

                            //装備品の描画                    
                            {
                                if (type1 >= 0)
                                {
                                    int att1 = s1.equipment_group.equipment1[link_num].call_attribute_1();
                                    int att2 = s1.equipment_group.equipment1[link_num].call_attribute_2();

                                    draw_flag1 = 1;
                                    s1.dm1.equipment_draw(x1 - 1, y1 - 1, type1, link_num, 1, att1, att2, 0);
                                }

                                //     s1.dm1.character_window_draw((int)x1, y1, type1, link_num, 2, 1, att2, s.base_run.character_mix.main_chara_link, 0, 0, 0);

                                /*
                                {
                                    g1.sc(255);
                                    g1.str2("" + s1.equipment_group.equipment1[link_num].call_time_stamp1(), x1, y1);
                                    g1.str2("" + s1.equipment_group.equipment1[link_num].call_time_stamp2(), x1, y1 + 20);
                                    g1.str2("" + s1.equipment_group.equipment1[link_num].num1, x1, y1 + 20 * 2);
                                }
                                */
                            }

                            if (clear_flag == 1) { g1.setClear2_re(); }



                            //誰かが装備している場合
                            if (character_link != s1.am1.character_null_num() && draw_flag1 == 1)
                            {
                                g1.setfont(g1.FONT_1_SMALL_STR);

                                g1.sc(255);
                                g1.str2("Ｅ", x1 + 2, y1 + 2);

                                g1.setfont_re();
                            }

                            //売却予定
                            if (s1.equipment_group.equipment1[link_num].sell_flag == 1)
                            {
                                g1.setfont(g1.FONT_1_SMALL_STR);

                                g1.sc(255);
                                g1.str2_center("売却", x1 + nt2 / 2, y1 + nt2 / 2 - 6);

                                g1.setfont_re();
                            }


                            //価格表示
                            if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_SHOP_BUY) == 1)
                            {
                                if (type1 >= 0)
                                {
                                    int coin1 = s1.equipment_group.equipment1[link_num].call_buy_coin_num();

                                    g1.setfont(g1.FONT_1_VERY_SMALL_STR);

                                    g1.sc(255);
                                    g1.str2_center("" + coin1, x1 + nt2 / 2, y1 + nt2 / 2 + 24);

                                    g1.setfont_re();
                                }
                            }
                        }
                    }

                    if (draw_flag1 == 0)
                    {
                        if (num1 < s1.base_run.equipment_organization_group.now_box_max_num_call())
                        {
                            g1.sc(255);
                            g1.drawRect(x1, y1, nt2, nt2, 0, 0);
                        }
                    }

                    //    g1.str2("sort:" + s1.base_run.equipment_organization_group.link_sort_box_call(num1), x1, y1+60);

                    /*
                    {
                        g1.sc(255);
                        g1.str2("" + s1.equipment_group.equipment1[link_num].call_time_stamp1(), x1, y1);
                        g1.str2("" + s1.equipment_group.equipment1[link_num].call_time_stamp2(), x1, y1 + 20);
                        g1.str2("" + s1.equipment_group.equipment1[link_num].num1, x1, y1 + 20 * 2);
                    }*/
                }
            }
        }
    }
}
