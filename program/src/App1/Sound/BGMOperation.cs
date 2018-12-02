using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BGMOperation : BGMNameExtend
{
    //現在再生している音楽の番号
    public int now_play_num;

    public int bgm_wait_play_tm;
    public int bgm_wait_play_type1;

    public int bgm_ch_vol_per_max() { return 100; }

    public ClearChange clear_change;
    
    public BGMOperation(Summary1 s1)
    {
        set1(s1);

        clear_change = new ClearChange(s1);
    }

    public void init1()
    {
        now_play_num = 0;

        bgm_wait_play_tm = 0;
        bgm_wait_play_type1 = 0;


        clear_change.init1();
    }

   
    public void play_loop_bgm(int type1)
    {
        if (s1.bgm_on != 0)
        {
            clear_change.init1();

            //再生できる音楽を全て停止 + メモリの開放
            {
                s1.bgm_control1.release_data();
            }

            s1.bgm1.play_loop_bgm(s1.bgm_control1.loadcheck1(type1));

            now_play_num = s1.bgm_control1.now_play_number;
        }
    }

    public void play_wait_loop_bgm(int type1,int wait1)
    {
    //    if (bgm_wait_play_tm <= 0)
        {
            bgm_wait_play_type1 = type1;
            bgm_wait_play_tm = wait1;
        }
    }

    public void bgm_fade_out()
    {
    //    if (bgm_play_slot >= 0)
        {
            //bgm_chvol(-1, bgm_play_slot, 60);

            bgm_fade_out(40);
        }
    }

    public void bgm_fade_out(int time1)
    {
    //    if (bgm_play_slot >= 0)
        {
            //bgm_chvol(-1, time1);

            clear_change.change_set(255, -255 / time1);
        }
    }

    public void bgm_stop()
    {
        s1.bgm_control1.all_stop();
    }

    public void bgm_volume_update()
    {
        s1.bgm_control1.all_volume_update();
    }


    public void run1()
    {        
        if (bgm_wait_play_tm >= 1)
        {
            if (bgm_wait_play_tm == 1)
            {
                this.play_loop_bgm(bgm_wait_play_type1);
            }

            bgm_wait_play_tm--;
        }



        clear_change.run1();

        if (clear_change.clear_speed1 != 0)
        {
            if (clear_change.clear_value1 <= 0 || clear_change.clear_value1 >= 255)
            {
                clear_change.clear_speed1 = 0;
                if (clear_change.clear_value1 <= 0) { bgm_stop(); }
            }
            
            int num1 = s1.bgm_control1.now_play_number;
            int slot1 = s1.bgm_control1.now_play_slot;
            int vol1 = clear_change.clear_value1 * 100 / 255;

            if (slot1 >= 0)
            {
                s1.bgm1.change_sound_volume(s1.bgm_control1.loadcheck1(num1), (int)(s1.bgm_control1.volume1[slot1] * s1.bgm_vol * vol1 / 100 / 100));
            }

        //    s1.bgm1.change_sound_volume(bgm_data1[num1], (int)(volume1[num1] * s1.bgm_vol / 100));
        //    change_vol_so(bgm_box[bgm_ch_vol_slot], 100 * nnt * s1.bgm_vol / 100 / bgm_ch_vol_per_max);
        }

        //
        {
            
        }

    }

    public void draw1()
    {

    }
}
