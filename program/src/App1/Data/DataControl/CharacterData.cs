using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CharacterData : SetVoid1
{
    int row_move1() { return 1; }

    public int CHARACTER_NAME = 2;

    public int STATUS_ATTRIBUTE_1 = 10;
    public int STATUS_ATTRIBUTE_2 = 11;

    public int STATUS_MHP = 16;
    public int STATUS_MMP = 17;
    public int STATUS_ATK = 18;
    public int STATUS_INT = 19;

    public int STATUS_TEC = 21;


    public CharacterData(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
    }


    public String str_call(int type1, int column_length1)
    {
        int t1 = type1 + row_move1();
        String st1 = "";

        st1 = s1.csv_manager.call_str1(s1.csv_manager.CHARACTER_DATA, t1, column_length1);

        return st1;
    }

    public int status_call(int type1, int column_length1)
    {
        int t1 = type1 + row_move1();
        int t2 = 0;

        {
            t2 = s1.csv_manager.call_int1(s1.csv_manager.CHARACTER_DATA, t1, column_length1);
        }

        return t2;
    }

    public String character_name(int type1) { return str_call(type1, CHARACTER_NAME); }
}
