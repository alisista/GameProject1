using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BaseFunction : SetVoid1
{
    public BaseFunction(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

    }





    public int use_music_call(int base_type)
    {
        int so_num = -1;//s.so.BGM_BASE_HOME;

        if (base_type == s1.base_run.STAGE1_SELECT) { so_num = s1.bgm_operation.BGM_STAGE_SELECT; }
        if (base_type == s1.base_run.ORGANIZATION_MENU) { so_num = s1.bgm_operation.BGM_BASE_1; }
        if (base_type == s1.base_run.SHOP_MENU) { so_num = s1.bgm_operation.BGM_SHOP; }
        if (base_type == s1.base_run.OTHER_MENU) { so_num = s1.bgm_operation.BGM_BASE_1; }

        return so_num;
    }














    public int character_organization_check()
    {
        int nt = 0;
        int type1 = s1.base_run.base_type;

        if (type1 == s1.base_run.CHARACTER_ORGANIZATION
         || type1 == s1.base_run.CHARACTER_PARTY_SELECT
         || s1.base_run.base_type_check(s1.base_run.CHARACTER_MULTI_PARTY_SELECT) == 1)
        {
            nt = 1;
        }

        return nt;
    }

    public int equipment_organization_check()
    {
        int nt = 0;
        int type1 = s1.base_run.base_type;

        if (type1 == s1.base_run.EQUIPMENT_ORGANIZATION
         || type1 == s1.base_run.EQUIPMENT_CHARACTER_EQ_CHANGE
         || type1 == s1.base_run.EQUIPMENT_SHOP_BUY
         || type1 == s1.base_run.EQUIPMENT_SHOP_SELL
            )
        {
            nt = 1;
        }

        return nt;
    }

    public int party_organization_check()
    {
        int nt = 0;
        int type1 = s1.base_run.base_type;

        if (type1 == s1.base_run.PARTY_ORGANIZATION
         || s1.base_run.base_type_check(s1.base_run.PARTY_USE_STAGE) == 1
            )
        {
            nt = 1;
        }

        return nt;
    }


    public void character_status_draw_call()
    {
        s1.base_run.character_status.create1();
        s1.base_run.character_status.clear_change.change_set(0, s1.base_run.character_status.clear_speed1());
        s1.touch_input.wait(40);
    }
    

    /*
    public void run1()
    {
    }

    public void draw1()
    {
    }
    */
}