using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//透過の度合いを設定するクラス
public class ClearChange : SetVoid1
{
    public int clear_value1;
//    public int clear_up_down;
    public int clear_speed1;

    public ClearChange(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        clear_value1 = 255;
        //    clear_up_down = 0;
        clear_speed1 = 0;//-8;
    }

    public void change_set(int clear_value1, int clear_speed1)
    {
        if (clear_value1 >= 0) this.clear_value1 = clear_value1;
        this.clear_speed1 = clear_speed1;
    }

    public void clear_call()
    {
        g1.setClear2(clear_value1);
    }

    public void clear_call_re()
    {
        g1.setClear2_re();
    }


    public void run1()
    {
        if (clear_speed1 != 0)
        {
            int np = clear_speed1;

            clear_value1 += clear_speed1;
            clear_value1 = m1.iover(clear_value1, 0, 255);
            if (clear_value1 <= 0 || clear_value1 >= 255) { clear_speed1 = 0; }
        }
    }

    public void draw1()
    {
    }
}
