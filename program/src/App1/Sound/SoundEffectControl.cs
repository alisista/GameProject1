using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//効果音のメモリ管理
//スロットは８０まで。それ以上ロードすると、何かしらの音データが解放される
public class SoundEffectControl : SetVoid1
{
    static int MAX1 = 80;
    public SoundEffectData1[] sound_effect_data1 = new SoundEffectData1[MAX1];

    public int[] load_type1 = new int[MAX1];
    public int[] volume1 = new int[MAX1];


    public SoundEffectControl(Summary1 s1)
    {
        set1(s1);

        for (int t = 0; t < MAX1; t++)
        {
            sound_effect_data1[t] = new SoundEffectData1();
        }
    }

    public void init1()
    {
        release_data();
    }

    public void release_data()
    {
        for (int t1 = 0; t1 < MAX1; t1++)
        {
            s1.sound_effect1.delete_se(sound_effect_data1[t1]);
            load_type1[t1] = 0;
            volume1[t1] = 0;
        }
    }

    public void all_volume_update()
    {
        for (int t1 = 0; t1 < MAX1; t1++)
        {
            s1.sound_effect1.change_sound_volume(sound_effect_data1[t1], (int)(volume1[t1] * s1.se_vol / 100));
        }
    }


    //要求された音データを持っている場合は、登録番号を返す　持っていない場合はロード
    public int sound_load_part1(int type1)
    {
        int slot1 = -1;

        if (type1 >= 1)
        {
            for (int t = 0; t < MAX1; t++)
            {
                if (type1 == load_type1[t])
                {
                    slot1 = t;
                    break;
                }
            }
            
            if (slot1 == -1)
            {
                //空いている領域を探して、発見したらそのスロットにデータを入れる
                for (int t = 0; t < MAX1; t++)
                {
                    if (load_type1[t] == 0)
                    {
                        slot1 = t;
                        break;
                    }

                    //全部埋まっていた場合は、メモリの全開放
                    if (t == MAX1 - 1)
                    {
                        init1();

                        slot1 = 0;
                    }
                }
                

                if (load_type1[slot1] == 0)
                {
                    load_type1[slot1] = type1;

                    {
                        String st, st1, st2;

                        int num1 = slot1;

                        {
                            st = s1.gamedata_directry() + "sedata/";
                            st1 = "";
                            st2 = "";

                            int vol1 = 100;

                            //    st2 = "enemy1/m" + (m1.add_space_str2("" + (type1), 4, 1, "0")) + ".png";

                            {
                                if (type1 == s1.sound_effect_operation.SE_BATTLE_ATTACK_1) { st2 = "mattimakers/battle/attack/" + "attack1" + ".wav"; vol1 = 100; }
                                if (type1 == s1.sound_effect_operation.SE_BATTLE_ATTACK_2) { st2 = "mattimakers/battle/attack/" + "attack2" + ".wav"; vol1 = 100; }
                                if (type1 == s1.sound_effect_operation.SE_BATTLE_ATTACK_3) { st2 = "mattimakers/battle/attack/" + "attack3" + ".wav"; vol1 = 100; }
                            }

                            if ((int)(m1.strlength(st2)) >= 1)
                            {
                                if (m1.file_check(st + st1 + st2) == 1)
                                {
                                    sound_effect_data1[num1] = s1.sound_effect1.load_se(st + st1 + st2);

                                    volume1[num1] = vol1;

                                    s1.sound_effect1.change_sound_volume(sound_effect_data1[num1], (int)(volume1[num1] * s1.se_vol / 100));
                                }
                            }
                        }
                    }
                }
            }
        }


        if (slot1 <= -1)
        {
            slot1 = 0;
        }

        return slot1;
    }


    public SoundEffectData1 loadcheck1(int type1)
    {
        int num1 = sound_load_part1(type1);
        return sound_effect_data1[num1];
    }
}
