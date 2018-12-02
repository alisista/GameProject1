using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//チームのステータス管理
public class BattleMemberGroupStatusControl : SetVoid1
{
    public int max1() { return 6; }

    //保存事項------------------------
    public int hp1;
    public int mp1;

    public int now_enchant1;
    public int now_enchant2;
    //------------------------

    public int set_enchant1;
    public int set_enchant2;

    public int set_battle_member;
    public int set_battle_member_skill_slot;
    public int now_skill1;

    public int battle_command;

    //HPの値の変化
    public ValueChange value_change1_1;
    public ValueChange value_change1_2;

    //MPの値の変化
    public ValueChange value_change2_1;
    public ValueChange value_change2_2;

    //HPダメージが上に登っていく演出の管理
    public ValueMove value_move1;

    //MPダメージが上に登っていく演出の管理
    public ValueMove value_move2;

    //HPの揺れる動作の管理
    public ShakeMove shake_move1;

    //MPの揺れる動作の管理
    public ShakeMove shake_move2;

    //ステータス変動に伴うHPとMPのカウンター変動
    public int hp_memo;
    public int mhp_memo;
    public int mp_memo;
    public int mmp_memo;


    public BattleMemberGroupStatusControl(Summary1 s1)
    {
        set1(s1);

        value_change1_1 = new ValueChange(s1);
        value_change1_2 = new ValueChange(s1);
        value_change2_1 = new ValueChange(s1);
        value_change2_2 = new ValueChange(s1);

        value_move1 = new ValueMove(s1);
        value_move2 = new ValueMove(s1);

        shake_move1 = new ShakeMove(s1);
        shake_move2 = new ShakeMove(s1);
    }
    
    public void init1()
    {
    //    m1.msbox(hp1);

        {
            now_enchant1 = 0;
            now_enchant2 = 3;

            set_enchant1 = now_enchant1;
            set_enchant2 = now_enchant2;

            set_battle_member = 0;
            set_battle_member_skill_slot = 0;
            now_skill1 = 0;

            battle_command = 0;
        }

        {
            hp1 = mhp_call();// 1200;
            mp1 = mmp_call();//400;
        }

        {
            hp_memo = 0;
            mhp_memo = 0;
            mp_memo = 0;
            mmp_memo = 0;
        }

        value_change1_1.init1();
        value_change1_2.init1();
        value_change2_1.init1();
        value_change2_2.init1();

        value_move1.init1();
        value_move2.init1();

        shake_move1.init1();
        shake_move2.init1();
    }

    public int hp_call() { return hp1; }
    public int mp_call() { return mp1; }

    public int mhp_call()
    {
        int nt = 0;

        for (int t1 = 0; t1 < max1(); t1++)
        {
            if (s1.battle_run.battle_member_group.battle_member[t1].on != 0)
            {
                int nt2 = s1.battle_run.battle_member_group.battle_member[t1].call_mhp();
                
                nt += nt2;

            }
        }

        nt = m1.iover(nt, 1, 99999999);

        return nt;
    }

    public int mmp_call()
    {
        int nt = 0;

        for (int t1 = 0; t1 < max1(); t1++)
        {
            if (s1.battle_run.battle_member_group.battle_member[t1].on != 0)
            {
                int nt2 = s1.battle_run.battle_member_group.battle_member[t1].call_mmp();
                
                nt += nt2;
            }
        }

        nt = m1.iover(nt, 1, 99999999);

        return nt;
    }

    public int value_hp_call() { return hp_call() + value_change1_1.call_value1(); }
    public int value_mp_call() { return mp_call() + value_change1_2.call_value1(); }
    public int value_mhp_call() { return mhp_call() + value_change2_1.call_value1(); }
    public int value_mmp_call() { return mmp_call() + value_change2_2.call_value1(); }




    //味方パーティにダメージが直接発生した場合
    public void hp_damage_set(int damage_num, int free1, int free2)
    {
        //最大以上は防止
        {
            int min1 = - (mhp_call() - hp_call());
            int max1 = hp_call();

            //int min1 = -hp_call();
            //int max1 = (mhp_call() - hp_call());

            damage_num = m1.iover(damage_num, min1, max1);
        }

        //実際のダメージ計算
        {
            damage_set(damage_num);

        //    if (hp_check() <= 0) defeat_set();
        }

        {
            int min1 = -(mhp_call());
            int max1 = +(mhp_call());

            value_change1_1.value1_add(damage_num, min1, max1);
        }
    }
    

