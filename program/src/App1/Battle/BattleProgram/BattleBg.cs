using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleBg : SetVoid1
{
    public ImageSaveDungeonBg image_save_dungeon_bg;

    //使用する背景のナンバー 0はダンジョンに合わせる
    public int battle_bg_num = 0;//5;

    //画面の奥に移動する管理変数
    public int move_flag;
    public int move_tm;
    public int move_tm_max;
    public float move_pp;
    float move_y1 = 0;

    public BattleBg(Summary1 s1)
    {
        set1(s1);
        image_save_dungeon_bg = new ImageSaveDungeonBg(s1);
    }
    
    public void init1()
    {
        image_save_dungeon_bg.init1();

        //ダンジョンの奥に行く実行の管理
        {
            //    large_cam = 0.70f;

            move_flag = 0;
            move_pp = 0;
            move_tm = -1;
            move_tm_max = 90;
        }

    }//init1()


    //奥画面に移動する管理
    public void dungeon_move_run()
    {
        //実際の移動
        if (move_tm >= 0 && move_tm < move_tm_max)
        {
            float move_point1 = 0.5f;
            int battle_num = 8;//(8回のみ → ダンジョンの最初を考えると7回が最大回数)

            move_tm++;

            float move1 = move_point1 / (battle_num);

            move_pp += move1 / move_tm_max;

            if (move_pp >= move_point1) move_pp = move_point1;

            move_y1 = m1.abs(m1.sin_r(3, 360 * move_tm / move_tm_max));
        }
        else
        {
            move_tm = -1;
            move_flag = 0;
        }
    }//dungeon_move()

    //ダンジョンの奥に移動実行
    public void dungeon_move()
    {
        if (move_tm <= -1)
        {
            move_tm = 0;
        }
    }



    public void run1()
    {
        dungeon_move_run();

        //デバッグ zボタンによるテスト
        if (s1.debug_on() == 1)
        {
            if (input1.rinput(1, input1.INPUT_D) == 1)
            {
                    dungeon_move();
            }
        }
    }

    public void draw1()
    {
        int y8 = 16;

     //   g1.sc(240, 160, 160);
     //   g1.drawRect(0, y8, 720, 480, 0, 0);


        //戦闘画面
        {
            int y1 = 16;//call_layout_y(2);
                int h1 = 480;


            {
                int x9 = 360;//s1.game_display_w / 2;
                //    int y9 = y1 + h1 / 2 + (int)(0.170f * move_pp*1000+move_y1);
                //  float la1 = 0.7f + 0.001f * move_pp * 1000;

                int y9 = y1 + h1 / 2 + (int)(170.0f * move_pp + move_y1) - 4 + 12 - 8+4;//-8;
                                                                                  //    float la1 = 0.7f + move_pp;
             //   float la1 = 0.70f + move_pp;
             float la1 = 1.0f + move_pp;

                /*
                int img_num = s1.dungeon_data.call_dungeon_bg_type();//battle_bg_num;
                if (img_num == 0) { img_num = 5; }

                g1.drawImage(s1.image_save_dungeon_bg.loadcheck2(img_num), x9, y9, la1, 0);
                */

                int img_num = battle_bg_num;
                if (battle_bg_num == 0)
                {
                    img_num = s1.data_magagement.dungeon_data.dungeon_back_image(s1.data_magagement.dungeon_data.dungeon_type1);
                }

                g1.drawImage(image_save_dungeon_bg.loadcheck2(img_num), x9, y9, la1, 0);


                //    g.drawImage(im.loadcheck(0, 30, 0), x9, y9,la1,0);

                //画面倍率表示
                //g.sc(255);
                //g.str2("" + la1, x9, y9);
            }

            /*

            if (dark_clear <= 254)
            {
                g.setClear(255 - dark_clear);
                g.sc(0);
                g.drawRect(0, 0, 800, 600);
                g.setClearre();
            }
            */
        }
    }//draw1
}
