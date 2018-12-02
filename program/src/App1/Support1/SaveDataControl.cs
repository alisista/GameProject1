using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO;


public class SaveDataControl : SetVoid1
{
    public SaveDataControlSupport save_data_control_support;

    //通常セーブデータ 256 KB  HDD は 30MB/s  フラッシュは 3%
    static int mainslotdata_max1 = 1024 * 256;//262144  //512;//524288;//128kb
    public int max1() { return mainslotdata_max1; }
    public byte[] savedata_box = new byte[mainslotdata_max1];

    //キャラ領域
    //8000*64 

    public int load_0__or__save_1;

    //現在のセーブ領域の位置
    public int savedata_num;

    //セーブの種類
    public int SAVE_BYTE = 0;
    public int SAVE_SHORT = 1;
    public int SAVE_INT = 2;
    public int SAVE_LONG = 3;
    public int SAVE_FLOAT = 4;
    public int SAVE_STRING_4 = 5;
    public int SAVE_STRING_8 = 6;
    


    public SaveDataControl(Summary1 s1)
    {
        set1(s1);

        save_data_control_support = new SaveDataControlSupport(s1);
    }

    public void init1()
    {
        save_data_control_support.init1();

        for (int t = 0; t < max1(); t++)
        {
            savedata_box[t] = 0;
        }

        load_0__or__save_1 = 0;


        if (s1.savedata_loadflag == 1)
        {
            file_load();
        }
    }

    public int load_0__or__save_1_check() { return load_0__or__save_1; }
    

    public int slotdata_load_or_save()
    {
        int nt = 1;

        save_data_control_support.slotdata_load_or_save();

        return nt;
    }

    public String savedata_file_name() { return "systemdata/savedata/" + "magipla_savedata1.dat"; }
    public String backup_savedata_file_name(String version_name) { return "systemdata/savedata/backup/" + "magipla_savedata1_"+ (version_name) +".dat"; }

    public void file_save()
    {
        file_save2();
    }


    public void file_load()
    {
        file_load2();

        if (s1.version_num > s1.savedata_version_num)
        {
            int save_flag = 0;

            try
            {
                //    File.WriteAllBytes(savedata_file_name(), savedata_box);

                File.Copy(savedata_file_name(), backup_savedata_file_name(s1.save_version_name()), true);

                //    save_flag = 1;
            }
            catch (Exception e)
            {
                m1.msbox("エラー：ファイルのバックアップができません\n " + e);
                m1.end();
            }

        //    if (save_flag == 1)
        //    {
        //        file_save2();
        //    }
        }
    }


    public void file_save2()
    {
        //savedata_boxに、必要な変数を書き込み
        load_0__or__save_1 = 1;
        slotdata_load_or_save();

        {
            try
            {
                //    File.WriteAllBytes("system/savedata.dat", slotdata_box);
                //File.WriteAllBytes(s.system_pass() + "system.dat", savedata_box);

                //    save_data_all_sum();

                //      m.msbox("saveA:" + save_data_all_sum());
                File.WriteAllBytes(savedata_file_name(), savedata_box);
                //    m.msbox("saveB:" + save_data_all_sum());

                //    save_data_all_sum();
            }
            catch (Exception e)
            {
                m1.msbox("エラー：ファイルの保存ができません\n " + e);
                m1.end();
            }
        }
    }

    public void file_load2()
    {
        load_0__or__save_1 = 0;
        
        try
        {
            savedata_box = File.ReadAllBytes(savedata_file_name());
        }
        catch (Exception e)
        {
            //ファイルが存在しない場合は生成
            if (m1.file_check(savedata_file_name()) == 0)
            {
                if (s1.debug_on() == 1)
                {
                    m1.msbox("新規データの作成！");
                }

                s1.am1.first_savedata_create();
            }
            else
            {
                m1.msbox("エラー：ファイルの読み込みができません\n " + e);
                m1.end();
            }
        }
        
        //savedata_box
        slotdata_load_or_save();
    }


