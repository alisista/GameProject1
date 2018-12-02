using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BaseButtonSupport : SetVoid1
{
    public BaseButtonSupport(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

    }


    public void button_touch(int num1)
    {
        int type1 = s1.base_run.base_type;

        if (type1 == s1.base_run.ORGANIZATION_MENU)
        {
            if (num1 == 0) { s1.base_run.menu_change_waitact_set(s1.base_run.CHARACTER_ORGANIZATION); }
            if (num1 == 1) { s1.base_run.menu_change_waitact_set(s1.base_run.PARTY_ORGANIZATION); }            
            if (num1 == 2) { s1.base_run.menu_change_waitact_set(s1.base_run.EQUIPMENT_ORGANIZATION); }
        }

        if (type1 == s1.base_run.SHOP_MENU)
        {
            if (num1 == 0) { s1.base_run.menu_change_waitact_set(s1.base_run.EQUIPMENT_SHOP_BUY); }
            if (num1 == 1) { s1.base_run.menu_change_waitact_set(s1.base_run.EQUIPMENT_SHOP_SELL); }
        }

        if (type1 == s1.base_run.OTHER_MENU)
        {
            if (num1 == 0) { s1.base_run.menu_change_waitact_set(s1.base_run.SYSTEM_OPTION); }
        }


    }
}
