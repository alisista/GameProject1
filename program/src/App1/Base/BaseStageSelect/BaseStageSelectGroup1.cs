using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BaseStageSelectGroup1 : SetVoid1
{
    int start_y = 10;

    public int create_num = 12;

    //ボタンの座標と大きさは、ここでクラスでメモっとけ
    static int MAX = 100;
    public BaseStageSelect1[] base_stage_select1 = new BaseStageSelect1[MAX];

    public int max() { return MAX; }
    
    public int start_px() { return 16; } //= 14;
    public int column_pw() { return 110; } //= 88;// 89;
    public int row_ph() { return 120; }// = 120;//100;//96;
    public int window_size() { return 88; }//80

    public int row_num() { return (create_num_call() + column_num()-1) / column_num(); }//m1.iover((now_box_num() + column_num()) / column_num(), 0, now_box_num() / column_num()); }//何列あるか
    public int column_num() { return 2; }   //列数
    public int create_num_call() { return create_num; }

    //public BaseButtonSupport base_button_support;


    int initflag = 0;


    public BaseStageSelectGroup1(Summary1 s1)
    {
        set1(s1);

        for (int t1 = 0; t1 < max(); t1++)
        {
            base_stage_select1[t1] = new BaseStageSelect1(s1, t1);
        }

    //    base_button_support = new BaseButtonSupport(s1);
    }


    public void init1()
    {
        if (initflag == 0)
        {
            initflag = 1;

            //    icon_touch_button_input = new IconTouchButtonInput();
            //    icon_touch_button_input.set(m, g, im, input, s);
        }


        for (int t1 = 0; t1 < max(); t1++)
        {
            base_stage_select1[t1].init1();
        }

        //    base_button_support.init1();

        //    icon_touch_button_input.init();

        //    create_menu();

        if (s1.base_run.base_type_check(s1.base_run.STAGE1_SELECT) == 1
            )
        {
            dataset1();
        }
    }

    

    //このクラスを呼び出した時に使用
    public void dataset1()
    {
        //    have_character_num_update();

        create_menu();

        cam_set();

        s1.scroll_bar1.base_create_y1();

        //    m1.msbox();
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


    public void create_menu()
    {
    //    create_num = 10;//8;//5
        

        //   init1();


        /*
        if (type == s1.base_run.ORGANIZATION_MENU) { create_num = 3; }
        if (type == s1.base_run.SHOP_MENU) { create_num = 2; }
        if (type == s1.base_run.OTHER_MENU) { create_num = 1; }
        */


        if (create_num >= 1)
        {
            create(create_num, 1);
        }
    }


    void create(int create_num, int title_in_flag)
    {
        int create_count = 0;


        if (create_num >= 1)
        {
            for (int t1 = 0; t1 < create_num; t1++)
            {
                int x2 = 32 + (t1 % 2) * (360 - 32 / 2 - 16);
                int y2 = 108 + (t1 / 2) * row_ph();

                base_stage_select1[t1].create(t1, x2, y2);

                base_stage_select1[t1].dungeon_num1 = create_num_call() - create_count - 1;

               create_count++;
            }
        }        
    }



    public void run1()
    {
        if (s1.base_run.base_move_no_check() == 0)
        {
            for (int t1 = 0; t1 < max(); t1++)
            {
                base_stage_select1[t1].run1();
            }
        }
    }//run()


    public void draw1()
    {
        for (int t1 = 0; t1 < max(); t1++)
        {
            base_stage_select1[t1].draw1();
        }

        //    s.dm.cam_seekber1_draw();
    }
}
