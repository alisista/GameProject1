using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ShakeMove : SetVoid1
{
    public int shake_time1;
    public int shake_time1_max;

    public float x1;
    public float y1;

    public ShakeMove(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        shake_time1 = -1;
        shake_time1_max = 30;

        x1 = 0;
        y1 = 0;
    }

    public float call_move_x() { return x1; }
    public float call_move_y() { return y1; }

    public void shake_set(int shake_time1,int shake_power)
    {
        if (shake_time1 == 1) shake_time1 = 30;

        this.shake_time1 = shake_time1;
        shake_time1_max = shake_time1;
    }

    public void run1()
    {
        //ダメージ動作
        if (shake_time1 >= 10 && shake_time1 <= 30)
        {
            int n1 = (20 - m1.abs(shake_time1 - 25)) * 1 / 2;
            x1 = m1.rand2(n1) * 3 / 4;
            y1 = m1.rand2(n1) * 3 / 4;
        }

        if (shake_time1 >= 0)
        {
            shake_time1--;
        }
    }

    public void draw1()
    {
    }
}