    //byte,short,int型のセーブ
    public int load_and_write_int(int data1, int byte_0__or__short_1__or__int_2)
    {
     //   data1 += 1;

        //byte
        if (byte_0__or__short_1__or__int_2 == 0)
        {
            if (load_0__or__save_1_check() == 0)
            {
                data1 = (int)savedata_box[savedata_num];

                savedata_num += 1;
            }

            if (load_0__or__save_1_check() == 1)
            {
                savedata_box[savedata_num] = (byte)(data1);

                savedata_num += 1;
            }
        }

        //short
        if (byte_0__or__short_1__or__int_2 == 1)
        {
            if (load_0__or__save_1_check() == 0)
            {
                data1 =
                    (savedata_box[savedata_num + 0] << 8)
                  + (savedata_box[savedata_num + 1]);

                savedata_num += 2;
            }

            if (load_0__or__save_1_check() == 1)
            {
                savedata_box[savedata_num + 0] = (byte)(data1 >> 8);
                savedata_box[savedata_num + 1] = (byte)(data1);

                savedata_num += 2;
            }
            
        //    for (int t1 = 0; t1 < 2; t1++)
        //    {
        //        if (savedata[savedata_num+t1] >= 2)
        //        s.save_protect_num += (byte)(savedata[savedata_num + t1]);
        //    }
        }

        //int
        if (byte_0__or__short_1__or__int_2 == 2)
        {
            if (load_0__or__save_1_check() == 0)
            {
                data1 =
                    (savedata_box[savedata_num + 0] << 24)
                  + (savedata_box[savedata_num + 1] << 16)
                  + (savedata_box[savedata_num + 2] << 8)
                  + (savedata_box[savedata_num + 3]);

                savedata_num += 4;
            }

            if (load_0__or__save_1_check() == 1)
            {
                savedata_box[savedata_num + 0] = (byte)(data1 >> 24);
                savedata_box[savedata_num + 1] = (byte)(data1 >> 16);
                savedata_box[savedata_num + 2] = (byte)(data1 >> 8);
                savedata_box[savedata_num + 3] = (byte)(data1);

                savedata_num += 4;
            }

            
        //    for (int t1 = 0; t1 < 4; t1++)
        //    {
        //        if (savedata[savedata_num + t1] >= 2)
        //        s.save_protect_num += (byte)(savedata[savedata_num + t1]);
        //    }
        }

     //   data1 -= 1;

        return data1;
    }

    public long load_and_write_long(long data1)
    {
     //   data1 += 1;

        //long
        {
            if (load_0__or__save_1_check() == 0)
            {
                data1 =
                    (savedata_box[savedata_num + 0] << 56)
                  + (savedata_box[savedata_num + 1] << 48)
                  + (savedata_box[savedata_num + 2] << 40)
                  + (savedata_box[savedata_num + 3] << 32)
                  + (savedata_box[savedata_num + 4] << 24)
                  + (savedata_box[savedata_num + 5] << 16)
                  + (savedata_box[savedata_num + 6] << 8)
                  + (savedata_box[savedata_num + 7]);

                savedata_num += 8;
            }

            if (load_0__or__save_1_check() == 1)
            {
                savedata_box[savedata_num + 0] = (byte)(data1 >> 56);
                savedata_box[savedata_num + 1] = (byte)(data1 >> 48);
                savedata_box[savedata_num + 2] = (byte)(data1 >> 40);
                savedata_box[savedata_num + 3] = (byte)(data1 >> 32);
                savedata_box[savedata_num + 4] = (byte)(data1 >> 24);
                savedata_box[savedata_num + 5] = (byte)(data1 >> 16);
                savedata_box[savedata_num + 6] = (byte)(data1 >> 8);
                savedata_box[savedata_num + 7] = (byte)(data1);

                savedata_num += 8;
            }
            
       //     for (int t1 = 0; t1 < 8; t1++)
       //     {
       //         if (savedata[savedata_num + t1] >= 2)
       //         s.save_protect_num += (byte)(savedata[savedata_num + t1]);
       //     }
        }

     //   data1 -= 1;

        return data1;
    }




    public int savedata_num_set(int savedata_num_1)
    {
        savedata_num = savedata_num_1;
        return savedata_num_1;
    }

    //文字列の保存 save_byte_length +1 の領域を使用 (先頭にbyte数を保存しているため)
    public String load_and_write_string(String data1, int save_byte_length)
    {
        if (load_0__or__save_1_check() == 0)
        {
            int max = (int)savedata_box[savedata_num];
            savedata_num++;
            byte[] byteArray = new byte[max];
            for (int t3 = 0; t3 < save_byte_length; t3++)
            {
                if (t3 < max)
                    byteArray[t3] = savedata_box[savedata_num];

                savedata_num++;
            }

            data1 = m1.encoding_getstring(byteArray);
        }

        if (load_0__or__save_1_check() == 1)
        {
            int nt = m1.strbyte(data1);
            savedata_box[savedata_num] = (byte)(nt);
            if (savedata_box[savedata_num] > save_byte_length) savedata_box[savedata_num] = (byte)save_byte_length;
            savedata_num++;

            byte[] byteArray = m1.encoding_getbyte(data1);

            for (int t3 = 0; t3 < save_byte_length; t3++)
            {
                if (t3 < nt)
                {
                    savedata_box[savedata_num] = byteArray[t3];
                }
                else
                {
                    savedata_box[savedata_num] = 0;
                }

                savedata_num++;
            }
        }

        return data1;
    }
}
