using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//詳細はこちらでサポート
public class DialogWindowSupport : DialogWindowExtend
{
    public DialogWindowSupport(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

    }

    public void create1(int type1, int type2, int main_type1, int free2)
    {
        int sendflag1 = 1;

        String st1 = "", st2 = "", st3 = "", st4 = "";

        String[] stbox1 = new String[8];
        for (int t = 0; t < s1.dialog_window1.explantion_num_max(); t++) { stbox1[t] = ""; }

        s1.dialog_window1.title_name = " ";

        String st9 = " -> ";

        s1.touch_input.wait_min(2);

    

        area_out_close_set();

        if (type1 == DIALOG_GAMEOVER_CONTINUE)
        {
            main_type_set(DIALOG_YESNO);
            //    title_name_set("コンティニュー？");
            title_name_set("ゲームオーバー");

            st1 = "[NUM1] コインを消費して 復活しますか？";
            st2 = "（手持ちのコイン [NUM2]）";

            st1 = m1.Change(st1, "[NUM1]", "" + (0));
            st2 = m1.Change(st2, "[NUM2]", "" + (100));

            area_out_close_no_set();
        }

        if (type1 == DIALOG_SKILL_USE_CHECK)
        {
            main_type_set(DIALOG_YES1_YES2_NO);

            {
                title_name_set("スキルの発動");

                int link1 = s1.battle_run.battle_member_group_status_control.set_battle_member;
                int skill_num1 = s1.battle_run.battle_member_group.battle_member[link1].call_skill(0);
                int skill_num2 = s1.battle_run.battle_member_group.battle_member[link1].call_skill(1);

            //    m1.msbox("" + link1 + "," + skill_num1 + "," + skill_num2);
            //    m1.end();

                String stt1= "ＭＰ：" + m1.num_half_full_change(s1.battle_run.battle_member_group.battle_member[link1].call_skill_point(0));
                stbox1[0] = s1.data_magagement.skill_data.skill_name(skill_num1) + "  "+stt1;
                stbox1[1] = s1.data_magagement.skill_data.skill_explanation1(skill_num1);
                stbox1[2] = s1.data_magagement.skill_data.skill_explanation2(skill_num1);

                if (skill_num2 >= 1)
                {
                    String stt2 = "ＭＰ：" + m1.num_half_full_change(s1.battle_run.battle_member_group.battle_member[link1].call_skill_point(1));
                    stbox1[3] = " ";
                    stbox1[4] = s1.data_magagement.skill_data.skill_name(skill_num2) + "  " + stt2;
                    stbox1[5] = s1.data_magagement.skill_data.skill_explanation1(skill_num2);
                    stbox1[6] = s1.data_magagement.skill_data.skill_explanation2(skill_num2);
                }


                {
                    s1.dialog_window1.yes1_name = "Ｓ１発動";
                    s1.dialog_window1.yes2_name = "Ｓ２発動";
                    s1.dialog_window1.no_name = "やめる";
                }
            }
            
        }

        if (type1 == DIALOG_GOTO_TITLE_YESNO)
        {
            main_type_set(DIALOG_YESNO);

            title_name_set("タイトル画面に移動");

            st1 = "タイトルに戻りますか？";
        }

        if (type1 == DIALOG_EQUIPMENT_CHECK || type1== DIALOG_EQUIPMENT_CHARACTER_EQ_CHANGE)
        {
            //type2に装備のリンク番号を保持

            //    main_type_set(DIALOG_YESNO);
            if (type1 == DIALOG_EQUIPMENT_CHECK) { main_type_set(DIALOG_OK); }
            if (type1 == DIALOG_EQUIPMENT_CHARACTER_EQ_CHANGE) { main_type_set(DIALOG_YESNO); }

            if (s1.equipment_group.equipment_null_check(type2) == 0)
            {
                int eq_type1 = s1.equipment_group.equipment1[type2].call_type1();

                title_name_set(s1.data_magagement.equipment_data.equipment_name(eq_type1));

                {
                    int[] numbox1 = { 0, 0, 0, 0, 0, 0 };
                    String[] strbox1 = { "", "", "", "", "", "" };

                    {
                        //    numbox1[0] = s1.character_group.character1[character_link].call_level();
                        numbox1[1] = s1.equipment_group.equipment1[type2].call_mhp();
                        numbox1[2] = s1.equipment_group.equipment1[type2].call_mmp();
                        numbox1[3] = s1.equipment_group.equipment1[type2].call_atk();
                        numbox1[4] = s1.equipment_group.equipment1[type2].call_int();
                        numbox1[5] = s1.equipment_group.equipment1[type2].call_tec();
                    }

                    for (int t1 = 0; t1 < 6; t1++)
                    {
                        strbox1[t1] = m1.num_half_full_change(numbox1[t1]);

                        {
                            strbox1[t1] = m1.add_space_str1(strbox1[t1], 3, 0, "　");
                        }
                    }

                    int np = 0, np2 = 0;

                    if (s1.equipment_group.equipment1[type2].call_mhp() >= 1) { if (np == 1) { stbox1[np2] += "　"; } stbox1[np2] += "ＨＰ　：" + strbox1[1]; np++; }
                    if (np >= 2) { np = 0; np2 += 1; }
                    if (s1.equipment_group.equipment1[type2].call_mmp() >= 1) { if (np == 1) { stbox1[np2] += "　"; } stbox1[np2] += "ＭＰ　：" + strbox1[2]; np++; }
                    if (np >= 2) { np = 0; np2 += 1; }
                    if (s1.equipment_group.equipment1[type2].call_atk() >= 1) { if (np == 1) { stbox1[np2] += "　"; } stbox1[np2] += "ＡＴＫ：" + strbox1[3]; np++; }
                    if (np >= 2) { np = 0; np2 += 1; }
                    if (s1.equipment_group.equipment1[type2].call_int() >= 1) { if (np == 1) { stbox1[np2] += "　"; } stbox1[np2] += "ＩＮＴ：" + strbox1[4]; np++; }
                    if (np >= 2) { np = 0; np2 += 1; }
                    if (s1.equipment_group.equipment1[type2].call_tec() >= 1) { if (np == 1) { stbox1[np2] += "　"; } stbox1[np2] += "ＴＥＣ：" + strbox1[5]; np++; }
                    if (np >= 2) { np = 0; np2 += 1; }


                    /*
                    stbox1[0] += "ＨＰ　：" + strbox1[1];
                    stbox1[0] += "　ＭＰ　：" + strbox1[2];
                    stbox1[1] += "ＡＴＫ：" + strbox1[3];
                    stbox1[1] += "　ＩＮＴ：" + strbox1[4];
                //    stbox1[2] += "ＴＥＣ：" + strbox1[5];
                */


                    if (s1.equipment_group.equipment1[type2].call_character_link() !=s1.am1.character_null_num())
                    {
                        int character_link = s1.equipment_group.equipment1[type2].call_character_link();

                        {
                            String name2 = s1.character_group.character1[character_link].call_name();

                        //    stbox1[6] = " ";
                            stbox1[7] = "" + name2 +" が 装備しています";
                        }
                    }
                }
            }

        //    if (type1 == DIALOG_EQUIPMENT_CHECK) { main_type_set(DIALOG_OK); }
            if (type1 == DIALOG_EQUIPMENT_CHARACTER_EQ_CHANGE)
            {
                s1.dialog_window1.yes1_name = "装備する";
                s1.dialog_window1.no_name = "やめる";
            }
        }

        if (type1 == CHARACTER_GET_1)
        {
        //    main_type_set(DIALOG_YESNO);

            title_name_set("クリアボーナス");

            st1 = "「○○」が仲間になりました！";

            area_out_close_no_set();
        }

        if (type1== EQUIPMENT_OVER)
        {
            title_name_set("装備品の数の限界");

            st1 = "装備品の保有数が限界を超えています";
            st2 = "一度 ショップで整理して下さい";
        }

        if (type1== LITTLE_COIN)
        {
            title_name_set("コイン不足");

            st1 = "コインが足りないです……";
        }

        if (type1 == EQUIPMENT_BUY)
        {
            title_name_set("装備品の購入");

            st1 = "[NUM1] コインを消費して 購入しますか？";
            st2 = "（手持ちのコイン [NUM2]）";

            int link_num = type2;
            int need_coin = s1.equipment_group.equipment1[link_num].call_buy_coin_num();

            st1 = m1.Change(st1, "[NUM1]", "" + (need_coin));
            st2 = m1.Change(st2, "[NUM2]", "" + (s1.app_variable1.coin_num_call()));
        }

        


        {
            if (sendflag1 == 1)
            {
                s1.dialog_window1.send_explantion_line4(st1, st2, st3, st4);
            }

            {
                for (int t1 = 0; t1 < s1.dialog_window1.explantion_num_max(); t1++)
                {
                    if (m1.strbyte(stbox1[t1]) >= 1)
                    {
                        s1.dialog_window1.explanation1[t1] = stbox1[t1];
                    }
                }
            }
        }
    }