    public int call_dx(int type)
    {
        int nt = 0;

        if (type == 0) { nt = 32; }
        if (type == 1) { nt = 76; }
        if (type == 2) { nt = 76 + 320; }

        return nt;
    }

    public int call_dy(int type)
    {
        int nt = 518;

        return nt;
    }


    //damage_type-HP回復とか MPダメージとか                未使用 another_type-ランクダウン文字とかの呼び出し
    public void damage_draw_effect_set(int damage_num, int week_1__resist_2, int hp0_or_mp1, int attack_attribute, int shake_flag)
    {
        float x7 = call_dx(1) + 4 + 270 / 2;
        float y7 = call_dy(1) - 12 - 4;

        int y70 = (int)value_move1.call_y();

        if (hp0_or_mp1 == 1) { x7= call_dx(2) + 4 + 270 / 2; y70 = (int)value_move2.call_y(); }


        {
            //    m1.msbox("Effect!");

            int effect_type1 = s1.effect_group.DAMAGE_NUM1;
            if (week_1__resist_2 == 1) { effect_type1 = s1.effect_group.DAMAGE_NUM1_LARGE; }
            if (week_1__resist_2 == 2) { effect_type1 = s1.effect_group.DAMAGE_NUM1_SMALL; }

            s1.effect_group.create(x7 + 4, y7 + y70, effect_type1, attack_attribute, m1.abs(damage_num), 0, 120, 0);

            int n1 = 16 + 10, n2 = 24 + 10, n3 = 12 + 10;

            if (hp0_or_mp1 == 0)
            {
                if (week_1__resist_2 == 0) { value_move1.value_count_draw_y_add(-n1); }
                if (week_1__resist_2 == 1) { value_move1.value_count_draw_y_add(-n2); }
                if (week_1__resist_2 == 2) { value_move1.value_count_draw_y_add(-n3); }
            }
            if (hp0_or_mp1 == 1)
            {
                if (week_1__resist_2 == 0) { value_move2.value_count_draw_y_add(-n1); }
                if (week_1__resist_2 == 1) { value_move2.value_count_draw_y_add(-n2); }
                if (week_1__resist_2 == 2) { value_move2.value_count_draw_y_add(-n3); }
            }

            if (damage_num >= 1 && shake_flag != 0)
            {
                if (hp0_or_mp1 == 0) { shake_move1.shake_set(1, 1); }
                if (hp0_or_mp1 == 1) { shake_move2.shake_set(1, 1); }
            }
        }

    }//damage_draw_effect_set

    public void damage_set(int damage_num)
    {
        hp1 -= damage_num;
    }

    //HPとMPの上限を確認
    public void hp_and_mp_min_max_check()
    {
        hp1 = m1.iover(hp1, 0, mhp_call());
        mp1 = m1.iover(mp1, 0, mmp_call());
    }

    //MHPやMMPが変わった際、パラメータがフレームごとに変化 //flow_num 0でコピー //1で実行
    public void mhp_and_mmp_counter_change(int flow_num)
    {
        int min1 = -999999999;
        int max1 = 999999999;

        if (flow_num == 0)
        {
            hp_memo = hp_call();
            mhp_memo = mhp_call();
            mp_memo = mp_call();
            mmp_memo = mmp_call();
        }

        if (flow_num == 1)
        {
            s1.battle_run.battle_member_group_status_control.hp_and_mp_min_max_check();

            value_change1_1.value1_add((hp_memo - hp_call()), min1, max1);
            value_change2_1.value1_add((mhp_memo - mhp_call()), min1, max1);

            value_change1_2.value1_add((mp_memo - mp_call()), min1, max1);
            value_change2_2.value1_add((mmp_memo - mmp_call()), min1, max1);
        }
    }

    public void hp_add(int num1)
    {
        //最大以上は防止
        {
            int min1 = -hp_call();
            int max1 = (mhp_call() - hp_call());
            num1 = m1.iover(num1, min1, max1);

            hp1 += num1;

            min1 = -(mhp_call());
            max1 = +(mhp_call());

            value_change1_1.value1_add(-num1, min1, max1);
        }

        hp_and_mp_min_max_check();
    }

    public void mp_add(int num1)
    {
        //最大以上は防止
        {
            int min1 = -mp_call();
            int max1 = (mmp_call() - mp_call());
            num1 = m1.iover(num1, min1, max1);

            mp1 += num1;

            min1 = -(mmp_call());
            max1 = +(mmp_call());

            value_change1_2.value1_add(-num1, min1, max1);
        }

        hp_and_mp_min_max_check();
    }


