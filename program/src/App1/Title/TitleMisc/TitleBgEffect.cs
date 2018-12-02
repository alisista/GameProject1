using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class TitleBgEffect : SetVoid1
{
    public int on;

    public float x;
    public float y;

    public int color_type;

    public int tm;

    public int th_num;
    public int th_r;
    public float th_1;
    public float th_speed;
    public int clear1;

    public float large_1;
    public int large_div;

    public TitleBgEffect(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        on = 0;

        x = 0;
        y = 0;

        color_type = 0;

        tm = 0;

        th_num = 6;
        th_r = 30;
        th_1 = 0;
        th_speed = 0.3f;//0;
        large_1 = 0.64f;
        clear1 = 20;
    }

    public int create1(float dx, float dy, int free_1)
    {
        on = 1;

        x = dx;
        y = dy;

        //    color_type = color_1;

        //情報はランダム生成
        {
            th_1 = m1.rand(360);

            //半径
            th_r = 40 + m1.rand(510);//~440

            //生成個数
            th_num = 6 + m1.rand(24) + ((th_r - 60) / 60) * 4;

            //回転速度
            //           th_speed = m1.rand2_1() * (0.025f + m1.rand(0.10f));
            th_speed = m1.rand2_1() * (0.010f + m1.rand(0.05f));

            //カラー
            color_type = m1.rand(16 - 1);

            //大きさ
            large_1 = (0.24f + m1.rand(0.32f))*1.5f;//0.48f + m1.rand(0.32f);

            //透過度
            clear1 = 12 + m1.rand(12);

            large_div = (1200 + m1.rand(80) * 10) * 2 / 3 ;
        }

        return th_num;
    }

    public void run1()
    {
        th_1 += th_speed;

        tm++;
    }

    public void draw1()
    {
    //    if (tm >= 1)
        {
            for (float t3 = 0; t3 < 360 - 2; t3 += (360 / th_num))//free[3])
            //    for (int t3 = 0; t3 < 360; t3 += 60)
            {
                float r1 = th_r;
                float th1 = t3 + th_1;

                float x9 = x + m1.cos_r(r1, th1);
                float y9 = y - m1.sin_r(r1, th1);

                int x8 = (int)(x9);
                int y8 = (int)(y9);

                int ntt = 50;//50;
                             //    if (x8 >= 0 - ntt && x8 <= s.dw + ntt && y8 >= 0 - ntt && y8 <= s.dh + ntt)

                int nnp = 60;

                float large_2 = large_1 + 1.0f * r1 / large_div;//1600;

                if (m1.rect_decision(x8, y8, 0 - ntt, 0 - ntt, 960 + ntt * 2, 540 + ntt * 2) == 1)
                    if (m1.circle_decision(x8, y8, 1, 960/2, 540/2, 600) == 1)
                    {
                        if (y8 <= 700 + nnp)
                        {
                            //    m.end();
                            g1.setClear2(clear1);
                            g1.drawImage(ic1.loadcheck(8, 18, color_type), x8, y8, large_2, -th1 + 90);
                            g1.setClear2_re();
                            //    g.drawImage(s.storylogo.imb[0].call(1), x8, y8, 0.32f, -(freef[0] + t3) + 90);
                        }
                    }
            }
        }
    }//draw()
}