    public void main_type_set(int main_type1)
    {
        s1.dialog_window1.main_type = main_type1;

        {
            s1.dialog_window1.reset_name1();
        }
    }

    public void title_name_set(String name1)
    {
        s1.dialog_window1.title_name = name1;
    }

    public void area_out_close_set()
    {
        s1.dialog_window1.area_out_close = 1;
    }

    public void area_out_close_no_set()
    {
        s1.dialog_window1.area_out_close = 0;
    }



    public void touch_yes(int num1)
    {
        int type1 = s1.dialog_window1.type1;
        int type2 = s1.dialog_window1.type2;

        {

            if (type1 == DIALOG_GAMEOVER_CONTINUE)
            {
                s1.battle_run.battle_flow1.battle_flow_set(s1.battle_run.battle_flow1.BATTLE_FLOW_CONTINUE);
            }

            if (type1 == DIALOG_SKILL_USE_CHECK)
            {
                if (num1 == 0) { s1.battle_run.battle_member_group_status_control.set_battle_member_skill_slot = 0; }
                if (num1 == 1) { s1.battle_run.battle_member_group_status_control.set_battle_member_skill_slot = 1; }

                s1.battle_run.battle_flow1.battle_flow_set(s1.battle_run.battle_flow1.BATTLE_FLOW_MEMBER_SKILL);
            }

            if (type1 == DIALOG_GOTO_TITLE_YESNO)
            {
                s1.fade_run.create1(s1.fade_run.FADE_WAIT_60, 1, 0, 0);

                s1.wait_action.waitact_set(s1.wait_action.BASE_TO_TITLE, 60);

                s1.input1.wait(61);

                s1.bgm_operation.bgm_fade_out();
            }

            if (type1 == DIALOG_EQUIPMENT_CHECK)
            {

            }

            if (type1 == DIALOG_EQUIPMENT_CHARACTER_EQ_CHANGE)
            {
                //装備の変更
                {
                    s1.character_group.character1[s1.base_run.character_status.character_link].equipment_change(type2, s1.base_run.character_status.equipment_slot);
                }

                s1.base_run.base_function.character_status_draw_call();
            }

            //クリアした仲間を参加させて、そのキャラのステータスを表示する
            if (type1 == CHARACTER_GET_1)
            {
                {
                    //    int num2 = s1.base_run.party_select_group.select_character_num;
                    int link_num = 0;//s1.base_run.party_select_group.party_call(num1, num2);

                    s1.base_run.base_function.character_status_draw_call();

                    s1.base_run.character_status.character_link = link_num;

                    s1.base_run.character_status.back_base_type = s1.base_run.base_type;
                    s1.base_run.character_status.no_setting_flag = 1;
                }
            }

            if (type1 == EQUIPMENT_BUY)
            {
                int link_num = type2;
                int need_coin = s1.equipment_group.equipment1[link_num].call_buy_coin_num();

                s1.app_variable1.coin_add(-need_coin);

                //ショップの装備を、空いている所有スペースに移動
                {
                    int link2_num = s1.equipment_group.equipment_create();
                    s1.equipment_group.equipment_move(link2_num, link_num);
                }
            }
        }
    }