    public void hp_add2(int num1)
    {
        //s1.battle_run.battle_member_group_status_control.
        hp_add(num1);

        int week_1_and_resist_2 = 0;
        damage_draw_effect_set(-num1, week_1_and_resist_2, 0, 100, 0);
    }

    public void mp_add2(int num1)
    {
        mp_add(num1);

        int week_1_and_resist_2 = 0;
        damage_draw_effect_set(-num1, week_1_and_resist_2, 1, 101, 0);
    }


    public void run1()
    {
        value_change1_1.run1();
        value_change1_2.run1();
        value_change2_1.run1();
        value_change2_2.run1();

        value_move1.run1();
        value_move2.run1();

        shake_move1.run1();
        shake_move2.run1();
    }

    public void draw1()
    {
        {
            value_change1_1.draw1();
            value_change1_2.draw1();
            value_change2_1.draw1();
            value_change2_2.draw1();

            value_move1.draw1();
            value_move2.draw1();

            shake_move1.draw1();
            shake_move2.draw1();
        }

        {
            //HP
            {
                //    g1.sc(32);
                //    g1.drawRect(0, y4 + y10-24, 720, 48, 0, 1);

                int w1 = 720;
                g1.drawImage2(ic1.loadcheck(4, 2, 0), 0, call_dy(0) - 24 - 4, w1, 32);
                g1.sc(16);
                g1.drawRect(0, call_dy(0) - 24 + 28, 720, 48, 0, 1);

                {
                    int x77 = call_dx(0);
                    int y77 = call_dy(0) + 2;

                    int att1 = s1.battle_run.battle_member_group.call_member_attribute() ;
                    s1.dm1.attribute_draw(x77, y77, att1, 0.8f, 0, 0);
                }

                for (int t1 = 0; t1 <= 1; t1++)
                {
                    int n1 = 320;

                    int x70 = call_dx(1) + (int)shake_move1.call_move_x() / 2;
                    int x71 = call_dx(2) + (int)shake_move2.call_move_x() / 2;

                    int y70 = call_dy(1) + (int)shake_move1.call_move_y() / 2;
                    int y71 = call_dy(2) + (int)shake_move2.call_move_y() / 2;

                    g1.sc(240);

                    //     g1.drawRect(20, y4 + y10, 360 - 40, 22 - y10, 0, 0);
                    if (t1 == 0)
                    {
                        int num1 = value_hp_call();
                        int num2 = value_mhp_call();

                        s1.dm1.gauge_window_draw1(x70, y70, n1 - 40, 100 * num1 / num2, 101, 12, 0, 0);
                    }


                    if (t1 == 1)
                    {
                        int num1 = value_mp_call();
                        int num2 = value_mmp_call();

                        s1.dm1.gauge_window_draw1(x71, y71, n1 - 40, 100 * num1 / num2, 102, 12, 0, 0);
                    }

                    g1.sc(240);

                    int nt2 = 270;
                    int nt3 = 120;

                    g1.setfont(g1.FONT_1_SMALL_STR);

                    int str_w1 = 10;

                    if (t1 == 0)
                    {
                        int num1 = value_hp_call();
                        int num2 = value_mhp_call();
                        int length1 = m1.strbyte("" + num1) + m1.strbyte("" + num2);

                        g1.str2("HP ", x70 + 8, y70 - 10);
                        //    g1.str2("7200 / 7200", x70 + 8 + nt2 - nt3, y4);
                        g1.str2("" + num1 + " / " + num2, x70 + 8 + nt2 - nt3 + str_w1 * (6 - (length1 - 2)), (y70 - 10));

                    //    g1.str2("7200 / 700", x70 + 8 + nt2 - nt3 + str_w1 * 1, (y70 - 10) - 20);
                    //    g1.str2("720 / 70", x70 + 8 + nt2 - nt3 + str_w1 * 3, (y70 - 10) - 40);
                    //    g1.str2("0 / 0", x70 + 8 + nt2 - nt3 + str_w1 * 6, (y70 - 10) - 60);
                    }

                    if (t1 == 1)
                    {
                        int num1 = value_mp_call();
                        int num2 = value_mmp_call();
                        int length1 = m1.strbyte("" + num1) + m1.strbyte("" + num2);

                        g1.str2("MP ", x71 + 8, y71 - 10);
                        g1.str2("" + num1 + " / " + num2, x71 + 8 + nt2 - nt3 + str_w1 * (6 - (length1 - 2)), (y71 - 10));
                    }

                    g1.setfont_re();
                }
            }
        }
    }//draw1()
}
