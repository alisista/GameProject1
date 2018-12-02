using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleEnemy : SetVoid1
{
    //自分自身の変数番号
    public int num1;

    //場合によっては、保存事項-----------------------------------
    //生存
    public int on;

    public int x1; //描画 x座標
    public int y1; //描画 y座標
    public int w1; //描画 横幅
    public int h1; //描画 縦幅
    public int type1;//敵の種類

    public int defeat_flag;//HPが0になった瞬間に成立 消滅はまだしていない
    public int defeat_wait_time;

    public int skill_slot;

    //-----------------------------------

    //敵キャラの攻撃動作時間
    public int attack_move_wait_time;
    public int attack_move_wait_max() { return 15; }//30;

    //敵キャラのジャンプ
    public int jump_move_wait_time;
    public int jump_move_wait_max() { return 15; }

    //敵キャラが現れた時の処理
    public int appear_move_wait_time;
    public int appear_move_wait_max() { return 20; }

    public int call_attack_move_wait() { return attack_move_wait_time; }
    public int call_jump_move_wait() { return jump_move_wait_time; }
    public int call_appear_move_wait() { return appear_move_wait_time; }


    //敵キャラクターのステータス管理
    public BattleEnemyStatus battle_enemy_status;

    //スキルの管理
    public BattleEnemySkill[] battle_enemy_skill = new BattleEnemySkill[3];



    //HPの値の変化
    public ValueChange value_change;

    //揺れる動作の管理
    public ShakeMove shake_move;

    //ダメージが上に登っていく演出の管理
    public ValueMove value_move;

    //透過情報
    public ClearChange clear_change;


    public BattleEnemy(Summary1 s1,int num1)
    {
        this.num1 = num1;

        set1(s1);

        battle_enemy_status = new BattleEnemyStatus(s1,num1);

        for (int t1 = 0; t1 < 3; t1++)
        {
            battle_enemy_skill[t1] = new BattleEnemySkill(s1, t1);
        }


        value_change = new ValueChange(s1);

        shake_move = new ShakeMove(s1);

        value_move = new ValueMove(s1);

        clear_change = new ClearChange(s1);        
    }

    public void init1()
    {
        on = 0;

        x1 = 0;
        y1 = 0;

        w1 = 0;
        h1 = 0;

        type1 = 0;


        defeat_flag = 0;
        defeat_wait_time = 0;

        attack_move_wait_time = 0;
        jump_move_wait_time = 0;
        appear_move_wait_time = 0;

        skill_slot = 0;


        /*
        if (init_flag == 0)
        {
            battle_enemy_status = new BattleEnemyStatus();
            battle_enemy_status.set(m, g, im, input, s);

        }*/

        battle_enemy_status.init1();

        skill_reset();


        {
            {
                value_change.init1();

                shake_move.init1();

                value_move.init1();

                clear_change.init1();
            }


           
        }
    }


    public void skill_reset()
    {
        skill_slot = 0;

        for (int t1 = 0; t1 < 3; t1++)
        {
            battle_enemy_skill[t1].init1();
        }
    }






    public void create(int type101, int level1, int null_1, int null_2, int null_3, int null_4)
    {
        on = 1;
        type1 = type101;
        int t1 = type1;

        {
            battle_enemy_status.init1();
        }

        x1 = 0;//後から別のクラスで調整
        y1 = s1.battle_run.battle_enemy_group.battle_enemy_dy() - call_h() / 2;
    }


    public int call_dx()
    {
        return x1;
    }

    public int call_dy()
    {
        return y1;
    }


    //そのキャラクターの横幅を教える 変数にもメモ
    public int call_w()
    {
        //横幅が不明の時は生成
        if (w1 == 0)
        {
            int type101 = type1;
            int slot1 = s1.data_magagement.enemy_draw_point.load_slot(type101);
            ImageData1 im1 = s1.battle_run.battle_enemy_group.image_save_enemy.loadcheck1(type101);

            w1 = im1.call_w();
            w1 = (int)(1.0f * w1 * s1.data_magagement.enemy_draw_point.enemy_draw_point_child[slot1].enemy_large);            
        }

        return w1;
    }

    public int call_h()
    {
        //横幅が不明の時は生成
        if (h1 == 0)
        {
            int type101 = type1;
            int slot1 = s1.data_magagement.enemy_draw_point.load_slot(type101);
            ImageData1 im1 = s1.battle_run.battle_enemy_group.image_save_enemy.loadcheck1(type101);

            h1 = im1.call_h();
            h1 = (int)(1.0f * h1 * s1.data_magagement.enemy_draw_point.enemy_draw_point_child[slot1].enemy_large);
        }

        return h1;
    }


    //生存確認
    public int alive_check()
    {
        int nt1 = 1;

        if (hp_check() >= 1 && on != 0)//&& defeat_flag == 0)
        {
            nt1 = 1;
        }
        else
        {
            nt1 = 0;
        }

        return nt1;
    }

    public int hp_check()
    {
        return battle_enemy_status.call_battle_status(battle_enemy_status.STATUS_HP);
    }

    public void defeat_set()
    {
        if (defeat_flag == 0)
        {
            defeat_flag = 1;
            defeat_wait_time = 30;

            battle_enemy_status.defeat_set();

            if (s1.battle_run.battle_enemy_group.alive_num_check() <= 1)
            {
                s1.battle_run.battle_enemy_group.target_lock_num = -1;
            }
        }
    }



    //敵キャラクターにダメージが直接発生した場合
    public void damage_set(int damage_num, int skill_point_cure_flag,int free1)
    {
        //最大以上は防止
        {
            int min1= -(battle_enemy_status.call_battle_status(battle_enemy_status.STATUS_MHP) - battle_enemy_status.call_battle_status(battle_enemy_status.STATUS_HP));
            int max1 = battle_enemy_status.call_battle_status(battle_enemy_status.STATUS_HP);

            damage_num = m1.iover(damage_num, min1, max1);
        }

        //実際のダメージ計算
        {
            battle_enemy_status.damage_set(damage_num);
            //hp_check();

            if (hp_check() <= 0) defeat_set();
        }

        /*

        //シールドがあってHPが75%を下回ると壊れる
        {
            if (battle_enemy_status.shield_flag == 1)
            {
                //   if (call_hp_per() <= 50)
                if (call_hp_per3() <= 500)//750)
                {
                    battle_enemy_status.shield_flag = 0;

                    s.so.se_play(s.so.SE_BATTLE_SHIELD_BREAK);


                    {
                        int x1 = x;
                        int y1 = y - call_h() / 2;
                        int color1 = battle_enemy_status.call_shield_attribute();

                        
                     //   int size1 = s.battle_enemy_group.battle_enemy[num].call_w();
                     //   int size2 = s.battle_enemy_group.battle_enemy[num].call_h();

                     //   if (size1 < size2) size1 = size2;
                        

                        {
                            //    int la1 = 100 * size1 / 128;

                            int color = color1;
                            s.effect_group.create(x1, y1, s.effect_group.ENEMY_SHIELD_BREAK, 100, color, 0, 0);
                        }
                    }
                }
            }
        }
        */

        {
            int min1 = -battle_enemy_status.call_battle_status(battle_enemy_status.STATUS_MHP);
            int max1 = battle_enemy_status.call_battle_status(battle_enemy_status.STATUS_MHP);

            value_change.value1_add(damage_num, min1, max1);            
        }
        

        /*
        //敵にダメージを与えた時のみ、SPに回復が行われる
        if (damage_num >= 1)// && skill_point_cure_flag>=1)
        {
            long damage_per2 = (long)10000 * damage_num / battle_enemy_status.status_box[battle_enemy_status.STATUS_MHP];
            int defeat_flag = 0;

            if (battle_enemy_status.status_box[battle_enemy_status.STATUS_HP] <= 0) { defeat_flag = 1; }

            s.gm.skill_point_cure((int)damage_per2, battle_enemy_status.call_boss_type(), defeat_flag, 0);
        }
        */
    }




    //damage_type-HP回復とか MPダメージとか another_type-ランクダウン文字とかの呼び出し
    public void damage_draw_effect_set(int damage_num, int damage_type, int week_1__resist_2, int another_type, int draw_num_type, int attack_attribute, int free2)
    {
        float x7 = x1 - 4;
        float y7 = y1 - call_h() * 0 - 12 + call_h() * 1 / 2;//y - 120 * 2 / 3;        

        {
            int n1 = 24;//24;

            //    m1.msbox("Effect!");

            int effect_type1 = s1.effect_group.DAMAGE_NUM1;
            if (week_1__resist_2 == 1) { effect_type1 = s1.effect_group.DAMAGE_NUM1_LARGE; }
            if (week_1__resist_2 == 2) { effect_type1 = s1.effect_group.DAMAGE_NUM1_SMALL; }

            s1.effect_group.create(x7 + 4, y7 + value_move.call_y(), effect_type1, attack_attribute, damage_num, 0, 120, 0);

            if (week_1__resist_2 == 0) { value_move.value_count_draw_y_add(-(16 + 10)); }
            if (week_1__resist_2 == 1) { value_move.value_count_draw_y_add(-(24 + 10)); }
            if (week_1__resist_2 == 2) { value_move.value_count_draw_y_add(-(12 + 10)); }
            
            shake_move.shake_set(1, 1);
        }

        /*
        //ダメージの場合
        if (another_type == 0)
        {
            //week_1__resist_2
            //attack_attribute

            //   week_1__resist_2 = 2;


            int tr = -1;

            //     draw_num_type = 0;

            if (week_1__resist_2 == 0)
            {
                tr = s.effect_group.create(x7, y7 + damage_count_draw_y, s.effect_group.DAMAGE_NUM, attack_attribute, damage_num, 0, 0);
                s.effect_group.effect[tr].type4 = draw_num_type;

                damage_count_draw_y -= 16 + 10;
            }

            if (week_1__resist_2 == 1)
            {
                tr = s.effect_group.create(x7, y7 + damage_count_draw_y, s.effect_group.DAMAGE_NUM_LARGE, attack_attribute, damage_num, 0, 0);
                s.effect_group.effect[tr].type4 = draw_num_type;

                damage_count_draw_y -= 24 + 10;
            }

            if (week_1__resist_2 == 2)
            {
                tr = s.effect_group.create(x7, y7 + damage_count_draw_y, s.effect_group.DAMAGE_NUM_MINI, attack_attribute, damage_num, 0, 0);
                s.effect_group.effect[tr].type4 = draw_num_type;

                damage_count_draw_y -= 12 + 10;
            }


            //    m.msbox(""+tr + "," + s.efg.ef[tr].type4);
        }
        else
        {
            //    //それ以外の場合
            //    s.efg.create(x7 + 4, y7 - n1 * damage_count, s.efg.DAMAGE_STR, 0, damage_num, 0, 0);
        }

        //    s.efg.create(300, 300, s.efg.DAMAGE_NUM, 0, 120, 0, 0);
        */

        
        
    }//damage_draw_effect_set


    public void skill_slot_next() { skill_slot += 1; }







    public void attack_move_set()
    {
        attack_move_wait_time = attack_move_wait_max();
    }

    public void jump_move_set()
    {
        jump_move_wait_time = jump_move_wait_max();
    }

    public void appear_move_set(int tm_wait)
    {
        appear_move_wait_time = appear_move_wait_max() + tm_wait;
    }


    public int call_attack_move_wait_time() { return attack_move_wait_time; }

    public void now_attribute_check()
    {
        if (call_hp() < call_mhp() / 2) { battle_enemy_status.status_box[battle_enemy_status.NOW_ATTRIBUTE] = call_attribute_2(); }
    }


    public String call_name() { return s1.data_magagement.enemy_data.enemy_name(call_type1()); }

    //   public int call_attribute_1() { return battle_enemy_status.status_box[battle_enemy_status.ATTRIBUTE_1]; }
    //   public int call_attribute_2() { return battle_enemy_status.status_box[battle_enemy_status.ATTRIBUTE_2]; }

    public int call_type1() { return type1; }

    public int call_attribute_1() { return battle_enemy_status.call_battle_status(battle_enemy_status.STATUS_ATTRIBUTE_1); }
    public int call_attribute_2() { return battle_enemy_status.call_battle_status(battle_enemy_status.STATUS_ATTRIBUTE_2); }

    public int call_now_attribute() { return battle_enemy_status.call_battle_status(battle_enemy_status.NOW_ATTRIBUTE); }

    public int call_mhp() { return battle_enemy_status.call_battle_status(battle_enemy_status.STATUS_MHP); }
    public int call_hp() { return hp_check(); }
    //   public int call_mmp() { return battle_enemy_status.call_battle_status(battle_enemy_status.STATUS_MMP); }

    public int call_atk() { return battle_enemy_status.call_battle_status(battle_enemy_status.STATUS_ATK); }

    public void run1()
    {



        {
            {
                value_change.run1();

                shake_move.run1();

                value_move.run1();

                clear_change.run1();
            }
        }

        //タイマー関連
        {
            if (attack_move_wait_time >= 1)
            {
                attack_move_wait_time--;
            }
            if (jump_move_wait_time >= 1)
            {
                jump_move_wait_time--;
            }

            if (appear_move_wait_time >= 1)
            {
                appear_move_wait_time--;
            }
        }


        if (defeat_wait_time > 0)
        {
            defeat_wait_time--;

            if (defeat_wait_time == 0)
            {
                clear_change.change_set(255, -8);
            }
        }
    }//run1

    public void draw1()
    {
        if (on != 0)
        {
            clear_change.clear_call();

            int x3 = x1 - call_w() / 2;
            int y3 = y1 - call_h() / 2;

            int appear_clear_flag=0;

            {
                int x2 = x1 + (int)shake_move.call_move_x();
                int y2 = y1 + (int)shake_move.call_move_y();

                float large_meg = 1.0f;


                //攻撃動作                            
                if (call_attack_move_wait_time() >= 1)
                {
                    {
                        int nn = 0;

                        int attack_move_wait_max2 = attack_move_wait_max();

                        int n3 = attack_move_wait_max2 - call_attack_move_wait_time();//*2;
                        if (n3 <= 0) n3 = 0;
                        float r1 = 150.0f;
                        nn = (int)(m1.sin_r(r1, 60 + 60 * n3 / attack_move_wait_max2) + r1 / 2 * 1.71f);

                        large_meg -= 0.0025f * nn;
                    }

                    {
                        float r2 = 8.0f;
                        int naa = 0 + (int)(m1.sin_r(r2, 180 * attack_move_wait_time / attack_move_wait_max()));

                        y2 += -naa;
                    }
                }


                //出現動作
                if (call_appear_move_wait() >= 1 && call_appear_move_wait() <= appear_move_wait_max())
                {
                    float r1 = 24.0f;
                    int naa = 0 + (int)(m1.sin_r(r1, 180 * call_appear_move_wait() / appear_move_wait_max()));

                    y2 += naa;

                    int clear1 = m1.iover(255 * (appear_move_wait_max() - call_appear_move_wait()) / appear_move_wait_max(), 0, 255);
                    g1.setClear2(clear1);
                    appear_clear_flag = 1;

                    large_meg -= 0.20f * (1.0f - (0.0f + appear_move_wait_max() - call_appear_move_wait()) / appear_move_wait_max());
                }
                else if (call_appear_move_wait() > appear_move_wait_max())
                {
                    g1.setClear2(0);
                    appear_clear_flag = 1;
                }


                //ロックオン
                int lock_flag = 0;
                {
                    if (num1 == s1.battle_run.battle_enemy_group.target_lock_num)
                    {
                        lock_flag = 1;
                    }
                }


                //敵の描画
                {
                    s1.dm1.battle_enemy_draw(x2, y2, type1, 0, 1, 0, lock_flag, large_meg);
                }
                
            }
            


            //HPゲージ
            {
                int w2 = m1.iover(call_w() - 32, 24, 720);

                int x10 = x1 - w2 / 2;
                int y10 = y1 + 16 - 2 + call_h() / 2;
                int h10 = 12;//16;

                {
                    int double_flag = 0;

                    {
                        if (battle_enemy_status.call_boss_type() >= 1) { double_flag = 1; }
                        if (call_attribute_1() != call_attribute_2()) { double_flag = 1; }
                    }

                    if (double_flag != 0)
                    {
                        //2ゲージの手法。未使用
                        /*
                        {
                            int w5 = s1.battle_run.battle_enemy_group.hp_gage_call(num1, w2);
                            float hp_per3 = 100.0f * s1.battle_run.battle_enemy_group.hp_gage_call(num1, w2) / w2;

                            {
                                int att1 = call_now_attribute();
                                int att2 = call_attribute_2();

                                int np5 = (int)(1.0f * (hp_per3 - 0) * 2);
                                np5 = m1.iover(np5, 0, 100);
                                s1.dm1.gauge_window_draw1(x10, y10, w2, (int)(np5), att2, h10, 1, 0);

                                if (hp_per3 >= 50) { s1.dm1.gauge_window_draw1(x10, y10, w2, (int)(1.0f * (hp_per3 - 50) * 2) + 100, att1, h10, 1, 1); }


                                s1.dm1.gauge_window_draw1(x10, y10, w2, 0 * w5 / w2, att1, h10, 0, 1);
                            }
                        }
                        */

                        //1ゲージを半分ずつ
                        {
                            int w5 = s1.battle_run.battle_enemy_group.hp_gage_call(num1, w2);
                            float hp_per3 = 100.0f * s1.battle_run.battle_enemy_group.hp_gage_call(num1, w2) / w2;

                            {
                                int att1 = call_now_attribute();
                                int att2 = call_attribute_2();
                                int att1_2 = call_attribute_1();

                                int np5 = (int)(1.0f * (hp_per3 - 0) * 2);
                                np5 = m1.iover(np5, 0, 100);
                                s1.dm1.gauge_window_draw1(x10, y10, w2 / 2, (int)(np5), att2, h10, 1, 0);
                                s1.dm1.gauge_window_draw1(x10, y10, w2 / 2, (int)(np5), att2, h10, 1, 1);

                            //    if (hp_per3 >= 50)
                                {
                                    s1.dm1.gauge_window_draw1(x10 + w2 / 2, y10, w2 / 2, (int)(1.0f * (hp_per3 - 50)) * 2, att1_2, h10, 1, 0);
                                    s1.dm1.gauge_window_draw1(x10 + w2 / 2, y10, w2 / 2, (int)(1.0f * (hp_per3 - 50)) * 2, att1, h10, 1, 1);
                                }


                                s1.dm1.gauge_window_draw1(x10, y10, w2, 0 * w5 / w2, att1, h10, 0, 1);
                            }
                        }
                    }
                    else
                    {

                        int w5 = s1.battle_run.battle_enemy_group.hp_gage_call(num1, w2);

                        //    g1.sc(255);
                        //    g1.str2("" + battle_enemy_status.call_battle_status(battle_enemy_status.STATUS_HP), x1, y1);

                        {
                            int att1 = call_attribute_1();

                            s1.dm1.gauge_window_draw1(x10, y10, w2, 100 * w5 / w2, att1, h10, 0, 0);
                        }
                    }
                }
            }

            //出現時の透過を元に戻す
            if (appear_clear_flag == 1)
            {
                g1.setClear2_re();
            }


            //デバッグステータス
            int status_draw_flag = 0;
            if (status_draw_flag == 1)
            {
                g1.setfont(0);
                g1.sc(255);

                float x81 = x3;
                float y81 = 40;//y3 - 140;
                int np81 = 24;

                g1.str2("N:" + call_name(), x81, y81 + np81 * 0);

                //     g1.str2("T:" + call_type1(), x81, y81 + np81 * 0);
                //     g1.str2("L:" + call_level1(), x81, y81 + np81 * 1);
                g1.str2("AT1:" + call_attribute_1(), x81, y81 + np81 * 2);
                g1.str2("AT2:" + call_attribute_2(), x81, y81 + np81 * 3);
                g1.str2("NAT:" + call_now_attribute(), x81, y81 + np81 * 4);

                g1.str2("S1:" + battle_enemy_skill[0].skill_attack_check(), x81, y81 + np81 * 6);
                g1.str2("S2:" + battle_enemy_skill[1].skill_attack_check(), x81, y81 + np81 * 7);
                g1.str2("S3:" + battle_enemy_skill[2].skill_attack_check(), x81, y81 + np81 * 8);

                //    g1.str2("H:" + call_mhp(), x81, y81 + np81 * 5);
                //    g1.str2("M:" + call_mmp(), x81, y81 + np81 * 6);
                //    g1.str2("A:" + call_atk(), x81, y81 + np81 * 7);
                //    g1.str2("I:" + call_int(), x81, y81 + np81 * 8);

                {
                    g1.sc(255);
                    g1.drawRect(x3, y3, call_w(), call_h(), 0, 0);
                }
            }

            clear_change.clear_call_re();
        }
    }
}