    public void touch_no()
    {
        int type1 = s1.dialog_window1.type1;
        int type2 = s1.dialog_window1.type2;

        {
            if (type1 == DIALOG_GAMEOVER_CONTINUE)
            {
                s1.fade_run.create1(s1.fade_run.FADE_WAIT_80, 1, 1, 0);

                s1.wait_action.waitact_set(s1.wait_action.DUNGEON_TO_BASE, 80);
            }
        }

    }//touch_no()

    public int yes_ok_check(int num1)
    {
        int nt = 1;

        int type1 = s1.dialog_window1.type1;
        int type2 = s1.dialog_window1.type2;

        {
            if (type1 == DIALOG_SKILL_USE_CHECK)
            {
                int point1 = 0, need_point1 = 0;

                point1 = s1.battle_run.battle_member_group_status_control.mp_call();

                int link1 = s1.battle_run.battle_member_group_status_control.set_battle_member;

                if (num1 == 0) { need_point1 = s1.battle_run.battle_member_group.battle_member[link1].call_skill_point(0); }
                if (num1 == 1) { need_point1 = s1.battle_run.battle_member_group.battle_member[link1].call_skill_point(1); }

                if (point1 < need_point1 || need_point1 == 0) { nt = 0; }
                if (s1.battle_run.battle_member_group.battle_member[link1].use_skill_flag != 0) { nt = 0; }
            }
        }

        return nt;
    }

    public void run1()
    {
    }

    public void draw1()
    {
    }
}
