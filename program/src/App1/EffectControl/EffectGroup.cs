using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EffectGroup : EffectExtend
{
    static public int MAX_NUM = 256;

    public Effect1[] effect1 = new Effect1[MAX_NUM];
    public int max_num() { return MAX_NUM; }

    public EffectGroup(Summary1 s1)
    {
        set1(s1);

        for (int t = 0; t < max_num(); t++)
        {
            effect1[t] = new Effect1(s1, t);
        }
    }

    public void init1()
    {
        for (int t = 0; t < max_num(); t++)
        {
            effect1[t].init1();
        }
    }

    //存在数を教える
    public int active_num_check()
    {
        int c2 = 0;
        for (int t = 0; t < max_num(); t++)
        {
            if (s1.effect_group.effect1[t].on != 0)
            {
                c2++;
            }
        }

        return c2;
    }

    public int create(float x1, float y1, int type1, int type2, int type3,int type4, int auto_delete_tm, int free1)
    {
        int num = active_num_check();

        int t = 0, t2 = 0;
        if (num <= max_num() - 1)
        {
            for (t = 0; t < max_num(); t++)
            {
                t2 = t;

                //   if (back_flag == 1) t2 = MAX() - t - 1;


                if (effect1[t2].on == 0)
                {
                    effect1[t2].init1();
                    effect1[t2].on = 1;

                    //    ef[t2].dpreset();

                    effect1[t2].x1 = x1;
                    effect1[t2].y1 = y1;
                    effect1[t2].type1 = type1;
                    effect1[t2].type2 = type2;
                    effect1[t2].type3 = type3;
                    effect1[t2].auto_delete_tm = auto_delete_tm;

                    //    m.msbox();

                    effect1[t2].create();
                    //	m.end();
                    break;
                }
            }
        }


        /*
        if (back_flag != 0)
        {
            back_flag = 0;
            return t2;
        }
        */

        return t2;
    }



    public void all_delete()
    {
        for (int t = 0; t < max_num(); t++)
        {
            if (effect1[t].on != 0)
            {
                effect1[t].on = 0;
            }
        }
    }




    public void run1()
    {
    //    max_update();

        for (int t = 0; t < max_num(); t++)
        {
            if (effect1[t].on != 0)
            {
                effect1[t].run1();
            }
        }
    }

    /*
    public void run2()
    {
        for (int t = 0; t < MAX; t++)
        {
            if (ef[t].priority == 3)
                ef[t].run();
        }
    }*/


    public void draw1()
    {
        for (int t = 0; t < max_num(); t++)
        {
            if (effect1[t].on != 0)
            {
                effect1[t].draw1();
            }
        }
    }

    public void draw2(int priority)
    {
        /*
        if (priority <= 98)
        {
            for (int t = 0; t < max2(); t++)
            {
                if (effect[t].on != 0)
                {
                    if (effect[t].priority == priority)
                        effect[t].draw();
                }
            }
        }
        */

        /*
    else

    {
        for (int t = 0; t < max(); t++)
        {
            if (ef[t].on != 0)
            {
                ef[t].draw();
            }
        }
    }*/
    }
}
