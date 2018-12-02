using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//戦闘の流れを全部管理
public class BattleFlow1 : SetVoid1
{
    public int tm1;

    public int battle_flow_type1;
    public int[] free1 = new int[9];
    
    public int BATTLE_FLOW_FREE = 1;
    public int BATTLE_MEMBER_ATTACK_CALL = 2;
    public int BATTLE_MEMBER_ATTACK_RUN1 = 3;

    public int BATTLE_ENEMY_ATTACK_RUN1 = 5;

    public int BATTLE_FLOW_CONTINUE = 10;

    public int BATTLE_FLOW_ENCHANTMENT = 15;

    public int BATTLE_FLOW_MEMBER_SKILL = 20;

    public int BATTLE_FLOW_FLOOR_BATTLE_END = 31;
    public int BATTLE_FLOW_DUNGEON_MOVE = 32;


    public BattleFlow1(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        battle_flow_type1 = BATTLE_FLOW_FREE;

        tm1 = 0;

        for (int t1 = 0; t1 < 9; t1++)
        {
            free1[t1] = 0;
        }
    }

    public int battle_flow_type_check(int battle_flow_type1)
    {
        int nt = 0;
        if (this.battle_flow_type1 == battle_flow_type1) { nt = 1; }
        return nt;
    }

    public void battle_flow_set(int type1)
    {
        init1();

        battle_flow_type1 = type1;

        tm1 = 1;
    }

    public void next_call()
    {
        int nt1 = 0;

        if (battle_flow_type1 == BATTLE_MEMBER_ATTACK_CALL && nt1 == 0)
        {
            nt1 = 1;

            if (s1.battle_run.battle_member_group_status_control.now_enchant1 != s1.battle_run.battle_member_group_status_control.set_enchant1 ||
            s1.battle_run.battle_member_group_status_control.now_enchant2 != s1.battle_run.battle_member_group_status_control.set_enchant2)
            {
                battle_flow_set(BATTLE_FLOW_ENCHANTMENT);
            }
            else
            {
                battle_flow_type1 = BATTLE_MEMBER_ATTACK_RUN1;
                s1.battle_run.battle_member_group_attack_run.member_all_attack_set();
            }
        }

        if (battle_flow_type1 == BATTLE_MEMBER_ATTACK_RUN1 && nt1 == 0)
        {
            nt1 = 1;

            if (s1.battle_run.battle_enemy_group.alive_num_check() <= 0)
            {
                battle_flow_set(BATTLE_FLOW_FLOOR_BATTLE_END);
            }
            else
            {
                battle_flow_type1 = BATTLE_ENEMY_ATTACK_RUN1;
                s1.battle_run.battle_enemy_group_attack_run.enemy_all_attack_set();
            }
        }

        if (battle_flow_type1 == BATTLE_ENEMY_ATTACK_RUN1 && nt1 == 0)
        {
            nt1 = 1;

            battle_flow_type1 = BATTLE_FLOW_FREE;
        }

        if (battle_flow_type1 == BATTLE_FLOW_CONTINUE && nt1 == 0) { nt1 = 1; battle_flow_type1 = BATTLE_FLOW_FREE; }

        if (battle_flow_type1 == BATTLE_FLOW_ENCHANTMENT && nt1 == 0)
        {
            nt1 = 1;
            battle_flow_type1 = BATTLE_MEMBER_ATTACK_RUN1;
            s1.battle_run.battle_member_group_attack_run.member_all_attack_set();
        }

        if (battle_flow_type1 == BATTLE_FLOW_MEMBER_SKILL && nt1 == 0)
        {
            nt1 = 1;
            battle_flow_set(BATTLE_FLOW_FREE);
        }

        if (battle_flow_type1== BATTLE_FLOW_DUNGEON_MOVE && nt1 == 0)
        {
            nt1 = 1;
            battle_flow_set(BATTLE_FLOW_FREE);
        }

        if (battle_flow_type1 == BATTLE_FLOW_FLOOR_BATTLE_END && nt1 == 0)
        {
            nt1 = 1;
            if (free1[1] == 0)
            {
                battle_flow_set(BATTLE_FLOW_DUNGEON_MOVE);
            }
            else
            {
                //ダンジョンクリア
            }
        }


        if (nt1 == 1)
        {
            tm1 = 1;
        }
    }


