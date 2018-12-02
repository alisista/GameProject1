using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EquipmentData : SetVoid1
{
    int row_move_num = 1;
    int row_move1() { return row_move_num; }

    public int ENCHANTMENT_NAME = 2;
    //    public int ENCHANTMENT_EXPLANATION_1 = 9;
    //    public int ENCHANTMENT_EXPLANATION_2 = 10;

    public int STATUS_ATTRIBUTE_1 = 10;
    public int STATUS_ATTRIBUTE_2 = 11;

    public int STATUS_MHP = 16;
    public int STATUS_MMP = 17;
    public int STATUS_ATK = 18;
    public int STATUS_INT = 19;


    public EquipmentData(Summary1 s1)
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

        {
            st1 = s1.csv_manager.call_str1(s1.csv_manager.EQUIPMENT_DATA, t1, column_length1);
        }

        return st1;
    }

    public int int_call(int type1, int column_length1)
    {
        int t1 = type1 + row_move1();
        int t2 = 0;

        {
            t2 = s1.csv_manager.call_int1(s1.csv_manager.EQUIPMENT_DATA, t1, column_length1);
        }

        return t2;
    }


    public String equipment_name(int type1) { return str_call(type1, ENCHANTMENT_NAME); }
//    public String enchantment_explanation1(int type1) { return str_call(type1, ENCHANTMENT_EXPLANATION_1); }
//    public String enchantment_explanation2(int type1) { return str_call(type1, ENCHANTMENT_EXPLANATION_2); }
}
