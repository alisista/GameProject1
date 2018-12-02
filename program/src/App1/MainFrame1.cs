using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using System.Windows.Forms;


using DxLibDLL;


public class MainFrame1
{
    long fps = 0;

    long[] wait_time = new long[9];
    String memory_memo = "";


    Summary1 s1;

    //この汎用ラッパークラスは、ここでしか使わない。他のクラスでは、s1から移動
    Misc1 m1;
    MainCanvas1 g1;


    //    Input1 input1;
    //    ImageControl1 ic1;


    public MainFrame1()
    {
        s1 = new Summary1();

        s1.m1 = new Misc1();
        s1.g1 = new MainCanvas1();

        s1.m1.init1();
        s1.g1.init1();

        m1 = s1.m1;
        g1 = s1.g1;
        

        long timer = m1.get_time();

    
        //    s1.init1();
        s1.init_set1(s1);

        /*
        s1.m1 = new Misc1();
        s1.g1 = new MainCanvas1();

        s1.m1.init1();
        s1.g1.init1();

               
        {
            s1.input1 = new Input1();
            s1.input1.init_set1(s1);

            s1.ic1 = new ImageControl1();
            s1.ic1.init_set1(s1);
        }*/


        /*
        s.so = new Sound();
        s.so.set(m, g, im, input, s);
        s.so.init();


        s.gm = new GameMisc();
        s.gm.set(m, g, im, input, s);
        s.gm.init();


        s.tc = new TagControl();
        s.tc.set(m, g, im, input, s);
        s.tc.init();

        s.ti = new TouchInput();
        s.ti.set(m, g, im, input, s);
        s.ti.init();
        */

        /*
        {
            s1.mr1 = new MainRun1();
            s1.mr1.init_set1(s1);
        }*/

        

        wait_time[4] = m1.get_time() - timer;
    }


    public void run1()
    {
        initdraw();


    //    run2();

        //実行(ループ)
        while (DX.ProcessMessage() == 0 && m1.end_flag == 0)
        {
            //    long stime = m1.get_time();

            //escapeで、終了確認
            if (DX.CheckHitKey(DX.KEY_INPUT_ESCAPE) != 0)
            {
                int nt = 1;

                if (s1.debug_on() == 0)
                {
                    DialogResult result = MessageBox.Show("ゲームを終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {
                        nt = 1;
                    }
                    else if (result == DialogResult.No)
                    {
                        nt = 0;
                    }
                }
                

                if (nt == 1)
                {
                    m1.end_flag = 1;
                    break;
                }
            }

            //他のスレッドに、ゲーム終了を知らせる
            if (DX.ProcessMessage() != 0)// || DX.CheckHitKey(DX.KEY_INPUT_ESCAPE) != 0)
            {
                m1.end_flag = 1;
            }





            

            long stime = m1.get_time();

            {
                long timer = m1.get_time();
                run2();
                wait_time[0] = m1.get_time() - timer;//wait_time[0];
            }



            fps = m1.FpsTimeFanction();

            int nnb = 1;
            if (s1.debug_frame_control_on() == 1)
            {
                if (DX.CheckHitKey(DX.KEY_INPUT_2) != 0)
                {
                    nnb = 5;//m1.end();
                }

                if (DX.CheckHitKey(DX.KEY_INPUT_3) != 0)
                {
                    m1.wait(50);
                    nnb = 0;
                }
            }




            //描画
            if (s1.draw_count >= s1.draw_count_max * nnb)
            {
                s1.draw_count = 0;

                

                long timer = m1.get_time();
                draw1();
                wait_time[1] = m1.get_time() - timer;//wait_time[0];
            }

            s1.draw_count += 1;




            int wait = 17;//(d.waitframe);//=32

            if (s1.debug_frame_control_on() == 1)
                if (DX.CheckHitKey(DX.KEY_INPUT_2) != 0)
                {
                    wait /= 5;//m1.end();
                }
            

            //	m1.wait(stime,m1.get_time(),33);//d.loop_wait_frame);//40
            m1.wait(stime, m1.get_time(), wait);
            //    m1.wait(stime, m1.get_time(), 17);

            wait_time[2] = m1.get_time() - stime;            
        }


       


        m1.end_flag = 1;
    }

