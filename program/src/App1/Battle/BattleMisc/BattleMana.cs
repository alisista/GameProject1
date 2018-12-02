using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//左上のゲージの管理
public class BattleMana : SetVoid1
{
    static int MANA_TYPE_MAX1 = 6;
    public int mana_max() { return MANA_TYPE_MAX1; }
    public int[] mana_box = new int[MANA_TYPE_MAX1];    //manaは、10000 で 100% 

    public int[] use_mana_box = new int[MANA_TYPE_MAX1];
    public int[] attribute_mana_box = new int[MANA_TYPE_MAX1];

    //マナは、緑、黄、赤、青、回復、魔力の順になっている。全部で６種類

    //値の変化
    public ValueChange[] value_change = new ValueChange[MANA_TYPE_MAX1];

    public BattleMana(Summary1 s1)
    {
        set1(s1);

        for (int t1 = 0; t1 < mana_max(); t1++)
        {
            value_change[t1] = new ValueChange(s1);
        }
    }

    public void init1()
    {
        for (int t1 = 0; t1 < mana_max(); t1++)
        {
            mana_box[t1] = 0;
            use_mana_box[t1] = 2500;
            attribute_mana_box[t1] = 0;

            value_change[t1].init1();
        }

        battle_start_mana();
    }

    public void battle_start_mana()
    {
        for (int t1 = 0; t1 < mana_max(); t1++)
        {
            mana_box[t1] = 2500 + m1.rand(50) * 100;
        }
    }

    public int mana_point_per_call(int type1)
    {
        int nt = 0;

        nt = mana_box[type1] / 100;

        return nt;
    }

    public int mana_point_draw_per_call(int type1)
    {
        int nt = mana_point_per_call(type1);

        nt += value_change[type1].call_value1() / 100;

        return nt;
    }

    public int use_mana_call(int type1) { return use_mana_box[type1]; }

    public void mana_add(int type1, int var1)
    {
        {
            int n1 = mana_box[type1];
            int n2 = 20000;

            int min1 = -n1;
            int max1 = (n2 - n1);
            var1 = m1.iover(var1, min1, max1);

            mana_box[type1] += var1;

            min1 = -(n2);
            max1 = +(n2);

            value_change[type1].value1_add(-var1, min1, max1);
        }

        mana_box[type1] = m1.iover(mana_box[type1], 0, 20000);
    }

    public void battle_mana_use()
    {
        for (int t1 = 0; t1 < mana_max(); t1++)
        {
            mana_add(t1, -use_mana_box[t1]);
        }
    }//battle_mana_use()

    //コマンドに合わせたマナの消費量
    public void battle_mana_use_calc()
    {
        attribute_mana_calc();

        for (int t1 = 0; t1 < 4; t1++)
        {
            //    m1.msbox(attribute_mana_box[t1]/4);
        }

        for (int t1 = 0; t1 < mana_max(); t1++)
        {
            int use_point = main_mana_use(t1);

            //attribute_mana_box[t1]は、最大で72((8+4)*6) 1.8倍の消費
            if (t1 < 4) { use_point = use_point * attribute_mana_box[t1] / 40; }
            if (t1 >= 4) { }

            //コマンド入力に合わせたマナの消費の変化
            {
                //    m1.msbox(s1.battle_run.battle_member_group_status_control.battle_command);
                
                if (s1.battle_run.battle_member_group_status_control.battle_command == 0) { }
                if (s1.battle_run.battle_member_group_status_control.battle_command == 1) { if (t1 < 4) { use_point *= 2; } if (t1 >= 4) { use_point = 0; } }
                if (s1.battle_run.battle_member_group_status_control.battle_command == 2) { if (t1 != 5) { use_point /= 2; } if (t1 == 5) { use_point *= 2; } }
                if (s1.battle_run.battle_member_group_status_control.battle_command == 3) { if (t1 == 4) { use_point *= 2; } else if (t1 == 5) { use_point /= 2; } else { use_point = 0; } }                
            }

       //     use_point = m1.iover(use_point, 0, attribute_mana_box[t1]);
            use_mana_box[t1] = use_point;
      //      mana_add(t1, -use_point);
        }
    }

