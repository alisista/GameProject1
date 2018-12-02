using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DxLibDLL;


public class SoundEffect1 : SetVoid1
{
    public SoundEffect1(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

    }

    public SoundEffectData1 load_se(String name)
    {
        SoundEffectData1 sound_effect_data1 = new SoundEffectData1();

        int nt = DX.LoadSoundMem(name);
        sound_effect_data1.adress_set(nt);

        return sound_effect_data1;
    }

    public int play_se(SoundEffectData1 sound_effect_data1)
    {
        int sound1 = sound_effect_data1.call();
        int nt1 = 0;

        if (sound1 != -1)
        {
            nt1 = DX.PlaySoundMem(sound1, DX.DX_PLAYTYPE_BACK);
        }

        return nt1;
    }

    public int delete_se(SoundEffectData1 sound_effect_data1)
    {
        int sound1 = sound_effect_data1.call();
        int nt1 = -1;

        if (sound1 != -1)
        {
            nt1 = DX.DeleteSoundMem(sound1);
            sound_effect_data1.adress_delete1();
        }

        return nt1;
    }

    public int change_sound_volume(SoundEffectData1 sound,int per1)
    {
        return DX.ChangeVolumeSoundMem((int)(255.0f * per1 / 100), sound.call());
    }







    public void run1()
    {
    }

    public void draw1()
    {
    }


}
