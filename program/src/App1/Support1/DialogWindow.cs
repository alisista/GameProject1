using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DialogWindow : DialogWindowExtend
{
    //1-ok 2-yesno 3-Yes1 yes2 No
    public int main_type = 0;

    DialogWindowSupport dialog_box_support;

    public int on;
    public int type1;
    public int type2;

    public float x1;
    public float y1;
    public int w1;
    public int h1;

    public int area_x1;
    public int area_y1;
    public int area_w1;
    public int area_h1;

    public int need_coin;

    public int area_out_close;

    public String yes1_name;
    public String yes2_name;
    public String no_name;


    int title_h() { return 68; }//72; }
    int explanation_h() { return 34; }
    int under_button_h() { return 90; }

    //通常フォントなら、25が適切
    // public int explantion_font_size_x1() { return 25; }

    //public int explantion_font_size_x2() { return 25; }

    //public int explantion_font_size_x2() { return 21; }

    //public int explantion_font_size_x2() { return 19; }//21; }

    public float explantion_font_size_x1() { return g1.font_w_size_call(g1.FONT_1_MAIN_STR); }
    public float explantion_font_size_x2() { return g1.font_w_size_call(g1.FONT_1_MIDDLE_STR); }

    public String title_name;
    public String[] explanation1 = { "", "", "", "", "", "", "", "", "", "" };

    public int explantion_num_max() { return 8; }

    public int on_check() { return on; }

    
    public DialogWindow(Summary1 s1)
    {
        set1(s1);

        dialog_box_support = new DialogWindowSupport(s1);
    }

    public void init1()
    {
        main_type = 0;
        on = 0;
        type1 = 0;
        type2 = 0;

        title_name = "";

        for (int t1 = 0; t1 < explantion_num_max(); t1++)
        {
            explanation1[t1] = "";
        }

        //テスト
        {
            title_name = "テストダイアログ１";

          //  explanation[0] = "１２３４５６７８９０１２３４５６７８９０１２３４５６７";

            
            for (int t1 = 0; t1 < 7; t1++)
            {
                explanation1[t1] = "１２３";
            }

            explanation1[1] = "朱と蒼タイプのＨＰを５０００回復。ステータスを１．５倍";

            explanation1[3] = " ";



            //    s1.dialog_window1.create1(s1.dialog_window1.TEST_WINDOW1, 0, 2, 0);

        //    s1.dialog_window1.create1(s1.dialog_window1.DIALOG_GAMEOVER_CONTINUE, 0, 0, 0);
        }


    }

    //メニューのリセット
    public void reset1()
    {
        /*
        x1 = 100;
        y1 = 100;
        w1 = 200;
        h1 = 200;
        */

        {
            y1 = 100;
            w1 = 200;
            h1 = 300;
        }

        {
            area_x1 = 0;
            area_y1 = 0;
            area_w1 = 720;
            area_h1 = 540;
        }
        
        //w1とh1は、文字数や配置場所によって自動で決まる
        {



            //文字の長さに応じて、w変更
            {
                int max_length = 0;
                for (int t1 = 0; t1 < explantion_num_max(); t1++)
                {
                    int nt1 = m1.strbyte(explanation1[t1]);
                    if (max_length < nt1)
                    {
                        max_length = nt1;
                    }
                }

                //   m.msbox(max_length);

                w1 = max_length * (int)explantion_font_size_x2() / 2 + 24 * 1;

                int w1_max = 360;
                if (main_type == DIALOG_YES1_YES2_NO) { w1_max = 480; }

                w1 = m1.iover(w1, w1_max, 640);
            }

            {
                h1 = all_h_call();
            }

            //縦横が決まったら座標移動
            //    if (s.base_run != null)
            {
                x1 = (area_x1 + area_w1 / 2) - w1 / 2;
                y1 = (area_y1 + area_h1 / 2) - h1 / 2;
            }
        }
    }

    public void reset2()
    {
        need_coin = 0;

        area_out_close = 0;

        reset_name1();
    }

    public void reset_name1()
    {
        if (main_type == DIALOG_OK)
        {
            yes1_name = "ＯＫ";
        }

        if (main_type == DIALOG_YESNO)
        {
            yes1_name = "はい";
            no_name = "いいえ";
        }


        if (main_type == DIALOG_YES1_YES2_NO){
            yes1_name = "はい１";
            yes2_name = "はい２";
            no_name = "いいえ";
        }
    }


    //typeに呼び出したい種類 main_typeにyesnoとかいれる
    public void create1(int type1, int type2, int main_type1, int free2)
    {
        on = 1;

        s1.touch_input.wait(2);

        //    s.main_run.base_load();


        this.type1 = type1;
        this.type2 = type2;

        main_type = main_type1;

        {
            reset2();
        }

        dialog_box_support.create1(type1, type2, main_type1, free2);

        reset1();
    }



    //0 … タイトル
    //1～ … 説明文
    public float call_line_y(int num1)
    {
        float nt = 0;
        int np = 0;

        
        if (num1 >= 1)
        {
            if (m1.strlength(title_name) >= 1)
            {
                np += title_h();
            }
            else
            {
                np += 8;
            }
        }
        
        for (int t1 = 2; t1 <= explantion_num_max() + 2; t1++)
        {
            if (num1 >= t1)
            {
                if (m1.strlength(explanation1[t1 - 2]) >= 1)
                {
                    np += explanation_h();
                }
            }
        }

        nt = y1 + np;        

        return nt;
    }

    public int call_line_y_add(int num)
    {
        int nt = (int)call_line_y(num);

        if (num == 0) { nt += 12 + 8; }
        if (num >= 1 && num <= explantion_num_max()) { nt += 6; }

        if (num == explantion_num_max() + 1) { nt += 36; }//40; }//32; }

        return nt;
    }


    public void send_explantion_line4(String mes1, String mes2, String mes3, String mes4)
    {
        for (int t1 = 0; t1 < explantion_num_max(); t1++) { explanation1[t1] = ""; }

        explanation1[0] = mes1;
        explanation1[1] = mes2;
        explanation1[2] = mes3;
        explanation1[3] = mes4;
    }

    public void send_explantion_line8(String mes1, String mes2, String mes3, String mes4, String mes5, String mes6, String mes7, String mes8)
    {
        for (int t1 = 0; t1 < explantion_num_max(); t1++) { explanation1[t1] = ""; }

        explanation1[0] = mes1;
        explanation1[1] = mes2;
        explanation1[2] = mes3;
        explanation1[3] = mes4;
        explanation1[4] = mes5;
        explanation1[5] = mes6;
        explanation1[6] = mes7;
        explanation1[7] = mes8;
    }


    public int all_h_call()
    {
        int nt = 0;

        for (int t1 = 0; t1 <= 16; t1++)
        {
            nt += call_line_h(t1);
        }

        return nt;
    }

    public int call_line_h(int num)
    {
        int nt = 0;

        if (num == 0)
        {
            if (m1.strlength(title_name) >= 1)
            {
                nt += title_h();
            }
        }

        if (num >= 1 && num < explantion_num_max() + 1)
        {
            if (m1.strlength(explanation1[num - 1]) >= 1)
            {
                nt += explanation_h();
            }
        }

        if (num == explantion_num_max() + 1)
        {
            nt += under_button_h();
        }

        return nt;
    }

    public int button_x(int button_num)
    {
        int nt = 0;
        
        if (main_type == DIALOG_OK)
        {
            nt = area_w1 / 2 - button_w() / 2;
        }

        if (main_type == DIALOG_YESNO)
        {
            int nt7 = 80;

            nt = area_w1 / 2;

            if (button_num == 0)
            {
                nt += (-nt7 - button_w() / 2);
            }
            if (button_num == 1)
            {
                nt += (+nt7 - button_w() / 2);
            }
        }

        if (main_type == DIALOG_YES1_YES2_NO)
        {
            int nt7 = 160;

            nt = area_w1 / 2;

            if (button_num == 0)
            {
                nt += (-nt7 - button_w() / 2);
            }
            if (button_num == 1)
            {
                nt = area_w1 / 2 - button_w() / 2;
            }
            if (button_num == 2)
            {
                nt += (+nt7 - button_w() / 2);
            }
        }

        return nt;
    }

    public int button_y()
    {
        int nt = 0;

        nt = call_line_y_add(explantion_num_max() + 1);

        nt = nt - button_h() / 4 - 2;

        return nt;
    }

    public int button_w()
    {
        return 108;
    }

    public int button_h()
    {
        return 48;
    }


    public void close1()
    {
        on = 0;

        s1.touch_input.wait_min(2);
    }


    //ぼたんを押した時
    public void button_touch_check(int button_num)
    {
        s1.touch_input.wait(4);

        //    m1.msbox(button_num);

        if (main_type == DIALOG_OK)
        {
            close1();

            dialog_box_support.touch_yes(0);

            s1.sm1.cursor_decide();
        }


        if (main_type == DIALOG_YESNO || main_type == DIALOG_YES1_YES2_NO)
        {
            //    if (s.dialog_order == 1)
            //    {
            //        if (button_num == 0) { button_num = 1; } else { button_num = 0; }
            //    }

            if ((button_num == 0) && yes1_ok_check() == 1)
            {
                {
                    //  s.gm.cursor_decide();

                    dialog_box_support.touch_yes(0);

                    /*
                    if (need_coin > 0)
                    {
                        s1.app_variable1.coin_add(-need_coin);
                        need_coin = 0;
                    }
                    */

                    close1();
                }
            }

            if ((button_num == 1 && main_type == DIALOG_YES1_YES2_NO) && yes2_ok_check() == 1)
            {
                {
                    //  s.gm.cursor_decide();

                    dialog_box_support.touch_yes(1);

                    m1.msbox();

                    close1();
                }
            }

            if ((button_num == 1 && main_type == DIALOG_YESNO )|| (button_num == 2 && main_type == DIALOG_YES1_YES2_NO))
            {
                s1.sm1.cursor_cancel();

                dialog_box_support.touch_no();

                close1();
            }
        }

    }


    public int yes1_ok_check()
    {
        int nt = dialog_box_support.yes_ok_check(0);

        /*
        if (s.game_variable.mana_true_call() < need_mana)
        {
            nt = 0;
        }
        */

        return nt;
    }

    public int yes2_ok_check()
    {
        int nt = dialog_box_support.yes_ok_check(1);

        return nt;
    }



    public void run1()
    {
        if (on != 0)
        {
            if (main_type == DIALOG_OK)
            {
                for (int t1 = 0; t1 <= 0; t1++)
                {
                    int px1 = s1.touch_input.point_x1();
                    int py1 = s1.touch_input.point_y1();

                    int np = 5;

                    int x7 = button_x(t1) - np;
                    int y7 = button_y() - np;//y1 + h1 - 48;
                    int w7 = button_w() + np * 2;
                    int h7 = button_h() + np * 2;

                    if (m1.rect_decision(px1, py1, x7, y7, w7, h7) == 1)
                    {
                        if (s1.touch_input.pull_check() == 1)
                        {
                            button_touch_check(t1);
                        }
                    }
                }
            }

            if (main_type == DIALOG_YESNO)
            {
                for (int t1 = 0; t1 <= 1; t1++)
                {
                    int px1 = s1.touch_input.point_x1();
                    int py1 = s1.touch_input.point_y1();

                    int np = 5;

                    int x7 = button_x(t1) - np;
                    int y7 = button_y() - np;//y1 + h1 - 48;
                    int w7 = button_w() + np * 2;
                    int h7 = button_h() + np * 2;


                    if (m1.rect_decision(px1, py1, x7, y7, w7, h7) == 1)
                    {
                        if (s1.touch_input.pull_check() == 1)
                        {
                            button_touch_check(t1);
                        }
                    }

                    if (t1 == 1)
                    {
                        if (s1.touch_input.push_check(1) == 1)
                        {
                            button_touch_check(t1);
                        }
                    }
                }
            }

            if (main_type == DIALOG_YES1_YES2_NO)
            {
                for (int t1 = 0; t1 <= 2; t1++)
                {
                    int px1 = s1.touch_input.point_x1();
                    int py1 = s1.touch_input.point_y1();

                    int np = 5;

                    int x7 = button_x(t1) - np;
                    int y7 = button_y() - np;//y1 + h1 - 48;
                    int w7 = button_w() + np * 2;
                    int h7 = button_h() + np * 2;


                    if (m1.rect_decision(px1, py1, x7, y7, w7, h7) == 1)
                    {
                        if (s1.touch_input.pull_check() == 1)
                        {
                            button_touch_check(t1);
                        }
                    }

                    if (t1 == 2)
                    {
                        if (s1.touch_input.push_check(1) == 1)
                        {
                            button_touch_check(t1);
                        }
                    }
                }
            }

            //画面外のタッチ
            {
                int px1 = s1.touch_input.point_x1();
                int py1 = s1.touch_input.point_y1();

                int np = -2;

                float x7 = x1 - np;
                float y7 = y1 - np;//y1 + h1 - 48;
                float w7 = w1 + np * 2;
                float h7 = h1 + np * 2;

                if (m1.rect_decision(px1, py1, x7, y7, w7, h7) == 0)
                {
                    if (s1.touch_input.pull_check() == 1)
                    {
                        if (area_out_close == 1)
                        {
                            {
                                s1.sm1.cursor_cancel();

                                close1();                                
                            }
                        }
                    }
                }
            }
        }//on
    }




    public void draw1()
    {
        if (on != 0)
        {         
            s1.dm1.boxdraw3(x1, y1, w1, h1, 0, 1);

            //    m1.end();

            //タイトル
            {
                //  g.sf(g.MAIN_STR);

                //    g.sf(g.BIG_STR);

                g1.setfont(g1.FONT_1_MAIN_STR);

                g1.sc(255);
                //    g.str3("" + title_name, x1 + w1 / 2, call_line_y_add(0), 22);// 27);

                g1.str2_center("" + title_name, x1 + w1 / 2, call_line_y_add(0), explantion_font_size_x1());// 27);


                g1.setfont_re();
            }

            

            //debug ライン確認
         //   for (int t1 = 0; t1 < 16; t1++)
         //   {
         //       g1.sc(255);
         //       g1.drawRect(x1, call_line_y(t1), w1, 1, 0, 0);
         //   }

            //explanation
            {
                g1.setfont(g1.FONT_1_MIDDLE_STR);
                g1.sc(255);

                for (int t1 = 0; t1 <= explantion_num_max(); t1++)
                {
                    int y6 = -6;

                    /*
                    if (t1 == 3)
                    {
                        y6 = 4;
                    }*/

                    g1.str2_center("" + explanation1[t1], x1 + w1 / 2, call_line_y_add(t1 + 1) + y6, explantion_font_size_x2());
                }

                g1.setfont_re();
            }

            {
                int x7 = (area_x1 + area_w1 / 2);
                int y7 = button_y();//y1 + h1 - 48;
                int y8 = call_line_y_add(explantion_num_max() + 1);

                int w7 = button_w();
                int h7 = button_h();


                int nt7 = 80;

                {
                    g1.setfont(g1.FONT_1_MIDDLE_STR);

                    g1.sc(255);

                    {
                        int clear1 = 60;

                        if (main_type == DIALOG_OK)
                        {
                            s1.dm1.boxdraw3(button_x(0), y7, w7, h7, 10, 1);

                            //    g1.str2_center("１２３４", x7, y8 - 3, explantion_font_size_x1());
                            g1.str2_center(""+ yes1_name, x7, y8 - 2, explantion_font_size_x2());
                        }


                        if (main_type == DIALOG_YESNO)
                        {
                        //    if (s.dialog_order == 0)
                            {
                                s1.dm1.boxdraw3(button_x(0), y7, w7, h7, 10, 1);
                                s1.dm1.boxdraw3(button_x(1), y7, w7, h7, 11, 1);

                                g1.str2_center(""+ yes1_name, x7 - nt7, y8, explantion_font_size_x2());
                                g1.str2_center(""+ no_name, x7 + nt7, y8, explantion_font_size_x2());
                                
                                //場合によっては はい禁止
                                if (yes1_ok_check() == 0)
                                {
                                    g1.sc(0);
                                    g1.setClear2(clear1);
                                    g1.drawRect(button_x(0), y7, w7, h7, 0, 1);
                                    g1.setClear2_re();
                                }
                            }
                        }


                        if (main_type == DIALOG_YES1_YES2_NO)
                        {
                            //    if (s.dialog_order == 0)
                            {
                                s1.dm1.boxdraw3(button_x(0), y7, w7, h7, 10, 1);
                                s1.dm1.boxdraw3(button_x(1), y7, w7, h7, 10, 1);
                                s1.dm1.boxdraw3(button_x(2), y7, w7, h7, 11, 1);

                                int nt8 = 160;

                                g1.str2_center(yes1_name, x7 - nt8, y8, explantion_font_size_x2());
                                g1.str2_center(yes2_name, x7, y8, explantion_font_size_x2());
                                g1.str2_center(no_name, x7 + nt8, y8, explantion_font_size_x2());

                                //場合によっては はい禁止
                                {
                                    if (yes1_ok_check() == 0)
                                    {
                                        g1.sc(0);
                                        g1.setClear2(clear1);
                                        g1.drawRect(button_x(0), y7, w7, h7, 0, 1);
                                        g1.setClear2_re();
                                    }

                                    if (yes2_ok_check() == 0)
                                    {
                                        g1.sc(0);
                                        g1.setClear2(clear1);
                                        g1.drawRect(button_x(1), y7, w7, h7, 0, 1);
                                        g1.setClear2_re();
                                    }
                                }
                            }
                        }
                    }

                        g1.setfont_re();
                }
            }

            /*
            

            {
                g.sf(g.MAIN_STR);

                g.sc(255);

                {
                    int x7 = s.game_display_w / 2;
                    int y7 = button_y();//y1 + h1 - 48;
                    int y8 = call_line_y_add(explantion_num_max() + 1);

                    int w7 = button_w();
                    int h7 = button_h();


                    int nt7 = 80;

                    if (main_type == DIALOG_YESNO)
                    {
                        if (s.dialog_order == 0)
                        {
                            s.dm.boxdraw3(button_x(0), y7, w7, h7, 10, 1);
                            s.dm.boxdraw3(button_x(1), y7, w7, h7, 11, 1);

                            g.str3("はい", x7 - nt7, y8, nnp);
                            g.str3("いいえ", x7 + nt7, y8, nnp);

                            //場合によっては はい禁止
                            if (yes_ok_check() == 0)
                            {
                                g.sc(0);
                                g.setClear(128);
                                g.drawRect(button_x(0), y7, w7, h7, 0, 1);
                                g.setClear(s.base_run.clear_call());
                            }
                        }
                        else
                        {
                            s.dm.boxdraw3(button_x(1), y7, w7, h7, 10, 1);
                            s.dm.boxdraw3(button_x(0), y7, w7, h7, 11, 1);

                            g.str3("はい", x7 + nt7, y8, nnp);
                            g.str3("いいえ", x7 - nt7, y8, nnp);

                            //場合によっては はい禁止
                            if (yes_ok_check() == 0)
                            {
                                g.sc(0);
                                g.setClear(128);
                                g.drawRect(button_x(1), y7, w7, h7, 0, 1);
                                g.setClear(s.base_run.clear_call());
                            }
                        }
                    }

                    if (main_type == DIALOG_OK)
                    {
                        s.dm.boxdraw3(button_x(0), y7, w7, h7, 10, 1);

                        g.str3("ＯＫ", x7, y8, nnp);
                    }
                }

                g.sf(0);
            }

            */
        }
    }

}
