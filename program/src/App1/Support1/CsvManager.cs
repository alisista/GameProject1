using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//CSVの直接管理　他クラスから呼び出したい場合は、このクラスを利用する
public class CsvManager : SetVoid1
{
    //csvの個数最大値
    static int MAX1 = 64;
    public int max1() { return MAX1; }

    public CsvData[] csv_data = new CsvData[MAX1];

    public String[] filename = new String[MAX1];

    //columnは自動で読み込みをすることができないため、先に最大サイズを設定しておく
    //テキストオーバーの範囲を指定しても問題なし
    int[] column_length = new int[MAX1];


    //2~63。配列番号に連結している
    public int TEST_CSV = 1;

    public int CHARACTER_DATA = 21;
    public int EQUIPMENT_DATA = 22;
    public int ENCHANTMENT_DATA = 23;
    public int SKILL_DATA = 24;
    public int ENEMY_DATA = 25;

    public int DUNGEON_DATA = 32;


    public int error_memo;

    public CsvManager(Summary1 s1)
    {
        set1(s1);

        for (int t1 = 0; t1 < max1(); t1++)
        {
            //    csv_data[t1] = new CsvData(s1);

            filename[t1] = "";
            column_length[t1] = 0;
        }
    }

    public void init1()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
        //    csv_data[t1].init1();
        }

        init1_setting();
    }

    public void init1_setting()
    {
        int main_column_length = 32;

        data_set(TEST_CSV, "TestCsv.csv", main_column_length);

        data_set(CHARACTER_DATA, "Character1.csv", 48);
        data_set(EQUIPMENT_DATA, "Equipment1.csv", 48); 
        data_set(ENCHANTMENT_DATA, "Enchantment.csv", main_column_length);
        data_set(SKILL_DATA, "Skill.csv", main_column_length);
        data_set(ENEMY_DATA, "Enemy.csv", main_column_length);


        data_set(DUNGEON_DATA, "Dungeon1.csv", 70);
    }

    public void data_set(int num1, String filename1, int column_length1)//, int length1)
    {
        filename[num1] = filename1;
        column_length[num1] = column_length1;
    }

    public int load_check(int num1)
    {
        int nt = 0;

        if (csv_data[num1] == null)
        {
            csv_data[num1] = new CsvData(s1, num1);
            csv_data[num1].init1();
        }

        if (csv_data[num1].load_flag == 0)
        {
            csv_data[num1].filename = filename[num1];
            csv_data[num1].column_length1 = column_length[num1];

        //    m1.msbox(csv_data[num1].filename);
        }

        csv_data[num1].load_check();

        return nt;
    }//load_check


    public int call_int1(int num1, int row1, int column1)
    {
        int nt1 = 0;

        load_check(num1);

        nt1 = csv_data[num1].call_int(row1, column1);

        return nt1;
    }


    public String call_str1(int num1, int row1,int column1)
    {
        String str1 = "";

        load_check(num1);

        str1 = csv_data[num1].call_str(row1, column1);

        return str1;
    }


    public String call_line(int num1, int row1)
    {
        String str1 = "";

        load_check(num1);

        for (int t1 = 0; t1 < csv_data[num1].column_length1; t1++)
        {
            str1 += csv_data[num1].call_str(row1, t1);
        }

        return str1;
    }


    public void run1()
    {
    }

    public void draw1()
    {
    }
}
