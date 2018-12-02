using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleMenu : SetVoid1
{
    int battle_menu_x = 720;

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

    //エンチャントの決定
    static int BATTLE_MENU_AREA4_MAX = 6;
    int[] area4_x = new int[BATTLE_MENU_AREA4_MAX];
    int[] area4_w = new int[BATTLE_MENU_AREA4_MAX];
    int[] area4_y = new int[BATTLE_MENU_AREA4_MAX];
    int[] area4_h = new int[BATTLE_MENU_AREA4_MAX];

    //バトルコマンドの決定
 //   static int BATTLE_MENU_AREA5_MAX = 6;
    int[][] area5_x = new int[2][];
    int[][] area5_w = new int[2][];
    int[][] area5_y = new int[2][];
    int[][] area5_h = new int[2][];

    public BattleMenu(Summary1 s1)
    {
        set1(s1);        
    }
    
    public void init1()
    {
        long time1 = m1.get_time();

        for (int t1 = 0; t1 < BATTLE_MENU_AREA1_MAX ; t1++)
        {
            area1_y[t1] = 0;
            area1_h[t1] = 0;
        }

        area1_y[0] = 0; area1_h[0] = 32;
        area1_y[1] = area1_y[0] + area1_h[0]; area1_h[1] = 104;
        area1_y[2] = area1_y[1] + area1_h[1]; area1_h[2] = 296;
        area1_y[3] = area1_y[2] + area1_h[2]; area1_h[3] = 108;


        //ボタンメニュー
        {
            for (int t2 = 0; t2 < 2; t2++)
            {
                area2_x[t2] = -5000;

                if (t2 == 1)
                {
                    area2_x[t2] = battle_menu_x + 30+108+8;
                    area2_w[t2] = 80;

                    area2_y[t2] = area1_y[0] + 10;
                    area2_h[t2] = 26;
                }
            }
        }


        //エンチャントメニュー
        {
            for (int t2 = 0; t2 < BATTLE_MENU_AREA4_MAX; t2++)
            {
            //    if (s1.battle_run.battle_member_group.member_on_check(t2) == 1)
                { 
                    area4_x[t2] = battle_menu_x + 30;
                    area4_w[t2] = 180;

                    area4_y[t2] = area1_y[2] + t2 * 46 + 12 + (t2 / 3) * 6 * 1;
                    area4_h[t2] = 32;
                }
            }

            //x3 + 20, y42 + t1 * 44 + 12 + (t1 / 3) * 4 * 1
        }

        //バトルコマンド
        {
            
            for (int t = 0; t < 2; t++)
            {
                area5_x[t] = new int[2];
                area5_y[t] = new int[2];
                area5_w[t] = new int[2];
                area5_h[t] = new int[2];
            }
            

            for (int t1 = 0; t1 < 2; t1++)
            {
                for (int t2 = 0; t2 < 2; t2++)
                {
                    //x3 + 12 + t1 * (120-6), y43 + t2 * 50  + 12

                    area5_x[t1][t2] = battle_menu_x + 12 + t1 * (120 - 6) + 4;
                    area5_y[t1][t2] = area1_y[3] + t2 * 50 + 12 + 2;
                    area5_w[t1][t2] = 96;
                    area5_h[t1][t2] = 36;
                }
            }
        }

    //    m1.msbox((m1.get_time() - time1));
    }

    public void run1()
    {

        if (s1.dialog_window1.on_check() == 0)
        {

            //戻るボタン
            {

            }

            if (s1.battle_run.flow_free_check() == 1)
            {
                {
                    int px1 = s1.touch_input.point_x1();
                    int py1 = s1.touch_input.point_y1();

                    for (int t2 = 0; t2 < BATTLE_MENU_AREA2_MAX; t2++)
                    {
                        int x1 = area2_x[t2];
                        int y1 = area2_y[t2];
                        int w1 = area2_w[t2];
                        int h1 = area2_h[t2];

                        if (m1.rect_decision(px1, py1, area2_x[t2], area2_y[t2], area2_w[t2], area2_h[t2]) == 1)
                        {
                            if (s1.touch_input.pull_check() == 1)
                            {
                                if (t2 == 1)
                                {
                                    m1.msbox("戻るボタンのチェック！");
                                }
                            }
                        }
                    }
                }

                {
                    int px1 = s1.touch_input.point_x1();
                    int py1 = s1.touch_input.point_y1();

                    for (int t2 = 0; t2 < BATTLE_MENU_AREA4_MAX; t2++)
                    {
                        if (s1.battle_run.battle_member_group.member_on_check(t2) == 1)
                        {
                            int x1 = area4_x[t2];
                            int y1 = area4_y[t2];
                            int w1 = area4_w[t2];
                            int h1 = area4_h[t2];

                            if (m1.rect_decision(px1, py1, area4_x[t2], area4_y[t2], area4_w[t2], area4_h[t2]) == 1)
                            {
                                if (s1.touch_input.pull_check() == 1)
                                {
                                    if (t2 <= 2 && s1.battle_run.battle_member_group_status_control.set_enchant1 != t2)
                                    {
                                        s1.battle_run.battle_member_group_status_control.set_enchant1 = t2;
                                    }
                                    if (t2 >= 3 && s1.battle_run.battle_member_group_status_control.set_enchant2 != t2)
                                    {
                                        s1.battle_run.battle_member_group_status_control.set_enchant2 = t2;
                                    }

                                    s1.touch_input.wait(2);
                                }
                            }
                        }
                    }
                }


                {
                    int px1 = s1.touch_input.point_x1();
                    int py1 = s1.touch_input.point_y1();

                    for (int t2 = 0; t2 < 2; t2++)
                    {
                        for (int t1 = 0; t1 < 2; t1++)
                        {
                            int x1 = area5_x[t1][t2];
                            int y1 = area5_y[t1][t2];
                            int w1 = area5_w[t1][t2];
                            int h1 = area5_h[t1][t2];

                            if (m1.rect_decision(px1, py1, x1, y1, w1, h1) == 1)
                            {
                                if (s1.touch_input.pull_check() == 1)
                                {
                                    s1.battle_run.battle_member_group_status_control.battle_command = t1 + t2 * 2;

                                //    s1.battle_run.battle_mana.battle_mana_use_calc();

                                    s1.battle_run.attack_start();

                                    s1.touch_input.wait(2);

                                //    m1.msbox(1);
                                }
                            }
                        }


                    }
                }
            }
        }
    }//run1()

    public void draw1()
    {
        int x3 = battle_menu_x;

        g1.sc(32);
        g1.drawRect(x3, 0, 240, 540, 0, 1);

        g1.sc(160, 240, 160);
        g1.drawRect(720, 0, 240, 540, 0, 0);

        //g1.drawImage2(ic1.loadcheck(0, 0, 0), 720, 0, 480, 48*2);

        int x16 = 720, y16 = 0, w16 = 240, h16 = 540;


        //windowのテスト
        {
        //    s1.dm1.boxdraw3(10, 10, 100, 400, 0, 1);

        }



        g1.drawrectImage(ic1.loadcheck(0, 1, 0), 720, 0, 240, 280);
        g1.drawrectImage(ic1.loadcheck(0, 1, 0), 720, 0 + 280, 240, 280);

        g1.drawImage2(ic1.loadcheck(1, 21, 0), 720 - 8, 0);

        //    g1.drawImage(ic1.loadcheck(0, 0, 0), x16, y16, x16 + w16, y16, x16 + w16, y16 + h16, x16, y16 + h16);

        //配置
        {
            g1.sc(240);

            int y30 = area1_y[0], h30 = area1_h[0];
            int y31 = area1_y[1], h31 = area1_h[1];
            int y32 = area1_y[2], h32 = area1_h[2];
            int y33 = area1_y[3], h33 = area1_h[3];

            int rect_draw_flag = 0;
            if (rect_draw_flag == 1)
            {
                g1.drawRect(x3, y30, 240, h30, 0, 0);
                g1.drawRect(x3, y31, 240, h31, 0, 0);
                g1.drawRect(x3, y32, 240, h32, 0, 0);
                g1.drawRect(x3, y33, 240, h33, 0, 0);
            }

            //1
            {
                int y43 = y33;

                String[] st7 = { "", "← 戻る"};
                g1.setfont(g1.FONT_1_SMALL_STR);

                for (int t1 = 0; t1 <= 1; t1++)
                {
                //    s1.dm1.boxdraw3(area2_x[t1], area2_y[t1], area2_w[t1], area2_h[t1], 0, 1);

                    g1.str2_center("" + st7[t1], area2_x[t1] + area2_w[t1] / 2 + 2, area2_y[t1] + 4, 20);
                }

                g1.setfont(g1.FONT_1_SMALL_STR);
            }

            //2 マナ
            {
                int y41 = y31;

                for (int t2 = 0; t2 <= 2; t2++) 
                {
                    for (int t1 = 0; t1 <= 1; t1++)
                    {
                        int att1 = t1 + t2 * 2 + 1;                        
                        int x51 = x3 + 36 + t1 * (120 - 4) + 4;
                        int y51 = y41 + t2 * 30 + 4 + 16;

                        //    g1.sc(240);
                        //    g1.drawRect(x51+4, y51, 60, 10, 0, 0);

                        //属性画像  
                        if (att1 <= 4)
                        {
                            s1.dm1.attribute_draw(x51 - 16, y51 + 4, att1, 0.6f, 0, 0);
                        }
                        if (att1 >= 5)
                        {
                            s1.dm1.hp_and_mp(x51 - 16, y51 + 4, att1 - 4, 0.8f, 0, 0);

                            if (att1 == 5) { att1 = 101; }
                            if (att1 == 6) { att1 = 102; }
                        }

                        int nn1 = 50;
                        nn1 = s1.battle_run.battle_mana.mana_point_draw_per_call((t1 + t2 * 2));
                    //    if (t1 == 0) { nn1 = 150; }

                        s1.dm1.gauge_window_draw1(x51 + 4, y51 - 2, 60, nn1, att1, 12, 0, 0);
                    }
                }                
            }

            //3
            {
                int y42 = y32;

                for (int t1 = 0; t1 <= 5; t1++)
                {
                    if (s1.battle_run.battle_member_group.member_on_check(t1) == 1)
                    {
                        //    g1.sc(240);
                        //    g1.drawRect(x3 + 20, y42 + t1 * 44 + 12 + (t1 / 3) * 4 * 1, 200, 36, 0, 0);

                        int np = 0;
                        if (t1 == s1.battle_run.battle_member_group_status_control.set_enchant1 || t1 == s1.battle_run.battle_member_group_status_control.set_enchant2)
                        {
                            np = 1;
                        }

                        s1.dm1.boxdraw3(area4_x[t1], area4_y[t1], area4_w[t1], area4_h[t1], np, 1);


                        g1.setfont(g1.FONT_1_SMALL_STR);

                   //     if (t1 == 0)
                        {
                            int att1 = 1;
                            int nt1 = 12;

                            //    s1.dm1.attribute_draw(area4_x[t1] + 4 + nt1 + 2, area4_y[t1] + nt1 + 3, att1, 0.5f, 0, 0);
                            //    g1.str2("１２３４５６７", area4_x[t1] + 32, area4_y[t1] + 6);

                            //   g1.str2("１２３４５６７８", area4_x[t1] + 12, area4_y[t1] + 6+1);

                            String enchantment_name = s1.battle_run.battle_member_group.enchantment_name_call(t1);


                            g1.str2_center(enchantment_name, area4_x[t1] + area4_w[t1]/2, area4_y[t1] + 6 + 1, g1.font_w_size_call(0));
                        }

                        g1.setfont_re();
                    }
                }

            }

            //4
            {
                int y43 = y33;

                String[] st7 = { "アタック", "バースト", "チャージ", "キュア" };
                g1.setfont(g1.FONT_1_SMALL_STR);

                for (int t2 = 0; t2 <= 1; t2++)
                {
                    for (int t1 = 0; t1 <= 1; t1++)
                    {
                     //   g1.sc(240);
                     //   g1.drawRect(x3 + 12 + t1 * (120-6), y43 + t2 * 50  + 12, 100, 40, 0, 0);

                        s1.dm1.boxdraw3(area5_x[t1][t2], area5_y[t1][t2], area5_w[t1][t2], area5_h[t1][t2], 0, 1);

                        g1.str2_center("" + st7[t1 + t2 * 2], area5_x[t1][t2] + area5_w[t1][t2] / 2 + 2, area5_y[t1][t2] + 9, 20);
                    }
                }

                g1.setfont(g1.FONT_1_SMALL_STR);
            }
        }

    }
}
