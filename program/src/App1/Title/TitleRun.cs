using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class TitleRun : SetVoid1
{
    public int no_draw_flag = 0;

    //画面上部のボタン
    static int BATTLE_MENU_AREA2_MAX = 1;
    int[] area2_x = new int[BATTLE_MENU_AREA2_MAX];
    int[] area2_w = new int[BATTLE_MENU_AREA2_MAX];
    int[] area2_y = new int[BATTLE_MENU_AREA2_MAX];
    int[] area2_h = new int[BATTLE_MENU_AREA2_MAX];

    int r99;
    int l99;

    TitleBgEffectGroup title_effect_group;

    public TitleRun(Summary1 s1)
    {
        set1(s1);

        title_effect_group = new TitleBgEffectGroup(s1);
    }

    public void init1()
    {
        no_draw_flag = 0;

        //ボタンメニュー
        {
            for (int t2 = 0; t2 <= 0; t2++)
            {
                area2_x[t2] = -5000;

                if (t2 == 0)
                {
                    area2_x[t2] = 720 + 30 + 108 + 8;
                    area2_w[t2] = 80;

                    area2_y[t2] = 0 + 10;
                    area2_h[t2] = 26;
                }
            }
        }

        bg_setting1();

        {
            s1.bgm_operation.play_wait_loop_bgm(s1.bgm_operation.BGM_TITLE_1, 40);
        }
    }

    public void bg_setting1()
    {
        r99 = m1.rand(360);
        l99 = m1.rand(15) * 10;
        title_effect_group.init1();
    }

    public void run1()
    {
        title_effect_group.run1();

        {
            int px1 = s1.touch_input.point_x1();
            int py1 = s1.touch_input.point_y1();

            //ボタン１
            for (int t2 = 0; t2 < 1; t2++)
            {
                {
                    int x1 = area2_x[t2] - 2;
                    int y1 = area2_y[t2] - 2;
                    int w1 = area2_w[t2] + 4;
                    int h1 = area2_h[t2] + 4;

                    if (m1.rect_decision(px1, py1, x1, y1, w1, h1) == 1)
                    {
                        if (s1.touch_input.pull_check() == 1)
                        {
                            m1.end();
                        }
                    }
                }
            }

            //押したらゲームに移動
            {
                int x1 = 0 - 2;
                int y1 = 100 - 2;
                int w1 = 960 + 4;
                int h1 = 540 + 4;

                if (m1.rect_decision(px1, py1, x1, y1, w1, h1) == 1)
                {
                    if (s1.touch_input.pull_check() == 1)
                    {
                        s1.fade_run.create1(s1.fade_run.FADE_WAIT_60, 1, 0, 0);

                        s1.wait_action.waitact_set(s1.wait_action.TITLE_TO_BASE, 60);

                        s1.input1.wait(61);

                        s1.bgm_operation.bgm_fade_out();
                    }
                }
            }


            no_draw_flag = 0;

            if (input1.rinput(0, input1.INPUT_W) == 1)
            {
                no_draw_flag = 1;
            }

            if (input1.rinput(1, input1.INPUT_E) == 1)
            {
                bg_setting1();
            }
        }
    }

    public void draw1()
    {
        {
            //背景
            {
                int x1 = 960 / 2;
                int y1 = 540 / 2;
                float large1 = 1.0f;
                float th1 = r99;// + s1.tm1 / 2;

                g1.drawImage(ic1.loadcheck(8, 17, 0), (int)x1, (int)y1, large1, th1);
            }

            {
                g1.sc(32);
                g1.setClear2(l99);
                g1.drawRect(0, 0, s1.display_w_call(), s1.display_h_call());
                g1.setClear2_re();
            }

            title_effect_group.draw1();
        }

        if (no_draw_flag==0)
        {

            //配置
            {
                //1
                {
                    String[] st7 = { "← 終了", "" };
                    g1.setfont(g1.FONT_1_SMALL_STR);

                    g1.sc(255);

                    for (int t1 = 0; t1 <= 0; t1++)
                    {
                        //    s1.dm1.boxdraw3(area2_x[t1], area2_y[t1], area2_w[t1], area2_h[t1], 0, 1);

                        g1.str2_center("" + st7[t1], area2_x[t1] + area2_w[t1] / 2 + 2, area2_y[t1] + 4, 20);
                    }

                    g1.setfont_re();
                //    g1.setfont(g1.FONT_1_SMALL_STR);
                }
            }

            //title
            {
                int x1 = 960 / 2;
                int y1 = 540 / 2 - 100;
                float large1 = 0.6f;

                g1.drawImage(ic1.loadcheck(8, 16, 0), (int)x1, (int)y1, large1, 0);
            }

            //PUSH
            {
                g1.setfont(g1.FONT_1_MAIN_STR);

                g1.sc(255);
                g1.str2_center("ＰＵＳＨ　ＳＴＡＲＴ", 960 / 2, 540 / 2 + 100 + (int)(m1.sin_r(8, s1.tm1 * 2 / 3)));

                g1.setfont_re();
            }


            //文字
            {
                g1.setfont(g1.FONT_1_SMALL_STR);

                g1.sc(255);
                g1.str2("" + s1.version_name_call(), 12, 12);

                //    g1.str2("（Ｑキーでスクリーンキャプチャー）", 12, 516);

                g1.str2("（Ｑキーでスクリーンキャプチャー）", 640, 516);

                g1.setfont_re();
            }
        }
    }
}
