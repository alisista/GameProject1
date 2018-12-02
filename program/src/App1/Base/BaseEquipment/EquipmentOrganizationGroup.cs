using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EquipmentOrganizationGroup : SetVoid1
{
    static int W_MAX = 8024;//max 8000 over +20 sort_need +2
    public EquipmentOrganization[] equipment_organization = new EquipmentOrganization[W_MAX];

    public int now_max1() { return 200; }//40; }//現在のボックスの最大値
    public int shop_box_max1() { return 10; }//ショップの販売数


    public int now_box_max_num_call()
    {
        int nt = now_max1();

        if (s1.base_run != null)
        {
            if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_SHOP_BUY) == 1) { nt = shop_box_max1(); }
        }

        return nt;
    }


    public int max1() { return W_MAX; }
    public int now_over_max1()
    {
        int nt = now_box_max_num_call() + 20;

        if (s1.base_run != null)
        {
            if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_SHOP_BUY) == 1) { nt = shop_box_max1(); }
        }

        return nt;
    }


    //    public CharacterOrganizationGroupSupport character_organization_group_support;

    public int start_px() { return 16; } //= 14;
    public int column_pw() { return 94; } //= 88;// 89;
    public int row_ph() { return 102; }// = 120;//100;//96;
    public int window_size() { return 64; }//80

    int[] link_sort_box = new int[W_MAX];//ソートした後のキャラクター番号の順番を保持

    public int link_sort_box_call(int num) { return link_sort_box[num]; }

    public int null_num() { return max1(); }


    public int init_flag = 0;

    public int over_all_space_num()
    {
        int nt = 0;
        int all_num = s1.equipment_group.equipment_all_num();

        if (all_num <= now_box_max_num_call()) { nt = now_box_max_num_call(); }
        if (all_num > now_box_max_num_call()) { nt = all_num; }

        if (s1.base_run != null)
        {
            if (s1.base_run.base_type_check(s1.base_run.EQUIPMENT_SHOP_BUY) == 1) { nt = shop_box_max1(); }
        }

        return nt;
    }

    public int row_num() { return (over_all_space_num() + column_num()) / column_num(); }//m1.iover((now_box_num() + column_num()) / column_num(), 0, now_box_num() / column_num()); }//何列あるか
    public int column_num() { return 7; }   //列数



    public EquipmentOrganizationGroup(Summary1 s1)
    {
        set1(s1);

        for (int t1 = 0; t1 < now_over_max1(); t1++)
        {
            equipment_organization[t1] = new EquipmentOrganization(s1, t1);
        }

    //    character_organization_group_support = new CharacterOrganizationGroupSupport(s1);
    }

    public void init1()
    {
        for (int t1 = 0; t1 < now_over_max1(); t1++)
        {
            equipment_organization[t1].init1();
        }

        for (int t1 = 0; t1 < now_over_max1(); t1++)
        {
            link_sort_box[t1] = t1;
        }

        //character_organization_group_support.init1();

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

        if (s1.base_run.base_type == s1.base_run.EQUIPMENT_ORGANIZATION
         || s1.base_run.base_type == s1.base_run.EQUIPMENT_CHARACTER_EQ_CHANGE
         || s1.base_run.base_type == s1.base_run.EQUIPMENT_SHOP_BUY
         || s1.base_run.base_type == s1.base_run.EQUIPMENT_SHOP_SELL
            )
        {
            dataset1();
        }

        if (s1.base_run.base_type == s1.base_run.EQUIPMENT_SHOP_BUY)
        {
            for (int t1 = 0; t1 < now_over_max1(); t1++)
            {
                link_sort_box[t1] = s1.equipment_group.shop_box_start_num() + t1;
            }
        }

        if (init_flag == 0)
        {
            init_flag = 1;

            shop_buy_create();
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

        equipment_character_check();

        s1.equipment_group.sell_flag_reset();

        if (s1.base_run.base_type != s1.base_run.EQUIPMENT_SHOP_BUY)
        {
            sort_update();
        }
    }

    public void sort_update()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
            link_sort_box[t1] = 9999;
        }

        {
            int count = 0;

            for (int t1 = 0; t1 < max1(); t1++)
            {
                link_sort_box[t1] = t1;
            //    count++;
            }
        }
        
        //ソートの実行
        sort_set(0);

    }//sort_update()
    
    

    //ソート  String[] box1 = { "0-通常", "1-入手", "2-STR", "3-属性", "4-タイプ", "5-レベル", "6-HP", "7-ATK", "8-INT", "9-CURE", "10-Rank", "(検索)" };
    public void sort_set(int sort_type)
    {
        //    sort_draw_num = type_num;

        //現在の最大値のままだと、一番最後がソートされないので注意
    //    int sort_num = now_over_max1() + 1;//last_num_check();//s1.equipment_group.max1();

        //最終番号+2以上にしておかないと、綺麗にソートできないので注意
        int sort_num = last_num_check() + 2;

     //   m1.msbox(sort_num);

        int div1 = 10000;


        for (int t1 = 0; t1 < sort_num; t1++)
        {
            if (s1.equipment_group.equipment_null_check(t1) == 1)
            {
                s1.equipment_group.equipment_construct_set(t1);
                s1.equipment_group.equipment1[t1].delete1();
            }
        }


        long[] sort_box = new long[sort_num];

        for (int t1 = 0; t1 < sort_num; t1++)
        {
            sort_box[t1] = -1;

            if (s1.equipment_group.equipment1[t1].on != 0)// && sort_ok_check(t1) == 1)
            {
                //ソート下５桁は キャラクターの保存番号
                sort_box[t1] = t1;
            }
        }

        //ソート開始！
        {
            //ソート  String[] box1 = {,,,,,, "6-HP",  , "8-INT", "9-CURE", "10-Rank", "(検索)" };

            //同一の値の場合の優先順位 (基本 例外もある)
            //2-加護1 3-STR

            //sort_set(7);
            {
                for (int t1 = 0; t1 < sort_num; t1++)
                {
                    if (sort_box[t1] >= 0)
                    {
                        long[] ntbox = { 0, 0, 0 };//longといえど 3つが限界
                        long np = sort_box[t1] % div1;

                        //現在のソートは入手順
                        if (sort_type == 0)
                        {
                            ntbox[0] = s1.equipment_group.equipment1[t1].call_time_stamp1();
                            ntbox[1] = s1.equipment_group.equipment1[t1].call_time_stamp2();
                            ntbox[2] = np;

                            //    sort_box[t1] = ntbox[0] * 1000000 * div1 * div1 + ntbox[1] * div1 * div1 + (9999 - np) * div1 + np;

                            sort_box[t1] = ntbox[0] * 1000000 * div1 + ntbox[1] * div1 + np;

                            //sort_box[t1] = (9999 - np) * div1 + np;
                        }

                        /*
                        {
                            ntbox[0] = (99 - s1.equipment_group.equipment1[t1].call_attribute_1());
                            ntbox[1] = (99 - s1.equipment_group.equipment1[t1].call_attribute_2());

                            sort_box[t1] = ntbox[1] * div1* div1 + ntbox[0] * div1  + np;
                        }
                        */

                        /*
                        //通常
                        if (type_num == 0)
                        {
                            ntbox[0] = (s.character_group.character[t1].call_favorite());
                            ntbox[1] = 100 - (s.character_group.character[t1].call_attribute_1());
                            ntbox[2] = (s.character_group.character[t1].call_STR());
                        }

                        if (s.character_group.character[t1].call_status(s.character_group.STATUS_ATK) >= 2 && sort_box[t1] >= 0)
                        {
                            sort_box[t1] =
                                ntbox[2] * div1 +
                                ntbox[1] * div1 * div1 +
                                ntbox[0] * div1 * div1 * div1 +
                            //    ntbox[1] * 100000 * 100000 * 100000 * 100000 +
                            //    ntbox[0] * 100000 * 100000 * 100000 * 100000 * 100000 +
                                np;

                            //    sort_box[t1] = np;
                        }
                        */
                    }
                }

                //   sort_box = s1.am1.sort_start(sort_num, sort_box, 2);

                sort_box = s1.am1.sort_start(sort_num, sort_box, 1);
            }
            
            //ソートの番号情報以外解除
            {
                //-1と 値を所持していない変数を下に送り込む
                //    s1.am1.sort_start2(sort_num, sort_box);

                sort_box = s1.am1.sort_start2(sort_num, sort_box);
            }


            //最後に-1になっているものを一番後ろの番号に戻す
            for (int t1 = 0; t1 < sort_num; t1++)
            {
                if (sort_box[t1] < 0)
                {
                    sort_box[t1] = sort_num - 1;//t1;
                }
            }
        }

        //リンクソートの復元
        {
            int count = 0;


            for (int t1 = 0; t1 < sort_num; t1++)
            {
                int link_num = (int)(sort_box[t1] % div1);
            //    int flag = sort_ok_check(link_num);
                
                if (t1 <= 2)
                {
                //    m1.msbox("link:"+link_num+" , "+ sort_box[t1]);
                //    m.msbox("flag:" + flag);
                }

            //    if (flag == 1)
                {
                    link_sort_box[count] = link_num;
                    count++;
                }
            }


            /*
            for (int t1 = 0; t1 < s.character_group.chara_max; t1++)
            {
                link_sort_box[t1] = (int)(sort_box[t1] % div1);
            }*/
        }
    }//sort_set


    


    
    


    public void cam_set()
    {
        s1.cam_2d.create1();

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
                    if (count < now_over_max1())
                    {
                        g1.sc(255);
                        //    g.str2("test", start_px + column_pw*t1, y3);

                        int nt2 = window_size();
                        //    g.drawRect(start_px + column_pw * t1, y3 + column_ph * t2, nt2, nt2, 0, 0);

                        equipment_organization[count].init1();
                        equipment_organization[count].create1(start_px() + column_pw() * t1, y3 + row_ph() * t2);
                    }

                    count++;
                }
            }
        }
    }


    //装備品を本当に装備しているかどうか、確認
    public void equipment_character_check()
    {
        for (int t1 = 0; t1 < now_over_max1(); t1++)
        {
            if (equipment_organization[t1].on != 0)
            {
                if (s1.equipment_group.equipment_null_check(t1) == 0)
                {
                    int character_link = s1.equipment_group.equipment1[t1].call_character_link();
                    int ntt1 = 0;

                    if (character_link != s1.am1.character_null_num())
                    {
                        for (int t2 = 0; t2 < 4; t2++)
                        {
                            if (s1.character_group.character1[character_link].call_equipment_link(t2) == t1)
                            {
                                ntt1 = 1; break;
                            }
                        }

                        if (ntt1 == 0)
                        {
                            s1.equipment_group.equipment1[t1].equipment_change(s1.am1.character_null_num());
                        }
                    }
                }
            }
        }
    }
    

    public int last_num_check()
    {
        int nt = 0;

        for (int t1 = now_over_max1() - 1; t1 >= 0; t1--)
        {
            if (s1.equipment_group.equipment_null_check(t1) == 0)
            {
                if (s1.equipment_group.equipment1[t1].on != 0)
                {
                    nt = t1;

                    break;
                }
            }
        }

        return nt;
    }


    public void shop_buy_create()
    {
        int create_num = shop_box_max1();
        int link_start_num = s1.equipment_group.shop_box_start_num();

        for (int t1 = link_start_num; t1 < link_start_num + create_num; t1++)
        {
            int item_num = 1;

            s1.equipment_group.equipment_create(t1, item_num);
        }
    }

    public int box_over_check()
    {
        int nt = 0;

        if (s1.equipment_group.equipment_all_num() > now_max1())
        {
            nt = 1;
        }

        return nt;
    }




    public void run1()
    {



        {
            int num1 = now_over_max1();

            for (int t1 = 0; t1 < num1; t1++)
            {
                equipment_organization[t1].run1();
            }
        }
    }

    public void draw1()
    {
        {
            for (int t1 = 0; t1 < now_over_max1(); t1++)
            {
                equipment_organization[t1].draw1();
            }
        }
    }
}
