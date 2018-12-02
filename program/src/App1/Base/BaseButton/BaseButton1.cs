using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BaseButton1 : SetVoid1
{
    public int num1;

    public int on;

    public int type1;
    public int px;
    public int py;
    public int pw;
    public int ph;

    public String name1;

    public BaseButton1(Summary1 s1,int num1)
    {
        set1(s1);
        this.num1 = num1;
    }

    public void init1()
    {
        on = 0;

        type1 = 0;
        px = 0;
        py = 0;
        pw = 0;
        ph = 0;

        //    img_num = 0;

        name1 = "";

        for (int t1 = 0; t1 < 9; t1++)
        {
   //         free[t1] = 0;
        }
    }


    public void create(int num1, int x2, int y2)
    {
        on = 1;

        px = x2;
        py = y2;
        pw = 272 - 4;
        ph = 44;
    }


    public void nameset()
    {
        //名前の設定
        {
            int type1 = s1.base_run.base_type;

            if (type1 == s1.base_run.ORGANIZATION_MENU)
            {
                /*
                if (num >= 0)
                {
                    int nt = num;
                    name = s.stringlist.base_scroll_button_name_call(nt);
                }
                */

                if (num1 == 0) { name1 = "キャラクター"; }
                if (num1 == 1) { name1 = "パーティ編成"; }
                if (num1 == 2) { name1 = "倉庫"; }
            }

            if (type1 == s1.base_run.SHOP_MENU)
            {
                if (num1 == 0) { name1 = "装備品の購入"; }
                if (num1 == 1) { name1 = "装備品の売却"; }
            //    if (num1 == 2) { name1 = ""; }
            }

            if (type1 == s1.base_run.OTHER_MENU)
            {
                if (num1 == 0) { name1 = "ゲームの設定"; }
            }
        }
    }


    public void run1()
    {
        if (on != 0)
        {
            if (s1.base_run.base_move_no_check() == 0)
            {
                if (on != 0)
                {
                    int x1 = px;
                    int y1 = py;// + (int)s.cam.call_y_positioin();
                    
                    int px1 = s1.touch_input.point_x1();
                    int py1 = s1.touch_input.point_y1();

                    //画面範囲内
                    if (s1.base_run.base_y1_and_h1_range_in_check(px1,py1) == 1)
                    {
                        //自分がタッチされると反応
                        if (m1.rect_decision(px1, py1, x1, y1, pw, ph) == 1)
                        {
                            if (s1.touch_input.pull_check() == 1)
                            {
                                if (s1.cam_2d.move_check() == 0)
                                {
                                    //    m.end();

                                    s1.touch_input.wait(20);
                                    //    s.base_run.icon_touch_button_group.icon_touch_button_input.scroll_button_touch(num);

                                    s1.base_run.base_button_group.base_button_support.button_touch(num1);

                                //    m1.msbox(num1);
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
            int x11 = px;
            int y11 = py;
            int w11 = pw;
            int h11 = ph;

            s1.dm1.boxdraw3(x11, y11, w11, h11, 0, 1);

            //メニューのタイトル名
            {
                nameset();

                String st = name1;//"１２３４５６７８９０";

                g1.setfont(g1.FONT_1_MAIN_STR);

                g1.sc(255);
                //   g1.str2(st, x11 + 10, y11 + 9);

                g1.str2_center(st, x11 + pw / 2 - 2, y11 + 9);

                g1.setfont_re();
            }
        }
    }
}
