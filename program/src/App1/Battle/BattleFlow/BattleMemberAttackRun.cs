using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//単体での攻撃活動、BattleMemberAttackRunが管理
public class BattleMemberAttackRun : SetVoid1
{
    //個別の番号 仲間のバトルキャラの番号リンクに連動
    int num1;

    public int on;

    public int attack_wait_time;

    BattleMemberAttackDamageCalc battle_member_attack_damage_calc;

    public BattleMemberAttackRun(Summary1 s1, int num1)
    {
        set1(s1);
        this.num1 = num1;

        battle_member_attack_damage_calc = new BattleMemberAttackDamageCalc(s1, num1);
    }

    public void init1()
    {
        on = 0;

        attack_wait_time = 0;

        battle_member_attack_damage_calc.init1();
    }

    public void attack_wait_set()
    {
        on = 1;

        attack_wait_time = 8;
    }

    public void attack_on1()
    {
        battle_member_attack_damage_calc.attack_on1();
    }

    public void run1()
    {
        if (attack_wait_time >= 1)
        {
            if (attack_wait_time == 1)
            {
                attack_on1();

                on = 0;
            }

            attack_wait_time--;
        }
    }

    public void draw1()
    {
    }
}
