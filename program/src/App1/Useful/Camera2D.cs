using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Camera2D : SetVoid1
{
    public int on;

    //カメラの位置
    public float x1;
    public float y1;

    //カメラの移動範囲の最大
    public float x_min;
    public float x_max;
    public float y_min;
    public float y_max;
    


    public int push_memo;
    public int area_push_x;
    public int area_push_y;
    public int area_push_w;
    public int area_push_h;

    //タッチ関係の y座標の制御
    public float y_memo;
    public float touch_y_memo;
    public float y_memo_before;
    public float ay;
    public int auto_slip_y;
    public float[] y_memo_box = new float[4];


    //タッチ関係の x座標の制御
    public float x_memo;
    public float touch_x_memo;
    public float x_memo_before;
    public float ax;
    public int auto_slip_x;
    public float[] x_memo_box = new float[4];


    public int move_flag;

    public float accel_speed_down() { return 0.5f; }//0.3f*2;
    public float accel_div() { return 0.75f; }
    public float accel_max() { return 36.0f; }//12.0f;
    
    public Camera2D(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        x1 = 0;
        y1 = 0;

        x_min = 0;
        y_min = 0;
        x_max = 0;
        y_max = 1000;


        push_memo = 0;
        area_push_x = -9999;
        area_push_y = -9999;
        area_push_w = 99999;
        area_push_h = 99999;

        {
            y_memo = 0;
            touch_y_memo = 0;
            y_memo_before = 0;
            ay = 0;
            auto_slip_y = 1;

            for (int t1 = 0; t1 < 4; t1++)
            {
                y_memo_box[t1] = -99999;
            }

            x_memo = 0;
            touch_x_memo = 0;
            x_memo_before = 0;
            ax = 0;
            auto_slip_x = 1;

            for (int t1 = 0; t1 < 4; t1++)
            {
                x_memo_box[t1] = -99999;
            }
        }

        move_flag = 0;
    }

    public void create1()
    {
        init1();
        on = 1;      
    }

    public void close1()
    {
    //    init1();
        on = 0;
    }

    public float call_x_positioin() { return x1; }
    public float call_y_positioin() { return y1; }

    public void x_min_set(int num) { x_min = num; }
    public void y_min_set(int num) { y_min = num; }
    public void x_max_set(int num) { x_max = num; }
    public void y_max_set(int num) { y_max = num; }


    public int dialog_check() { return s1.base_run.base_move_no_check(); }


    public int move_check()
    {
        int nt = move_flag;

        return nt;
    }


    public void move_flag_check_run()
    {
        //加速度状態によって、タッチインターフェースに動いたかどうかを教える
        {
            int move_p = 8;

            if (s1.touch_input.touch_check() == 1 && ((m1.abs(touch_y_memo - s1.touch_input.point_y1()) >= move_p)))// || m1.abs(touch_x_memo - s1.touch_input.point_x1()) >= move_p))
            {
                move_flag = 1;

            //    m1.msbox(m1.abs(touch_y_memo - s1.touch_input.point_y1()));
                //    m.msbox(m.abs(touch_x_memo - s.ti.touch_x_per2_change_x()));
            }

            if (s1.touch_input.touch_check() == 1 && ((m1.abs(touch_x_memo - s1.touch_input.point_x1()) >= move_p)))
            {
                move_flag = 1;
            }

            //   if (s.ti.pull_check() == 1)
            if (s1.touch_input.touch_check() == 0)
            {
                move_flag = 0;
            }
        }
    }


    public void push_area_set(int x11, int y11, int w11, int h11)
    {
        area_push_x = x11;
        area_push_y = y11;
        area_push_w = w11;
        area_push_h = h11;
    }


    public void run1()
    {
        if (on != 0)
        {
            //    y1 += 0.2f;

            int np = 1;

            if (s1.base_run != null)
            {
                if (s1.base_run.character_status.on != 0)
                {
                    np = 0;
                }
            }

            if (s1.scroll_bar1.on!=0 && s1.scroll_bar1.push_memo1 != 0)
            {
                np = 0;
            }

            
            if (np == 1)
            {
                run2();
            }

            //run2より後ろ
            move_flag_check_run();
        }
    }

    public void run2()
    {
        {
            //タッチで反応できるエリアを触った場合、動き始める
            if (s1.touch_input.push_check() == 1)
            {
                //    push_flag_memo = 1;

                int px1 = s1.touch_input.point_x1();
                int py1 = s1.touch_input.point_y1();

                if (m1.rect_decision(px1, py1, area_push_x, area_push_y, area_push_w, area_push_h) == 1)
                {
                    //    m.msbox();
                    push_memo = 1;
                }
            }

            //y座標計算
            {
                if (dialog_check() == 0)
                {
                    //おした時、押した場所をメモする＋加速止
                    if (s1.touch_input.push_check() == 1)
                    {
                        touch_y_memo = s1.touch_input.point_y1();

                        ay = 0;

                        int px1 = s1.touch_input.point_x1();
                        int py1 = s1.touch_input.point_y1();

                        //     scroll_another_type_1_push_init(1);

                        //加速メモのリセット
                        {
                            for (int t1 = 4 - 1; t1 >= 0; t1--)
                            {
                                y_memo_box[t1] = 0;
                            }
                        }

                        y_memo = y1;
                    }
                }


                if (push_memo == 1)
                {
                    if (dialog_check() == 0)
                    {
                        if (s1.touch_input.touch_check() == 1)
                        {
                            y1 = y_memo + touch_y_memo - s1.touch_input.point_y1();

                            //    y_memo_before = s.ti.touch_y_per_change_y();


                            //加速のボックス更新
                            {
                                for (int t1 = 4 - 1; t1 >= 1; t1--)
                                {
                                    y_memo_box[t1] = y_memo_box[t1 - 1];
                                }

                                y_memo_box[0] = s1.touch_input.point_y1();//y;
                            }
                        }
                    }

                    //手を離した時に加速値を決める
                    if (s1.touch_input.pull_check() == 1)
                    {
                        //    ay = y_memo_before - s.ti.touch_y_per_change_y();

                        int count = 0;
                        float ay_sum = 0;

                        for (int t1 = 0; t1 < 4 - 1; t1++)
                        {
                            if (m1.abs(y_memo_box[t1]) >= 1 && m1.abs(y_memo_box[t1 + 1]) >= 1)
                            {
                                float add1 = -(y_memo_box[t1] - y_memo_box[t1 + 1]);
                                ay_sum += add1;

                                //    y_memo_sum += y_memo_box[t1];

                                if (m1.abs(add1) >= 1)
                                {
                                    count++;
                                }
                            }
                        }

                        //    count = 1;
                        //    y_memo_sum = y_memo_box[0];

                        if (count >= 1)
                        {
                            ay = ay_sum / count;// - s.ti.touch_y_per_change_y();

                            ay = ay * accel_div();

                            ay = m1.iover(ay, -accel_max(), accel_max());
                        }

                        //    scroll_another_type_1_pull_update(1);

                        if (auto_slip_y == 0)
                        {
                            ay = 0;
                        }
                    }
                }

                
                //加速制御
                {
                    float ay1_stop = accel_speed_down();

                    if (ay > ay1_stop / 2) { ay -= ay1_stop; }
                    else if (ay < -ay1_stop / 2) { ay += ay1_stop; }
                    else
                    {
                        ay = 0;
                    }

                    y1 += ay;
                }

                if (y1 < y_min) { y1 = y_min; ay = 0; }
                if (y1 > y_max) { y1 = y_max; ay = 0; }
            }//y座標計算


            //x座標計算
            {
                //おした時、押した場所をメモする＋加速止
                if (dialog_check() == 0)
                {
                    if (s1.touch_input.push_check() == 1)
                    {
                        touch_x_memo = s1.touch_input.point_x1();
                        ax = 0;

                        //party_cam
                        if (s1.base_run.party_select_group != null)
                        {
                            if (s1.base_run.base_function.party_organization_check() == 1)
                            {
                                s1.base_run.party_select_group.party_camera_control.party_move_reset();
                            }
                        }

                        //加速メモのリセット
                        {
                            for (int t1 = 4 - 1; t1 >= 0; t1--)
                            {
                                x_memo_box[t1] = 0;
                            }
                        }

                        x_memo = x1;
                    }
                }

                if (push_memo == 1)
                {
                    if (dialog_check() == 0)
                    {
                        if (s1.touch_input.touch_check() == 1)
                        {
                            x1 = x_memo + touch_x_memo - s1.touch_input.point_x1();

                            //加速のボックス更新
                            {
                                for (int t1 = 4 - 1; t1 >= 1; t1--)
                                {
                                    x_memo_box[t1] = x_memo_box[t1 - 1];
                                }

                                x_memo_box[0] = s1.touch_input.point_x1();//y;
                            }
                        }
                    }
                    
                    //手を離した時に加速値を決める
                    {
                        if (s1.touch_input.pull_check() == 1)
                        {
                            int count = 0;
                            float ax_sum = 0;

                            for (int t1 = 0; t1 < 4 - 1; t1++)
                            {
                                if (m1.abs(x_memo_box[t1]) >= 1 && m1.abs(x_memo_box[t1 + 1]) >= 1)
                                {
                                    float add1 = -(x_memo_box[t1] - x_memo_box[t1 + 1]);
                                    ax_sum += add1;
                                    
                                    if (m1.abs(add1) >= 1)
                                    {
                                        count++;
                                    }
                                }
                            }

                            if (count >= 1)
                            {
                                ax = ax_sum / count;// - s.ti.touch_y_per_change_y();
                                ax = ax * accel_div();
                                ax = m1.iover(ax, -accel_max(), accel_max());
                            }

                            //party_cam
                            if (s1.base_run.party_select_group != null)
                            {
                                if (s1.base_run.base_function.party_organization_check() == 1)
                                {
                                    s1.base_run.party_select_group.party_camera_control.party_camera_move_decide();
                                }
                            }

                            if (auto_slip_x == 0)
                            {
                                ax = 0;
                            }
                        }
                    }
                }

                //party_cam
                if (s1.base_run.party_select_group != null)
                {
                    //party_cam_control の、x_quick_move_scroll_bar_run()で制御
                    if (push_memo == 3)
                    {
                    //    s1.base_run.party_select_group.party_camera_control.party_camera_move_decide();
                    }
                }

                //加速制御
                {
                    float ax1_stop = accel_speed_down();

                    if (ax > ax1_stop / 2) { ax -= ax1_stop; }
                    else if (ax < -ax1_stop / 2) { ax += ax1_stop; }
                    else
                    {
                        ax = 0;
                    }

                    x1 += ax;
                }

                if (x1 < x_min) { x1 = x_min; ax = 0; }// m.msbox(1); }
                if (x1 > x_max) { x1 = x_max; ax = 0; }// m.msbox(1); }
            }


            //パーティ時専用の特殊な計算    
            //party_cam
            if (s1.base_run.party_select_group != null)
            {
                s1.base_run.party_select_group.party_camera_control.party_camera_slip_move();
            }

            //ラスト
            if (s1.touch_input.pull_check() == 1)
            {
                push_memo = 0;
            }
        }
    }//run2()

    public void draw1()
    {
        
        if (on != 0)
        {
            int x71 = 16;
            int nt1 = 24;

            /*
            g1.sc(255);
            g1.str2("cam_x:" + (int)x1, x71, 16 + nt1 * 1);
            g1.str2("cam_y:" + (int)y1, x71, 16 + nt1 * 2);

            g1.str2("cam_area_x:" + (int)area_push_x, x71, 16 + nt1 * 4);
            g1.str2("cam_area_y:" + (int)area_push_y, x71, 16 + nt1 * 5);
            g1.str2("cam_area_w:" + (int)area_push_w, x71, 16 + nt1 * 6);
            g1.str2("cam_area_h:" + (int)area_push_h, x71, 16 + nt1 * 7);
            */

            //    g1.str2("y_min:" + (int)y_min, x71, 16 + nt1 * 4);
            //    g1.str2("y_max:" + (int)y_max, x71, 16 + nt1 * 5);

            //          g1.str2("ym:" + (int)(m1.abs(touch_y_memo - s1.touch_input.point_y1())), x71, 16 + nt1 * 7);
            //            g1.str2("ymf:" + move_flag, x71, 16 + nt1 * 8);
        }
        
    }
}
