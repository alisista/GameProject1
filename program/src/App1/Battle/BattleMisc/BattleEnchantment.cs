using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleEnchantment : SetVoid1
{
    BattleEnchantmentSupport battle_enchantment_support;

    public BattleEnchantment(Summary1 s1)
    {
        set1(s1);

        battle_enchantment_support = new BattleEnchantmentSupport(s1);
    }

    public void init1()
    {
        battle_enchantment_support.init1();
    }


    public int enchantment_type_func(int enchantment_type1) { return enchantment_type1; } //変数をかっこで囲むだけ

    //ステータス強化系
    public int enchantment_power_up(int val1, int status_type1, int battle_character_link1)
    {
        //    int enchantment_type1 = 1;
        int link1 = battle_character_link1;

        int num2 = 1;
        for (int t1 = 0; t1 <= num2; t1++)
        {
            int link2 = 0;
            if (t1 == 0) { link2 = s1.battle_run.battle_member_group_status_control.now_enchant1; }
            if (t1 == 1) { link2 = s1.battle_run.battle_member_group_status_control.now_enchant2; }

            if (s1.battle_run.battle_member_group.enchantment_use_ok(link2) != 0)
            {
                //ここから別クラスに配置
                {
                    int status_type2 = 0;
                    if (status_type1 == s1.battle_run.battle_member_group.battle_member[0].battle_member_status.STATUS_MHP) { status_type2 = s1.am1.STATUS_MHP; }
                    if (status_type1 == s1.battle_run.battle_member_group.battle_member[0].battle_member_status.STATUS_MMP) { status_type2 = s1.am1.STATUS_MMP; }
                    if (status_type1 == s1.battle_run.battle_member_group.battle_member[0].battle_member_status.STATUS_ATK) { status_type2 = s1.am1.STATUS_ATK; }
                    if (status_type1 == s1.battle_run.battle_member_group.battle_member[0].battle_member_status.STATUS_INT) { status_type2 = s1.am1.STATUS_INT; }

                    int use_enchantment_type1 = s1.battle_run.battle_member_group.battle_member[link2].call_enchantment();

                    val1 = battle_enchantment_support.enchantment_power_up_one_calc(val1, t1, status_type2, battle_character_link1, use_enchantment_type1, 0);

                    /*
                    //En1 緑タイプだったら、HP+500
                    if (enchantment_type1 == enchantment_type_func(1))
                    {
                        if (s1.battle_run.battle_member_group.battle_member[link1].call_attribute_1() == s1.am1.ATTRIBUTE_GREEN)
                        {
                            if (status_type1 == s1.battle_run.battle_member_group.battle_member[0].battle_member_status.STATUS_MHP)
                            {
                                val1 += 500;
                            }
                        }
                    }
                    */
                }
            }
        }


        return val1;
    }


    //flowによるエンチャントの変更
    public void enchantment_change()
    {
        //    m1.msbox();

        //HPとMPの変動
        //他のクラスでも使うから、汎用性が高いものを用意
        {
            s1.battle_run.battle_member_group_status_control.mhp_and_mmp_counter_change(0);
        }

        {
            s1.battle_run.battle_member_group_status_control.now_enchant1 = s1.battle_run.battle_member_group_status_control.set_enchant1;
            s1.battle_run.battle_member_group_status_control.now_enchant2 = s1.battle_run.battle_member_group_status_control.set_enchant2;
        }

        {
            s1.battle_run.battle_member_group_status_control.mhp_and_mmp_counter_change(1);
        }
    }


    public void run1()
    {
    }

    public void draw1()
    {
    }
}
