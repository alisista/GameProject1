using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BaseOption : SetVoid1
{
    public BaseOption(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

    }


    public int button_x(int num1)
    {
        int nt = 210 + 40;
        return nt;
    }

    public int button_y(int num1)
    {
        int nt = s1.base_run.base_call_y2() + num1 * 80 + 32;
        return nt;
    }

    public int button_w(int num1)
    {
        int nt = 160;
        return nt;
    }

    public int button_h(int num1)
    {
        int nt = 80;
        return nt;
    }



    public void run1()
    {
        if (s1.base_run.base_move_no_check() == 0)
        {
            for (int t1 = 0; t1 <= 3; t1++)
            {
                int px1 = s1.touch_input.point_x1();
                int py1 = s1.touch_input.point_y1();

                int np = 0;

                int nm = t1;
                int x7 = button_x(nm) - np;
                int y7 = button_y(nm) - np;
                int w7 = button_w(nm) + np * 2;
                int h7 = button_h(nm) + np * 2;

                if (m1.rect_decision(px1, py1, x7, y7, w7, h7) == 1)
                {
                    if (s1.touch_input.pull_check() == 1)
                    {
                        if (t1 == 0)
                        {
                            s1.bgm_vol += 20;
                            if (s1.bgm_vol > 100) s1.bgm_vol = 0;

                            s1.bgm_operation.bgm_volume_update();
                        }

                        if (t1 == 1)
                        {
                            s1.se_vol += 20;
                            if (s1.se_vol > 100) s1.se_vol = 0;

                            s1.sound_effect_operation.sound_effect_volume_update();
                        }

                        if (t1 == 2)
                        {
                            s1.draw_count_max += 1;
                        //    if (s1.draw_count_max <= 0) { s1.draw_count_max = 3; }
                             if (s1.draw_count_max >= 4) { s1.draw_count_max = 1; }
                        }
                    }
                }
            }
        }
    }

    public void draw1()
    {
        {
            int x1 = 20+40;
            int y1 = 20 + s1.base_run.base_call_y2();
            int w1 = 350;//440;
            int h1 = 360-80;//460;

            s1.dm1.boxdraw3(x1, y1, w1, h1, 0, 1);

           g1.setfont(g1.FONT_1_MAIN_STR);
       
            String[] stbox1 = { "BGM", "SE", "描画回数", "" };

            g1.sc(255);
            for (int t1 = 0; t1 < 3; t1++)
            {
                g1.str2(stbox1[t1], x1 + 32, y1 + 40 + t1 * 80);

                {
                    String st2 = "";

                    if (t1 == 0) { st2 = "" + m1.add_space_str1(""+s1.bgm_vol,3,0," ") + " %"; }
                    if (t1 == 1) { st2 = "" + m1.add_space_str1("" + s1.se_vol, 3, 0, " ") + " %"; }
                    if (t1 == 2) {
                        if (s1.draw_count_max == 1) { st2 = "1 / 1"; }
                        if (s1.draw_count_max == 2) { st2 = "1 / 2"; }
                        if (s1.draw_count_max == 3) { st2 = "1 / 3"; } }
                //    if (t1 == 3) { if (s.dialog_order == 0) { st2 = "YES_NO"; } if (s.dialog_order == 1) { st2 = "NO_YES"; } }

                    int np = 0;
                 //   if (t1 >= 2) np = -10;
                 //   if (t1 >= 3) np = -20;

                    g1.str2(st2, x1 + 242 + np, y1 + 40 + t1 * 80);
                }

                int x10 = button_x(t1);
                int y10 = button_y(t1);
                int w10 = button_w(t1);
                int h10 = button_h(t1);

             //      g1.drawRect(x10, y10, w10, h10, 0, 0);
            }

            g1.setfont(g1.FONT_1_SMALL_STR);

            g1.sc(255);
            g1.str2("（画面上の数字を押すと 設定が変更されます）", 300, 510);

            g1.setfont_re();
        }
    }
}
