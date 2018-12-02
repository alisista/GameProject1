using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CharacterOrganization : SetVoid1
{
    int num1;

    public int on;
    float x1;
    float y1;

    public CharacterOrganization(Summary1 s1, int num1)
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
        if (no_use_select_check() == 0)
        {
            if (s1.base_run.base_type_check(s1.base_run.CHARACTER_ORGANIZATION) == 1)
            {
                call_character_status();

                s1.touch_input.wait(20);
            }


            if (s1.base_run.base_type_check(s1.base_run.CHARACTER_PARTY_SELECT) == 1)
            {
                int link_num = s1.base_run.character_organization_group.link_sort_box_call(num1);

                s1.base_run.character_organization_group.set_link_memo = link_num;

                s1.base_run.menu_change_waitact_set(s1.base_run.character_organization_group.back_base_type);

                s1.wait_action.action_add = s1.wait_action.ACTION_ADD_PARTY_SET;
            }
        }

        if (s1.base_run.base_type_check(s1.base_run.CHARACTER_MULTI_PARTY_SELECT) == 1)
        {
            int party_num2 = -1;

            int link_num = s1.base_run.character_organization_group.link_sort_box_call(num1);

            for (int t1 = 0; t1 < 6; t1++)
            {
                if (s1.base_run.party_select_group.party_call(t1) == link_num)
                {
                    party_num2 = t1;
                    break;
                }
            }

            if (party_num2 >= 0)
            {
                s1.base_run.party_select_group.party_set(party_num2, s1.am1.character_null_num());
            }
            else
            {
                for (int t1 = 0; t1 < 6; t1++)
                {
                    if (s1.base_run.party_select_group.party_call(t1) == s1.am1.character_null_num())
                    {
                        s1.base_run.party_select_group.party_set(t1,link_num);
                        break;
                    }
                }
            }
        }
    }

    public void call_character_status()
    {
        int link_num = s1.base_run.character_organization_group.link_sort_box_call(num1);

        s1.base_run.base_function.character_status_draw_call();

        s1.base_run.character_status.character_link = link_num;

        s1.base_run.character_status.back_base_type = s1.base_run.base_type;
    }

    public int no_use_select_check()
    {
        int nt = 0;

        if (s1.base_run.base_type_check(s1.base_run.CHARACTER_PARTY_SELECT) == 1)
        {
            int link_num = s1.base_run.character_organization_group.link_sort_box_call(num1);

            for (int t1 = 0; t1 < 6; t1++)
            {
                if (s1.base_run.party_select_group.party_call(t1) == link_num)
                {
                    nt = 1;
                    break;
                }
            }
        }

        if (s1.base_run.base_type_check(s1.base_run.CHARACTER_MULTI_PARTY_SELECT) == 1)
        {
            int link_num = s1.base_run.character_organization_group.link_sort_box_call(num1);

            for (int t1 = 0; t1 < 6; t1++)
            {
                if (s1.base_run.party_select_group.party_call(t1) == link_num)
                {
                    nt = 1;
                    break;
                }
            }
        }

        return nt;
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
                            int link_num = s1.base_run.character_organization_group.link_sort_box_call(num1);

                            if (s1.character_group.character_null_check(link_num) == 0)
                            {
                                if (s1.character_group.character1[link_num].on != 0)
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
                                                //    m1.msbox("long");

                                                //   s.gm.cursor_decide();

                                                call_character_status();

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

    public void draw1()
    {
        if (on != 0)
        {
            float y1 = call_y();
            int nt2 = s1.base_run.character_organization_group.window_size();
            int ntt1 = 120;

            if (y1 >= -ntt1 && y1 <= s1.display_h_call() + ntt1)
            {
                int link_num = s1.base_run.character_organization_group.link_sort_box_call(num1);

                {
                    //    g1.sc(255);
                    //    g1.drawRect(x1, y1, nt2, nt2, 0, 0);
                }

                //キャラクターの描画
                int character_draw_flag = 0;
                if (s1.character_group.character_null_check(link_num) == 0)
                {
                    int type1 = s1.character_group.character1[link_num].call_type1();

                    if (s1.character_group.character1[link_num].on == 0) { type1 = -1; }

                    if (no_use_select_check() == 1) { g1.setClear2(80); }

                    {
                        int att1 = s1.character_group.character1[link_num].call_attribute_1();
                        int att2 = s1.character_group.character1[link_num].call_attribute_2();

                        character_draw_flag = 1;
                        s1.dm1.character_window_draw(x1 - 1, y1 - 1, type1, link_num, 1, att1, att2, 0);
                    }

                    if (no_use_select_check() == 1) { g1.setClear2_re(); }

                    //     s1.dm1.character_window_draw((int)x1, y1, type1, link_num, 2, 1, att2, s.base_run.character_mix.main_chara_link, 0, 0, 0);

                    //    g.sc(255);
                    //    g.str2("on:"+on, x, y1);
                    //    g.str2("cl:" + link_num, x, y1);
                    //    g.str2("num:" + num, x, y1+20);

                    add_message(x1 + nt2 / 2, y1 + nt2 / 2-10);
                }

                if (character_draw_flag == 0)
                {
                    g1.sc(255);
                    g1.drawRect(x1, y1, nt2, nt2, 0, 0);
                }
            }
        }
    }

    public void add_message(float x1, float y1)
    {
        if (no_use_select_check() == 1)
        {
            if (s1.base_run.base_type_check(s1.base_run.CHARACTER_PARTY_SELECT) == 1)
            {
                g1.setfont(g1.FONT_1_MIDDLE_STR);
                g1.sc(255);
                g1.str2_center("参加中", x1, y1);
                g1.setfont_re();
            }
        }

        if (s1.base_run.base_type_check(s1.base_run.CHARACTER_MULTI_PARTY_SELECT) == 1)
        {
            int party_num2 = -1;

            int link_num = s1.base_run.character_organization_group.link_sort_box_call(num1);

            for (int t1 = 0; t1 < 6; t1++)
            {
                if (s1.base_run.party_select_group.party_call(t1) == link_num)
                {
                    party_num2 = t1;
                    break;
                }
            }

            if (party_num2 >= 0)
            {
                g1.setfont(g1.FONT_1_MIDDLE_STR);
                g1.sc(255);
                g1.str2_center("参加 " + m1.num_half_full_change(party_num2+1), x1, y1);
                g1.setfont_re();
            }
        }
    }
}
