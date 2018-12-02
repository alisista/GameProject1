using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//本来の2Dカメラクラスの一部を制御して、パーティ画面のスクロールを実装したもの
public class PartyCameraControl : SetVoid1
{
    float party_move_x;
    float party_move_x_memo;
    int party_move_wait;

    public int party_scroll_tm() { return 24; }

    public PartyCameraControl(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

    }

    public int use_ok_check() { return 1; }
    public int dialog_check() { return s1.base_run.base_move_no_check(); }

    //2Dカメラクラスからの制御------------------------------------------

    public void party_move_reset()
    {
        if (use_ok_check() == 1)
        {
            party_move_wait = -1;

            party_move_x = 0;
            party_move_x_memo = s1.cam_2d.x1;
        }
    }//party_move_reset()

    //手を離したとき滑る成分を決める
    public void party_camera_move_decide()
    {
        if (dialog_check() == 0)
        {
            if (use_ok_check() == 1)
            {
                {
                    //特殊 パーティ編成は 手を離した際、加速度によって、sin移動として、どこに行くか決めてしまう
                    //   if (party_select_flag == 1)
                    {
                        int party_num = x_calc_party_num_call(s1.cam_2d.x1);

                        int direct = 1;
                        if (s1.cam_2d.ax < 0) direct = -1;

                        if (m1.abs(s1.cam_2d.ax) >= 3.0f)
                        {
                            if (m1.abs(s1.cam_2d.ax) >= 18.0f)
                            {
                                party_num += 2 * direct;
                            }
                            else
                            {
                                party_num += 1 * direct;
                            }
                        }
                        else
                        {

                        }

                        //    m.msbox(x);

                        if (s1.base_run != null)
                        {
                        //    if (s.base_run.base_type == s.base_run.PARTY_SELECT || s.base_run.base_type == s.base_run.PARTY_SELECT_GOTO_DUNGEON || s.base_run.base_type == s.base_run.PARTY_SELECT_COPY)
                            {
                                party_num = m1.iover(party_num, 0, s1.base_run.party_select_group.now_party_save_num_call() - 1);

                                //    m.msbox(party_num);

                                //    s.game_variable.party_use_num = party_num;
                                s1.base_run.party_select_group.party_use_num = party_num;
                            }
                        }


                        //    m.msbox();

                        //sin移動で、partynumに移動
                        {
                            party_move_x = party_calc_x_call(party_num) - (int)s1.cam_2d.x1;
                            party_move_x_memo = party_calc_x_call(party_num);
                            party_move_wait = party_scroll_tm();
                        }

                        s1.cam_2d.ax = 0;
                    }
                }
            }
        }
    }//party_camera_move_decide()

    //2Dカメラクラスからの制御------------------------------------------

    public int x_calc_party_num_call(float x1)
    {
        int nt = 0;

        int n1 = s1.base_run.base_call_all_w1();

        int max = s1.base_run.party_select_group.now_party_save_num_call();

        for (int t1 = 0; t1 < max; t1++)
        {
            if (x1 >= t1 * n1 - n1 / 2 && x1 <= t1 * n1 + n1 / 2)
            {
                nt = t1;
                //    m.msbox(n1 / 2 - t1 * n1);
                break;
            }
        }

        return nt;
    }

    public int party_calc_x_call(int party_num)
    {
        int nt = 0;

        nt = party_num * s1.base_run.base_call_all_w1();

        return nt;
    }

    public void party_camera_slip_move()
    {
        if (use_ok_check() == 1)
        {
            {
                //   if (party_select_touch_count == 1)
                if (party_move_wait >= 0)
                {
                    //    party_select_touch_count = 0;

                    //    m.msbox(party_move_wait);

                    int tm3 = party_move_wait;
                    s1.cam_2d.x1 = party_move_x_memo - party_move_x - m1.sin_r(party_move_x, 90 * (party_scroll_tm() - tm3) / party_scroll_tm());

                    party_move_wait--;
                }
                else
                {
                    if (s1.cam_2d.push_memo == 1)
                    {
                        if (m1.abs(party_move_x) >= 1)
                            s1.cam_2d.x1 = party_move_x_memo;
                    }
                }
            }
        }
    }


    public void run1()
    {
        if (use_ok_check() == 1)
        {
        //    large_flag = 0;

            x_quick_move_scroll_bar_run();
        }
    }

    public void x_quick_move_scroll_bar_run()
    {
        /*
        if (dialog_check() == 0)
        {
            int touch_flag = 0;

            int px1 = s1.touch_input.point_x1();
            int py1 = s1.touch_input.point_y1();

            int px2 = 0;//416;
            int py2 = 640;//640;//s.base_run.base_call_y(2) + s.base_run.base_middle_title_h();
            int pw2 = 480;//64;
            int ph2 = 50;//40;//s.base_run.base_middle_h_call() - s.base_run.base_middle_title_h() - 2;

            if (m.rect_decision(px1, py1, px2, py2, pw2, ph2) == 1)
            {
                if (s.ti.push_check() == 1)
                {
                    s.cam.push_flag_memo = 3;
                }
            }

            if (s.cam.push_flag_memo == 3)
            //    if (touch_flag==1)
            {
                {
                    int w1 = s.dm.scroll_bar_w();

                    int x20 = px2 + w1 / 2;
                    int w20 = m.iover(pw2 - w1, 1, 999999);

                    float nnp = 1.0f * (px1 - x20) * 100 / w20;
                    float per = m.iover(nnp, 0, 100);

                    s.cam.x = per * s.cam.x_max / 100;
                }
            }
        }
        */
    }//x_quick_move_scroll_bar_run()

    public void draw1()
    {
    }
}
