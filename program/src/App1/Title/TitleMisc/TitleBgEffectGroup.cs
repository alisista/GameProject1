using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class TitleBgEffectGroup : SetVoid1
{
    public int max() { return 64; }
    TitleBgEffect[] title_bg_effect = new TitleBgEffect[64];

    public TitleBgEffectGroup(Summary1 s1)
    {
        set1(s1);

        for (int t1 = 0; t1 < max(); t1++)
        {
            title_bg_effect[t1] = new TitleBgEffect(s1);
        }
    }

    public void init1()
    {
        for (int t1 = 0; t1 < max(); t1++)
        {
            title_bg_effect[t1].init1();
        }

        effect_create();
    }

    public void effect_create()
    {
        int cx = s1.display_w_call() / 2;//240;
        int cy = s1.display_h_call() / 2;//400;
        int color_1 = 0;

        int create_num = 0;

        //    for (int t1 = 0; t1 < 32; t1++)
        for (int t1 = 0; t1 < 40; t1++)
        {
            if (create_num <= 32 * 32)//24 * 32)
            {
                create_num += effect_child_create(cx, cy, color_1);
            }
            else
            {
                break;
            }
        }
    }


    public int effect_child_create(int dx, int dy, int color_1)
    {
        int nt = 0;

        for (int t1 = 0; t1 < max(); t1++)
        {
            if (title_bg_effect[t1].on == 0)
            {
                nt = title_bg_effect[t1].create1(dx, dy, color_1);
                break;
            }
        }

        return nt;
    }

    public void run1()
    {
        for (int t1 = 0; t1 < max(); t1++)
        {
            if (title_bg_effect[t1].on != 0)
            {
                title_bg_effect[t1].run1();
            }
        }
    }//run()


    public void draw1()
    {
        for (int t1 = 0; t1 < max(); t1++)
        {
            if (title_bg_effect[t1].on != 0)
            {
                title_bg_effect[t1].draw1();
            }
        }
    }//draw()
}
