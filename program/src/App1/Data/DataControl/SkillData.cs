using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SkillData : SetVoid1
{
    int row_move_num = 1;
    int row_move1() { return row_move_num; }

    public int SKILL_NAME = 2;

    public int NEED_POINT = 5;

    public int SKILL_EXPLANATION_1 = 9;
    public int SKILL_EXPLANATION_2 = 10;

    public SkillData(Summary1 s1)
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
            st1 = s1.csv_manager.call_str1(s1.csv_manager.SKILL_DATA, t1, column_length1);
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
            t2 = s1.csv_manager.call_int1(s1.csv_manager.SKILL_DATA, t1, column_length1);
        }

        return t2;
    }


    public String skill_name(int type1) { return str_call(type1, SKILL_NAME); }

    public int skill_use_need_point(int type1) { return int_call(type1, NEED_POINT); }

    public String skill_explanation1(int type1) { return str_call(type1, SKILL_EXPLANATION_1); }
    public String skill_explanation2(int type1) { return str_call(type1, SKILL_EXPLANATION_2); }
}
