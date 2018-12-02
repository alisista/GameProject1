using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleMemberStatus : SetVoid1
{
    //自分自身の変数番号
    int num1;

    static int STATUS_MAX = 10;
    public int[] status_box = new int[STATUS_MAX];

    public int STATUS_HP = 0;    
    public int STATUS_MP = 1;



    //保存はしない変数
    public int STATUS_MHP = 100010;
    public int STATUS_MMP = 100020;
    public int STATUS_ATK = 100030;
    public int STATUS_INT = 100040;

    public int STATUS_ATTRIBUTE_1 = 100110;
    public int STATUS_ATTRIBUTE_2 = 100120;





    public BattleMemberStatus(Summary1 s1, int num1)
    {
        set1(s1);
        this.num1 = num1;
    }

    public void init1()
    {
        for (int t1 = 0; t1 < STATUS_MAX; t1++)
        {
            status_box[t1] = 0;
        }


        //     status_box[STATUS_HP] = 300; status_box[STATUS_MHP] = status_box[STATUS_HP];

   //     status_box[STATUS_HP] = 200;


   //     status_box[ATTRIBUTE_1] = num1 + 1; status_box[ATTRIBUTE_2] = 1;// m1.iover(num1 + 1, 1, 6);
    }



    public int call_battle_status_box(int status_type)
    {
        int nt = 0;

        nt = status_box[status_type];

        //    nt = curse_status_change(nt, status_type);

        return nt;
    }

    public int call_battle_status(int status_type)
    {
        int nt1 = 0;

        if (status_type< STATUS_MHP)
        {
            call_battle_status_box(status_type);
        }
        else
        {
            int link_num1 = s1.battle_run.battle_member_group.battle_member[num1].character_link_num1;

            if (status_type == STATUS_MHP)
            {
                nt1 = s1.character_group.call_character_status(link_num1, s1.character_group.STATUS_MHP);
                nt1 = s1.battle_run.battle_enchantment.enchantment_power_up(nt1, status_type, num1);
            }

            if (status_type == STATUS_MMP)
            {
                nt1 = s1.character_group.call_character_status(link_num1, s1.character_group.STATUS_MMP);
                nt1 = s1.battle_run.battle_enchantment.enchantment_power_up(nt1, status_type, num1);
            }

            if (status_type == STATUS_ATK)
            {
                nt1 = s1.character_group.call_character_status(link_num1, s1.character_group.STATUS_ATK);
                nt1 = s1.battle_run.battle_enchantment.enchantment_power_up(nt1, status_type, num1);
                nt1 /= 10;
            }

            if (status_type == STATUS_INT)
            {
                nt1 = s1.character_group.call_character_status(link_num1, s1.character_group.STATUS_INT);
                nt1 = s1.battle_run.battle_enchantment.enchantment_power_up(nt1, status_type, num1);
            }

            if (status_type == STATUS_ATTRIBUTE_1)
            {
                nt1 = s1.character_group.call_character_status(link_num1, s1.character_group.STATUS_ATTRIBUTE_1);
            }

            if (status_type == STATUS_ATTRIBUTE_2)
            {
                nt1 = s1.character_group.call_character_status(link_num1, s1.character_group.STATUS_ATTRIBUTE_2);
            }
        }

        return nt1;
    }
    
    public int call_mana_power()
    {
        int nt1 = 0;

        //現在のマナから攻撃力を算出
        //マナは50%の時に、攻撃力100%で計算
        //単一属性の攻撃力は、0 ～ 300% 内で変動 基本は100%
        //副属性が+0.5倍あるので、出力時には2/3される
        //白黒は1/4
        {
            int[] att_move_ok_box = new int[9];
            for (int t = 0; t < 9; t++) { att_move_ok_box[t] = 0; }

            nt1 = 0;

            for (int t1 = 0; t1 <= 1; t1++)
            {
                int att1 = s1.battle_run.battle_member_group.battle_member[num1].call_attribute_1();
                if (t1 == 1) { att1 = s1.battle_run.battle_member_group.battle_member[num1].call_attribute_2(); }

                int pp = 1;
                if (t1 == 1) { pp = 2; }

                if (att1 == s1.am1.ATTRIBUTE_GREEN) { nt1 += s1.battle_run.battle_mana.mana_power(s1.am1.MANA_GREEN) / pp; }
                if (att1 == s1.am1.ATTRIBUTE_YELLOW) { nt1 += s1.battle_run.battle_mana.mana_power(s1.am1.MANA_YELLOW) / pp; }
                if (att1 == s1.am1.ATTRIBUTE_RED) { nt1 += s1.battle_run.battle_mana.mana_power(s1.am1.MANA_RED) / pp; }
                if (att1 == s1.am1.ATTRIBUTE_BLUE) { nt1 += s1.battle_run.battle_mana.mana_power(s1.am1.MANA_BLUE) / pp; }

                for (int t2 = 0; t2 < 4; t2++)
                {
                    if (att1 == s1.am1.ATTRIBUTE_WHITE) { nt1 += s1.battle_run.battle_mana.mana_power(s1.am1.MANA_GREEN + t2) / 4 / pp; }
                    if (att1 == s1.am1.ATTRIBUTE_BLACK) { nt1 += s1.battle_run.battle_mana.mana_power(s1.am1.MANA_GREEN + t2) / 4 / pp; }
                }
            }
        }

        return nt1;
    }

    public int call_cure_point(int hp_0__mp_1)
    {
        int nt1 = 0;

        nt1 = call_cure_power(hp_0__mp_1) * call_cure_mana_power(hp_0__mp_1) / 100;

        return nt1;
    }

    //HP回復力とMP回復力
    public int call_cure_power(int hp_0__mp_1)
    {
        int nt1 = 0;

        //基本値は 1/16
        if (hp_0__mp_1 == 0) { nt1 += (call_battle_status(STATUS_MHP) + call_battle_status(STATUS_INT) * 4) / 8 / 4; }
        if (hp_0__mp_1 == 1) { nt1 += (call_battle_status(STATUS_MMP) * 8 + call_battle_status(STATUS_INT) * 4) / 8 / 4; }

        return nt1;
    }

    public int call_cure_mana_power(int hp_0__mp_1)
    {
        int nt1 = 0;

        if (hp_0__mp_1 == 0) { nt1 += s1.battle_run.battle_mana.mana_power(s1.am1.MANA_HP); }
        if (hp_0__mp_1 == 1) { nt1 += s1.battle_run.battle_mana.mana_power(s1.am1.MANA_MP); }

        return nt1;
    }


    public void run1()
    {
    }

    public void draw1()
    {
    }
}
