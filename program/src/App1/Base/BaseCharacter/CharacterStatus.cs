using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CharacterStatus : SetVoid1
{
    public int on;

    public int character_link;
    public int equipment_slot;

    public int close_wait_tm;

    public int back_base_type;//戻った時のベースタイプのメモ

    public int no_setting_flag;//装備などの変更禁止

    //各メニューの座標を設定
    static int MENU_AREA1_MAX = 6;
    int[] area1_x = new int[MENU_AREA1_MAX];
    int[] area1_w = new int[MENU_AREA1_MAX];
    int[] area1_y = new int[MENU_AREA1_MAX];
    int[] area1_h = new int[MENU_AREA1_MAX];

    //右側のタッチボタン
    static int MENU_AREA3_MAX = 8;
    int[] area3_x = new int[MENU_AREA3_MAX];
    int[] area3_w = new int[MENU_AREA3_MAX];
    int[] area3_y = new int[MENU_AREA3_MAX];
    int[] area3_h = new int[MENU_AREA3_MAX];

    //透過情報
    public ClearChange clear_change;


    public int clear_speed1() { return 8; }

    public CharacterStatus(Summary1 s1)
    {
        set1(s1);

        clear_change = new ClearChange(s1);

        {
            back_base_type = 2;

            character_link = 0;
        }
    }

    public void init1()
    {
        on = 0;
        
        equipment_slot = 0;

        no_setting_flag = 0;

        //     back_base_type = -1;

        close_wait_tm = 0;

        {
            for (int t1 = 0; t1 < MENU_AREA1_MAX; t1++)
            {
                area1_x[t1] = 0;
                area1_y[t1] = 0;
                area1_w[t1] = 0;
                area1_h[t1] = 0;
            }

            //エリア0 画面一番上
            //エリア1 左側、キャラ描画
            //エリア2 右側、ステータス画面
            {
                //area0 は未使用
                //    area1_x[0] = 0; area1_y[0] = 0; area1_w[0] = s1.display_w_call(); area1_h[0] = 10;//48;

                int y21 = 10;

                area1_x[1] = 0; area1_y[1] = area1_y[0] + y21; area1_w[1] = 360; area1_h[1] = s1.display_h_call() - y21;

                area1_x[2] = area1_x[1] + area1_w[1]; area1_y[2] = area1_y[1] ; area1_w[2] = s1.display_w_call() - area1_w[1] - 90; area1_h[2] = area1_h[1];

                area1_x[3] = area1_x[1] + area1_w[1] + area1_w[2]; area1_y[2] = area1_y[1]; area1_w[3] = (s1.display_w_call() - area1_w[1]- area1_w[2]); area1_h[3] = s1.display_h_call();
            }

            //タッチボタン
            {
                for (int t2 = 0; t2 < MENU_AREA3_MAX; t2++)
                {
                    {
                        int np5 = 48;

                        area3_x[t2] = area1_x[3] + 16 + 14;
                        area3_w[t2] = np5;

                        area3_y[t2] = 16 + 66 * t2;
                        area3_h[t2] = np5;
                    }
                }

                //x3 + 20, y42 + t1 * 44 + 12 + (t1 / 3) * 4 * 1
            }

            clear_change.init1();
        }
    }

    public void create1()
    {
        init1();

        on = 1;
    }

    public void close1()
    {
        //    on = 0;

    //    m1.msbox();

        clear_change.change_set(255, -clear_speed1());

        close_wait_tm = 1;


        if (back_base_type >= 0)
        {
            s1.base_run.base_type_change_quick(back_base_type);

            back_base_type = -1;
        }

        if (s1.base_run.base_type_check(s1.base_run.STAGE_RESULT) == 1)
        {
            s1.base_run.base_stage_result.scene_type = s1.base_run.base_stage_result.SCENE_EXP_GET;
            s1.base_run.base_stage_result.scene_tm1 = 0;
        }
    }

    public int line_h() { return 30; }

    public int area_x3_call() { return area1_x[3]; }

    public void run1()
    {
        if (on != 0)
        {

            clear_change.run1();

            if (s1.dialog_window1.on_check() == 0 && close_wait_tm == 0)
            {
                {
                    //画面右の装備変更                
                    int px1 = s1.touch_input.point_x1();
                    int py1 = s1.touch_input.point_y1();

                    for (int t2 = 0; t2 < MENU_AREA3_MAX; t2++)
                    {
                        {
                            int npp1 = 4;
                            int x1 = area3_x[t2] - npp1;
                            int y1 = area3_y[t2] - npp1;
                            int w1 = area3_w[t2] + npp1 * 2;
                            int h1 = area3_h[t2] + npp1 * 2;

                            if (m1.rect_decision(px1, py1, x1, y1, w1, h1) == 1)
                            {
                                if (s1.touch_input.pull_check() == 1)
                                {
                                    if (t2 == 0)
                                    {
                                        close1();
                                        s1.touch_input.wait(20);
                                    }

                                    if (t2 >= 1 && t2 <= 4 && no_setting_flag == 0)
                                    {
                                        equipment_slot = t2 - 1;

                                        clear_change.change_set(255, -clear_speed1());
                                        close_wait_tm = 1;
                                        s1.base_run.base_type_change_quick(s1.base_run.EQUIPMENT_CHARACTER_EQ_CHANGE);
                                    }
                                }
                            }
                        }
                    }
                }
                

                //その他 画面左をタッチで戻る
                {
                    int px1 = s1.touch_input.point_x1();
                    int py1 = s1.touch_input.point_y1();

                    {
                        int x1 = 0;
                        int y1 = 0;
                        int w1 = area_x3_call() - x1;
                        int h1 = s1.display_h_call();

                        int np = 0;

                        if (m1.rect_decision(px1, py1, x1, y1, w1, h1) == 1)
                        {
                            if (s1.touch_input.pull_check() == 1)
                            {
                                np = 1;
                            }
                        }

                        if (s1.touch_input.push_check(1) == 1) { np = 1; }

                        if (np == 1)
                        {
                            close1();

                            s1.touch_input.wait(20);
                        }
                    }
                }
            }

            if (close_wait_tm >= 1)
            {
                if (clear_change.clear_value1 <= 1)
                {
                    on = 0;
                }
            }
        }
    }   

    public void draw1()
    {
        if (on!=0){
            clear_change.clear_call();

            g1.setfont(g1.FONT_1_SMALL_STR);


            int type1 = s1.character_group.character1[character_link].call_type1();

            int nn1 = 19;

            //背景
            {
                for (int t1 = 0; t1 < 2; t1++)
                {
                    for (int t2 = 0; t2 < 2; t2++)
                    {
                        g1.drawrectImage(ic1.loadcheck(0, 2, 0), 0 + t1 * 480, 0 + t2 * 480, 480, 480);
                    }
                }
            }

            {
                int rect_draw_flag = 0;
                if (rect_draw_flag == 1)
                {
                    for (int t1 = 0; t1 < MENU_AREA1_MAX; t1++)
                    {
                        int x3 = area1_x[t1];
                        int y3 = area1_y[t1];
                        int w3 = area1_w[t1];
                        int h3 = area1_h[t1];

                        g1.sc(255);
                        g1.drawRect(x3, y3, w3, h3, 0, 0);
                    }
                }


                int w1 = 135 * 3;


                //    g1.sc(255);
                //   g1.drawRect(0, 0, w1, 540, 0, 0);
            }

            //キャラ描画
            {
                ImageData1 id1 = s1.image_save_character.loadcheck1(type1);//ic1.loadcheck(0, 0, 0);

                float la3 = 1.0f;//0.50f;//0.55f;//

                int w1 = (int)(la3 * id1.call_w());
                int h1 = (int)(la3 * id1.call_h());

                int x4 = 0 + w1 / 2 + 40;//-32;
                int y4 = 0 + h1 / 2 + 72;//60;

                s1.dm1.character_draw(x4, y4, type1, 0, 0);

                /*
                ImageData1 id1 = s1.image_save_character.loadcheck1(type1);//ic1.loadcheck(0, 0, 0);

                float la3 = 1.0f;//0.50f;//0.55f;//

                int w1 = (int)(la3 * id1.call_w());
                int h1 = (int)(la3 * id1.call_h());

                int x4 = 0 + w1 / 2 - 32;//- 70;//- 95;//- 65;//100;
                int y4 = 0 + h1 / 2 + 60; //+ 60;//+ 60;//70;

                float th3 = 0;

                g1.drawImage(id1, x4, y4, la3, th3);
                */
            }

            {
                int x31 = area1_x[1];
                int y31 = area1_y[1];//area1_y[2] + 0

                int w31 = area1_w[1];
                int h31 = area1_h[1];

                
                String name1= s1.data_magagement.character_data.character_name(type1);

                g1.sc(255);
                    g1.str2(name1, x31 + 16+64, y31+6);

                int att1 = s1.character_group.character1[character_link].call_attribute_1();
                int att2 = s1.character_group.character1[character_link].call_attribute_2();

                float large1 = 0.70f;
                int ny1 = y31 + 16 - 1;
                s1.dm1.attribute_draw(x31 + 16+4, ny1, att1, large1, 0, 0);
                s1.dm1.attribute_draw(x31 + 16 + 4 + 30, ny1, att2, large1, 0, 0);
            }

            {
                int nnp1 = 4;
                int move_y = 10;

                
                //    s1.dm1.boxdraw3(x41 + nnp1, y41 + nnp1, w41, h41, 0, 1);
                
                int x51 = area1_x[2];
                int y51 = area1_y[2] + 0 + move_y;//204 + 16;

                int w51 = area1_w[2] - nnp1 * 2;
                int h51 = area1_h[2] - nnp1 * 2;

                s1.dm1.boxdraw3(x51 + nnp1, y51 + nnp1, w51, 80, 0, 1);

                {
                    int nnp2 = 16;

                    int x52 = x51 + nnp1 + nnp2;
                    int y52 = y51 + nnp1 + nnp2;

                    //    g1.str2("Ｌｖ　：１００　ＨＰ　：１０００　ＭＰ　：　１００", x52, y52 + line_h() * 0);
                    //    g1.str2("ＴＥＣ：１００　ＡＴＫ：　１００　ＩＮＴ：　１００", x52, y52 + line_h() * 1);

                    int[] numbox1 = { 0, 0, 0, 0, 0, 0 };
                    String[] strbox1 = { "", "", "", "", "", "" };

                    {
                        numbox1[0] = s1.character_group.character1[character_link].call_level();
                        numbox1[1] = s1.character_group.character1[character_link].call_mhp();
                        numbox1[2] = s1.character_group.character1[character_link].call_mmp();
                        numbox1[3] = s1.character_group.character1[character_link].call_tec();
                        numbox1[4] = s1.character_group.character1[character_link].call_atk();
                        numbox1[5] = s1.character_group.character1[character_link].call_int();
                    }

                    for (int t1 = 0; t1 < 6; t1++)
                    {
                        strbox1[t1] = m1.num_half_full_change(numbox1[t1]);

                        if (t1 % 3 == 0)
                        {
                            strbox1[t1] = m1.add_space_str1(strbox1[t1], 3, 0, "　");
                        }
                        else
                        {
                            strbox1[t1] = m1.add_space_str1(strbox1[t1], 4, 0, "　");
                        }
                    }

                    g1.str2("Ｌｖ　：" + strbox1[0], x52, y52 + line_h() * 0);
                    g1.str2("ＨＰ　：" + strbox1[1], x52 + 8 * nn1, y52 + line_h() * 0);
                    g1.str2("ＭＰ　：" + strbox1[2], x52 + 17 * nn1, y52 + line_h() * 0);

                //    g1.str2("ＴＥＣ：" + strbox1[3], x52, y52 + line_h() * 1);
                    g1.str2("ＡＴＫ：" + strbox1[4], x52 + 8 * nn1, y52 + line_h() * 1);
                    g1.str2("ＩＮＴ：" + strbox1[5], x52 + 17 * nn1, y52 + line_h() * 1);
                }



                int x41 = area1_x[2];
                int y41 = area1_y[2] + 80 + 16 + move_y;

                int w41 = area1_w[2] - nnp1 * 2;
                int h41 = area1_h[2] - nnp1 * 2;


                s1.dm1.boxdraw3(x41 + nnp1, y41 + nnp1, w41, 204, 0, 1);

                {


                    g1.sc(255);

                    //  g1.str2("てすとです", x41 + nnp1 * 2, y41 + nnp1 * 2);

                    {
                        int nnp2 = 16;

                        int x42 = x41 + nnp1 + nnp2;
                        int y42 = y41 + nnp1 + nnp2;


                        g1.str2("装備：", x42, y42);

                        //     g1.str2("適正ランク：Ａ", x42 + area1_w[2] / 2, y42);

                        /*
                        for (int t2 = 0; t2 < 2; t2++)
                        {
                            for (int t1 = 0; t1 < 2; t1++)
                            {
                                g1.str2("○１２３４５６７８９０１", x42 + t1 * (area1_w[2] - 16) / 2, y42 + line_h() * (t2 + 1));
                            }
                        }
                        */

                        for (int t2 = 0; t2 < 4; t2++)
                        {
                            String name1 = "";
                            int eq_link = s1.character_group.character1[character_link].call_equipment_link(t2);

                            if (eq_link != s1.am1.equipment_null_num())
                            {
                                if (s1.equipment_group.equipment_null_check(eq_link) == 0)
                                {
                                    name1 = s1.equipment_group.equipment1[eq_link].call_name();
                                }
                            }
                            else
                            {
                                name1 = "－－－－－－－－－";
                            }

                            g1.str2("" + name1, x42, y42 + line_h() * (t2 + 1));
                        }

                        int tec1= s1.character_group.character1[character_link].call_tec();
                        String tec_str1 = m1.num_half_full_change(tec1);
                        tec_str1 = m1.add_space_str1(tec_str1, 3, 0, "　");

                        g1.str2("ＴＥＣ：" + tec_str1, x42 + 17 * nn1, y42 + line_h() * (4 + 1));
                    }


                    /*
                    {
                        int nnp2 = 16;

                        int x43 = x41 + nnp1 + nnp2;
                        int y43 = y41 + nnp1 + nnp2 + line_h() * 3 + 10;

                        g1.str2("アビリティ：", x43, y43);

                        for (int t1 = 0; t1 < 10; t1++)
                        {
                            int nnp3 = 48;
                            int nnp4 = 40;
                            int x44 = x43 + t1 * nnp3;
                            int y44 = y43 + line_h();

                            g1.sc(255);
                            g1.drawRect(x44, y44, nnp4, nnp4, 0, 0);
                        }
                    }
                    */
                }


                int x61 = area1_x[2];
                int y61 = area1_y[2] + 284 + 16 + 16 * 1 + move_y;

                int w61 = area1_w[2] - nnp1 * 2;
                int h61 = area1_h[2] - nnp1 * 2;

                s1.dm1.boxdraw3(x61 + nnp1, y61 + nnp1, w61, 180, 0, 1);

                {
                    int nnp2 = 16;

                    int x62 = x61 + nnp1 + nnp2;
                    int y62 = y61 + nnp1 + nnp2;

                    int pp1 = 10;

                    //     g1.str2("スキル１：１２３４５６７８９０　　ＭＰ：１０００", x62, y62 + line_h() * 0 + pp1 * 0);
                    //     g1.str2("スキル２：１２３４５６７８９０　　ＭＰ：１０００", x62, y62 + line_h() * 1 + pp1 * 0);

                    {
                        String skill_1_name = "";
                        int skill_num1 = s1.character_group.character1[character_link].call_skill_1();
                        skill_1_name = s1.data_magagement.skill_data.skill_name(skill_num1);

                        g1.str2("スキル：" + skill_1_name, x62, y62 + line_h() * 0 + pp1 * 0);


                        int mp1 = s1.character_group.character1[character_link].call_skill_1_need_point();
                        String mp_str = m1.num_half_full_change(mp1);
                        mp_str = m1.add_space_str1(mp_str, 4, 0, "　");

                        g1.str2("ＭＰ　：" + mp_str, x62 + nn1 * 16, y62 + line_h() * 0 + pp1 * 0);

                        String skill_explanation1 = "";//"１２３４５６７８９０１２３４５６７８９０１２３４５";

                        skill_explanation1 = s1.data_magagement.skill_data.skill_explanation1(skill_num1)+"";
                        if (m1.strbyte(s1.data_magagement.skill_data.skill_explanation2(skill_num1)) >= 1)
                        {
                            skill_explanation1 += "。" + s1.data_magagement.skill_data.skill_explanation2(skill_num1);
                        }

                        if (m1.strbyte(skill_explanation1) >= 50)
                        {
                            skill_explanation1 = m1.substring(skill_explanation1, 0, 23) + "…";
                        }

                        g1.str2(skill_explanation1, x62, y62 + line_h() * 1);
                    }

                    {
                        String enchantment_1_name = "";
                        String enchantment_1_exp1 = "";
                        String enchantment_1_exp2 = "";
                        int enchantment_1_num = s1.character_group.character1[character_link].call_enchantment();

                        enchantment_1_name = s1.data_magagement.enchantment_data.enchantment_name(enchantment_1_num);
                        enchantment_1_exp1= s1.data_magagement.enchantment_data.enchantment_explanation1(enchantment_1_num);
                        enchantment_1_exp2 = s1.data_magagement.enchantment_data.enchantment_explanation2(enchantment_1_num);

                        g1.str2("エンチャント："+ enchantment_1_name, x62, y62 + line_h() * 2 + pp1 * 1);
                        g1.str2(enchantment_1_exp1, x62, y62 + line_h() * 3 + pp1 * 1);
                        g1.str2(enchantment_1_exp2, x62, y62 + line_h() * 4 + pp1 * 1);

                        //    g1.str2("エンチャント：１２３４５６７８９０", x62, y62 + line_h() * 2 + pp1 * 1);
                        //    g1.str2("１２３４５６７８９０１２３４５６７８９０１２３４", x62, y62 + line_h() * 3 + pp1 * 1);
                        //    g1.str2("１２３４５６７８９０１２３４５６７８９０１２３４", x62, y62 + line_h() * 4 + pp1 * 1);
                    }

                    /*
                    for (int t1 = 0; t1 < 7; t1++)
                    {
                        g1.str2("１２３", x52, y52 + line_h() * t1);
                    }*/
                }
            }

            {
                int x91 = area1_x[3] + 16;
                int y91 = area1_y[3];

                int w91 = area1_w[3];
                int h91 = area1_h[3];

                /*
                g1.setClear2(160);
                g1.sc(32);
                g1.drawRect(x91, y91, w91, h91, 0, 1);               
                g1.setClear2_re();
                */

                for (int t2 = 0; t2 < 2; t2++)
                {
                    g1.drawrectImage(ic1.loadcheck(0, 1, 0), x91, y91 + t2 * 480, 40+6, 0, 240, 480);
                }

                //   for (int t2 = 0; t2 < 8; t2++)

                /*
                for (int t2 = 0; t2 < 5; t2++)
                {
                    int np5 = 48;
                    int x92 = x91;
                    int y92 = y91;
                    int w92 = np5;
                    int h92 = np5;
                    int h93 = 66;

                    g1.sc(255);
                    g1.drawRect(x92 + 14, 16 + h93 * t2, w92, h92, 0, 0);

                    if (t2 == 0)
                    {
                        g1.str2("戻る", x92 + 14, 16 + h93 * t2);
                    }

                    if (t2 == 7)
                    {
                        g1.str2("☆", x92 + 14, 16 + h93 * t2);
                    }
                }
                */

                for (int t2 = 0; t2 < 5; t2++)
                {
                    int x92 = area3_x[t2];
                    int y92 = area3_y[t2];
                    int w92 = area3_w[t2];
                    int h92 = area3_h[t2];                    
                    int draw_flag = 0;

                    if (t2 >= 1 && t2 <= 6 && no_setting_flag != 0) { g1.setClear2(128); }


                    if (t2 == 0)
                    {
                        g1.sc(255);
                        g1.str2("←戻る", x92 - 4, y92 + 12);
                    }

                    if (t2 >= 1 && t2 <= 4)
                    {
                        
                            int slot1 = t2 - 1;
                        int eq_link1 = s1.character_group.character1[character_link].call_equipment_link(slot1);

                        if (eq_link1 == s1.am1.equipment_null_num())
                        {

                        }
                        else
                        {
                            int etype1 = s1.equipment_group.equipment1[eq_link1].call_type1();
                            int att1 = s1.equipment_group.equipment1[eq_link1].call_attribute_1();
                            int att2 = s1.equipment_group.equipment1[eq_link1].call_attribute_2();
                            
                            draw_flag = 1;
                            s1.dm1.equipment_draw(x92, y92, etype1, 0, 0, att1, att2, 0);


                        //    g1.sc(255);
                        //    g1.str2(""+type1,x92, y92);
                        }
                    }



                    if (draw_flag == 0)
                    {
                        if (t2 >= 1)
                        {
                            g1.sc(255);
                            g1.drawRect(x92, y92, w92, h92, 0, 0);
                        }
                    }

                    if (t2 >= 1 && t2 <= 6 && no_setting_flag != 0) { g1.setClear2_re(); }
                }

                    g1.drawImage2(ic1.loadcheck(1, 21, 0), x91 - 8, 0);
            }

            g1.setfont_re();

            clear_change.clear_call_re();
        }//on
    }//draw1()
}
