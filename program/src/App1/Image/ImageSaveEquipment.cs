using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ImageSaveEquipment : SetVoid1
{
    static int IMG_MAX = 120;
    public ImageData1[] img1 = new ImageData1[IMG_MAX];

    public int[] load_type1 = new int[IMG_MAX];

    public ImageSaveEquipment(Summary1 s1)
    {
        set1(s1);

        for (int t = 0; t < IMG_MAX; t++)
        {
            img1[t] = new ImageData1();
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
            g1.delete_graph(img1[t1]);
            load_type1[t1] = 0;
        }
    }


    //要求された画像を持っている場合は、登録番号を返す　持っていない場合はロード
    public int img_load_part1(int type1)
    {
        int slot1 = -1;

        if (type1 >= 1)
        {
            for (int t = 0; t < IMG_MAX; t++)
            {
                if (type1 == load_type1[t])
                {
                    slot1 = t;
                    break;
                }
            }


            if (slot1 == -1)
            {
                //   m1.msbox(1);

                //空いている領域を探して、発見したらそのスロットに画像を入れる
                for (int t = 0; t < IMG_MAX; t++)
                {
                    if (load_type1[t] == 0)
                    {
                        slot1 = t;
                        break;
                    }

                    //全部埋まっていた場合は、メモリの全開放
                    if (t == IMG_MAX - 1)
                    {
                        init1();

                        slot1 = 0;
                    }
                }

                //    m1.msbox(2);


                if (load_type1[slot1] == 0)
                {
                    load_type1[slot1] = type1;

                    {
                        String st, st1, st2;

                        int num1 = slot1;

                        {
                            st = s1.res_pass();
                            st1 = "";
                            st2 = "";

                            st2 = "equipment/e" + (m1.add_space_str1("" + (type1), 4, 0, "0")) + ".png";

                            if ((int)(m1.strlength(st2)) >= 1)
                            {
                                if (m1.file_check(st + st1 + st2) == 1)
                                {
                                    img1[num1] = g1.load_image(st + st1 + st2);
                                }
                            }
                        }
                    }
                }
            }
        }


        if (slot1 <= -1)
        {
            slot1 = 0;
        }

        return slot1;
    }



    //敵キャラの全体絵を返す
    public ImageData1 loadcheck1(int type1)
    {
        int num1 = img_load_part1(type1);
        return img1[num1];
    }



    public void run1()
    {
    }

    public void draw1()
    {
    }
}