    public void run1()
    {
        {
            if (battle_flow_type1 == BATTLE_MEMBER_ATTACK_CALL)
            {
                if (tm1 == 2) { next_call(); }
            }

            if (battle_flow_type1 == BATTLE_FLOW_CONTINUE)
            {
                if (tm1 == 2)
                {
                    s1.battle_run.battle_member_group.battle_continue1();
                }

                if (tm1 == 4)
                {
                    next_call();
                }
            }

            if (battle_flow_type1 == BATTLE_FLOW_ENCHANTMENT)
            {
                if (tm1 == 2)
                {
                    int link1 = s1.battle_run.battle_member_group_status_control.set_enchant1;
                    int link2 = s1.battle_run.battle_member_group_status_control.set_enchant2;

                    if (s1.battle_run.battle_member_group.enchantment_use_ok(link1) != 0) { s1.battle_run.battle_member_group.battle_member[link1].attack_move_set(); }
                    if (s1.battle_run.battle_member_group.enchantment_use_ok(link2) != 0) { s1.battle_run.battle_member_group.battle_member[link2].attack_move_set(); }

                    int enchant1 = s1.battle_run.battle_member_group.battle_member[link1].call_enchantment();
                    int enchant2 = s1.battle_run.battle_member_group.battle_member[link2].call_enchantment();

                    {
                        String st1 = "";

                        if (s1.battle_run.battle_member_group.enchantment_use_ok(link1) != 0)
                        {
                            st1 += s1.data_magagement.enchantment_data.enchantment_name(enchant1);
                        }

                        if (s1.battle_run.battle_member_group.enchantment_use_ok(link1) != 0 && s1.battle_run.battle_member_group.enchantment_use_ok(link2) != 0)
                        {
                            st1 += " ＆ ";
                        }

                        if (s1.battle_run.battle_member_group.enchantment_use_ok(link2) != 0)
                        {
                            st1 += s1.data_magagement.enchantment_data.enchantment_name(enchant2);
                        }

                        //メッセージテスト
                        s1.battle_run.battle_message_window.message_stock(st1);
                        s1.battle_run.battle_message_window.draw_wait_set(60);
                    }

                    //２人共エンチャントを使えない
                    if (s1.battle_run.battle_member_group.enchantment_use_ok(link1) == 0 && s1.battle_run.battle_member_group.enchantment_use_ok(link2) == 0)
                    {
                        tm1 = 60;
                    }
                }

                if (tm1 == 4)
                {
                    //    s1.battle_run.battle_flow1.battle_flow_set(s1.battle_run.battle_flow1.BATTLE_FLOW_FREE);
                }

                if (tm1 == 8)
                {
                    //ステータスの変化
                    s1.battle_run.battle_enchantment.enchantment_change();
                }

                if (tm1 == 60)
                {
                    next_call();
                }
            }

            if (battle_flow_type1 == BATTLE_FLOW_MEMBER_SKILL)
            {
                if (tm1 == 2)
                {
                    int link1 = s1.battle_run.battle_member_group_status_control.set_battle_member;
                    int slot1 = s1.battle_run.battle_member_group_status_control.set_battle_member_skill_slot;
                    int point1 = s1.battle_run.battle_member_group.battle_member[link1].call_skill_point(slot1);

                    int skill_num = s1.battle_run.battle_member_group.battle_member[link1].call_skill(slot1);

                    s1.battle_run.battle_member_group_status_control.now_skill1 = skill_num;
                    if (s1.battle_run.battle_member_group.skill_use_ok(link1) != 0) { s1.battle_run.battle_member_group.battle_member[link1].attack_move_set(); }

                    {
                        String st1 = s1.data_magagement.skill_data.skill_name(skill_num);
                        s1.battle_run.battle_message_window.message_stock(st1);
                        s1.battle_run.battle_message_window.draw_wait_set(60);
                    }

                    //MPの消費と使用反応
                    {
                        s1.battle_run.battle_member_group.battle_member[link1].use_skill_flag = 1;
                        s1.battle_run.battle_member_group_status_control.mp_add(-point1);
                    }
                }

                if (tm1 == 4)
                {
                    //    s1.battle_run.battle_flow1.battle_flow_set(s1.battle_run.battle_flow1.BATTLE_FLOW_FREE);
                }

                if (tm1 == 8)
                {
                    //ステータスの変化
                    s1.battle_run.battle_skill.skill_use(s1.battle_run.battle_member_group_status_control.set_battle_member, s1.battle_run.battle_member_group_status_control.now_skill1);
                }

                if (tm1 == 60)
                {
                    next_call();
                }
            }

            if (battle_flow_type1 == BATTLE_FLOW_DUNGEON_MOVE)
            {
                if (tm1 == 2)
                {
                    if (s1.data_magagement.dungeon_data.battle_num_last_check() == 0)
                    {
                        s1.battle_run.battle_bg.dungeon_move();

                        s1.data_magagement.dungeon_data.dungeon_battle_num++;

                        {
                            s1.effect_group.create(300, 300, s1.effect_group.BATTLE_NEXT_AREA_NAME_LOGO, 0, 0, 0, 240, 0);
                        }

                        if (s1.data_magagement.dungeon_data.battle_num_last_check() != 0)
                        {
                            s1.bgm_operation.bgm_fade_out(120);
                        }
                    }
                }

                if (s1.data_magagement.dungeon_data.dungeon_battle_num == 1)
                {
                    if (tm1 == 12)
                    {
                        if (s1.data_magagement.dungeon_data.battle_num_last_check() == 0)
                        {
                            s1.bgm_operation.play_loop_bgm(s1.data_magagement.dungeon_data.dungeon_normal_battle_bgm_num());
                        }
                    }
                }
            

                if (tm1 == 120)
                {
                    if (s1.data_magagement.dungeon_data.battle_num_last_check() != 0)
                    {
                        s1.bgm_operation.play_loop_bgm(s1.data_magagement.dungeon_data.dungeon_boss_battle_bgm_num());
                    }
                }

                int n1 = 100;

                if (tm1 == n1 + 2)
                {
                 //   if (s1.data_magagement.dungeon_data.battle_num_last_check() == 0)
                    {
                        s1.battle_run.battle_enemy_group.battle_enemy_appear_control.enemy_appear();
                    }
                }

                if (tm1 == n1 + 62)
                {
                    next_call();
                }
            }

            if (battle_flow_type1 == BATTLE_FLOW_FLOOR_BATTLE_END)
            {
                int nt1 = 0;

                //最終フロア
                if (s1.data_magagement.dungeon_data.dungeon_battle_num >= s1.data_magagement.dungeon_data.dungeon_battle_num_max())
                {
                    nt1 = 1;

                    free1[1] = 1;//next_callの時の判定
                }
                else
                {
                    nt1 = 0;

                    free1[1] = 0;
                }

                if (free1[1] == 0)
                {
                    if (tm1 == 30)
                    {
                        next_call();
                    }
                }
                else
                {
                    int nt3 = 0;

                    if (tm1 == 10+ nt3) { s1.bgm_operation.bgm_fade_out(60); }

                    if (tm1 == 10+ nt3)
                    {
                        s1.effect_group.create(0, 0, s1.effect_group.STAGE_CLEAR, 0, 0, 0, 240, 0);
                    }

                        //タッチしたら次に進行
                        if (tm1 == 20+ nt3)
                    {
                        tm1--;

                        if (s1.touch_input.pull_check() != 0)
                        {
                            tm1++;
                        }
                    }

                    if (tm1 == 30+ nt3)
                    {
                        s1.fade_run.create1(s1.fade_run.FADE_WAIT_60, 1, 0, 0);

                        s1.wait_action.waitact_set(s1.wait_action.DUNGEON_CLEAR, 60);
                    }
                }
            }
        }

        if (tm1 >= 1 && tm1 <= 9999999) { tm1++; }
    }//run1()

    public void draw1()
    {
    }
}
