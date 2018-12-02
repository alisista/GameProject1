using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//音楽の操作管理クラス
public class SoundEffectOperation : SoundEffectNameExtend
{
    public SoundEffectOperation(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

    }


    public void play_se(int num1)
    {
    //    if (s1.bgm_on != 0)
        {
            s1.sound_effect1.play_se(s1.sound_effect_control1.loadcheck1(num1));
        }
    }

    public void sound_effect_volume_update()
    {
        s1.sound_effect_control1.all_volume_update();
    }

    /*
    public void se_play(int num1)
    {
        SoundData1 num

        //   m.msbox(3);

        /*
        if (num >= 0 && num <= se_max - 1)
        {
            if (se_box_wait[num] < 0)
            {
                se_box_flag[num] = 1;

                //    m.msbox(2);

                //ナンバーのファイルが用意されていなかった場合、その場でロード
                if (sound_load_ok[num] == 0)
                {
                    se_load(num);
                }
            }
        }
    }
    */



    public void run1()
    {
    }

    public void draw1()
    {
    }
}
