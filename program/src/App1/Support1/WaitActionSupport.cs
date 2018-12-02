using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class WaitActionSupport : WaitActionExtend
{
    public WaitActionSupport(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

    }

    //待ちアクション
    public void waitact(int type1)
    {
        long timer = m1.get_time();

        //    int type9 = 0;

        //    m.msbox(type);

        //初期化
        {
            s1.effect_group.init1();

            s1.cam_2d.init1();
            s1.scroll_bar1.close1();
        }

        {
            if (type1 == DUNGEON_TO_BASE)
            {
                m1.msbox("call1");
            }

            if (type1 == DUNGEON_CLEAR)
            {
                m1.msbox("clear_call1");
            }

            if (type1== BASE_MENU_CHANGE)
            {
                s1.base_run.base_type_change(s1.wait_action.freei[0]);

                //            if (type == s.base_run.CHARACTER_MENU)
                //          {
                //            s.base_run.main_type_change(s.base_run.CHARACTER_MENU);
                //      }
                

            //    if (flag == 1)
                {
                    s1.touch_input.wait(20);
                    s1.base_run.clear_change.change_set(0, 20);
                }
            }

            if (type1== TITLE_TO_BASE)
            {
                s1.mr1.game_type_change(s1.mr1.GAME_BASE);

                s1.base_run.base_type_change(s1.base_run.ORGANIZATION_MENU);

                s1.fade_run.create1(s1.fade_run.FADE_WAIT_60, 0, 0, 0);

                s1.touch_input.wait(21);

                //背景のメモリは開放
                s1.ic1.img_release_part(8, 17);
            }

            if (type1 == BASE_TO_TITLE)
            {
                s1.mr1.game_type_change(s1.mr1.GAME_TITLE);

                s1.title_run.init1();

                s1.fade_run.create1(s1.fade_run.FADE_WAIT_60, 0, 0, 0);

                s1.touch_input.wait(21);
            }

            if (type1== BASE_TO_DUNGEON)
            {
                s1.mr1.game_type_change(s1.mr1.GAME_BATTLE);

            //    s1.battle_run.battle_start();
            }
        }

        //追加動作
        {
            if (s1.wait_action.action_add == s1.wait_action.ACTION_ADD_PARTY_SET)
            {
                int link_num = s1.base_run.character_organization_group.set_link_memo;

                s1.base_run.party_select_group.party_set(link_num);
            }

            if (s1.wait_action.action_add >= 1)
            {
                s1.wait_action.action_add = 0;
            }
        }


     //   type2_memo = 0;

        //    if (DX.CheckHitKey(DX.KEY_INPUT_2) != 0) timer -= 1000;

        //    m.wait(17*60);

        //１秒間待たせる
        //     m.wait(timer, m.get_time(), s.load_wait_millisecond);

    //    m1.system_gc();
    }

    public void run1()
    {
    }

    public void draw1()
    {
    }
}
