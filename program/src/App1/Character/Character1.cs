using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Character1 : CharacterExtend
{
    static int STATUS_MAX = 32;
    public int status_max() { return STATUS_MAX; }
    public int[] status_box = new int[STATUS_MAX];

    public int call_level_max() { return 100; }

    //個別の番号
    int num1;

    public int on;

    public Character1(Summary1 s1, int num1)
    {
        set1(s1);
        this.num1 = num1;
    }


    public void init1()
    {
        on = 0;

        for (int t1 = 0; t1 < status_max(); t1++)
        {
            status_box[t1] = 0;
        }
    }//init1()




    public void status_create(int type1, int level1, int free1, int free2)
    {
        init1();

        on = 1;

        status_box[LEVEL1] = level1;
        status_box[TYPE1] = type1;

        status_box[SKILL_1] = type1;
        status_box[SKILL_2] = 0;


      //  status_box[EQUIPMENT_1] = 0;

        status_box[EQUIPMENT_1] = s1.am1.equipment_null_num();
        status_box[EQUIPMENT_2] = s1.am1.equipment_null_num();
        status_box[EQUIPMENT_3] = s1.am1.equipment_null_num();
        status_box[EQUIPMENT_4] = s1.am1.equipment_null_num();


        /*
        status_box[STATUS_MHP] = s1.character_group.call_create_status(type1, level1, STATUS_MHP);
        status_box[STATUS_MMP] = s1.character_group.call_create_status(type1, level1, STATUS_MMP);
        status_box[STATUS_ATK] = s1.character_group.call_create_status(type1, level1, STATUS_ATK);
        status_box[STATUS_INT] = s1.character_group.call_create_status(type1, level1, STATUS_INT);
        */

        /*
        name1 = default_name();



        {
            int rare_1 = 1;//call_Rare();

            status_box[LEVEL_MAX] = 45 + rare_1 * 5;//20 + rare_1 * 10;//24 + rare_1 * 6;//20 + rare_1 * 10;
        }


        {
            status_box[CREATE_VER] = s.game_version();
        }


        if (num <= s.character_group.max - s.character_group.over_add_max())
        {
            status_box[GET_CHARACTER_COUNT] = s.game_variable.get_character_counter;

            s.game_variable.get_character_counter += 1;
        }

        on = 1;



        //ステータス生成すると図鑑が埋まる
        if (race >= 1)
            if (s.character_group.race_get_flag[race] == 0)
            {
                //    if (num<=30)
                //    m.msbox("race:"+race+" num:"+num);

                s.character_group.race_get_flag[race] = 1;
            }
        

        

        //ステータス生成を行った際 以下のルールに従ってプロテクトキーを生成する
        //利用は特にしない 以降のバージョンでBanチェックが出来たりもする
        //不正に作られたキャラクターはおそらくここの値が-1になっている

        //11+race+クラウンup数
        {
            protect_key_set();
        }

        //個体値の生成
        {
            solid_set();
        }


        //作成したキャラは召喚リストに追加
        if (num <= s.character_group.max - s.character_group.over_add_max())
        {
            s.character_group.summon_ok_flag[race] = 1;
        }


        s.gm.organization_max_update();
        */

        //タイムスタンプ
        {
            status_box[GET_DATE_1] = m1.time_stanp_1();
            status_box[GET_DATE_2] = m1.time_stanp_2();
        }

    }//status_create()



    public int call_status_box(int status_type1) { return status_box[status_type1]; }

    //そのキャラクターの最終ステータスを返す。但しGroup以外では使わないこと
    public int call_status(int status_type1)
    {
        int nt = 0;

        int level1 = status_box[LEVEL1];
        int type1 = status_box[TYPE1];
        
        if (status_type1 >= STATUS_MHP)
        {
            //キャラクターの基礎ステータス
            nt = s1.character_group.call_create_status(type1, level1, status_type1);

            if (status_type1 != STATUS_TEC)
            {
                nt = equipment_calc(nt, status_type1);
            }
            else
            {
                nt = equipment_technic_calc(nt, status_type1);
            }
            
        }else
        {
            nt = call_status_box(status_type1);
        }


        /*
        {
            nt = s.character_group.call_status(race, level, type);

            if (type >= STATUS_MHP && type <= STATUS_CURE)
            {
                //    nt = call_summon_star_send_status(type, nt, 0);

                {
                    //個体値補正(最初！)
                    nt = call_solid_power_up(type, nt, 0);

                    //+値
                    nt = call_plus_send_status(type, nt, 0);

                    //レベルスーパー
                    nt = call_level_super_send_status(type, nt, 0);



                    //サモンスター (+30%)


                    //深化キャラには関係なし
                    {
                        //タイプ一致 (+5%)
                        if (call_status_type_1() == call_status_type_2()) { nt = nt + nt / 20; }

                        //ランク一致 (+5%)
                        if (call_Rare() == call_Rare_2()) { nt = nt + nt / 20; }
                    }


                    //深化キャラのステータス送り
                    nt = call_ability_power_up_character_send_status(type, nt);

                    //    nt = call_crystal_send_status(type, nt, 0);
                }

                nt += call_power_up_character_send_status(type);

                if (nt <= 0) nt = 1;
            }
        }
        */

        return nt;
    }

    public String call_name() { return s1.data_magagement.character_data.character_name(call_type1()); }
    public int call_type1() { return call_status(TYPE1); }
    public int call_attribute_1() { return call_status(STATUS_ATTRIBUTE_1); }
    public int call_attribute_2() { return call_status(STATUS_ATTRIBUTE_2); }

    public int call_level() { return call_status(LEVEL1); }
    public int call_exp1() { return call_status(NOW_EXP); }
    public int call_mhp() { return call_status(STATUS_MHP); }
    public int call_mmp() { return call_status(STATUS_MMP); }
    public int call_tec() { return call_status(STATUS_TEC); }
    public int call_atk() { return call_status(STATUS_ATK); }
    public int call_int() { return call_status(STATUS_INT); }

    public int call_equipment_link(int num1) { return call_status(EQUIPMENT_1 + num1); }

    public int call_skill_1() { return call_status(SKILL_1); }
    public int call_skill_2() { return call_status(SKILL_2); }
    public int call_enchantment() { return call_status(TYPE1); }

    public int call_skill_1_need_point() { return s1.data_magagement.skill_data.skill_use_need_point(call_skill_1()); }
    public int call_skill_2_need_point() { return s1.data_magagement.skill_data.skill_use_need_point(call_skill_2()); }


    public int equipment_calc(int var1, int status_type1)
    {
        int tec1 = call_tec();

        for (int t1 = 0; t1 < 4; t1++)
        {
            int eq_link = call_equipment_link(t1);
            if (eq_link != s1.am1.equipment_null_num())
            {
                int var2 = 0;

                if (status_type1 == STATUS_MHP) { var2 = s1.equipment_group.equipment1[eq_link].call_mhp(); }
                if (status_type1 == STATUS_MMP) { var2 = s1.equipment_group.equipment1[eq_link].call_mmp(); }
                if (status_type1 == STATUS_ATK) { var2 = s1.equipment_group.equipment1[eq_link].call_atk(); }
                if (status_type1 == STATUS_INT) { var2 = s1.equipment_group.equipment1[eq_link].call_int(); }

                var1 += var2 * tec1 / 100;
            }
        }

        return var1;
    }

    public int equipment_technic_calc(int var1, int status_type1)
    {
        for (int t1 = 0; t1 < 4; t1++)
        {
            int eq_link = call_equipment_link(t1);
            if (eq_link != s1.am1.equipment_null_num())
            {
                var1 += s1.equipment_group.equipment1[eq_link].call_mhp();
            }
        }

        return var1;
    }



    //装備の変更
    public void equipment_change(int eq_link1,int slot)
    {
        if (slot >= 0 && slot <= 3)
        {
            int eq_link2 = status_box[EQUIPMENT_1 + slot];

            //現在の装備の解除
            if (eq_link2 == s1.am1.equipment_null_num())
            {
            }
            else
            {
                status_box[EQUIPMENT_1 + slot] = s1.am1.equipment_null_num();
                s1.equipment_group.equipment1[eq_link2].equipment_change(s1.am1.character_null_num());
            }

            //装備
            if (eq_link1 != s1.am1.equipment_null_num())
            {
                status_box[EQUIPMENT_1 + slot] = eq_link1;
                s1.equipment_group.equipment1[eq_link1].equipment_change(num1);
            }
        }
    }


    public void get_exp(int var1)
    {
        if (call_level() < call_level_max())//status_box[LEVEL_MAX])// || status_box[LEVEL_MAX] >= 100 && call_level() < 500)
        {
            status_box[NOW_EXP] += var1;

            /*
            if (s.tm % 2 == 0)
            {
                if (point >= 1)
                {
                    s.so.se_play(s.so.SE_EXP_GET);
                }
            }
            */

            if (status_box[NOW_EXP] >= level_up_need_exp(call_level()))
            {
                level_up();
            }
        }
        else
        {
            status_box[NOW_EXP] = 0;
        }
    }

    public int level_up_need_exp()
    {
        return level_up_need_exp(call_level());
    }

    public int level_up_need_exp(int level)
    {
        int nt = 0;

        nt = 1000;
        
        nt = m1.iover(nt, 1, 9999);
        
        return nt;
    }

    public void level_up()
    {
        if (call_level() < call_level_max())
        {
            status_box[NOW_EXP] -= level_up_need_exp(call_level());
            status_box[NOW_EXP] = m1.iover(status_box[NOW_EXP], 0, 9999999);

            if (status_box[LEVEL1] <= 99)
            {
                status_box[LEVEL1] += 1;
            }

            /*
            s.so.se_play(s.so.SE_LEVEL_UP);
            */

            //    if (status_box[LEVEL] >= 100) { status_box[LEVEL] = 100; }

            //    protect_key_updata();
        }
    }


    public void run1()
    {
    }

    public void draw1()
    {
    }
}