    //属性による倍率を入れない場合のマナ消費量
    public int main_mana_use(int type1)
    {
        int nt = mana_box[type1];

        if (nt <= 10000) { nt /= 2; }
        if (nt > 10000) { nt = (nt - 10000) * 3 / 2 + 5000; }

        return nt;
    }

    //各属性から計算できるマナの消費倍率
    //主属性+8、副属性+4　白と黒は全部に+1/4(2,1)
    public void attribute_mana_calc()
    {
        for (int t1 = 0; t1 < mana_max(); t1++)
        {
            attribute_mana_box[t1] = 0;
        }

        for (int t1 = 0; t1 < 6; t1++)
        {
            if (s1.battle_run.battle_member_group.attack_ok(t1) != 0)
            {
                for (int t2 = 0; t2 < 2; t2++)
                {
                    int att = s1.battle_run.battle_member_group.battle_member[t1].call_attribute_1();
                    if (t2 == 1) { att = s1.battle_run.battle_member_group.battle_member[t1].call_attribute_2(); }

                    if (att <= s1.am1.ATTRIBUTE_BLUE)
                    {
                        int pp = 8;
                        if (t2 == 1) { pp = 4; }

                        attribute_mana_box[att - 1] += pp;
                    }

                    if (att > s1.am1.ATTRIBUTE_BLUE)
                    {
                        int pp = 2;
                        if (t2 == 1) { pp = 1; }

                        for (int t3 = 0; t3 < 4; t3++)
                        {
                            attribute_mana_box[t3] += pp;
                        }
                    }
                }
            }
        }
    }

    //ターン終了時のマナ回復量
    public void turn_end_mana_cure()
    {
        //マナの消費量は敵が変更している可能性もあるので、後に再計算
        {
            battle_mana_use_calc();
            battle_mana_use();
        }

        for (int t1 = 0; t1 < mana_max(); t1++)
        {
            int rand1_per = 50 + m1.rand(50);

            int n1 = m1.iover(mana_box[t1] / 100, 0, 100);
            int add_point = 0;

            {
                //0%だと40%ぐらい、100%だと10%ぐらい回復する *3/4
                {
                    int per1 = 30 - 10 * n1 / 100;

                    add_point = 100 * per1 * rand1_per / 100;

                    if (add_point > (10000 - mana_box[t1])) { add_point = (10000 - mana_box[t1]); }
                }
            }

            mana_add(t1, add_point);
        }
    }

    public void debug_mana_full()
    {
        for (int t1 = 0; t1 < mana_max(); t1++)
        {
            int add_point = (20000 - mana_box[t1]);
            mana_add(t1, add_point);
        }
    }

    public void enemy_mana_change(int type1, int type2, int per1) {
        //    mana_add(type1, var1);

        int var1 = (mana_box[type1]) * per1 / 100;

        mana_add(type1, -var1);
        mana_add(type2, var1);
    }

    //マナの消費量はどのくらいの攻撃倍率になるかの計算
    //2500で100% 5000で200% 20000で300%
    public int mana_power(int type1)
    {
        int pow_per = 100;
        int nt = use_mana_box[type1];

        if (nt <= 5000) { pow_per = nt / 25; }
        if (nt > 5000) { pow_per = 200 + (nt - 5000) / 150; }

        return pow_per;
    }

    public void run1()
    {
        for (int t1 = 0; t1 < mana_max(); t1++)
        {
            value_change[t1].run1();
        }
    }

    public void draw1()
    {
        for (int t1 = 0; t1 < mana_max(); t1++)
        {
            value_change[t1].draw1();
        }
    }
}
