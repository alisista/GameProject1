using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CharacterOrganizationGroup : CharacterOrganizationExtend
{
    static int W_MAX = 31;
    public CharacterOrganization[] character_organization = new CharacterOrganization[W_MAX];

    public int max1() { return W_MAX; }

    public CharacterOrganizationGroupSupport character_organization_group_support;

    public int start_px() { return 16; } //= 14;
    public int column_pw() { return 110; } //= 88;// 89;
    public int row_ph() { return 118; }// = 120;//100;//96;
    public int window_size() { return 88; }//80

    int[] link_sort_box = new int[W_MAX];//ソートした後のキャラクター番号の順番を保持

    public int link_sort_box_call(int num) { return link_sort_box[num]; }



    public int row_num() { return (now_box_num() + column_num()) / column_num(); }//m1.iover((now_box_num() + column_num()) / column_num(), 0, now_box_num() / column_num()); }//何列あるか
    public int column_num() { return 6; }   //列数


    public int back_base_type;//戻った時のベースタイプのメモ

    public int set_link_memo;//何らかの設定をした際、即時反映をしたくないから、キャラクターのリンクをメモしておく


    public CharacterOrganizationGroup(Summary1 s1)
    {
        set1(s1);

        for (int t1 = 0; t1 < max1(); t1++)
        {
            character_organization[t1] = new CharacterOrganization(s1, t1);
        }

        character_organization_group_support = new CharacterOrganizationGroupSupport(s1);

        {
            back_base_type = 2;

            set_link_memo = -1;
        }
    }

    public void init1()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
            character_organization[t1].init1();
        }

        for (int t1 = 0; t1 < max1(); t1++)
        {
            link_sort_box[t1] = t1;

            //    sort_box[t1] = 99999;
        }

        character_organization_group_support.init1();

        /*
        for (int t1 = 0; t1 < escape_max; t1++)
        {
            escape_link_memo[t1] = -1;
        }


        select_wait = -1;
        select_cglink_memo = -1;

        escape_wait = -1;

        mix_summoner_1 = 0;//-1;
        mix_summoner_2 = 1;//-1;




        //       favorite_flag = 1;//0

        favorite_save_flag = 0;

        sort_draw_num = 0;

        have_character_num_update();

        //    dataset();

        character_link = -2;
        */

        if (s1.base_run.base_type_check(s1.base_run.CHARACTER_ORGANIZATION) == 1
         || s1.base_run.base_type_check(s1.base_run.CHARACTER_PARTY_SELECT) == 1
         || s1.base_run.base_type_check(s1.base_run.CHARACTER_MULTI_PARTY_SELECT) == 1
           )
        {
            dataset1();
        }

        
    }

    //このクラスを呼び出した時に使用
    public void dataset1()
    {
    //    have_character_num_update();

        create_window();

        cam_set();

        s1.scroll_bar1.base_create_y1();

    //    m1.msbox();
    }


    public int now_box_num()
    {
        int nt1 = max1();
    //    int nt1 = box_space();
    //    if (nt1 < now_have_num()) nt1 = now_have_num();
        return nt1;
    }


    public void cam_set()
    {
        s1.cam_2d.create1();

        s1.base_run.push_camera_area_set();

        int h1 = 0;

        //    h1 = line_num() * column_ph - s.bm.base_middle_h_call() - s.bm.base_middle_title_h + 172;
        h1 = row_num() * row_ph() - s1.base_run.base_call_h2();
        h1 = m1.iover(h1, 0, 9999999);

        //   m.msbox(h1);

    //    int h2 = (s1.base_run.base_call_h1());
    //    if (h1 < h2) { h1 = h2; }

        s1.cam_2d.y_max_set(h1);
    }



    public void create_window()
    {
        {
            int y2 = s1.base_run.base_call_y2();//s.base_run.base_call_y(2) + s.base_run.base_middle_title_h();
            int y3 = y2;

            int count = 0;

            for (int t2 = 0; t2 < row_num(); t2++)
            {
                for (int t1 = 0; t1 < column_num(); t1++)
                {
                    if (count < max1())
                    {
                        g1.sc(255);
                        //    g.str2("test", start_px + column_pw*t1, y3);

                        int nt2 = window_size();
                        //    g.drawRect(start_px + column_pw * t1, y3 + column_ph * t2, nt2, nt2, 0, 0);

                        character_organization[count].init1();
                        character_organization[count].create1(start_px() + column_pw() * t1, y3 + row_ph() * t2);
                    }

                    count++;
                }
            }
        }
    }


    public void run1()
    {



        {
            int num1 = now_box_num();

            for (int t1 = 0; t1 < num1; t1++)
            {
                character_organization[t1].run1();
            }
        }
    }

    public void draw1()
    {
        //キャラクター
        {
            for (int t1 = 0; t1 < now_box_num(); t1++)
            {
                character_organization[t1].draw1();
            }
        }
    }
}
