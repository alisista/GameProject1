using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BaseMainAddMenu : SetVoid1
{
    //適当に配置できるウインドウ
    static int MENU_AREA1_MAX = 2;
    int[] area1_x = new int[MENU_AREA1_MAX];
    int[] area1_w = new int[MENU_AREA1_MAX];
    int[] area1_y = new int[MENU_AREA1_MAX];
    int[] area1_h = new int[MENU_AREA1_MAX];
    int[] area1_str_add_y = new int[MENU_AREA1_MAX];


    //適当に配置できるボタン
    static int MENU_AREA2_MAX = 2;
    int[] area2_x = new int[MENU_AREA2_MAX];
    int[] area2_w = new int[MENU_AREA2_MAX];
    int[] area2_y = new int[MENU_AREA2_MAX];
    int[] area2_h = new int[MENU_AREA2_MAX];
    int[] area2_str_add_y = new int[MENU_AREA2_MAX];
    String[] area2_str = new String[MENU_AREA2_MAX];


    public BaseMainAddMenu(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        for (int t2 = 0; t2 < MENU_AREA1_MAX; t2++)
        {
            area1_x[t2] = -5000;
        }

        for (int t2 = 0; t2 < MENU_AREA2_MAX; t2++)
        {
            area2_x[t2] = -5000;
            area2_str[t2] = "";
        }

        {
            if (s1.base_run.base_type_check(s1.base_run.PARTY_USE_STAGE) == 1)
            {
                area2_str[0] = "出発する";

                area2_w[0] = 120;
                area2_h[0] = 48;
                area2_x[0] = s1.base_run.base_call_all_w1() / 2 - area2_w[0] / 2;
                area2_y[0] = 400;
                area2_str_add_y[0] = 12;
            }

            if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_SHOP_SELL) == 1)
            {
                area1_w[0] = 270;
                area1_h[0] = 68;
                area1_x[0] = s1.base_run.base_call_all_w1() - area1_w[0] - 72;
                area1_y[0] = 540 - area1_h[0] - 20;

                area2_w[0] = 80;
                area2_h[0] = 40;
                area2_x[0] = area1_x[0] + area1_w[0] - area2_w[0] - 16;
                area2_y[0] = area1_y[0] + 14;
                area2_str_add_y[0] = 10;
                area2_str[0] = "実行";
            }
        }
    }

    public void push_button_call(int button_num)
    {
        if (s1.base_run.base_type_check(s1.base_run.PARTY_USE_STAGE) == 1)
        {
            if (button_num == 0)
            {
                //    if (s1.cam_2d.ax <= 0.05f)
                {
                    if (s1.base_run.party_select_group.party_member_num_call() >= 1)
                    {
                        s1.touch_input.wait(4);

                        {
                            goto_dungeon();
                        }

                        s1.base_run.party_select_group.party_camera_control.party_camera_move_decide();
                    }
                }
            }
        }

        if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_SHOP_SELL) == 1)
        {
            if (button_num == 0)
            {
            //    m1.msbox();

                s1.equipment_group.sell_multi();

                s1.base_run.equipment_organization_group.sort_update();
            }
        }
    }

    public void goto_dungeon()
    {
        int wait1 = 100;

        s1.fade_run.create1(s1.fade_run.FADE_WAIT_60, 1, 1, 0);

        s1.wait_action.waitact_set(s1.wait_action.BASE_TO_DUNGEON, wait1);
        //        s1.wait_action.freei[0] = type;
        s1.touch_input.wait(wait1);
    }


    public void run1()
    {
        if (s1.base_run.base_move_no_check() == 0 && s1.cam_2d.move_check() == 0) //&& s1.cam_2d.ax <= 0.05f)
        {
            int px1 = s1.touch_input.point_x1();
            int py1 = s1.touch_input.point_y1();
            
            for (int t2 = 0; t2 < MENU_AREA2_MAX; t2++)
            {
                {
                    int x1 = area2_x[t2];
                    int y1 = area2_y[t2] - 2;
                    int w1 = area2_w[t2];
                    int h1 = area2_h[t2] + 4;

                    int np = 0;

                    if (m1.rect_decision(px1, py1, x1, y1, w1, h1) == 1)
                    {
                        if (s1.touch_input.pull_check() == 1)
                        {
                            np = 1;
                        }
                    }

                    if (np == 1)
                    {
                        //   s1.touch_input.wait(4);

                        push_button_call(t2);
                    }
                }
            }

            for (int t2 = 0; t2 < MENU_AREA1_MAX; t2++)
            {
                {
                    int x1 = area1_x[t2];
                    int y1 = area1_y[t2] - 2;
                    int w1 = area1_w[t2];
                    int h1 = area1_h[t2] + 4;

                    int np = 0;

                    if (m1.rect_decision(px1, py1, x1, y1, w1, h1) == 1)
                    {
                        if (s1.touch_input.pull_check() == 1)
                        {
                            np = 1;
                        }
                    }

                    if (np == 1)
                    {
                        s1.touch_input.wait(2);
                    }
                }
            }
        }
    }

    public void draw1()
    {
        //2
        {
            for (int t1 = 0; t1 < MENU_AREA1_MAX; t1++)
            {
                {
                    s1.dm1.boxdraw3(area1_x[t1], area1_y[t1], area1_w[t1], area1_h[t1], 0, 1);
                }
            }

            for (int t1 = 0; t1 < MENU_AREA2_MAX; t1++)
            {
                {
                    int np = 0;

                    s1.dm1.boxdraw3(area2_x[t1], area2_y[t1], area2_w[t1], area2_h[t1], np, 1);

                    int no_flag = 0;

                    //     int party_use_num1 = s1.base_run.party_select_group.party_use_num_call();

                    {
                        if (s1.base_run.base_type_check(s1.base_run.PARTY_USE_STAGE) == 1)
                        {
                            if (s1.base_run.party_select_group.party_member_num_call() <= 0) { no_flag = 1; }
                        }
                    }


                    g1.setfont(g1.FONT_1_MIDDLE_STR);

                    //     if (t1 == 0)
                    {
                        String button_name1 = area2_str[t1];

                        g1.str2_center(button_name1, area2_x[t1] + area2_w[t1] / 2, area2_y[t1] + area2_str_add_y[t1], g1.font_w_size_call(0));
                    }

                    if (no_flag == 1)
                    {
                        int clear1 = 60;

                        g1.sc(0);
                        g1.setClear2(clear1);
                        g1.drawRect(area2_x[t1], area2_y[t1], area2_w[t1], area2_h[t1], 0, 1);
                        g1.setClear2_re();
                    }

                    g1.setfont_re();
                }
            }

            draw2();
        }
    }

    public void draw2()
    {
        {
            int x51 = area1_x[0] + 16;
            int y51 = area1_y[0] + 24;

            //g1.setfont(g1.FONT_1_MIDDLE_STR);

            g1.setfont(g1.FONT_1_SMALL_STR);

            {
                int ntt1 = m1.iover(s1.equipment_group.sell_multi_coin_call(), 0, 999999);
            //    ntt1 = 7777777;

                g1.sc(255);
                String coin_str1 = "Coin:" + m1.add_space_str1("" + ntt1, 6, 0, " ");
                g1.str2(coin_str1, x51, y51);
            }

            g1.setfont_re();
        }
    }
}
