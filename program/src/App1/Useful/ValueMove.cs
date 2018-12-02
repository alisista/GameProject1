using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ValueMove : SetVoid1
{
    //ダメージ表示のカウント 連続でダメージを受けると上に行く
    public int value_count_draw;
    public int value_count_reset_wait;
    public float value_count_draw_y;

    public ValueMove(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        value_count_draw = 0;
        value_count_draw_y = 0;
        value_count_reset_wait = -1;

    //    value_wait_time = -1;
    //    value_wait_time_max = 30;
    }

    public void value_count_draw_y_add(float f1)
    {
        value_count_draw_y += f1;

        //高く登っていくカウントの計算
        {
            value_count_draw++;

            if (value_count_reset_wait <= -1)
            {
                value_count_reset_wait = 60;
            }
            else
            {
                value_count_reset_wait += 20;

                if (value_count_reset_wait > 60) value_count_reset_wait = 60;
            }
        }
    }

    public float call_y() { return value_count_draw_y; }

    public void run1()
    {
        //ダメージ動作と表示 タイマー
        {
            //            if (damage_wait >= 0)
            //          {
            //            damage_wait--;
            //      }

            if (value_count_reset_wait >= 0)
            {
                if (value_count_reset_wait == 0)
                {
                    value_count_draw = 0;
                    value_count_draw_y = 0;
                }

                value_count_reset_wait--;
            }
        }
    }

    public void draw1()
    {
    }
}
