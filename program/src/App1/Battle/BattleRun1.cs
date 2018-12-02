using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleRun1 :SetVoid1
{
    public int battle_window_w_call() { return 720; }
    public int battle_window_center_x_call() { return 360; }

    public int logo_center_y() { return 180; }

    public int battle_start_wait_tm;
    public int battle_start_wait_max() { return 30; }

    public BattleFlow1 battle_flow1;
    
    public BattleBg battle_bg;
    public BattleMenu battle_menu;

    public BattleMemberGroup battle_member_group;
    public BattleEnemyGroup battle_enemy_group;
    //    public EnemyDrawPoint

    public BattleMemberGroupAttackRun battle_member_group_attack_run;
    public BattleEnemyGroupAttackRun battle_enemy_group_attack_run;
    public BattleEnemySkillRun battle_enemy_skill_run;

    public BattleMemberGroupStatusControl battle_member_group_status_control;
    public BattleEnchantment battle_enchantment;
    public BattleSkill battle_skill;

    public BattleMessageWindow battle_message_window;

    public BattleMana battle_mana;




    public BattleVariableControl battle_variable_control;//戦闘をプレイするにあたって、重要な変数の管理

    /*
    //保存事項------------
    public int enchant1;
    public int enchant2;

    //------------
    */

    public BattleRun1(Summary1 s1)
    {
        set1(s1);

    //    long time1 = m1.get_time();

        battle_flow1 = new BattleFlow1(s1);

        battle_bg = new BattleBg(s1);
        battle_menu = new BattleMenu(s1);

        battle_member_group = new BattleMemberGroup(s1);
        battle_enemy_group = new BattleEnemyGroup(s1);

        battle_member_group_attack_run = new BattleMemberGroupAttackRun(s1);
        battle_enemy_group_attack_run = new BattleEnemyGroupAttackRun(s1);
        battle_enemy_skill_run = new BattleEnemySkillRun(s1);

        battle_member_group_status_control = new BattleMemberGroupStatusControl(s1);
        battle_enchantment = new BattleEnchantment(s1);
        battle_skill = new BattleSkill(s1);
        battle_mana = new BattleMana(s1);






        battle_variable_control = new BattleVariableControl(s1);

        battle_message_window = new BattleMessageWindow(s1);

    //    m1.msbox((m1.get_time() - time1));
    }
    
    public void init1()
    {
        //long time1 = m1.get_time();

        battle_flow1.init1();

        //      battle_variable_control.init1();

        {
            if (s1.app_variable1.stage_type1 >= 0)
            {
                if (s1.app_variable1.stage_type2 >= 0)
                {
                    s1.data_magagement.dungeon_data.dungeon_type1 = s1.app_variable1.stage_type2;
                }
            }
        }


        battle_bg.init1();
        //   long time1 = m1.get_time(); 
        battle_menu.init1();
     //   m1.msbox((m1.get_time() - time1));

        //    long time1 = m1.get_time();

        battle_member_group.init1();

    //    m1.msbox((m1.get_time() - time1));

        //   long time2 = m1.get_time();

        battle_enemy_group.init1();//45f

     //   m1.msbox((m1.get_time() - time2));


        battle_member_group_attack_run.init1();
        battle_enemy_group_attack_run.init1();
        battle_enemy_skill_run.init1();

    //    long time2 = m1.get_time();

    //    battle_member_group_status_control.init1();

    //    int nt1 = battle_member_group_status_control.mhp_call();
    //    m1.msbox(nt1);

        battle_enchantment.init1();
        battle_skill.init1();
        battle_mana.init1();

        battle_member_group_status_control.init1();

    //    int nt2 = battle_member_group_status_control.mhp_call();
    //    m1.msbox(nt2);


        //音楽の再生テスト
        {
            //    s1.bgm_operation.play_loop_bgm(s1.bgm_operation.BGM_BATTLE_1);

            //   s1.bgm_operation.play_loop_bgm(s1.data_magagement.dungeon_data.dungeon_normal_battle_bgm_num());            
        }

        
        if (s1.data_magagement.dungeon_data.dungeon_battle_num == 0)
        {
            battle_start();
        }



            battle_message_window.init1();

     //   m1.msbox((m1.get_time() - time2));

        //    m1.msbox((m1.get_time() - time1));

        //    s1.data_magagement.character_data.status_call(1, s1.data_magagement.character_data.STATUS_MHP);
    }


    public void battle_start()
    {
        battle_start_wait_tm = battle_start_wait_max();

        battle_flow1.battle_flow_set(0);

        s1.fade_run.create1(s1.fade_run.FADE_WAIT_60, 0, 0, 0);



    }



    public void attack_start()
    {
        battle_flow1.battle_flow_set(battle_flow1.BATTLE_MEMBER_ATTACK_CALL);
    }

    public void battle_finish()
    {

    }


    public int flow_free_check()
    {
        int nt = 0;

        if (s1.battle_run.battle_flow1.battle_flow_type_check(s1.battle_run.battle_flow1.BATTLE_FLOW_FREE) == 1)
        {
            if (s1.dialog_window1.on == 0)
            {
                nt = 1;
            }
        }

        return nt;
    }


    public void lock_on_update()
    {
        //ロックオンの設定
        if (flow_free_check()==1 && battle_enemy_group.alive_num_check()>=2)
        {
            //敵をタッチすると、ロックオンできる
            if (s1.touch_input.pull_check() == 1)
            {
                int px1 = s1.touch_input.point_x1();
                int py1 = s1.touch_input.point_y1();

                int flag1 = 0;
                
                {
                    for (int t1 = 0; t1 < s1.battle_run.battle_enemy_group.max(); t1++)
                    {
                        if (s1.battle_run.battle_enemy_group.battle_enemy[t1].alive_check() == 1)
                        {
                            int x11 = (int)s1.battle_run.battle_enemy_group.battle_enemy[t1].call_dx() - s1.battle_run.battle_enemy_group.battle_enemy[t1].call_w() / 2;
                            int y11 = (int)s1.battle_run.battle_enemy_group.battle_enemy[t1].call_dy() - s1.battle_run.battle_enemy_group.battle_enemy[t1].call_h() / 2;
                            int w11 = s1.battle_run.battle_enemy_group.battle_enemy[t1].call_w();
                            int h11 = s1.battle_run.battle_enemy_group.battle_enemy[t1].call_h();

                        //    m1.msbox("" + x11 + "," + y11 + "," + w11 + "," + h11);
                       //     m1.end();

                            if (m1.rect_decision(px1, py1, x11, y11, w11, h11) == 1)
                            {
                                {
                                //    m1.end();

                                    if (s1.battle_run.battle_enemy_group.target_lock_num == t1)
                                    {
                                     //   s1.sm1.cursor_cancel();
                                        s1.battle_run.battle_enemy_group.target_lock_num = -1;
                                        flag1 = 1;
                                        break;
                                    }
                                    else
                                    {
                                        //   s.gm.cursor_decide();
                                        s1.battle_run.battle_enemy_group.target_lock_num = t1;
                                        flag1 = 1;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    if (flag1 == 0)
                    {
                        s1.battle_run.battle_enemy_group.target_lock_num = -1;

                    //    m1.msbox(2);
                    }
                }
            }
        }
    }

    public String call_dungeon_name()
    {
        return s1.data_magagement.dungeon_data.dungeon_name(s1.data_magagement.dungeon_data.dungeon_type1);
    }



    public void run1()
    {
        battle_flow1.run1();

        battle_bg.run1();

        battle_menu.run1();

        battle_member_group.run1();
        battle_enemy_group.run1();

        battle_member_group_attack_run.run1();
        battle_enemy_group_attack_run.run1();

        battle_member_group_status_control.run1();

        battle_message_window.run1();

        battle_mana.run1();


        if (battle_start_wait_tm >= 1)
        {
            battle_start_wait_tm--;

            if (battle_start_wait_tm == 1)
            {
                battle_flow1.battle_flow_set(battle_flow1.BATTLE_FLOW_DUNGEON_MOVE);
            }

            if (battle_start_wait_tm == battle_start_wait_max() - 1)
            {
                //HPとMPの増加
                {
                    s1.battle_run.battle_member_group_status_control.hp1 = 1;
                    s1.battle_run.battle_member_group_status_control.mp1 = 1;
                }
            }

            if (battle_start_wait_tm == 1)
            {
                //HPとMPの増加
                {
                    s1.battle_run.battle_member_group_status_control.hp_add(9999999);
                    s1.battle_run.battle_member_group_status_control.mp_add(9999999);
                }
            }
        }



        lock_on_update();

        //デバッグ zボタンによるテスト
        if (s1.debug_on() == 1)
        {
            if (input1.rinput(1, input1.INPUT_Z) == 1)
            {
                s1.effect_group.create(300, 300, s1.effect_group.STAGE_CLEAR, 0, 0, 0, 240, 0);

                //   int nt1=battle_member_group_status_control.mhp_call();
                //    m1.msbox(nt1);

                //   battle_flow1.battle_flow_set(battle_flow1.BATTLE_FLOW_DUNGEON_MOVE);

                s1.battle_run.battle_enemy_group.init1();
            }

            if (input1.rinput(1, input1.INPUT_X) == 1)
            {
                //    s1.bgm_operation.play_loop_bgm(s1.bgm_operation.BGM_BATTLE_1);

                s1.bgm_operation.bgm_fade_out(240);
            }

            if (input1.rinput(1, input1.INPUT_C) == 1)
            {
                s1.bgm_operation.play_loop_bgm(s1.bgm_operation.BGM_BATTLE_2);
            }
        }
    }
    


    public void draw1()
    {
        battle_flow1.draw1();

        //ダンジョン画面
        {

            battle_bg.draw1();
        }

        battle_enemy_group.draw1();
        battle_member_group.draw1();

        battle_member_group_attack_run.draw1();
        battle_enemy_group_attack_run.draw1();

        battle_member_group_status_control.draw1();

        battle_message_window.draw1();

        battle_mana.draw1();



        //ステータス画面
        {
            
            int y2 = 384-4;
            
            int y4 = y2 + 112 + 12+4;

            //上の部分
            {
                //    g1.sc(32);
                //    g1.drawRect(0, 0, 720, 32, 0, 1);

                int w1 = 720;
                g1.drawImage2(ic1.loadcheck(4, 1, 0), 0, 0, w1, 32);

                int y21 = 6;

                g1.sc(240);
                g1.setfont(g1.FONT_1_SMALL_STR);
                g1.str2(call_dungeon_name()+"  " + m1.iover((s1.data_magagement.dungeon_data.dungeon_battle_num),1,99) + " / " + s1.data_magagement.dungeon_data.dungeon_battle_num_max(), 0 + 12, y21);
                g1.str2("C: 999999", 600 + 8, y21);
                g1.setfont_re();
            }
        }

        //右側
        {
            battle_menu.draw1();            
        }
        


        {
        //    g1.drawImage(ic1.loadcheck(5, 0, 0), 300, 300, 0.9f, 0);
        }

        /*
        {
            s1.dm1.boxdraw3(10, 10, 400, 400, 0, 1);

            for (int t1 = 0; t1 < 7; t1++)
            {
                String st8 = "";

                for (int t2 = 0; t2 < 10; t2++)
                {
                    st8 += s1.csv_manager.call_str1(s1.csv_manager.TEST_CSV, t1, t2) + ",";
                }

                g1.setfont(g1.FONT_1_SMALL_STR);
                if (t1==0)g1.str2("CSV ロードテスト:", 30, t1 * 32 + 32 * 1);
                g1.str2(st8, 30, t1 * 32 + 32*2);
                g1.setfont_re();
            }
        }
        */

        /*
        {
            s1.dm1.boxdraw3(10, 10, 400, 400, 0, 1);

            for (int t1 = 0; t1 < 7; t1++)
            {
                String st8 = "";

                for (int t2 = 0; t2 < 10; t2++)
                {
                    st8 += ""+s1.data_magagement.character_data.status_call(t1 + 1, s1.data_magagement.character_data.STATUS_MHP + t2) + ",";
                }

                g1.setfont(g1.FONT_1_SMALL_STR);
             
           g1.str2(st8, 30, t1 * 32 + 32 * 2);
                g1.setfont_re();
            }
        }
        */

        //    g1.setfont_re();

        g1.setfont(0);
    }
}