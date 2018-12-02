using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//ベース画面の背景管理
public class BaseBgControl : SetVoid1
{
    public int CHANGE_WAIT = 60;//48;

    //    int img_slot=0;

    int before_img_slot;
    int now_img_slot;

    int before_img_multi_flag = 0;
    int now_img_multi_flag = 0;

    int clear_wait;
    int clear_wait_max;


    public BaseBgControl(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        before_img_slot = -1;
        now_img_slot = 1;//5;
        now_img_multi_flag = 1;


        bg_change(1, 0);

    //    now_img_slot = 1;


        clear_wait = -1;
        clear_wait_max = 1;
    }



    public void bg_change(int quick_flag, int free1)
    {
        int type1 = s1.base_run.base_type;

        int img_num1 = 1;

        {
            if (type1 == s1.base_run.ORGANIZATION_MENU) { img_num1 = 1; now_img_multi_flag = 1; }

            if (type1 == s1.base_run.STAGE1_SELECT
             || type1 == s1.base_run.PARTY_USE_STAGE)
            {
                img_num1 = 2; now_img_multi_flag = 1;
            }

            if (type1 == s1.base_run.SHOP_MENU
             || type1 == s1.base_run.EQUIPMENT_SHOP_BUY
             || type1 == s1.base_run.EQUIPMENT_SHOP_SELL)
            {
                img_num1 = 3; now_img_multi_flag = 1;
            }

            if (type1 == s1.base_run.OTHER_MENU
             || type1 == s1.base_run.SYSTEM_OPTION){

                img_num1 = 4; now_img_multi_flag = 1;
            }
        }
        
        if (now_img_slot != img_num1 || quick_flag == 1)
        {
            if (quick_flag == 0)
            {
                change_set(img_num1);
            }
            else
            {
                //    m.msbox(imgnum1);
                img_set(img_num1);

                //    quick_flag = 0;
            }
        }
    }


    public void img_set(int img_slot)
    {
        //   m.msbox(img_slot);

        clear_wait = -1;
        clear_wait_max = 1;//-1;

        now_img_slot = img_slot;
        before_img_slot = img_slot;

    //    before_img_multi_flag = now_img_multi_flag;
    }

    public void change_set(int img_slot)
    {
        clear_wait = CHANGE_WAIT;//s.ds.img_change_frame;
        clear_wait_max = clear_wait;


        //    img_slot++;

        before_img_slot = now_img_slot;
        now_img_slot = img_slot;

        before_img_multi_flag = now_img_multi_flag;
    }


    public void run1()
    {
        if (clear_wait >= 0)
        {
            clear_wait--;
        }
    }


    public void draw1()
    {
        //背景の描画
        {
            int px1 = 0;
            int py1 = 0;//s1.base_run.base_call_y(2);
            int pw1 = 960 - 240;//s1.display_w_call();
            int ph1 = 540;//s1.base_run.base_middle_h_call();

         //   if (s.base_run.base_type == s.base_run.DUNGEON_CLEAR)
         //   {
         //       py1 = 360 - ph1 / 2 + 44;
         //   }


            int py2 = py1 + ph1 / 2;


            int pic_num = 8;


            //now_img_multi_flag

            for (int t1 = 0; t1 <= 1; t1++)
            {
                int num1 = now_img_slot;
                if (t1 == 1) { num1 = before_img_slot; }

                int multi_flag = now_img_multi_flag;
                if (t1 == 1) { multi_flag = before_img_multi_flag; }

                int num3 = 255;

                if (t1 == 1)
                {
                    num3 = (int)(1.0f * 255 * clear_wait / clear_wait_max);
                    num3 = m1.iover(num3, 0, 255);

                    g1.setClear2(num3);
                }

                if (num1 >= 0 && num3 >= 1)
                {
                    if (multi_flag == 0)
                    {
                        g1.drawImage(ic1.loadcheck(pic_num, num1, 0), px1 + pw1 / 2, py2);
                    }else
                    {
                        ImageData1 id1 = ic1.loadcheck(pic_num, num1, 0);

                        int pw2 = id1.call_w();
                        int ph2 = id1.call_h();

                        int num_x1 = pw1 / pw2;
                        int num_y1 = ph1 / ph2;

                        for (int t3 = 0; t3 < num_x1+1; t3++)
                        {
                            for (int t4 = 0; t4 < num_y1+1; t4++)
                            {
                                int x5 = px1 + pw1 / 2 + t3 * pw2 - num_x1 * pw2 / 2;
                                int y5 = py1 + ph1 / 2 + t4 * ph2 - num_y1 * ph2 / 2;

                                g1.drawImage(id1, x5, y5);
                            }
                        }
                    }
                }

                if (t1 == 1) { g1.setClear2_re(); }
            }
        }

    }//draw()
}
