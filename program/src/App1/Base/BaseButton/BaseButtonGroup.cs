using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BaseButtonGroup : SetVoid1
{
    int start_y = 10;

    //ボタンの座標と大きさは、ここでクラスでメモっとけ
    static int MAX = 100;
    public BaseButton1[] base_button1 = new BaseButton1[MAX];

    public int max() { return MAX; }

    public int create_count = 0;


    //    public IconTouchButtonInput icon_touch_button_input;

    public BaseButtonSupport base_button_support;


    int initflag = 0;


    public BaseButtonGroup(Summary1 s1)
    {
        set1(s1);

        for (int t1 = 0; t1 < max(); t1++)
        {
            base_button1[t1] = new BaseButton1(s1, t1);
        }

        base_button_support = new BaseButtonSupport(s1);
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
            base_button1[t1].init1();
        }

        base_button_support.init1();

        //    icon_touch_button_input.init();

        create_count = 0;


        
    }

    
    public int line_h1_call()
    {
        int nt = 96;//172;//92;//96;

        return nt;
    }


    public void create_menu()
    {
        create_menu(s1.base_run.base_type);
    }

    public void create_menu(int type)
    {
        int create_num = 0;//8;//5

        //   create_count = 0;

        init1();


        if (type == s1.base_run.ORGANIZATION_MENU) { create_num = 3; }
        if (type == s1.base_run.SHOP_MENU) { create_num = 2; }
        if (type == s1.base_run.OTHER_MENU) { create_num = 1; }

        if (create_num >= 1)
        {
            create(create_num, 1);
        }
    }


    void create(int create_num, int title_in_flag)
    {
        int nt1 = 0;//create_count;


        if (create_num >= 1)
        {
            for (int t1 = 0; t1 < create_num; t1++)
            {
                int x2 = 32 + (t1 % 2) * (360 - 32 / 2 - 16);
                int y2 = 108 + (t1 / 2) * line_h1_call();

                /*
                //連番
                int y2 = window_y_call() + start_y + t1 * line_h1_call();

                if (title_in_flag == 1)
                {
                    y2 += s.base_run.base_middle_title_h();
                }
                */

                base_button1[t1].create(t1, x2, y2);

                //    create_count++;
            }
        }


        /*
        //カメラもオートでセット
        {
            s.cam.reset();

            int h1 = 0;

            h1 = (create_num / 3) * line_h1_call() - 320;// - (s.base_run.base_middle_h_call() - s.base_run.base_middle_title_h());

            //    m.msbox(h1);

            int h2 = s.base_run.base_under_menu_h_call() - s.base_run.base_middle_title_h() - 39;
            if (h1 < h2)
            {
                h1 = h2;
            }

            s.cam.y_max_set(h1);



            if (s.base_run.base_type == s.base_run.WORLD_SELECT)
            {
                s.cam.y = s.base_run.scroll_point_call(s.base_run.WORLD_SELECT);
            }


            //s.cam.push_area_set(0, (s.base_run.base_call_y(2) + s.base_run.base_middle_title_h()), s.game_display_w, s.base_run.base_middle_h_call() - s.base_run.base_middle_title_h());

            int w1 = 416;
            s.cam.push_area_set(0, (s.base_run.base_call_y(2) + s.base_run.base_middle_title_h()), w1, s.base_run.base_middle_h_call() - s.base_run.base_middle_title_h() - 2);

            //   s.cam.push_area_set(0, 0, 300, 300);
        }
        */
    }



    public void run1()
    {
        if (s1.base_run.base_move_no_check() == 0)
        {
            for (int t1 = 0; t1 < max(); t1++)
            {
                base_button1[t1].run1();
            }
        }
        
        /*
        //継続的に自分のポイントを教える
        if (s.base_run.base_type == s.base_run.WORLD_SELECT)
        {
            s.base_run.scroll_point_set(s.base_run.WORLD_SELECT, (int)s.cam.y);
        }
        */
    }//run()


    public void draw1()
    {
        for (int t1 = 0; t1 < max(); t1++)
        {
            base_button1[t1].draw1();
        }
        
    //    s.dm.cam_seekber1_draw();
    }
}
