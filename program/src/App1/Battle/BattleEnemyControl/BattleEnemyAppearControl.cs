using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleEnemyAppearControl : SetVoid1
{
    static int BATTLE_ENEMY_MAX2 = 6;
    public int max1() { return BATTLE_ENEMY_MAX2; }

    public BattleEnemySlot[] battle_enemy_slot = new BattleEnemySlot[BATTLE_ENEMY_MAX2];

    int init_flag;

    public BattleEnemyAppearControl(Summary1 s1)
    {
        set1(s1);

        for (int t1 = 0; t1 < max1(); t1++)
        {
            battle_enemy_slot[t1] = new BattleEnemySlot();
            battle_enemy_slot[t1].init1();
        }

        init_flag = 0;
    }

    public void init1()
    {
        if (init_flag == 0)
        {
            init_flag = 1;
            
            enemy_slot_init();

            //敵キャラのテスト生成
            {
                enemy_slot_race_set();

                //     enemy_slot_type1_set(6, 7, 0, 0);

                //   enemy_slot_type1_set(12, 14, 15, 0);

                //   enemy_slot_type1_set(17, 18, 19, 0);

                //    enemy_slot_type1_set(4, 5, 6, 0);

                //enemy_slot_type1_set(6, 0, 0, 0);

                //  enemy_slot_type1_set(1, 2, 3, 0);

                //    enemy_slot_type1_set(1, 11, 12, 0);

                // enemy_slot_type1_set(12, 14, 15, 0);

                if (s1.data_magagement.dungeon_data.dungeon_battle_num >= 1)
                {
                        enemy_make(0);
                }
            }
        }
    }

    public void enemy_appear()
    {
        s1.battle_run.battle_enemy_group.init1();

        enemy_slot_init();
        enemy_slot_race_set();
        enemy_make(0);
    }


    public void enemy_slot_init()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
            battle_enemy_slot[t1].init1();
        }
    }

    public void debug_enemy_create()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
            s1.battle_run.battle_enemy_group.battle_enemy[t1].init1();
            battle_enemy_slot[t1].init1();
        }

        enemy_slot_race_set();
        enemy_make(0);
    }



    //敵の出現 デバッグ用かも
    public void enemy_slot_type1_set(int num1, int num2, int num3, int num4)
    {
        init1();

        if (num1 >= 1) battle_enemy_slot[0].type1 = num1;
        if (num2 >= 1) battle_enemy_slot[1].type1 = num2;
        if (num3 >= 1) battle_enemy_slot[2].type1 = num3;
        if (num4 >= 1) battle_enemy_slot[3].type1 = num4;
    }



    //敵情報から、敵を形成する
    public void enemy_make(int free1)
    {
        //敵キャラの画像メモリを一旦開放
        {
            s1.data_magagement.enemy_draw_point.release_data();
            s1.battle_run.battle_enemy_group.image_save_enemy.release_data();
        }

        //    int status_meg = 100;

        //    m1.msbox();

        int num1 = 0;// + BC_ENEMY_START_NUM;
        int x1 = 0;

        for (int t9 = 0; t9 < max1(); t9++)
        {
            if (battle_enemy_slot[t9].type1 >= 1)
            {
                if (x1 <= s1.battle_run.battle_window_w_call() - 20)
                {
                    //    bc[num1].init(num1);


                    //ddd
                    //    bc[num1].battle_join = 1;
                    //  bc[num1].cglink = s.chg.ENEMY_START_NUM + t9;


                    //   bc[num1].create(enemy_slot_race[t9], enemy_slot_level[t9], 1, 0);

                    {
                        int race1 = battle_enemy_slot[t9].type1;
                        int level1 = battle_enemy_slot[t9].strength1;

                        s1.battle_run.battle_enemy_group.battle_enemy[num1].create(race1, level1, 0, 0, 0, 0);

                        s1.battle_run.battle_enemy_group.battle_enemy[num1].appear_move_set(num1 * 8);
                    }

                    //ddd
                    //    bc[num1].clear_draw_tm = (12 - t9) * 10 - 120;

                    //    long time1 = m1.get_time();

                    s1.battle_run.battle_enemy_group.battle_enemy[num1].x1 = x1 + s1.battle_run.battle_enemy_group.battle_enemy[num1].call_w() / 2;
                    x1 += s1.battle_run.battle_enemy_group.battle_enemy[num1].call_w() + 8;//+ 16;

                    num1++;

                    //     m1.msbox(num1);


                    //    time1 = m.get_time() - time1;
                    //    m.msbox(time1);
                }
            }
        }


        //出現したキャラを中央に合わせる
        int gw = s1.battle_run.battle_window_w_call();//s1.game_display_w;
        int n1 = (gw - x1) / 2;

        for (int t1 = 0; t1 < num1; t1++)
        {
            s1.battle_run.battle_enemy_group.battle_enemy[t1].x1 += n1;
        }

        //   return nt;
    }


    //通常における敵生成
    public void enemy_slot_race_set()
    {
        enemy_slot_init();

        //通常エンカウントの敵作成
        {
        //    drop_rare_num = -1;
        //    drop_boss_num = -1;

            int enemy_num = 3;
            int battle_num = s1.data_magagement.dungeon_data.dungeon_battle_num_max();

        //    m1.msbox(battle_num);

            //battle_num
            //1F 2~3 (2.5)
            //2F 2~4 (3.5)
            //3F 2~5 (3.5)
            //4F 3~5 (4.0)
            //5F 4~5 (4.5)
            if (battle_num <= 1) { enemy_num = 2 + m1.rand(1); }
            if (battle_num == 2) { enemy_num = 3 + m1.rand(1); }
            if (battle_num == 3) { enemy_num = 3 + m1.rand(1); }
            if (battle_num == 4) { enemy_num = 3 + m1.rand(2); }
            if (battle_num >= 5) { enemy_num = 4 + m1.rand(1); }

            //   enemy_num = 2;
            
            
            int[] enemy_box = new int[36];
            int cc = -1;

        //    m1.msbox(s1.data_magagement.dungeon_data.dungeon_normal_enemy_type(s1.battle_run.battle_variable_control.dungeon_type1, 0));

            //出現する可能性のある敵を全部ボックスに詰める
            for (int t1 = 0; t1 < 12; t1++)
            {
                int nm = s1.data_magagement.dungeon_data.dungeon_normal_enemy_type(s1.data_magagement.dungeon_data.dungeon_type1, t1);
                if (nm >= 1 && nm <= 9998)
                {
                    cc++;
                    enemy_box[cc] = nm;
                }

                //debug
                {
                    //    cc = 0;
                    //    enemy_box[cc] = s.dungeon_data.call_dungeon_enemy_type(25);
                }
            }

            /*
            //デバッグ敵出現クラスがある場合は、そこに詰め込む
            if (debug_enemy_box[0] >= 1)
            {
                cc = 0;

                for (int t1 = 0; t1 < nnm; t1++)
                {
                    enemy_box[t1] = 0;
                }

                for (int t1 = 0; t1 < 18; t1++)
                {
                    int nm = debug_enemy_box[t1];
                    if (nm >= 1 && nm <= 9998)
                    {
                        cc++;
                        enemy_box[cc] = nm;
                    }
                }
            }

            /*
            int rare_flag = 0, rare_create_num = 0;

            //レア敵が出現する場合、フラグを立てる
            {
                int dungeon_num = s.dungeon_data.dungeon_num;
                int floor_num = s.dungeon_data.dungeon_floor;
                //   int battle_num = s.dungeon_data.dungeon_battle_num;

                int nt = 0;

                {
                    int flag1 = 1;
                    if (battle_num == s.dungeon_data.boss_middle_battle_1()
                     || battle_num == s.dungeon_data.boss_middle_battle_2()
                     || battle_num == s.dungeon_data.dungeon_battle_num_max_call())
                    {
                        flag1 = 0;
                    }

                    if (flag1 == 1)
                    {
                        {
                            int rand1 = m.rand(999) + 1;

                            if (rand1 <= s.dungeon_data.rare_enemy_apper_per())
                            {
                                rare_flag = 1;
                                rare_create_num = m.rand(2);
                            }
                        }
                    }
                }
            }
            */


            if (cc >= 0)
            {
                int size_all = 0;

                for (int t1 = 0; t1 < enemy_num; t1++)
                {
                    int use_enemy_box = m1.rand(cc);
                    int type1 = enemy_box[use_enemy_box];

                    /*
                    if (rare_flag == 1)
                    {
                        if (rare_create_num == t1)
                        {
                            rare_flag = 2;

                            int r1 = s.dungeon_data.call_dungeon_enemy_type(s.dungeon_data.DUNGEON_RARE_ENEMY_1 - s.dungeon_data.DUNGEON_NORMAL_ENEMY_START);
                            if (r1 >= 1) { race = r1; } else { rare_flag = 0; }
                        }
                    }
                    */


                    if (type1 >= 1)
                    {
                        int w_size = s1.data_magagement.enemy_data.call_enemy_size_w(type1);
                        size_all += w_size;

                        int size_max = s1.battle_run.battle_window_w_call() - 120;
                        if (size_all >= size_max)
                        {
                            size_all -= w_size;
                        }
                        else
                        {
                            /*
                            if (rare_flag == 2)
                            {
                                drop_rare_num = t1;
                                rare_flag = 0;

                                //                            m.msbox("rarecall:"+t1);
                            }
                            */

                            //スロットに代入(生成成功)
                            battle_enemy_slot[t1].type1 = type1;
                        }
                    }
                }
            }else
            {
                m1.msbox("error!");
            }

            /*
            rare_flag = 0;
            */
        }
    }
}
