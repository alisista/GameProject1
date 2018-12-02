using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DxLibDLL;


//起動したら、永続的に使用するような画像
public class ImageControl1 : SetVoid1
{
    static int TYPE = 16;
    static int NUMBER_1 = 32;
    static int NUMBER_2 = 32;

    //    public int[][][] img=new int[TYPE][][];

    public ImageData1[][][] img = new ImageData1[TYPE][][];

    int[][] loadmemo = new int[TYPE][];


    Misc1 m;
    MainCanvas1 g;
    Summary1 s;

    public void init_set1(Summary1 s1)
    {
        set1(s1);
        init1();

        this.m = m1;
        this.g = g1;
        this.s = s1;
    }
    


    public void init1()
    {
        for (int t = 0; t < TYPE; t++)
        {
            loadmemo[t] = new int[NUMBER_1];
        }

        for (int t = 0; t < TYPE; t++)
        {
            for (int t2 = 0; t2 < NUMBER_1; t2++)
            {
                loadmemo[t][t2] = 0;
            }
        }


        //多重配列宣言
        {
            for (int t = 0; t < TYPE; t++)
            {
                img[t] = new ImageData1[NUMBER_1][];
            }

            for (int t = 0; t < TYPE; t++)
            {
                for (int t1 = 0; t1 < NUMBER_1; t1++)
                {
                    img[t][t1] = new ImageData1[NUMBER_2];
                }
            }

            for (int t = 0; t < TYPE; t++)
            {
                for (int t1 = 0; t1 < NUMBER_1; t1++) for (int t2 = 0; t2 < NUMBER_2; t2++)
                    {
                        {
                            img[t][t1][t2] = new ImageData1();
                        }
                    }
            }
        }
    }//init1




    public ImageData1 loadcheck(int num1, int num2, int num3)
    {
        img_load_part(num1, num2);

        return img[num1][num2][num3];
    }




