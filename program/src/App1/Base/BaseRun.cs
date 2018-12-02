using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BaseRun : SetVoid1
{
    public int base_type = 30;

//    public int STAGE_MENU_1 = 1;
    public int ORGANIZATION_MENU = 2;
    public int SHOP_MENU = 3;
    public int OTHER_MENU = 4;

    public int STAGE1_SELECT = 11;

    public int CHARACTER_ORGANIZATION = 20;
    public int CHARACTER_PARTY_SELECT = 21;
    public int CHARACTER_MULTI_PARTY_SELECT = 22;

    public int EQUIPMENT_ORGANIZATION = 30;
    public int EQUIPMENT_CHARACTER_EQ_CHANGE = 31;

    public int PARTY_ORGANIZATION = 40;
    public int PARTY_USE_STAGE = 41;

    public int STAGE_RESULT = 50;

    public int EQUIPMENT_SHOP_BUY = 60;
    public int EQUIPMENT_SHOP_SELL = 61;

    public int SYSTEM_OPTION = 70;


    public CharacterOrganizationGroup character_organization_group;

    public CharacterStatus character_status;

    public EquipmentOrganizationGroup equipment_organization_group;

    public PartySelectGroup party_select_group;

    public BaseStageSelectGroup1 base_stage_select_group;


    public BaseMenu base_menu;
    public BaseTitleMenu base_title_menu;

    public BaseBgControl base_bg_control;

    public BaseButtonGroup base_button_group;

    public BaseFunction base_function;

    public BaseMainAddMenu base_main_add_menu;

    public BaseStageResult base_stage_result;

    public BaseOption base_option;



    public ClearChange clear_change;

    public int base_call_all_w1() { return 720; }
    public int base_call_all_h1() { return 540; }

    public int base_title_menu_y() { return 16; }

    public int base_call_y2() { return 84; }
    public int base_call_h2() { return s1.display_h_call() - base_call_y2(); }

    public BaseRun(Summary1 s1)
    {
        set1(s1);

        character_organization_group = new CharacterOrganizationGroup(s1);

        equipment_organization_group = new EquipmentOrganizationGroup(s1);

        party_select_group = new PartySelectGroup(s1);

        base_stage_select_group = new BaseStageSelectGroup1(s1);


        character_status = new CharacterStatus(s1);

        base_menu = new BaseMenu(s1);

        base_title_menu = new BaseTitleMenu(s1);

        base_bg_control = new BaseBgControl(s1);

        base_button_group = new BaseButtonGroup(s1);

        base_function = new BaseFunction(s1);

        base_main_add_menu = new BaseMainAddMenu(s1);

        base_stage_result = new BaseStageResult(s1);

        base_option = new BaseOption(s1);



        clear_change = new ClearChange(s1);
    }

    public void init1()
    {
        character_organization_group.init1();

        character_status.init1();

        equipment_organization_group.init1();

        party_select_group.init1();

        base_stage_select_group.init1();


        base_menu.init1();

        base_title_menu.init1();

        base_bg_control.init1();

        base_button_group.init1();

        base_function.init1();

        base_main_add_menu.init1();

        base_stage_result.init1();

        base_option.init1();


        clear_change.init1();

        {
            base_button_group.create_menu();
        }

        {
            //    s1.bgm_operation.play_loop_bgm(s1.bgm_operation.BGM_BASE_1);

            sound_set();
        }

        //   clear_change.change_set(255, -16);

    //    s1.base_run.character_status.create1();
    //    s1.base_run.character_status.no_setting_flag = 1;
    }


    int base_change_wait_tm() { return 32; }
    int base_touch_wait_tm() { return 32; }

    public void menu_change_waitact_set(int type)
    {
        s1.wait_action.waitact_set(s1.wait_action.BASE_MENU_CHANGE, base_change_wait_tm());
        s1.wait_action.freei[0] = type;
        s1.touch_input.wait(base_touch_wait_tm());
        clear_change.change_set(255, -16);
    }

    public int base_type_check(int base_type1)
    {
        int nt = 0;

        if (this.base_type == base_type1) { nt = 1; }

        return nt;
    }

    public void base_type_change(int base_type1)
    {
        this.base_type = base_type1;
        
        base_type_reset();

        int bg_change_flag = 1;

        //s.base_run.base_under_menu.message_reset();

        if (bg_change_flag == 1)
        {
            s1.base_run.base_bg_control.bg_change(0, 0);

            sound_set();
        }
        
        //base_tm = 0;
    }

    public void base_type_change_quick(int base_type1)
    {
        this.base_type = base_type1;

        base_type_reset();

        s1.base_run.base_bg_control.bg_change(1, 0);
    }

    public void base_type_reset()
    {
        int type1 = base_type;

        {
            //    base_title_menu.dataset();

            //    m1.msbox(type1);

            if (type1 == s1.base_run.CHARACTER_ORGANIZATION
             || type1 == s1.base_run.CHARACTER_PARTY_SELECT
             || s1.base_run.base_type_check(s1.base_run.CHARACTER_MULTI_PARTY_SELECT) == 1
            )
            {
                //    m1.msbox("A:"+type1);

                character_organization_group.init1();
            }

            if (type1 == s1.base_run.EQUIPMENT_ORGANIZATION
             || type1 == s1.base_run.EQUIPMENT_CHARACTER_EQ_CHANGE
             || type1 == s1.base_run.EQUIPMENT_SHOP_BUY
             || type1 == s1.base_run.EQUIPMENT_SHOP_SELL
                )
            {
                equipment_organization_group.init1();
            }

            if (type1 == s1.base_run.PARTY_ORGANIZATION
             || s1.base_run.base_type_check(s1.base_run.PARTY_USE_STAGE) == 1
                )
            {
                party_select_group.init1();
            }

            if (s1.base_run.base_type_check(s1.base_run.STAGE1_SELECT) == 1
                )
            {
                base_stage_select_group.init1();
            }

            if (s1.base_run.base_type_check(s1.base_run.SYSTEM_OPTION) == 1
                )
            {
                base_option.init1();
            }


            base_title_menu.init1();

            base_main_add_menu.init1();


            {
                base_button_group.init1();
                base_button_group.create_menu();
            }
        }
    }

    public void sound_set()
    {
        //BGMの再生
        {
            int so_num = s1.base_run.base_function.use_music_call(base_type);

            //   m.msbox("play:"+s.so.now_play);
           //    m1.msbox("use:"+so_num);

            if (s1.bgm_operation.now_play_num != so_num && so_num >= 0)
            {
                //    m.msbox("stop");

                s1.bgm_operation.bgm_stop();
                //    s1.bgm_operation.bgm_load_and_play(so_num, 40);

                s1.bgm_operation.play_wait_loop_bgm(so_num, 30);
            }
        }
    }

    //ベースメニューを変更した際、サウンドを変えるべきか確認
    public int sound_fade_out_check(int change_base_type)
    {
        int nt = 0;

        {
            int so_num = s1.base_run.base_function.use_music_call(change_base_type);

            if (s1.bgm_operation.now_play_num != so_num && so_num >= 0)
            {
                nt = 1;
            }
        }

        return nt;
    }

    public int base_y1_and_h1_range_in_check(float px3,float py3)
    {
        int nt = 0;
        
        float x3 = 0;
        float y3 = base_call_y2();
        int w3 = 720;
        int h3 = base_call_h2();
        
        if (m1.rect_decision(px3, py3, x3, y3, w3, h3) == 1)
        {
            nt = 1;
        }               
                
        return nt;
    }

    public int base_move_no_check()
    {
        int nt = 0;
        if (s1.dialog_window1.on_check() != 0) { nt = 1; }
        if (s1.base_run.character_status.on != 0) { nt = 1; }

        if (s1.base_run.base_type_check(s1.base_run.STAGE_RESULT) == 1)
        {
            if (s1.base_run.base_stage_result.menu_ok_check() == 0) { nt = 1; }
        }

        return nt;
    }

    public void push_camera_area_set()
    {
        s1.cam_2d.push_area_set(0, 0, base_call_all_w1(), base_call_all_h1());

    //    m1.msbox();
    }




    public void run1()
    {
        character_status.run1();

        //    if (character_status.on == 0)
        {
            if (s1.base_run.base_type_check(s1.base_run.STAGE_RESULT) == 1
                )
            {
                base_stage_result.run1();
            }


            {
                base_menu.run1();

                base_title_menu.run1();

                base_main_add_menu.run1();

                base_bg_control.run1();

                base_button_group.run1();
            }


            if (s1.base_run.base_function.character_organization_check() == 1)
            {
                character_organization_group.run1();
            }

            if (s1.base_run.base_function.equipment_organization_check() == 1)
            {
                equipment_organization_group.run1();
            }

            if (s1.base_run.base_function.party_organization_check() == 1)
            {
                party_select_group.run1();
            }

            if (s1.base_run.base_type_check(s1.base_run.STAGE1_SELECT) == 1
                )
            {
                base_stage_select_group.run1();
            }

            if (s1.base_run.base_type_check(s1.base_run.SYSTEM_OPTION) == 1
                )
            {
                base_option.run1();
            }


            clear_change.run1();
        }


        //デバッグ zボタンによるテスト
        if (s1.debug_on() == 1)
        {
            if (input1.rinput(1, input1.INPUT_Z) == 1)
            {
                s1.app_variable1.coin_add(20000);
            }

            if (input1.rinput(1, input1.INPUT_X) == 1)
            {
                s1.app_variable1.coin_add(-20000);
            }

            if (input1.rinput(1, input1.INPUT_C) == 1)
            {
                s1.sound_effect_operation.play_se(s1.sound_effect_operation.SE_BATTLE_ATTACK_1);

             //   s1.bgm_operation.play_loop_bgm(s1.bgm_operation.BGM_BATTLE_2);
            }


            if(input1.rinput(1, input1.INPUT_A) == 1)
            {
                int nt1 = m1.dialog_yesno("ロードする？");

                if (nt1 == 1)
                {
                    s1.save_data_control.file_load();
                }
            }

            if (input1.rinput(1, input1.INPUT_S) == 1)
            {
                int nt1 = m1.dialog_yesno("セーブする？");

                if (nt1 == 1)
                {
                    s1.save_data_control.file_save();
                }
            }
        }
    }

    public void draw1()
    {
        if (character_status.on==0 || character_status.clear_change.clear_value1 <= 254)
        {
            base_bg_control.draw1();

            {
                clear_change.clear_call();

                {
                    if (s1.base_run.base_function.character_organization_check() == 1)
                    {
                        character_organization_group.draw1();
                    }

                    if (s1.base_run.base_function.equipment_organization_check() == 1)
                    {
                        equipment_organization_group.draw1();
                    }

                    if (s1.base_run.base_function.party_organization_check() == 1)
                    {
                        party_select_group.draw1();
                    }

                    if (s1.base_run.base_type_check(s1.base_run.STAGE1_SELECT) == 1
                )
                    {
                        base_stage_select_group.draw1();
                    }

                    if (s1.base_run.base_type_check(s1.base_run.STAGE_RESULT) == 1
                )
                    {
                        base_stage_result.draw1();
                    }

                    if (s1.base_run.base_type_check(s1.base_run.SYSTEM_OPTION) == 1
               )
                    {
                        base_option.draw1();
                    }


                    base_button_group.draw1();

                    base_title_menu.draw1();

                    base_main_add_menu.draw1();


                    s1.scroll_bar1.draw1();
                    s1.scroll_bar2.draw1();
                }

                clear_change.clear_call_re();
            }


            //一番上にウインドウ
            {
                int nt70 = 2;
                int x16 = 0 + nt70;
                int y16 = 0 + nt70;
                int w16 = 720 - nt70 * 2 - 2;
                int h16 = 44 - nt70 * 2;

                //    g1.drawrectImage(ic1.loadcheck(0, 2, 0), x16, y16, 0, 0, 400, h16);
                //    g1.drawrectImage(ic1.loadcheck(0, 2, 0), x16+400, y16, 0, 0, w16, h16);
                //    s1.dm1.boxdraw3(x16, y16, w16, h16, 0, 0);
            }



            {
                base_menu.draw1();
            }
        }


        character_status.draw1();


        //気になる変数の表示
        {
            int x71 = 16;
            int nt1 = 24;
            
            g1.sc(255);
            //    g1.str2("A:" + (int)s1.base_run.party_select_group.party_use_num_call(), x71, 16 + nt1 * 1);
            //    g1.str2("B:" + (int)s1.base_run.party_select_group.select_character_num_call(), x71, 16 + nt1 * 2);

            /*
            g1.str2("A:" + (int)s1.touch_input.pull_check(), x71, 16 + nt1 * 1);
            g1.str2("B:" + (int)s1.touch_input.pull_check(), x71, 16 + nt1 * 2);
            g1.str2("C:" + (int)s1.touch_input.touch_check(), x71, 16 + nt1 * 3);
            g1.str2("D:" + (int)s1.touch_input.input_wait, x71, 16 + nt1 * 4);
            */
        }
    }
}
