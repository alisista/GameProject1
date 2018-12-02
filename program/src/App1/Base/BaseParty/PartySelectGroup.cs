using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class PartySelectGroup : SetVoid1
{
    //ボタンの座標と大きさは、ここでクラスでメモっとけ
    static int MAX1 = 64;//10;
    public PartySelect[] party_select = new PartySelect[MAX1];

    public int max1() { return MAX1; }

    //パーティ編成のリンク保存
    public int party_use_num;
    public int[][] party_save;

//    public int select_party_num;
    public int select_character_num;

    public PartyCameraControl party_camera_control;

    int init_flag = 0;

    public PartySelectGroup(Summary1 s1)
    {
        set1(s1);

        for (int t1 = 0; t1 < max1(); t1++)
        {
            party_select[t1] = new PartySelect(s1, t1);
        }

        party_camera_control = new PartyCameraControl(s1);

        

        {
            int length1 = 64;
            int length2 = 6;

            party_save = new int[length1][];

            for (int t1 = 0; t1 < length1; t1++)
            {
                party_save[t1] = new int[length2];

                for (int t2 = 0; t2 < length2; t2++)
                {
                    party_save[t1][t2] = s1.am1.character_null_num();
                }
            }

        //    m1.msbox();
        }
    }

    public void init1()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
            party_select[t1].init1();
        }

        party_camera_control.init1();
        
        
        if (s1.base_run.base_type_check(s1.base_run.PARTY_ORGANIZATION) == 1
         || s1.base_run.base_type_check(s1.base_run.PARTY_USE_STAGE) == 1
            )
        {
            data_set1();
        }

        if (init_flag==0)
        {
            init_flag = 1;


            party_use_num = 0;
            select_character_num = 0;


            int n1 = 0;

            s1.base_run.party_select_group.party_set(n1, 0, 0);
            s1.base_run.party_select_group.party_set(n1, 1, 1);
            s1.base_run.party_select_group.party_set(n1, 2, 2);
            s1.base_run.party_select_group.party_set(n1, 3, 3);
            s1.base_run.party_select_group.party_set(n1, 4, 4);
            //    s1.base_run.party_select_group.party_set(0, 0);
        }
    }

    public void data_set1()
    {
        camera_set();

        multi_create(4);

        s1.scroll_bar2.base_create_x1();
    }

    public void camera_set()
    {
        s1.cam_2d.init1();

        s1.cam_2d.on = 1;

        s1.base_run.push_camera_area_set();
        s1.cam_2d.push_area_set(0, 0, s1.base_run.base_call_all_w1(), s1.base_run.base_call_all_h1() - 60);

        int w1 = 0;

        {
            w1 = s1.base_run.base_call_all_w1() * (s1.base_run.party_select_group.now_party_save_num_call() - 1);
        }

        s1.cam_2d.x_max_set(w1);
        s1.cam_2d.y_max_set(0);

        {
            s1.cam_2d.x1 = s1.base_run.base_call_all_w1() * s1.base_run.party_select_group.party_use_num_call();
        }

        //    s.cam.party_select_flag = 1;

        //    m1.msbox();
    }

    //パーティメニューを複数生成
    public void multi_create(int create_num)
    {
   //     int nt1 = create_count;
        
        if (create_num >= 1)
        {
            for (int t1 = 0; t1 < create_num; t1++)
            {
                //連番
                int x2 = 0 + s1.base_run.base_call_all_w1() * t1;//10 + s.game_display_w * t1;
                int y2 = s1.base_run.base_call_y2();//0;//call_y(0) + 8;//16;

                if (s1.base_run.base_type_check(s1.base_run.PARTY_USE_STAGE) == 1) { y2 -= 30; }
                
                party_select[t1].create1(x2, y2);
            }
        }
    }

    public int now_party_save_num_call()
    {
        return 4;
    }

    public int select_character_num_call() { return select_character_num; }
    public int party_use_num_call() { return party_use_num; }

    public void party_clear(int party1)
    {
        for (int t1 = 0; t1 < 6; t1++)
        {
            party_set(party1, t1, s1.am1.character_null_num());
        }
    }

    public int party_call(int num1)
    {
        return party_save[party_use_num_call()][num1];
    }

    public int party_call(int party1, int num1)
    {
        return party_save[party1][num1];
    }

    public void party_set(int ch_link)
    {
        party_set(party_use_num_call(), select_character_num_call(), ch_link);
    }

    public void party_set(int num1, int ch_link)
    {
        party_set(party_use_num_call(), num1, ch_link);
    }

    public void party_set(int party1, int num1, int ch_link)
    {
        party_save[party1][num1] = ch_link;
    }

    public int party_member_num_call()
    {
        int nt = 0;
        for (int t1 = 0; t1 < 6; t1++)
        {
            if (party_call(party_use_num, t1) != s1.am1.character_null_num())
            {
                nt += 1;
            }
        }

        return nt;
    }


    public int party_status_call(int party_num,int status_type)
    {
        int nt = 0;

        for (int t1 = 0; t1 < 6; t1++)
        {
            if (party_call(party_num, t1) != s1.am1.character_null_num())
            {
                int link_num = party_call(party_num, t1);

                if (status_type == s1.character_group.STATUS_MHP) { nt += s1.character_group.character1[link_num].call_mhp(); }
                if (status_type == s1.character_group.STATUS_MMP) { nt += s1.character_group.character1[link_num].call_mmp(); }
                if (status_type == s1.character_group.STATUS_ATK) { nt += s1.character_group.character1[link_num].call_atk(); }
                if (status_type == s1.character_group.STATUS_INT) { nt += s1.character_group.character1[link_num].call_int(); }
            }
        }

        return nt;
    }


    public void run1()
    {
        party_camera_control.run1();

        for (int t1 = 0; t1 < max1(); t1++)
        {
            party_select[t1].run1();
        }
    }

    public void draw1()
    {
        party_camera_control.draw1();

        for (int t1 = 0; t1 < max1(); t1++)
        {
            party_select[t1].draw1();
        }
    }
}
