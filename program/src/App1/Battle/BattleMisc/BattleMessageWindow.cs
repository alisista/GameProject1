using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//上部にメッセージを表示するクラス
public class BattleMessageWindow : SetVoid1
{
    static int MAX1 = 16;
    public int max1() { return MAX1; }
    String[] mes_box = new String[MAX1];

    public int draw_num;
    public int draw_wait;
    public int draw_wait_first_memo;
    public int draw_wait_set_num;
    
    public int draw_wait_max() { return 30; }
    public int draw_wait_max2() { return 180; }//最後のメッセージの場合


    public BattleMessageWindow(Summary1 s1)
    {
        set1(s1);
    }

    
    public void init1()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
            mes_box[t1] = "";
        }

        draw_wait = -1;
        draw_num = 0;
        draw_wait_first_memo = -1;
        draw_wait_set_num = 0;
    }


    public void message_stock(String mes) { message_receive(mes); }    

    public void message_receive(String mes)
    {
        draw_num++;

        if (draw_num > max1()) draw_num = (max1() - 1);

        mes_box[draw_num] = mes;


        draw_wait = draw_wait_first_memo;

        /*
        if (draw_wait_first_memo < 0)
        {
            draw_wait = -1;
        }
        */

        /*
        if (draw_wait > draw_wait_max()) { 
            draw_wait = draw_wait_max(); 
        }
        else
        {
            if (draw_wait_first_memo >= 0)
            {
                draw_wait = draw_wait_first_memo;
            }
        }
        */
    }

    public int message_end_check()
    {
        int nt = 0;

        if (draw_num <= 0 && draw_wait < 0)
        {
            nt = 1;
        }

        return nt;
    }

    public int message_draw_end_check()
    {
        int nt = 0;

        if (draw_num <= 0 && draw_wait_first_memo < 0)
        {
            nt = 1;
        }

        return nt;
    }


    public void message_clear()
    {
        init1();
    }

    public void draw_wait_set(int wait_time)
    {
        draw_wait_set_num = wait_time;
    }

    public void run1()
    {

        if (draw_wait < 0)
        {
            //メッセージを次へ
            if (draw_num >= 1)
            {
                mes_box[max1() - 1] = "";

                for (int t1 = 0; t1 < max1() - 1; t1++)
                {
                    mes_box[t1] = mes_box[t1 + 1];
                }

                if (draw_num == 1)
                {
                    draw_wait = draw_wait_max2();
                    draw_wait_first_memo = draw_wait_max();
                }

                if (draw_num > 1)
                {
                    draw_wait = draw_wait_max();
                    draw_wait_first_memo = draw_wait_max();
                }

                if (draw_wait_set_num >= 1)
                {
                    draw_wait = draw_wait_set_num;
                    draw_wait_set_num = 0;
                }

                draw_num--;
            }
            else
            {
                //メッセージが空の場合
                {

                }
            }
        }


        if (draw_wait >= 0)
        {
            draw_wait--;
        }

        if (draw_wait_first_memo >= 0)
        {
            draw_wait_first_memo--;
        }
    }

    public void draw1()
    {
        int draw_flag = 1;

        if (message_end_check() == 1)
        {
            draw_flag = 0;
        }

        if (draw_flag == 1)
        {
            String now_draw_mes = mes_box[0];

       //     g1.sc(255);
       //     g1.str2(now_draw_mes, 48, 48);

            if (m1.strlength(now_draw_mes) >= 1)
            {
                int y2 = 32;

                //    g1.setfont(g1.FONT_1_MIDDLE_STR);

                g1.setfont(g1.FONT_1_MAIN_STR);

                int w3 = (int)(g1.font_w_size_call() * m1.strbyte(now_draw_mes) / 2) + 48;
            //    w3 = m1.iover(w3, 0, 640);

                s1.dm1.boxdraw3(0 + (720 - w3) / 2, y2 + 8, w3, 36, 0, 1);

                g1.str2_center("" + now_draw_mes, (720) / 2, y2 + 13, g1.font_w_size_call());
                                   
                g1.setfont_re();
            }
        }
        else
        {
            mes_box[0] = "";
        }
    }
}
