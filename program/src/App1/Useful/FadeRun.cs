using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class FadeRun : SetVoid1
{
    public int fade_type;
    public int fade_in_or_out;


    public int ontm;//生存時間
    public int need_tm;//フェードに必要な時間

    public int color_type;


    public int FADE_IN = 0;
    public int FADE_OUT = 1;
    public int FADE_ANOTHER = 2;

    public int FADE_NORMAL = 0;
    public int FADE_WAIT_40 = 0;
    public int FADE_WAIT_60 = 1;
    public int FADE_WAIT_90 = 2;
    public int FADE_WAIT_120 = 3;
    public int FADE_WAIT_150 = 4;
    public int FADE_WAIT_80 = 5;
    //    public int FADE_BASE_FADE = 1;

    public FadeRun(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        fade_type = 0;
        fade_in_or_out = 0;

        color_type = 0;

        ontm = 0;
        need_tm = 0;
    }


    public int main_fade_use;

    //よく使うフェード 60f
    public void main_fade_create(int fade_in_0_or_fade_out_1)
    {
        /*
        s.fadesp.fade_init();

        //mfs起動
        if (fade_in_0_or_fade_out_1 == 0) { s.fadesp.fade_set(1, 0); }
        if (fade_in_0_or_fade_out_1 == 1) { s.fadesp.fade_set(0, 0); main_fade_use = 1; }
        */
    }


    int need_tm_max(int num)
    {
        int nt = 40;

        if (num == -1) { nt = 20; }
        if (num == FADE_WAIT_60) { nt = 60; }
        if (num == FADE_WAIT_90) { nt = 90; }
        if (num == FADE_WAIT_120) { nt = 120; }
        if (num == FADE_WAIT_150) { nt = 150; }
        if (num == FADE_WAIT_80) { nt = 80; }

        return nt;
    }


    public void clear()
    {
        //   s.fadesp.fade_init();

        fade_in_or_out = -1;
    }


    public void create1(int fade_type1, int fadein0_or_fadeout1, int input_wait_flag, int free2)
    {
        if (fadein0_or_fadeout1 == FADE_IN)
        {
        }

        //   s.fadesp.fade_init();

        need_tm = need_fade_tm(fade_type1);

        fade_type = fade_type1;
        fade_in_or_out = fadein0_or_fadeout1;


        ontm = need_tm;

        if (input_wait_flag == 0)
        {
            if (fadein0_or_fadeout1 == 0)
            {
                need_tm /= 2;
            }

            //   input.wait(need_tm + 1);
            s1.touch_input.wait(need_tm + 1);
        }
    }


    /*
    public void capture_fade_create(int fade_type1)
    {
     //   s.fadesp.fade_init();

        g.Screen_capture();

        need_tm = need_fade_tm(fade_type1);

        fade_in_or_out = FADE_ANOTHER;

        ontm = need_tm;

    //    fade_type = fade_type1;
    }

    //スクリプトからの要求 キャプチャーフェード
    public void capture_fade_create_script(int fade_type1)
    {
        capture_fade_create(fade_type1);

        s.sc.mw.clear();
    }
    */




    //フェードに必要な時間を返す
    public int need_fade_tm(int fade_type)
    {
        int nt = need_tm_max(fade_type);//need_tm_max(0);

        //   nt = 90;

        //    if (fade_type == FADE_WAIT_60) {}

        return nt;
    }


    public void run1()
    {
        if (fade_type == FADE_NORMAL)
        {
            if (fade_in_or_out == FADE_IN)
            {

            }

            if (fade_in_or_out == FADE_OUT)
            {

            }

            if (fade_in_or_out == FADE_ANOTHER)
            {

            }
        }

        if (ontm >= 0)
        {
            ontm--;
        }
    }

    public void draw1()
    {
        int color1 = 34;//32

        if (color_type == 1)
        {
            color1 = 216;//32;
        }

        //    if (fade_type == FADE_NORMAL)
        {
            if (fade_in_or_out == FADE_IN)
            {
                if (ontm > 0)
                {
                    int nt = (ontm - 1) * 255 / need_tm;
                    if (nt < 0) { nt = 0; }
                    if (nt > 255) { nt = 255; }

                    g1.setClear(nt);
                    g1.sc(color1);
                    g1.drawRect(0, 0, s1.display_w_call(), s1.display_h_call(), 0, 1);
                    g1.setClearre();
                }
                else
                {
                    fade_in_or_out = -1;
                    color_type = 0;
                }
            }

            if (fade_in_or_out == FADE_OUT)
            {
                if (ontm > 0)
                {
                    int nt = 255 - (ontm - 1) * 255 / need_tm;
                    if (nt < 0) { nt = 0; }
                    if (nt > 255) { nt = 255; }

                    g1.setClear(nt);
                    g1.sc(color1);
                    g1.drawRect(0, 0, s1.display_w_call(), s1.display_h_call(), 0, 1);
                    g1.setClearre();
                }
                else
                {
                    g1.sc(color1);
                    g1.drawRect(0, 0, s1.display_w_call(), s1.display_h_call(), 0, 1);
                }
            }

            /*
            if (fade_in_or_out == FADE_ANOTHER)
            {
                {
                //    Image im1 = new Image();
                //    im1.img_address = g.cap_image;

                    int nt = (ontm - 1) * 255 / need_tm;
                    if (nt < 0) { nt = 0; }
                    if (nt > 255) { nt = 255; }

                    g.setClear(nt);

                    g.drawImage2(g.cap_image, 0, 0);
                    g.setClearre();
                }
            }
            */
        }
    }
}
