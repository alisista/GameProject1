using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BaseMenu : SetVoid1
{
    int base_menu_x = 720;

    //各メニューの座標を設定
    static int BATTLE_MENU_AREA1_MAX = 6;
    int[] area1_y = new int[BATTLE_MENU_AREA1_MAX];
    int[] area1_h = new int[BATTLE_MENU_AREA1_MAX];

    //画面上部のボタン
    static int BATTLE_MENU_AREA2_MAX = 2;
    int[] area2_x = new int[BATTLE_MENU_AREA2_MAX];
    int[] area2_w = new int[BATTLE_MENU_AREA2_MAX];
    int[] area2_y = new int[BATTLE_MENU_AREA2_MAX];
    int[] area2_h = new int[BATTLE_MENU_AREA2_MAX];

    //メニューの移動
    static int BATTLE_MENU_AREA3_MAX = 8;
    int[] area3_x = new int[BATTLE_MENU_AREA3_MAX];
    int[] area3_w = new int[BATTLE_MENU_AREA3_MAX];
    int[] area3_y = new int[BATTLE_MENU_AREA3_MAX];
    int[] area3_h = new int[BATTLE_MENU_AREA3_MAX];


    public BaseMenu(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        for (int t1 = 0; t1 < BATTLE_MENU_AREA1_MAX; t1++)
        {
            area1_y[t1] = 0;
            area1_h[t1] = 0;
        }

        area1_y[0] = 0; area1_h[0] = 40;//32;
        area1_y[1] = area1_y[0] + area1_h[0]; area1_h[1] = 104;

        //ボタンメニュー
        {
            for (int t2 = 0; t2 < 2; t2++)
            {
                area2_x[t2] = -5000;

                if (t2 == 1)
                {
                    area2_x[t2] = base_menu_x + 30 + 108 + 8;
                    area2_w[t2] = 80;

                    area2_y[t2] = 0 + 10;
                    area2_h[t2] = 26;
                }
            }
        }

        //メニューの移動
        {
            for (int t2 = 0; t2 < BATTLE_MENU_AREA3_MAX; t2++)
            {
                //    if (s1.battle_run.battle_member_group.member_on_check(t2) == 1)
                {
                    area3_x[t2] = base_menu_x + 30;
                    area3_w[t2] = 180;

                    area3_y[t2] = area1_y[1] + t2 * 60 + 12;
                    area3_h[t2] = 34;
                }
            }

            //x3 + 20, y42 + t1 * 44 + 12 + (t1 / 3) * 4 * 1
        }
    }


    public void back_button_call()
    {
        int type1 = s1.base_run.base_type;

        if (type1 == s1.base_run.ORGANIZATION_MENU)
        {
            s1.dialog_window1.create1(s1.dialog_window1.DIALOG_GOTO_TITLE_YESNO, 0, 0, 0);
        }

        if (type1 == s1.base_run.STAGE1_SELECT
         || type1 == s1.base_run.SHOP_MENU
         || type1 == s1.base_run.OTHER_MENU
        )
        {
            s1.base_run.menu_change_waitact_set(s1.base_run.ORGANIZATION_MENU);
        }

        if (type1 == s1.base_run.CHARACTER_ORGANIZATION)
        {
            s1.base_run.menu_change_waitact_set(s1.base_run.ORGANIZATION_MENU);
        }

        if (type1 == s1.base_run.CHARACTER_PARTY_SELECT || s1.base_run.base_type_check(s1.base_run.CHARACTER_MULTI_PARTY_SELECT) == 1)
        {
            s1.base_run.menu_change_waitact_set(s1.base_run.character_organization_group.back_base_type);
        }
        

        if (type1 == s1.base_run.PARTY_ORGANIZATION)
        {
            s1.base_run.menu_change_waitact_set(s1.base_run.ORGANIZATION_MENU);
        }

        if (s1.base_run.base_type_check(s1.base_run.PARTY_USE_STAGE) == 1)
        {
            s1.base_run.menu_change_waitact_set(s1.base_run.STAGE1_SELECT);
        }


        if (type1 == s1.base_run.EQUIPMENT_ORGANIZATION)
        {
            s1.base_run.menu_change_waitact_set(s1.base_run.ORGANIZATION_MENU);
        }

        if (type1 == s1.base_run.EQUIPMENT_CHARACTER_EQ_CHANGE)
        {
            s1.base_run.base_function.character_status_draw_call();
        }

        if (s1.base_run.base_type_check(s1.base_run.STAGE_RESULT) == 1)
        {
            s1.base_run.menu_change_waitact_set(s1.base_run.ORGANIZATION_MENU);
        }

        if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_SHOP_BUY) == 1
         || s1.base_run.base_type_check(s1.base_run.EQUIPMENT_SHOP_SELL) == 1)
        {
            s1.base_run.menu_change_waitact_set(s1.base_run.SHOP_MENU);
        }

        if (s1.base_run.base_type_check(s1.base_run.SYSTEM_OPTION) == 1)
        {
            s1.base_run.menu_change_waitact_set(s1.base_run.OTHER_MENU);
        }
        
    }


    public void run1()
    {
        if (s1.base_run.base_move_no_check() == 0)
        {
            int px1 = s1.touch_input.point_x1();
            int py1 = s1.touch_input.point_y1();

            for (int t2 = 0; t2 < BATTLE_MENU_AREA2_MAX; t2++)
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
                            if (t2 == 1)
                            {
                                np = 1;
                            }
                        }
                    }

                    if (s1.touch_input.push_check(1) == 1) { np = 1; }

                    if (np == 1)
                    {
                        s1.touch_input.wait(4);

                        back_button_call();                        
                    }
                }
            }

            for (int t2 = 0; t2 < BATTLE_MENU_AREA3_MAX; t2++)
            {
                {
                    int x1 = area3_x[t2];
                    int y1 = area3_y[t2] - 2;
                    int w1 = area3_w[t2];
                    int h1 = area3_h[t2] + 4;

                    if (m1.rect_decision(px1, py1, x1, y1, w1, h1) == 1)
                    {
                        if (s1.touch_input.pull_check() == 1)
                        {
                            //    m1.msbox(t2);
                            int base_change_type = -1;

                            if (t2 == 0) { base_change_type = s1.base_run.STAGE1_SELECT; }
                            if (t2 == 1) { base_change_type = s1.base_run.ORGANIZATION_MENU; }
                            if (t2 == 2) { base_change_type = s1.base_run.SHOP_MENU; }
                            if (t2 == 3) { base_change_type = s1.base_run.OTHER_MENU; }

                            if (base_change_type >= 0)
                            {
                                s1.base_run.menu_change_waitact_set(base_change_type);

                                if (base_change_type >= 0)
                                {
                                    if (s1.base_run.sound_fade_out_check(base_change_type) == 1)
                                    {
                                        s1.bgm_operation.bgm_fade_out();
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
        g1.sc(255);
        
        int x16 = 720, y16 = 0, w16 = 240, h16 = 540;

        {
            g1.drawrectImage(ic1.loadcheck(0, 1, 0), 720, 0, 240, 280);
            g1.drawrectImage(ic1.loadcheck(0, 1, 0), 720, 0 + 280, 240, 280);

            g1.drawImage2(ic1.loadcheck(1, 21, 0), 720 - 8, 0);
        }


        //配置
        {
            int y30 = area1_y[0], h30 = area1_h[0];
            int y31 = area1_y[1], h31 = area1_h[1];

            //1
            {
                String[] st7 = { "", "← 戻る" };
                g1.setfont(g1.FONT_1_SMALL_STR);

                for (int t1 = 0; t1 <= 1; t1++)
                {
                    //    s1.dm1.boxdraw3(area2_x[t1], area2_y[t1], area2_w[t1], area2_h[t1], 0, 1);

                    g1.str2_center("" + st7[t1], area2_x[t1] + area2_w[t1] / 2 + 2, area2_y[t1] + 4, 20);
                }

                g1.setfont(g1.FONT_1_SMALL_STR);
            }

            //2
            {
                int y41 = y31;

                String[] st7 = { "お出かけ", "編成", "ショップ", "その他", "", "", "", "" };

                for (int t1 = 0; t1 <= 3; t1++)
                {
                    {
                        int np = 0;

                        s1.dm1.boxdraw3(area3_x[t1], area3_y[t1], area3_w[t1], area3_h[t1], np, 1);


                        g1.setfont(g1.FONT_1_MIDDLE_STR);

                        //     if (t1 == 0)
                        {
                            String button_name1 = st7[t1];


                            g1.str2_center(button_name1, area3_x[t1] + area3_w[t1] / 2, area3_y[t1] + 6 + 1, g1.font_w_size_call(0));
                        }

                        g1.setfont_re();
                    }
                }

            }
        }


        {
            int x40 = x16 + 96;
            int y40 = 516;

            if (s1.debug_draw() == 1) { y40 -= 20; }

            g1.setfont(g1.FONT_1_SMALL_STR);

            {
                int ntt1 = m1.iover(s1.app_variable1.value_coin_num_call(), 0, 99999999);
                g1.sc(255);
                String coin_str1 = "Coin:" + m1.add_space_str1("" + ntt1, 8, 0, " ");
                g1.str2(coin_str1, x40, y40);
            }

            /*
            {
                String eq_str1 = "eq: "+ s1.equipment_group.equipment_all_num() + " / " + s1.base_run.equipment_organization_group.now_max1();

                {
                    g1.str2(eq_str1, x40, y40-40);
                }
            }
            */

            /*
            {
                {
                    g1.str2("ver load: "+s1.savedata_version_num, x40, y40 - 60);

                    g1.str2("ver now : " + s1.version_num, x40, y40 - 40);
                }
            }
            */

            g1.setfont_re();
        }
    }
}