    public void img_load_part(int num, int num2)
    {
        //    if (num >= 0 && num2 >= 0)
        {
            String st, st1, st2;

            if (loadmemo[num][num2] == 0)
            {
                loadmemo[num][num2] = 1;


                st = s.res_pass();//+s.ds.folder_name;
                st1 = "";
                st2 = "";

                //分割量
                int x_num = 1;
                int y_num = 1;
                //	int frame=24;

                //   g.load_image_back_color(255, 255, 255);


                int t1 = num;
                int t2 = num2;

                //    for (int t1 = 0; t1 < TYPE; t1++)
                {
                    //      for (int t2 = 0; t2 < NUMBER_1; t2++)
                    {
                        //  for (int t3 = 0; t3 < NUMBER_2; t3++)
                        {

                            x_num = 1; y_num = 1;
                            st2 = "";

                            //ウインドウ画面関連
                            if (t1 == 0)
                            {
                                //test
                             //   if (t2 == 0) { st2 = "character/cs0003.png"; }

                                //    if (t2 == 0) { st2 = "window/mainwindow3.png"; }
                                if (t2 == 1) { st2 = "window/mainwindow4.png"; }
                                if (t2 == 2) { st2 = "window/mainwindow5.png"; }
                            }

                            if (t1 == 1)
                            {

                                if (t2 == 4) { st2 = "window3/scrollbar.png"; }

                                /*
                                if (t2 == 0) { st2 = "window3/charawindow.png"; x_num = 6; }
                                if (t2 == 1) { st2 = "battle/battle_top.png"; }
                                if (t2 == 2) { st2 = "window3/undericon.png"; x_num = 7; }
                                if (t2 == 3) { st2 = "window3/actericon.png"; }
                                
                                //    if (t2 == 5) { st2 = "window3/number_draw.png"; }
                                if (t2 == 6) { st2 = "window3/favorite.png"; }


                                if (t2 == 9) { st2 = "fade/block.png"; }
                                if (t2 == 10) { st2 = "battle/block1.png"; x_num = 8; }
                                if (t2 == 11) { st2 = "battle/touch_circle.png"; }
                                if (t2 == 12) { st2 = "battle/atk1.png"; }
                                if (t2 == 13) { st2 = "battle/cure1.png"; x_num = 7; }
                                if (t2 == 14) { st2 = "battle/cure2.png"; }
                                */

                                ////ウインドウ構成
                                {
                                    if (t2 == 15) { st2 = "window/bg.png"; }
                                    if (t2 == 16) { st2 = "window/barup.png"; }
                                    if (t2 == 17) { st2 = "window/bardown.png"; }
                                    if (t2 == 18) { st2 = "window/barleft.png"; }
                                    if (t2 == 19) { st2 = "window/barright.png"; }
                                    if (t2 == 20) { st2 = "window/barblock.png"; }
                                    if (t2 == 21) { st2 = "window/barleft2.png"; }

                                    if (t2 == 24) { st2 = "window/bg2.png"; }
                                    if (t2 == 25) { st2 = "window/bg3.png"; }
                                }
                            }

                            if (t1 == 2)
                            {
                                if (t2 == 0) { st2 = "status/attribute1.png"; x_num = 6; }
                                if (t2 == 1) { st2 = "status/hp_and_mp.png"; x_num = 2; }
                                if (t2 == 2) { st2 = "status/character_window_set_1.png"; x_num = 6; }
                                if (t2 == 3) { st2 = "status/character_window_set_2.png"; x_num = 6; }
                                if (t2 == 4) { st2 = "status/character_window_set_3.png"; x_num = 6; }
                                if (t2 == 5) { st2 = "status/character_window_set_4.png"; x_num = 6; }
                                if (t2 == 6) { st2 = "status/character_window_set_5.png"; x_num = 6; }
                                if (t2 == 7) { st2 = "status/character_window_set_6.png"; x_num = 6; }
                            }

                            //ゲージ関連
                            if (t1 == 3)
                            {
                                st1 = "gauge/";

                                if (t2 == 1) { st2 = "1_1.png"; }
                                if (t2 == 2) { st2 = "1_2.png"; }
                                if (t2 == 3) { st2 = "1_3.png"; }
                                if (t2 == 4) { st2 = "2_1.png"; }
                                if (t2 == 5) { st2 = "2_2.png"; }
                                if (t2 == 6) { st2 = "2_3.png"; }
                                if (t2 == 7) { st2 = "3_1.png"; }
                                if (t2 == 8) { st2 = "3_2.png"; }
                                if (t2 == 9) { st2 = "3_3.png"; }
                                if (t2 == 10) { st2 = "4_1.png"; }
                                if (t2 == 11) { st2 = "4_2.png"; }
                                if (t2 == 12) { st2 = "4_3.png"; }
                                if (t2 == 13) { st2 = "5_1.png"; }
                                if (t2 == 14) { st2 = "5_2.png"; }
                                if (t2 == 15) { st2 = "5_3.png"; }
                                if (t2 == 16) { st2 = "6_1.png"; }
                                if (t2 == 17) { st2 = "6_2.png"; }
                                if (t2 == 18) { st2 = "6_3.png"; }
                                if (t2 == 19) { st2 = "7_1.png"; }
                                if (t2 == 20) { st2 = "7_2.png"; }
                                if (t2 == 21) { st2 = "7_3.png"; }
                                if (t2 == 22) { st2 = "8_1.png"; }
                                if (t2 == 23) { st2 = "8_2.png"; }
                                if (t2 == 24) { st2 = "8_3.png"; }
                                if (t2 == 25) { st2 = "gaugewindow1.png"; }
                                if (t2 == 26) { st2 = "gaugewindow2.png"; }
                                if (t2 == 27) { st2 = "gaugewindow3.png"; }

                                if (t2 == 29) { st2 = "shadow1.png"; }
                                if (t2 == 30) { st2 = "shadow2.png"; }
                            }

                            //window2
                            if (t1 == 4)
                            {
                                st1 = "window2/";

                                if (t2 == 1) { st2 = "top_shadow.png"; }
                                if (t2 == 2) { st2 = "under_shadow.png"; }
                            }


                            //色々
                            if (t1 == 5)
                            {
                                st1 = "";

                                if (t2 == 0) { st2 = "misc/shadow1.png"; }

                                if (t2 == 4) { st2 = "misc/lock.png"; }

                                if (t2 == 21) { st2 = "value_box/value1.png"; x_num = 10; }
                                if (t2 == 22) { st2 = "value_box/value2.png"; x_num = 10; }
                                if (t2 == 23) { st2 = "value_box/value3.png"; x_num = 10; }
                                if (t2 == 24) { st2 = "value_box/value4.png"; x_num = 10; }
                                if (t2 == 25) { st2 = "value_box/value5.png"; x_num = 10; }
                                if (t2 == 26) { st2 = "value_box/value6.png"; x_num = 10; }
                                if (t2 == 27) { st2 = "value_box/value7.png"; x_num = 10; }
                                if (t2 == 28) { st2 = "value_box/value8.png"; x_num = 10; }
                            }


                            //戦闘関連
                            if (t1 == 7)
                            {
                                st1 = "";
                            //    if (t2 == 0) { st2 = "battle/gameover.png"; x_num = 8; }
                                if (t2 == 1) { st2 = "battle/stageclear.png"; x_num = 11; }
                            //    if (t2 == 2) { st2 = "battle/manastar2.png"; x_num = 8; }
                                //    if (t2 == 3) { st2 = "misc/magic_circle.png"; x_num = 6; }
                            //    if (t2 == 4) { st2 = "battle/bossbattle.png"; }

                                //    if (t2 == 16) { st2 = "battle/status1.png"; x_num = 6; }
                                //    if (t2 == 17) { st2 = "battle/rank1.png"; x_num = 6; y_num = 2; }
                            }


                            //ベース関連
                            if (t1 == 8)
                            {
                                st1 = "base/";

                                if (t2 == 1) { st2 = "basebg1.png";}
                                if (t2 == 2) { st2 = "basebg2.png"; }
                                if (t2 == 3) { st2 = "basebg3.png"; }
                                if (t2 == 4) { st2 = "basebg4.png"; }

                                if (t2 >= 16) { st1 = "title/"; }

                                if (t2 == 16) { st2 = "title_logo.png"; }
                                if (t2 == 17) { st2 = "titlebg1.jpg"; }
                                if (t2 == 18) { st2 = "piece.png"; x_num = 16; }
                            //    if (t2 == 19) { st2 = "piece2.png"; }
                            }

                            /*
                            if (t1 == 0)
                            {
                                if (t2 == 0) { st2 = "main/mana.png"; }
                                if (t2 == 1) { st2 = "main/attribute.png"; x_num = 6; }
                                if (t2 == 2) { st2 = "main/shadow1.png"; }
                                if (t2 == 3) { st2 = "main/button1.png"; }
                                if (t2 == 4) { st2 = "main/lock.png"; }
                                if (t2 == 5) { st2 = "num/num1.png"; x_num = 10; }
                                if (t2 == 6) { st2 = "num/num2.png"; x_num = 10; }
                                if (t2 == 7) { st2 = "num/num3.png"; x_num = 10; }
                                if (t2 == 8) { st2 = "num/num4.png"; x_num = 10; }
                                if (t2 == 9) { st2 = "num/num5.png"; x_num = 10; }
                                //    if (t2 == 10) { st2 = "num/num6.png"; x_num = 10; }
                                //    if (t2 == 11) { st2 = "num/num7.png"; x_num = 10; }


                                if (t2 == 11) { st2 = "num/att1.png"; x_num = 10; }
                                if (t2 == 12) { st2 = "num/att2.png"; x_num = 10; }
                                if (t2 == 13) { st2 = "num/att3.png"; x_num = 10; }
                                if (t2 == 14) { st2 = "num/att4.png"; x_num = 10; }
                                if (t2 == 15) { st2 = "num/att5.png"; x_num = 10; }
                                if (t2 == 16) { st2 = "num/att6.png"; x_num = 10; }
                            }

                            if (t1 == 1)
                            {
                                if (t2 == 0) { st2 = "window3/charawindow.png"; x_num = 6; }
                                if (t2 == 1) { st2 = "battle/battle_top.png"; }
                                if (t2 == 2) { st2 = "window3/undericon.png"; x_num = 7; }
                                if (t2 == 3) { st2 = "window3/actericon.png"; }
                                if (t2 == 4) { st2 = "window3/scrollber.png"; }
                                //    if (t2 == 5) { st2 = "window3/number_draw.png"; }
                                if (t2 == 6) { st2 = "window3/favorite.png"; }


                                if (t2 == 9) { st2 = "fade/block.png"; }
                                if (t2 == 10) { st2 = "battle/block1.png"; x_num = 8; }
                                if (t2 == 11) { st2 = "battle/touch_circle.png"; }
                                if (t2 == 12) { st2 = "battle/atk1.png"; }
                                if (t2 == 13) { st2 = "battle/cure1.png"; x_num = 7; }
                                if (t2 == 14) { st2 = "battle/cure2.png"; }

                            }


                            //ウインドウボタン関連
                            if (t1 == 2)
                            {
                                if (t2 == 0) { st2 = "window2/mainwindow.png"; }
                                if (t2 == 1) { st2 = "window2/mainwindow2.png"; }
                                if (t2 == 2) { st2 = "window2/line2.png"; }
                                if (t2 == 3) { st2 = "window2/close.png"; }
                                if (t2 == 4) { st2 = "window2/line3.png"; }

                                if (t2 == 6) { st2 = "window2/mainwindow3.png"; }
                                if (t2 == 7) { st2 = "window2/mainwindow4.png"; }

                                if (t2 == 15) { st2 = "window2/bg.png"; }
                                if (t2 == 16) { st2 = "window2/barup.png"; }
                                if (t2 == 17) { st2 = "window2/bardown.png"; }
                                if (t2 == 18) { st2 = "window2/barleft.png"; }
                                if (t2 == 19) { st2 = "window2/barright.png"; }
                                if (t2 == 20) { st2 = "window2/barblock.png"; }
                                if (t2 == 21) { st2 = "window2/barleft2.png"; }
                                if (t2 == 22) { st2 = "window2/bg2.png"; }
                                if (t2 == 23) { st2 = "window2/bg3.png"; }
                                //    if (t2 == 24) { st2 = "window2/bg4.png"; }
                                //    if (t2 == 25) { st2 = "window2/bg5.png"; }
                            }



                            //ゲージ関連
                            if (t1 == 3)
                            {
                                st1 = "window_gage/";

                                if (t2 == 0) { st2 = "gagewindow1.png"; }
                                if (t2 == 1) { st2 = "gagewindow2.png"; }
                                if (t2 == 2) { st2 = "gagewindow3.png"; }

                                if (t2 == 4) { st2 = "guts1.png"; }
                                if (t2 == 5) { st2 = "guts2.png"; }
                                if (t2 == 6) { st2 = "exp1.png"; }
                                if (t2 == 7) { st2 = "exp2.png"; }
                                if (t2 == 8) { st2 = "hp1.png"; }
                                if (t2 == 9) { st2 = "hp2.png"; }
                                if (t2 == 10) { st2 = "mp1.png"; }
                                if (t2 == 11) { st2 = "mp2.png"; }
                                if (t2 == 12) { st2 = "defeat_hp1.png"; }
                                if (t2 == 13) { st2 = "defeat_hp2.png"; }
                            }


                            if (t1 == 5)
                            {
                                st1 = "";

                                if (t2 == 0) { st2 = "effect/star1.png"; x_num = 7; }
                                if (t2 == 1) { st2 = "effect/shockwave.png"; x_num = 6; }
                                if (t2 == 2) { st2 = "effect/manastar3.png"; x_num = 8; }

                                if (t2 == 16) { st2 = "battle/rank1.png"; x_num = 7; y_num = 2; }
                                if (t2 == 17) { st2 = "battle/curse1.png"; x_num = 6; }
                                if (t2 == 18) { st2 = "battle/jwel_1.png"; x_num = 8; }
                                if (t2 == 19) { st2 = "battle/field.png"; }
                            }

                            if (t1 == 6)
                            {
                                st1 = "";

                                if (t2 == 0) { st2 = "logo/exp1.png"; }
                                if (t2 == 1) { st2 = "logo/exp2.png"; }
                                if (t2 == 2) { st2 = "logo/exp3.png"; }
                                if (t2 == 3) { st2 = "logo/exp4.png"; }
                                if (t2 == 4) { st2 = "logo/exp5.png"; }


                                if (t2 == 8) { st2 = "logo/str1.png"; }
                                //    if (t2 == 9) { st2 = "logo/str2.png"; }



                                if (t2 == 16) { st2 = "battle/block2.png"; x_num = 1; }
                                if (t2 == 17) { st2 = "battle/drop1.png"; x_num = 5; }
                                if (t2 == 18) { st2 = "battle/drop2.png"; x_num = 5; }
                            }



                            //消してもいいかもしれない系統
                            if (t1 == 7)
                            {
                                st1 = "";
                                if (t2 == 0) { st2 = "battle/gameover.png"; x_num = 8; }
                                if (t2 == 1) { st2 = "battle/stageclear.png"; x_num = 11; }
                                if (t2 == 2) { st2 = "battle/manastar2.png"; x_num = 8; }
                                //    if (t2 == 3) { st2 = "misc/magic_circle.png"; x_num = 6; }
                                if (t2 == 4) { st2 = "battle/bossbattle.png"; }

                                //    if (t2 == 16) { st2 = "battle/status1.png"; x_num = 6; }
                                //    if (t2 == 17) { st2 = "battle/rank1.png"; x_num = 6; y_num = 2; }
                            }



                            //8番だけは、ゲームタイプが変わるたびにメモリ解放が起きる
                            if (t1 == 8)
                            {
                                st1 = "base_bg/";

                                if (t2 == 0) { st2 = "status.png"; }

                                if (t2 == 5) { st2 = "basebg.png"; }
                                if (t2 == 6) { st2 = "dungeonselect.png"; }
                                if (t2 == 7) { st2 = "shop.png"; }
                                if (t2 == 8) { st2 = "orchard.png"; }
                                if (t2 == 9) { st2 = "another.png"; }
                                if (t2 == 10) { st2 = "home.png"; }
                                if (t2 == 11) { st2 = "basebg2.png"; }


                                if (t2 == 20) { st2 = "title.png"; }
                                //     if (t2 == 21) { st2 = "title.png"; }

                                if (t2 == 24) { st2 = "logo1.png"; }
                            }



                            if (t1 == 9)
                            {
                                if (t2 == 1) { st2 = "talkchara/test2.png"; }
                            }
                            */


                            if ((int)(m.strlength(st2)) >= 1)
                            {
                                split_load(st + st1 + st2, t1, t2, 0, x_num, y_num);

                            }

                        }
                    }
                }

            }
        }
    }


