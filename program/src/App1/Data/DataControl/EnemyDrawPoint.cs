using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//敵の表示位置や倍率を管理するクラス

//ストックはＸ個までしか存在していない 全部は読み込まない

public class EnemyDrawPoint : SetVoid1
{
    static int MAX2 = 36;

    public int max() { return MAX2; }
    public int[] load_type1 = new int[MAX2];
    public EnemyDrawPointChild[] enemy_draw_point_child = new EnemyDrawPointChild[MAX2];

    public int use_slot;
    public int use_enemy_type1;

    public EnemyDrawPoint(Summary1 s1)
    {
        set1(s1);

        for (int t = 0; t < max(); t++)
        {
            load_type1[t] = 0;

            enemy_draw_point_child[t] = new EnemyDrawPointChild(s1, t);
        }     
    }

    public void init1()
    {
        release_data();

        use_slot = 0;
        use_enemy_type1 = 0;
    }

    public void release_data()
    {
        for (int t1 = 0; t1 < max(); t1++)
        {
            load_type1[t1] = 0;
            enemy_draw_point_child[t1].init1();
        }
    }


    //目的の種類の変数を使用できるようにする
    public int load_slot(int type1)
    {
        int slot1 = -1;

        if (type1 >= 1)
        {
            for (int t = 0; t < max(); t++)
            {
                if (type1 == load_type1[t])
                {
                    slot1 = t;
                    break;
                }
            }


            if (slot1 == -1)
            {
                //空いている領域を探して、発見したらそのスロットに画像を入れる
                for (int t = 0; t < max(); t++)
                {
                    if (load_type1[t] == 0)
                    {
                        slot1 = t;
                        break;
                    }

                    //全部埋まっていた場合は、メモリの全開放
                    if (t == max() - 1)
                    {
                        init1();

                        slot1 = 0;
                    }
                }
                
                if (load_type1[slot1] == 0)
                {
                    load_type1[slot1] = type1;

                    {
                        //ここにロードメソッド
                        use_slot = slot1;
                        position_load(type1);
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


    /*
    public int call_variable(int type1,int call_variable_num)
    {
        
    }
    */
    

    public void position_create(int enemy_type1, int x_move1, int y_move1, int shadow_large1_per, int shadow_y_move1, int enemy_large_per, int null1, int null2)
    {
        if (use_enemy_type1 == enemy_type1)
        {
            int t1 = use_slot;
            enemy_draw_point_child[t1].enemy_draw_setting(x_move1, y_move1, shadow_large1_per, shadow_y_move1, enemy_large_per, null1);
        }
    }

    public void position_copy(int enemy_type1, int copy_target)
    {
        if (use_enemy_type1 == enemy_type1)
        {
            //コピーはコピーではなく、再ロード
            position_load(copy_target);
        }
    }

    
    //宣言は関数のようにしておきたいから、少し回りくどいけど、以下を採用。
    //ひとまず、ロードは全部プログラムに書いておく。
    public void position_load(int type1)
    {
        int t1 = type1;
        use_enemy_type1 = type1;

        if (t1 >= 20 * 0 && t1 < 20 * 1)
        {
            position_create(1, +4, -5, 1, -4, 100, 0, 0);
            position_create(2, -2, +20, 110, -5, 100, 0, 0);
            position_create(3, 0, -30, 100, 10, 100, 0, 0);
            position_create(4, 0, 0, 120, +5, 100, 0, 0);
            position_copy(5, 4);
            position_create(6, 0, 0, 100, +5, 100, 0, 0);
            position_create(7, -10, 0, 120, -12, 95, 0, 0);
            position_copy(8, 7);
            position_copy(9, 7);
            position_copy(10, 7);
            position_copy(11, 7);
            position_create(12, 0, -10, 100, +5, 100, 0, 0);
            position_copy(13, 12);
            position_create(14, -5, -5, 90, +5, 100, 0, 0);
            position_create(15, 0, +25, 120, -10, 100, 0, 0);
            position_copy(16, 15);
            position_copy(17, 15);
            position_create(18, +5, -10, 100, 0, 100, 0, 0);
            position_copy(19, 18);
        }



        //if (t1 >= 0 && t1 < 20)
        //if (t1 >= 0 && t1 < 20)
    }
}
