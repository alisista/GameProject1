using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BaseStageSelect1 : SetVoid1
{
    public int num1;
    public int dungeon_num1;

    public int on;

    public int type1;
    public int px;
    public int py;
    public int pw;
    public int ph;

    public String name1;

    public BaseStageSelect1(Summary1 s1, int num1)
    {
        set1(s1);
        this.num1 = num1;
    }

    public void init1()
    {
        on = 0;

        dungeon_num1 = 0;

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
        ph = 64;//44;
    }


    public void nameset()
    {
        //名前の設定
        {
            int nt1 = dungeon_num1 + 1;

            name1 = s1.data_magagement.dungeon_data.dungeon_name(nt1);//"１２３４５６７８９０:"+ dungeon_num1;
        }
    }


    public void stage_select_push()
    {
        int over_flag = 0;

        if (s1.base_run.equipment_organization_group.box_over_check() == 0) { }
        else
        {
            s1.dialog_window1.create1(s1.dialog_window1.EQUIPMENT_OVER, 0, s1.dialog_window1.DIALOG_OK, 0);

            over_flag = 1;
        }

        if (over_flag == 0)
        {
            {
                s1.app_variable1.stage_type1 = 0;
                s1.app_variable1.stage_type2 = dungeon_num1 + 1;
            }

            s1.base_run.menu_change_waitact_set(s1.base_run.PARTY_USE_STAGE);
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
                    int y1 = py - (int)s1.cam_2d.call_y_positioin();

                    int px1 = s1.touch_input.point_x1();
                    int py1 = s1.touch_input.point_y1();

                    //画面範囲内
                    if (s1.base_run.base_y1_and_h1_range_in_check(px1, py1) == 1)
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

                                    //     s1.base_run.base_button_group.base_button_support.button_touch(num1);

                                    stage_select_push();
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
            float x11 = px;
            float y11 = py - s1.cam_2d.call_y_positioin();
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

                g1.str2_center(st, x11 + pw / 2 - 2, y11 + 9+8);

                g1.setfont_re();
            }
        }
    }
}