    public void img_release_part(int num, int num2)
    {
        //    if (num >= 0 && num2 >= 0)
        {
            String st, st1, st2;

            //    if (loadmemo[num][num2] == 0)
            {
                loadmemo[num][num2] = 0;

                for (int t1 = 0; t1 < NUMBER_2; t1++)
                {
                    g.delete_graph(img[num][num2][t1]);
                }
            }
        }
    }
    


    /*
    //メモリ開放
    public void release()
    {
        for (int t3 = 0; t3 < NUMBER_2; t3++)
        {
            if (img[t3] != -1)
            {
                g.delete_graph(img[t3]);
            }

            img[t3] = -1;
        }
    }
    */



    void split_load(string name, int type, int number, int type3, int x_num, int y_num)//, int sload)
    {

        if (m1.strlength(name) >= 1)
        {
            if (x_num <= 1 && y_num <= 1 || type3 >= 1)
            {
                {
                    img[type][number][type3] = g1.load_image(name);
                }
            }

            else if ((x_num >= 2 || y_num >= 2) && type3 == 0)
            {
                ImageData1 image = new ImageData1();
                image = g.load_image(name);

                if (x_num * y_num <= NUMBER_2)
                {// || send2==1){
                    for (int t3 = 1; t3 <= y_num; t3++)
                    {
                        for (int t2 = 1; t2 <= x_num; t2++)
                        {
                            int size_x, size_y;
                            //	DX.GetGraphSize(image,&size_x,&size_y);
                            DX.GetGraphSize(image.call(), out size_x, out size_y);

                            int xn = x_num;
                            int yn = y_num;

                            {
                                img[type][number][(t2 - 1) + (t3 - 1) * (xn)] = g.split_image(image, (t2 - 1) * size_x / xn, (t3 - 1) * size_y / yn, size_x / xn, size_y / yn);
                            }
                        }
                    }
                }

                g1.delete_graph(image);
            }
        }

    }

    public void run1()
    {
    }

    public void draw1()
    {
    }
}

