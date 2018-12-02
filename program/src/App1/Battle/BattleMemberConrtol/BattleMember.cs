using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleMember :SetVoid1
{
    //自分自身の変数番号
    public int num1;

    //場合によっては、保存事項-----------------------------------
    //生存
    public int on;

//    public int type1;//種類
    public int character_link_num1; //使用しているキャラクターの番号

    public int use_skill_flag;

    //-----------------------------------


    public float x1; //描画 x座標
    public float y1; //描画 y座標
    public int w1; //描画 横幅
    public int h1; //描画 縦幅

    //攻撃動作
    public int attack_move_wait_time;
    public int attack_move_wait_max() { return 20; }


    //敵キャラクターのステータス管理
    public BattleMemberStatus battle_member_status;

    public BattleMember(Summary1 s1, int num1)
    {
        this.num1 = num1;

        set1(s1);

        battle_member_status = new BattleMemberStatus(s1, num1);

    //    init1();
    }

    public void init1()
    {
        battle_member_status.init1();

//        type1 = 0;
        character_link_num1 = 0;

        use_skill_flag = 0;


        x1 = 0;
        y1 = 0;

        w1 = 0;
        h1 = 0;

        attack_move_wait_time = 0;

        {
            int left1 = 10;

            int space_left = 10;
            int rect1 = call_window_size();

            int t1 = num1;
            {
                float x103 = left1 + (rect1 + space_left) * t1;
                float y103 = battle_member_dy();

                w1 = 128;
                h1 = w1;
                int type1 = t1 + 1;
                float large1 = (1.0f * rect1 / w1);

                x1 = x103;
                y1 = y103;
            }
        }
    }

    public int call_window_size() { return 108; }

    /*
    public void create1(int type101, int level1, int null_1, int null_2, int null_3, int null_4)
    {
        on = 1;
    //    type1 = type101;
    //    int t1 = type1;

    //    x1 = 0;//後から別のクラスで調整
    //    y1 = 0;// s1.battle_run.battle_enemy_group.battle_enemy_dy() - call_h() / 2;
    }*/

    public void character_link_set_and_create(int character_link_num1)
    {
        this.character_link_num1 = character_link_num1;

        on = 1;

   //     create1(call_type1(), call_level1(), 0, 0, 0, 0);
    }

    
    public int call_attribute_1() { return m1.iover(battle_member_status.call_battle_status(battle_member_status.STATUS_ATTRIBUTE_1), 1, 9999); }
    public int call_attribute_2() { return m1.iover(battle_member_status.call_battle_status(battle_member_status.STATUS_ATTRIBUTE_2), 1, 9999); }

    public int call_mhp() { return battle_member_status.call_battle_status(battle_member_status.STATUS_MHP); }
    public int call_mmp() { return battle_member_status.call_battle_status(battle_member_status.STATUS_MMP); }
    public int call_atk() { return battle_member_status.call_battle_status(battle_member_status.STATUS_ATK); }
    public int call_int() { return battle_member_status.call_battle_status(battle_member_status.STATUS_INT); }

    public int call_level1() { return s1.character_group.call_character_status(character_link_num1, s1.character_group.LEVEL1); }
    public int call_type1() { return s1.character_group.call_character_status(character_link_num1, s1.character_group.TYPE1); }

    public int call_enchantment() { return call_type1(); }
    public int call_skill(int slot) { return s1.character_group.call_character_status(character_link_num1, s1.character_group.SKILL_1 + slot); }
    public int call_skill_point(int slot) { return s1.data_magagement.skill_data.skill_use_need_point(call_skill(slot)); }

    public int call_mana_power() { return battle_member_status.call_mana_power(); }
    public int call_cure_point(int hp_0__mp_1) { return battle_member_status.call_cure_point(hp_0__mp_1); }
    

    //敵キャラクターの表示位置
    public int battle_member_dy()
    {
        int nt = 384 - 4;//316;//332;//340;

        return nt;
    }

    public void attack_move_set()
    {
        attack_move_wait_time = attack_move_wait_max();
    }

    public int call_attack_move_wait_time() { return attack_move_wait_time; }

    public int alive_check() { return on; }

    //行動可能かどうか
    public int move_ok_check()
    {
        int nt1 = 1;// attack_ok_check();

        return nt1;
    }

    public int attack_ok_check()
    {
        int nt1 = 1;

        //攻撃力が10%に満たない場合は、攻撃できない
        {
            if (call_mana_power() < 10) nt1 = 0;
        }

        return nt1;
    }


    






    public void run1()
    {
        if (on != 0)
        {
            //キャラクターウインドウのタッチとスキルの使用
            {
                if (s1.dialog_window1.on_check() == 0)
                {
                    if (s1.battle_run.flow_free_check() == 1)
                    {
                        {
                            int px1 = s1.touch_input.point_x1();
                            int py1 = s1.touch_input.point_y1();

                            int t2 = num1;
                            {
                                if (s1.battle_run.battle_member_group.member_on_check(t2) == 1)
                                {
                                    float x81 = x1;
                                    float y81 = y1;
                                    float w81 = call_window_size();
                                    float h81 = call_window_size();

                                    if (m1.rect_decision(px1, py1, x81, y81, w81, h81) == 1)
                                    {
                                        if (s1.touch_input.pull_check() == 1)
                                        {
                                            //    m1.msbox();

                                            s1.battle_run.battle_member_group_status_control.set_battle_member = t2;

                                            s1.dialog_window1.create1(s1.dialog_window1.DIALOG_SKILL_USE_CHECK, 0, 0, 0);                                           
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            if (attack_move_wait_time >= 1)
            {
                attack_move_wait_time--;
            }
        }
    }

    public void draw1()
    {
        if (on != 0)
        {
            float x2 = x1;
            float y2 = y1;

            //    m1.end();

            //攻撃動作
            {
                if (call_attack_move_wait_time() >= 1)
                {
                    int n3 = attack_move_wait_max() - call_attack_move_wait_time();
                    float r1 = 120.0f;//* 2 / 3;
                    int nn = (int)(m1.sin_r(r1, 60 + 60 * n3 / attack_move_wait_max()) + r1 / 2 * 1.71f);

                    y2 += nn;
                }
            }


            {
                int att1 = call_attribute_1();
                int att2 = call_attribute_2();

                s1.dm1.character_window_draw(x2, y2, call_type1(), 0, 0, att1, att2, 0);
            }

            //ステータスの開示
            int status_draw_flag = 0;
            if (status_draw_flag == 1)
            {
                g1.setfont(0);
                g1.sc(255);

                float x81 = x2;
                float y81 = y2-96;
                int np81 = 24;

                g1.str2("T:" + call_type1(), x81, y81 + np81 * 0);
                g1.str2("L:" + call_level1(), x81, y81 + np81 * 1);
                g1.str2("AT1:" + call_attribute_1(), x81, y81 + np81 * 2);
                g1.str2("AT2:" + call_attribute_2(), x81, y81 + np81 * 3);

                g1.str2("H:" + call_mhp(), x81, y81 + np81 * 5);
                g1.str2("M:" + call_mmp(), x81, y81 + np81 * 6);
                g1.str2("A:" + call_atk(), x81, y81 + np81 * 7);
                g1.str2("I:" + call_int(), x81, y81 + np81 * 8);
            }
        }
    }
}
