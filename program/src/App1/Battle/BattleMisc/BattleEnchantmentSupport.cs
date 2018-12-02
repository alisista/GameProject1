using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleEnchantmentSupport : BattleEnchantmentSupportExtend
{
    public BattleEnchantmentSupport(Summary1 s1)
    {
        set1(s1);
    }

    //ここに強化系のスキルを色々と書いていく
    public int enchantment_power_up_one_calc(int val1, int number1, int status_type2, int link1, int use_enchantment_type1, int free2)
    {
        status_type_memo = status_type2;
        link1_memo = link1;
        this.use_enchantment_type1 = use_enchantment_type1;

        //En1 緑タイプだったら、HP+500
        if (enchantment_type1_check(1) != 0)
        {
            if (character_attribute_check(s1.am1.ATTRIBUTE_GREEN) != 0)
            {
                if (status_type_check(s1.am1.STATUS_MHP) != 0) { val1 += 500; }
            }
        }

        //En4 緑タイプだったら、HP1.5倍
        if (enchantment_type1_check(4) != 0)
        {
            if (character_attribute_check(s1.am1.ATTRIBUTE_GREEN) != 0)
            {
                if (status_type_check(s1.am1.STATUS_MHP) != 0) { val1 = val1 * 150 / 100; }
            }
        }



        return val1;
    }
}
