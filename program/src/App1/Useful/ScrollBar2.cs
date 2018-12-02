using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//X軸用のスクロールバー
public class ScrollBar2 : SetVoid1
{
    public int on;

    public float x1;
    public float y1;
    public int w1;
    public int h1;

    public int push_memo1;

    public ScrollBar2(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        on = 0;

        x1 = 0;// 680 + 4;
        y1 = 540 - 40 + 4;
        w1 = 10;
        h1 = 10;

        push_memo1 = 0;
    }

    public void close1()
    {
        on = 0;
    }

    public void base_create_x1()
    {
        on = 1;

        x1 = 16 * 2;
        y1 = 540 - 40 + 4 + 4;

        w1 = s1.base_run.base_call_all_w1() - 12 - 32*2;
    }

    public int dialog_check() { return s1.base_run.base_move_no_check(); }

    public int scroll_bar_w()
    {
        int w1 = s1.base_run.base_call_all_w1() - 6;
        int wn = s1.base_run.base_call_all_w1();
        int wj = (int)s1.cam_2d.x_max + wn;
        int w2 = w1 * wn / (wj);

        w2 = m1.iover(w2, 48, wn - 6);

        return w2;
    }

    public void run1()
    {
        if (on != 0)
        {
            if (dialog_check() == 0)
            {
                if (s1.cam_2d.x_max >= 1)
                {
                    float px1 = s1.touch_input.point_x1();
                    float py1 = s1.touch_input.point_y1();

                    float px2 = x1;// s1.base_run.base_call_all_w1();//416;
                    float py2 = y1 - 20;
                    int pw2 = w1-2; 
                    int ph2 = 64;

                    if (m1.rect_decision(px1, py1, px2, py2, pw2, ph2) == 1)
                    {
                        if (s1.touch_input.push_check() == 1)
                        {
                            {
                                push_memo1 = 1;

                            //    s1.cam_2d.push_memo = 3;                            
                            }
                        }
                    }

                    if (push_memo1 == 1)
                    {
                        {
                            int w7 = scroll_bar_w();

                            float x20 = px2 + w7 / 2;
                            int w20 = m1.iover(pw2 - w7, 1, 999999);

                            float nnp = 1.0f * (px1 - x20) * 100 / w20;
                            float per = m1.iover(nnp, 0, 100);

                            s1.cam_2d.x1 = per * s1.cam_2d.x_max / 100;

                        //    s1.cam_2d.x1 = 5000;
                        }
                    }

                    if (s1.touch_input.pull_check() == 1)
                    {
                        push_memo1 = 0;

                        if (s1.base_run.party_select_group != null)
                        {
                            if (s1.base_run.base_function.party_organization_check() == 1)
                            {
                                s1.base_run.party_select_group.party_camera_control.party_camera_move_decide();
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
            float x3 = x1;//466;
            float y3 = y1;//s1.base_run.base_call_y1();

            int w3 = w1;//10;
            int h3 = h1;//s1.base_run.base_call_h1()-12;
            

            if (push_memo1 == 1)
            {
                y3 -= 4;
                h3 += 8;
            }

            //現在位置を示すバー
            if (s1.cam_2d.x_max >= 1)
            {
                int w5 = scroll_bar_w();
                float x5 = x1 + 1.0f * (w3 - w5) * s1.cam_2d.x1 / s1.cam_2d.x_max;

                g1.drawImage2(ic1.loadcheck(1, 4, 0), x5 + 1, y3 + 1, w5 - 2, h3 - 2);

                g1.sc(52, 108, 146);
                g1.drawRect(x5 + 1, y3 + 1, w5 - 2, h3 - 2, 0, 0);
            }
            else
            {
            }

            //枠
            if (s1.cam_2d.x_max >= 1)
            {
                s1.dm1.boxdraw3(x3 + 1, y3 + 1, w3 - 2, h3 - 2, 10, 0);
            }
        }
    }
}
