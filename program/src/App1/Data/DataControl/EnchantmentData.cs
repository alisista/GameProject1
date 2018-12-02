using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EnchantmentData : SetVoid1
{
    int row_move_num = 1;
    int row_move1() { return row_move_num; }

    public int ENCHANTMENT_NAME = 2;
    public int ENCHANTMENT_EXPLANATION_1 = 9;
    public int ENCHANTMENT_EXPLANATION_2 = 10;

    public EnchantmentData(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        /*
        {
            String st8 = "";

            for (int t1 = 0; t1 < 7; t1++)
            {
                for (int t2 = 0; t2 < 10; t2++)
                {
                    st8 += s1.csv_manager.call_str1(s1.csv_manager.ENCHANTMENT_DATA, t1, t2) + ",";
                }

                st8 += "\n";
            }

        //    m1.msbox(st8);
        }
        */

        {
         //   String st8 = enchantment_explanation1(1);
         //   m1.msbox(st8);
        }
    }

    public String str_call(int type1, int column_length1)
    {
        int t1 = type1 + row_move1();
        String st1 = "";

        {
            st1 = s1.csv_manager.call_str1(s1.csv_manager.ENCHANTMENT_DATA, t1, column_length1);
        }

     //   m1.msbox(st1);

     //   m1.end();

        return st1;
    }

    public int int_call(int type1, int column_length1)
    {
        int t1 = type1 + row_move1();
        int t2 = 0;

        {
            t2 = s1.csv_manager.call_int1(s1.csv_manager.ENCHANTMENT_DATA, t1, column_length1);
        }

        return t2;
    }


    public String enchantment_name(int type1) { return str_call(type1, ENCHANTMENT_NAME); }
    public String enchantment_explanation1(int type1) { return str_call(type1, ENCHANTMENT_EXPLANATION_1); }
    public String enchantment_explanation2(int type1) { return str_call(type1, ENCHANTMENT_EXPLANATION_2); }
}
