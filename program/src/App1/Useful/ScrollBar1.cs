using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//カメラを移動させる時に使うバー。大抵は編成の時、右に置かれている
public class ScrollBar1 : SetVoid1
{
    public int on;

    public float x1;
    public float y1;
    public int w1;
    public int h1;

    public int push_memo1;

    public ScrollBar1(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        on = 0;

        x1 = 680 + 4;
        y1 = 0;
        w1 = 10;
        h1 = 10;

        push_memo1 = 0;
    }

    public void close1()
    {
        on = 0;
    }

    public void base_create_y1()
    {
        on = 1;

        x1 = 680 + 4;
        y1 = s1.base_run.base_call_y2();

        h1 = s1.base_run.base_call_h2() - 12;
    }

    /*
    public float call_x_positioin() { return x1; }
    public float call_y_positioin() { return y1; }
    */


    public int dialog_check() { return s1.base_run.base_move_no_check(); }

    public int scroll_bar_h()
    {
        int h1 = s1.base_run.base_call_h2() - 6;
        int hn = s1.base_run.base_call_h2();
        int hj = (int)s1.cam_2d.y_max + hn;//m.iover(((int)s.cam.y_max + hn), 1, h1);
        int h2 = h1 * hn / (hj);

        h2 = m1.iover(h2, 48, hn - 6);

        return h2;
    }

    public void run1()
    {
        if (on != 0)
        {
            //    y1 += 0.2f;

            if (dialog_check() == 0)
            {
                if (s1.cam_2d.y_max >= 1)
                {
                    float px1 = s1.touch_input.point_x1();
                    float py1 = s1.touch_input.point_y1();

                    float px2 = x1 - 20;//416;
                    float py2 = y1;
                    int pw2 = 48;
                    int ph2 = h1- 2;

                    if (m1.rect_decision(px1, py1, px2, py2, pw2, ph2) == 1)
                    {
                        if (s1.touch_input.push_check() == 1)
                        {
                            /*
                            int px3 = 6;
                            int py3 = 606;
                            int pw3 = 480 - px3 * 2 - 24;
                            int ph3 = 72;

                            if (m.rect_decision(px1, py1, px3, py3, pw3, ph3) == 0 || s.base_run.base_type != s.base_run.CHARACTER_PARTY_SELECT_MULTI)
                            */

                            {
                                push_memo1 = 1;
                            }
                        }
                    }
                    
                    if (push_memo1 == 1)
                    {
                        {
                            int h7 = scroll_bar_h();

                            float y20 = py2 + h7 / 2;
                            int h20 = m1.iover(ph2 - h7, 1, 999999);

                            float nnp = 1.0f * (py1 - y20) * 100 / h20;
                            float per = m1.iover(nnp, 0, 100);

                            s1.cam_2d.y1 = per * s1.cam_2d.y_max / 100;
                        }
                    }

                    if (s1.touch_input.pull_check() == 1)
                    {
                        push_memo1 = 0;
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

            //枠
            //   g.sc(255);
            //   g.drawRect(x1, y1, w1, h1, 0, 0);

            
            if (push_memo1 == 1)
            {
                x3 -= 4;
                w3 += 8;
            }
            

            //現在位置を示すバー
            if (s1.cam_2d.y_max >= 1)
            {
                int h5 = scroll_bar_h();
                float y5 = y1 + 1.0f * (h3 - h5) * s1.cam_2d.y1 / s1.cam_2d.y_max;

                g1.drawImage2(ic1.loadcheck(1, 4, 0), x3 + 1, y5 + 1, w3 - 2, h5 - 2);

                g1.sc(52, 108, 146);
                g1.drawRect(x3 + 1, y5 + 1, w3 - 2, h5 - 2, 0, 0);
            }
            else
            {
            //    int h2 = scroll_bar_h();
            //    g1.drawImage2(ic1.loadcheck(1, 4, 0), x3 + 1, y3 + 1, w3 - 2, h3 - 2);
            }

            /*
            //現在位置を示すバー
            if (s.cam.y_max >= 1)
            {
                int h2 = scroll_bar_h();

                int y2 = y1 + (h1 - h2) * (int)s.cam.y / (int)s.cam.y_max;

                g.drawImage2(im.loadcheck(1, 4, 0), x1 + 1, y2 + 1, w1 - 2, h2 - 2);

                g.sc(52, 108, 146);
                g.drawRect(x1 + 1, y2 + 1, w1 - 2, h2 - 2, 0, 0);
            }
            else
            {
                int h2 = scroll_bar_h();
                g.drawImage2(im.loadcheck(1, 4, 0), x1 + 1, y1 + 1, w1 - 2, h2 - 2);
            }
            */

            //枠
            if (s1.cam_2d.y_max >= 1)
            {
                s1.dm1.boxdraw3(x3 + 1, y3 + 1, w3 - 2, h3 - 2, 10, 0);
            }
        }
    }
}