    public void run2()
    {
        g1.run();

        if (s1.debug_frame_control_on() == 1)
        {
            while (true)
            {
                if (DX.CheckHitKey(DX.KEY_INPUT_1) == 0)
                {
                    break;
                }
                else
                {
                    m1.wait(10);
                }
            }
        }


        //スクリーンキャプチャ(Qキー)
        if (s1.input1.rinput(1, s1.input1.INPUT_Q) != 0)
        {
            {
                //   m.msbox(1);
                g1.screencapture_save();
            }
        }


        
        s1.run1();


        /*
        s.ti.run();

        s.tc.run();

        

    //    s.tw.run();

//        s.meg.run();
        */

        //メモリ確認のタイマー
        {
            wait_time[7]++;
            if (wait_time[7] >= 10)
            {
                wait_time[7] = 0;

                long currentSet = Environment.WorkingSet;

                memory_memo = "" + (currentSet / 1024/1024);//currentSet.ToString("N0");
                //    Console.WriteLine("現在のメモリ使用量は{0}byteです。", currentSet.ToString("N0"));
            }
        }
    }//run1()


    void initdraw()
    {

    }

    public void draw1()
    {
        //一旦別画面にゲームの内容を描画
        /*
        {
            g1.make_draw_screen_img(640, 480);
            g1.make_draw_screen_img(s1.display_w_call(), s1.display_h_call());
        }
        */

        //画面初期化
        g1.sc(32);
        g1.drawRect(0, 0, s1.display_w, s1.display_h);


        //これを入れておかないと、スクリーンキャプチャーの際に、画像たちの透過が乗算されてしまう
        //        DX.SetDrawBlendMode(DX.DX_BLENDMODE_PMA_ALPHA, 255);

        /*
        s.ti.draw();

        s.tc.draw();
        */

        s1.draw1();



        //        s.meg.draw();

        //     s.tw.draw();


        if (s1.debug_draw()==1)
        {
            int nt2 = 540, nt1 = 24;

            g1.sc(232);
            g1.str2("Run  :" + wait_time[0], nt2 - 12, 24 - 4);
            g1.str2("Draw :" + wait_time[1], nt2 - 12, 24 - 4 + nt1 * 1);
            g1.str2("Max  :" + wait_time[2], nt2 - 12, 24 - 4 + nt1 * 2);


            g1.str2("Open :" + wait_time[4], nt2 - 12, 24 - 4 + nt1 * 4);
            g1.str2("Mem  :" + memory_memo + " MB", nt2 - 12, 24 - 4 + nt1 * 5);

            int pp3 = 7;

            g1.str2("Touch_x  :" + s1.touch_input.point_x1(), nt2 - 12, 24 - 4 + nt1 * (pp3 + 0));
            g1.str2("Touch_y  :" + s1.touch_input.point_y1(), nt2 - 12, 24 - 4 + nt1 * (pp3 + 1));

            {
                int pp4 = 10;

                g1.str2("Effect : " + s1.effect_group.active_num_check() + " / " + s1.effect_group.max_num(), nt2 - 12, 24 - 4 + nt1 * (pp4 + 0));
            }


            //            g1.sc(232);
            g1.str2("FPS : " + fps, nt2 - 12, 460 - 4);


            int ntp = 1;
            if (s1.mr1.game_type == 0) { ntp = 0; }

            if (ntp == 1)
            {
                g1.str2("" + s1.title_name1(), 760 - 12 - 8, 524 - 4);
                //g1.str2("" + s1.title_name, 740 + 64, 524 - 4);
            }
        }

        /*
        {
            ImageData1 id1 = g1.make_draw_screen_img_re();

            g1.drawImage2(id1, 0, 0, 1.0f);

            g1.delete_graph(id1);//画像生成した後は、削除が必須。忘れると危険            
        }
        */


   //     DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);

        //   if (s1.tm1 <= 20)        
        DX.ScreenFlip();        

        //   m1.wait(3000);
    }


}

