using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//ダンジョン背景の画像管理クラス
public class ImageSaveDungeonBg : SetVoid1
{
    //画像保存は複数用意してあるが、背景に使うのは0だけ。他は拡張用
    static int IMG_MAX = 4;

    public ImageData1[] img2 = new ImageData1[IMG_MAX];
    int[][] loadmemo2 = new int[IMG_MAX][];


    public ImageSaveDungeonBg(Summary1 s1)
    {
        set1(s1);

        for (int t = 0; t < IMG_MAX; t++)
        {
            img2[t] = new ImageData1();
            loadmemo2[t] = new int[1];
        }
    }

    public void init1()
    {
        release_data();
    }


    public void release_data()
    {
        for (int t1 = 0; t1 < IMG_MAX; t1++)
        {
            g1.delete_graph(img2[t1]);
            loadmemo2[t1][0] = 0;
        }
    }
    

    public ImageData1 loadcheck2(int num1)
    {
        int slot1 = 0;

        img_load_bg1(slot1, num1);
        return img2[slot1];
    }


    //必要な画像を送り返す
    public void img_load_bg1(int slot1, int bg_num)
    {
        String st, st1, st2;

        if (loadmemo2[slot1][0] == 0)
        {
            st = s1.res_pass();
            st1 = "";
            st2 = "";

            {
                st2 = "";

                //ダンジョン背景
                {
                    st2 = "battle_bg/" + (m1.add_space_str1("" + (bg_num), 3, 0, "0")) + ".jpg";//".png";

                    if ((int)(m1.strlength(st2)) >= 1)
                    {
                        if (m1.file_check(st + st1 + st2) == 1)
                        {
                            img2[slot1] = g1.load_image(st + st1 + st2);
                        }
                    }
                }
            }

            loadmemo2[slot1][0] = 1;
        }
    }


    /*
    //t2=0,ダンジョン背景
    public void img_load_part2(int num, int t2)
    {
        String st, st1, st2;

        if (loadmemo2[num][t2] == 0)
        {
            st = s1.res_pass();
            st1 = "";
            st2 = "";

            //    for (int t1 = 1; t1 < make_chara_num; t1++)
            {
                {
                    st2 = "";

                    //ダンジョン背景
                    if (t2 == 0)
                    {
                        st2 = "battle_bg/" + (m1.add_space_str2("" + (num), 3, 1, "0")) + ".jpg";//".png";

                        if ((int)(m1.strlength(st2)) >= 1)
                        {
                            if (m1.file_check(st + st1 + st2) == 1)
                            {
                                img2[num].img_address = g1.load_image(st + st1 + st2);
                            }
                        }
                    }

                }
            }

            loadmemo2[num][t2] = 1;
        }
        
    }
    */
}


//}
