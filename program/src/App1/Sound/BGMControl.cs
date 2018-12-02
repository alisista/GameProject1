using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//BGMの制御関数とメモリ管理
public class BGMControl : SetVoid1
{
    static int MAX1 = 1;
    public BGMData1[] bgm_data1 = new BGMData1[MAX1];

    public int[] load_type1 = new int[MAX1];
    public int[] volume1 = new int[MAX1];

    public BGMNameExtend name;


    public int now_play_number;
    public int now_play_slot;


    public BGMControl(Summary1 s1)
    {
        set1(s1);

        for (int t = 0; t < MAX1; t++)
        {
            bgm_data1[t] = new BGMData1();
        }

        name = new BGMNameExtend();
    }

    public void init1()
    {
        release_data();
    }

    public void release_data()
    {
        now_play_number = -1;
        now_play_slot = -1;

        for (int t1 = 0; t1 < MAX1; t1++)
        {
            s1.bgm1.delete_bgm(bgm_data1[t1]);
            load_type1[t1] = 0;
            volume1[t1] = 0;
        }
    }
    

    public void all_stop()
    {
        for (int t1 = 0; t1 < MAX1; t1++)
        {
            s1.bgm1.stop_sound(bgm_data1[t1]);
        }
    }

    public void all_volume_update()
    {
        for (int t1 = 0; t1 < MAX1; t1++)
        {
            s1.bgm1.change_sound_volume(bgm_data1[t1], (int)(volume1[t1] * s1.bgm_vol / 100));
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
                        String st, st1, st2, st3;

                        int num1 = slot1;

                        {
                            st = s1.gamedata_directry() + "bgm/";
                            st1 = "";

                            st2 = ""; st3 = "";

                            int vol1 = 100;

                            //    st2 = "enemy1/m" + (m1.add_space_str2("" + (type1), 4, 1, "0")) + ".png";

                            {
                                if (type1 == name.BGM_TITLE_1) { st2 = "title01i" + ".ogg"; st3 = "title01l" + ".ogg"; vol1 = 100; }
                                if (type1 == name.BGM_BASE_1) { st2 = "base01i" + ".ogg"; st3 = "base01l" + ".ogg"; vol1 = 100; }
                                if (type1 == name.BGM_STAGE_SELECT) { st2 = "base02i" + ".ogg"; st3 = "base02l" + ".ogg"; vol1 = 100; }
                                if (type1 == name.BGM_SHOP) { st2 = "base03i" + ".ogg"; st3 = "base03l" + ".ogg"; vol1 = 100; }
                                

                                if (type1 == name.BGM_BATTLE_1) { st2 = "battle01i" + ".ogg"; st3 = "battle01l" + ".ogg"; vol1 = 100; }
                                if (type1 == name.BGM_BATTLE_2) { st2 = "battle02i" + ".ogg"; st3 = "battle02l" + ".ogg"; vol1 = 100; }

                            }

                            if ((int)(m1.strlength(st2)) >= 1)
                            {
                                if (m1.file_check(st + st1 + st2) == 1)
                                {
                                    bgm_data1[num1] = s1.bgm1.load_bgm_intro_and_loop(st + st1 + st2, st + st1 + st3);

                                    now_play_slot = slot1;
                                    now_play_number = type1;

                                    volume1[num1] = vol1;

                                    s1.bgm1.change_sound_volume(bgm_data1[num1], (int)(volume1[num1] * s1.bgm_vol / 100));                                    
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


    public BGMData1 loadcheck1(int type1)
    {
        int num1 = sound_load_part1(type1);
        return bgm_data1[num1];
    }
}
