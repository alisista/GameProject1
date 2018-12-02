using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DxLibDLL;


public class BGM1 : SetVoid1
{
    public BGM1(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

    }


    

    //多分この関数は使わない
    /*
    public void play_bgm(BGMData1 bgm_data1)
    {
        if (bgm_data1.call() != -1)
        {
            DX.PlaySoundMem(bgm_data1.call(), DX.DX_PLAYTYPE_BACK);
        }
    }
    */


    public void play_loop_bgm(BGMData1 bgm_data1)
    {
        if (bgm_data1.call() != -1)
        {
            DX.PlaySoundMem(bgm_data1.call(), DX.DX_PLAYTYPE_LOOP, DX.TRUE);
        }
    }


    //BGMは全てイントロとループで再生するため、この関数の必要はない（けれど、一応残しておく）
    public BGMData1 load_bgm(String name)
    {
        BGMData1 bgm_data1 = new BGMData1();

        int nt = DX.LoadSoundMem(name);
        bgm_data1.adress_set(nt);

        return bgm_data1;
    }


    public BGMData1 load_bgm_intro_and_loop(String file_path1, String file_path2)
    {
        BGMData1 bgm_data1 = new BGMData1();

        streaming_play();

        {
            int nt = DX.LoadSoundMem2(file_path1, file_path2);
            bgm_data1.adress_set(nt);
        }

        streaming_play_re();

        return bgm_data1;
    }


    public int delete_bgm(BGMData1 bgm_data1)
    {
        //もし音楽が再生中なら一旦ストップしてから破棄
        {
            if (check_sound_mem(bgm_data1) == 1)
            {
                stop_sound(bgm_data1);
            }
        }


        int sound1 = bgm_data1.call();
        int nt1 = -1;

        if (sound1 != -1)
        {
            nt1 = DX.DeleteSoundMem(sound1);
            bgm_data1.adress_delete1();
        }

        return nt1;
    }

    public int change_sound_volume(BGMData1 bgm_data1, int per1)
    {
        return DX.ChangeVolumeSoundMem((int)(255.0f * per1 / 100), bgm_data1.call());
    }


    //ストリーミング再生に変更 streaming_play_reとセットで！
    public void streaming_play()
    {
        DX.SetCreateSoundDataType(DX.DX_SOUNDDATATYPE_FILE);
    }

    public void streaming_play_re()
    {
        DX.SetCreateSoundDataType(DX.DX_SOUNDDATATYPE_MEMNOPRESS);
    }

    //音楽が再生されているか、確認
    //１：再生中
    //０：再生されていない
    //－１：エラー発生
    public int check_sound_mem(BGMData1 bgm_data1)
    {
        int nt = 0;
        int sound1 = bgm_data1.call();

        nt = DX.CheckSoundMem(sound1);

        return nt;
    }

    public void stop_sound(BGMData1 bgm_data1)
    {
        int sound1 = bgm_data1.call();

        if (sound1 != -1)
        {
            DX.StopSoundMem(sound1);
        }
    }


    /*
    //未使用関数

    //再生しているBGMの時間をチェック 秒数*60を返す ?
    public int time_check_sample(int slot)
    {
        return DX.GetCurrentPositionSoundMem(bgm_box[slot]) / 1000;
    }


    


    //指定したサウンドハンドルの再生位置をミリ秒単位で取得する（圧縮形式に対しては不安定）
    public int get_sound_current_time(int slot)
    {
        return DX.GetSoundCurrentTime(bgm_box[slot]);
    }

    //指定したサウンドハンドルの音楽の総時間を取得する（ミリ秒単位）
    public int get_sound_total_time(int slot)
    {
        return DX.GetSoundTotalTime(bgm_box[slot]);
    }

    //再生位置を指定 ミリ秒
    public int set_sound_current_time(int slot,int time){
        return DX.SetSoundCurrentTime(time,bgm_box[slot]);
    }
    */
}
