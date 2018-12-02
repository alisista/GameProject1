using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//直接使うことはない エンチャント管理系に継承
public class BattleEnchantmentSupportExtend : SetVoid1
{
    public int status_type_memo;
    public int link1_memo;
    public int use_enchantment_type1;

    public void init1()
    {
        status_type_memo = 0;
        link1_memo = 0;
    }
    
    public int enchantment_type1_check(int type1)
    {
        int nt1 = 0;
        if (use_enchantment_type1 == type1) { nt1 = 1; }
        return nt1;
    }

    public int status_type_check(int status_type1)
    {
        int nt1 = 0;
        if (status_type1 == status_type_memo) { nt1 = 1; }
        return nt1;
    }

    public int character_attribute_check(int att1)
    {
        int nt1 = 0;
        if (s1.battle_run.battle_member_group.battle_member[link1_memo].call_attribute_1() == att1) { nt1 = 1; }
        if (s1.battle_run.battle_member_group.battle_member[link1_memo].call_attribute_2() == att1) { nt1 = 1; }
        return nt1;
    }
}
