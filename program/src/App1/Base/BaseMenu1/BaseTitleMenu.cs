using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//左画面の一番上に表示されるタイトル名等
public class BaseTitleMenu : SetVoid1
{
    //画面上部のボタン
    static int MENU_AREA2_MAX = 3;
    int[] area2_x = new int[MENU_AREA2_MAX];
    int[] area2_w = new int[MENU_AREA2_MAX];
    int[] area2_y = new int[MENU_AREA2_MAX];
    int[] area2_h = new int[MENU_AREA2_MAX];
    String[] area2_name = new String[MENU_AREA2_MAX];

    public BaseTitleMenu(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        for (int t1 = 0; t1 < 2; t1++)
        {
            area2_x[t1] = -90000;
            area2_y[t1] = 0;
            area2_w[t1] = 0;
            area2_h[t1] = 0;

            area2_name[t1] = "";
        }

        for (int t1 = 0; t1 < 1; t1++)
        {
            area2_x[t1] = 16 + 400 + (1 - t1) * 160;
            area2_y[t1] = s1.base_run.base_title_menu_y() + 2;
            area2_w[t1] = 120;
            area2_h[t1] = 44 - 2 * 2;
        }

        data_set1();
    }


    public String title_name_call()
    {
        String st1 = "";
        int base_type1 = s1.base_run.base_type;

        if (base_type1 == s1.base_run.STAGE1_SELECT) { st1 = "ステージ セレクト"; }
        if (base_type1 == s1.base_run.ORGANIZATION_MENU) { st1 = "編成"; }
        if (base_type1 == s1.base_run.SHOP_MENU) { st1 = "ショップ"; }
        if (base_type1 == s1.base_run.OTHER_MENU) { st1 = "その他"; }

        if (base_type1 == s1.base_run.CHARACTER_ORGANIZATION) { st1 = "キャラクターの管理"; }
        if (base_type1 == s1.base_run.CHARACTER_PARTY_SELECT) { st1 = "パーティメンバーの選択"; }
        if (s1.base_run.base_type_check(s1.base_run.CHARACTER_MULTI_PARTY_SELECT) == 1) { st1 = "メンバーの複数選択"; }

        if (base_type1 == s1.base_run.EQUIPMENT_ORGANIZATION) { st1 = "倉庫の確認"; }
        if (base_type1 == s1.base_run.EQUIPMENT_CHARACTER_EQ_CHANGE) { st1 = "装備品の選択"; }

        if (base_type1 == s1.base_run.PARTY_ORGANIZATION) { st1 = "パーティ編成"; }
        if (base_type1 == s1.base_run.PARTY_USE_STAGE) { st1 = "出発するパーティの選択"; }

        if (base_type1 == s1.base_run.STAGE_RESULT) { st1 = "リザルト"; }

        if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_SHOP_BUY) == 1) { st1 = "装備品の購入"; }
        if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_SHOP_SELL) == 1) { st1 = "装備品の売却"; }

        if (s1.base_run.base_type_check(s1.base_run.SYSTEM_OPTION) == 1) { st1 = "ゲームの設定"; }

        return st1;
    }

    public void data_set1()
    {
        //    if (s1.base_run.base_function.equipment_organization_check() == 1)

        if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_CHARACTER_EQ_CHANGE) == 1)
        {
            area2_name[0] = "はずす";
        }

        if (s1.base_run.base_type_check(s1.base_run.CHARACTER_PARTY_SELECT) == 1)
        {
            area2_name[0] = "はずす";
        }

        if (s1.base_run.base_type_check(s1.base_run.PARTY_ORGANIZATION) == 1
         || s1.base_run.base_type_check(s1.base_run.PARTY_USE_STAGE) == 1
            )
        {
            area2_name[0] = "複数の編集";
        }
    }

    public void button_call(int num1)
    {
        if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_CHARACTER_EQ_CHANGE) == 1)
        {
            s1.character_group.character1[s1.base_run.character_status.character_link].equipment_change(s1.am1.equipment_null_num(), s1.base_run.character_status.equipment_slot);

            s1.base_run.base_function.character_status_draw_call();
        }

        if (s1.base_run.base_type_check(s1.base_run.CHARACTER_PARTY_SELECT) == 1)
        {
            int link_num = s1.am1.character_null_num();

            s1.base_run.character_organization_group.set_link_memo = link_num;

            s1.base_run.menu_change_waitact_set(s1.base_run.character_organization_group.back_base_type);

            s1.wait_action.action_add = s1.wait_action.ACTION_ADD_PARTY_SET;
        }

        if (s1.base_run.base_type_check(s1.base_run.PARTY_ORGANIZATION) == 1
         || s1.base_run.base_type_check(s1.base_run.PARTY_USE_STAGE) == 1
            )
        {
            s1.base_run.character_organization_group.back_base_type = s1.base_run.base_type;

            s1.base_run.menu_change_waitact_set(s1.base_run.CHARACTER_MULTI_PARTY_SELECT);
        }
    }//button_call

    public void run1()
    {
        if (s1.base_run.base_move_no_check() == 0)
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

                    if (m1.rect_decision(px1, py1, x1, y1, w1, h1) == 1)
                    {
                        if (s1.touch_input.pull_check() == 1)
                        {
                            if (m1.strbyte(area2_name[t2]) >= 1)
                            {
                                s1.touch_input.wait(4);

                                button_call(t2);
                            }
                        }
                    }
                }
            }
        }
    }
        

    public void draw1()
    {
        int y1 = s1.base_run.base_title_menu_y();

        {
            int x11 = 16;
            int y11 = y1;
            int w11 = 320;
            int h11 = 44;

            s1.dm1.boxdraw3(x11, y11, w11, h11, 0, 1);


            //メニューのタイトル名
            {
                String st = title_name_call();

                g1.setfont(g1.FONT_1_MAIN_STR);

                g1.sc(255);
                //   g1.str2(st, x11 + 10, y11 + 9);

                g1.str2_center(st, x11 + w11 / 2 - 2, y11 + 9);

                g1.setfont_re();
            }
        }

        {
            for (int t1 = 0; t1 < 2; t1++)
            {
                if (m1.strbyte(area2_name[t1]) >= 1)
                {
                    int np = 0;

                    s1.dm1.boxdraw3(area2_x[t1], area2_y[t1], area2_w[t1], area2_h[t1], np, 1);

                    {
                        g1.setfont(g1.FONT_1_SMALL_STR);

                        g1.sc(255);
                        g1.str2_center(area2_name[t1], area2_x[t1] + area2_w[t1] / 2, area2_y[t1]+11);

                        g1.setfont_re();
                    }
                }
            }
        }
    }
}
