using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//値がフレームごとに変化する時の手助けを行うクラス
public class ValueChange : SetVoid1
{
    public float value1;
    public float value1_change;
    public int value1_change_wait_max() { return 40; }

    public ValueChange(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        value1 = 0;
        value1_change = 0;
    }

    public int call_value1() { return (int)value1; }

    public void value1_add(int set_value1)
    {
        value1_add(set_value1, -99999999, 99999999);
    }

    public void value1_add(int set_value1,int min1,int max1)
    {
        value1 += set_value1;
        value1 = m1.iover(value1, min1, max1);
        value1_change = m1.abs((value1 / value1_change_wait_max())) + 1;
    }

    public void run1()
    {
        if (value1 > 0.01f)
        {
            value1 -= value1_change;
            if (value1 <= 0.01f)
            {
                value1 = 0;
                value1_change = 0;
            }
        }

        if (value1 < -0.01f)
        {
            value1 += value1_change;
            if (value1 >= 0.01f)
            {
                value1 = 0;
                value1_change = 0;
            }
        }
    }//run1()

    public void draw1()
    {
    }
}
