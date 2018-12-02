using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class SaveDataControlSupport : SetVoid1
{
    //セーブの種類
    public int SAVE_BYTE = 0;
    public int SAVE_SHORT = 1;
    public int SAVE_INT = 2;
    public int SAVE_LONG = 3;
    public int SAVE_FLOAT = 4;
    public int SAVE_STRING_4 = 5;
    public int SAVE_STRING_8 = 6;


    public int savedata_num_set(int savedata_num_1) { return s1.save_data_control.savedata_num_set(savedata_num_1); }

    public int load_and_write_int(int var1, int byte_0__or__short_1__or__int_2) { return s1.save_data_control.load_and_write_int(var1, byte_0__or__short_1__or__int_2); }
    public long load_and_write_long(long var1) { return s1.save_data_control.load_and_write_long(var1); }


    public SaveDataControlSupport(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

    }

    public void slotdata_load_or_save()
    {
        //0 ~ 99 基本情報の保存
        {
            savedata_num_set(0);

            //0番目に100をセーブ 復元なし (セーブデータの存在を示す)
            load_and_write_int((100), SAVE_BYTE);


            savedata_num_set(10);

            //10,製品番号 初作なので「1」
            load_and_write_int((1), SAVE_SHORT);

            //12 ～ 13番目 ver情報
            s1.savedata_version_num = load_and_write_int((s1.version_num), SAVE_SHORT);


            savedata_num_set(20);

            //20 ～ 27 番目 セーブデータを作成した日時
            load_and_write_int((m1.time_stanp_1()), SAVE_INT);
            load_and_write_int((m1.time_stanp_2()), SAVE_INT);

        }

        //100 ~ AppVariable の値の保存情報
        {
            savedata_num_set(100);

            s1.app_variable1.coin_num = load_and_write_int(s1.app_variable1.coin_num_call(), SAVE_INT);// +4
        }

    }//slotdata_load_or_save()
}
