using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class AppVariable1 : SetVoid1
{
    //------------保存すべき変数
    public int player_rank;
    public int player_rank_exp;

    public int coin_num;

    //保存すべき変数


    //------------保存しなくて良い変数
    public int stage_type1;
    public int stage_type2;


    //保存しなくて良い変数


    //コインの値の変化
    public ValueChange value_change_coin;


    public AppVariable1(Summary1 s1)
    {
        set1(s1);

        value_change_coin = new ValueChange(s1);
    }

    public void init1()
    {
        stage_type1 = -1;
        stage_type2 = -1;

        player_rank = 1;
        player_rank_exp = 0;

        coin_num = 10000;

        value_change_coin.init1();
    }

    public int coin_num_call() { return coin_num; }
    public int value_coin_num_call() { return coin_num_call() + value_change_coin.call_value1(); }

    public void coin_add(int coin_num1)
    {
        //最大以上は防止
        {
            int min1 = -coin_num_call();
            int max1 = 99999999 - coin_num_call();
            coin_num1 = m1.iover(coin_num1, min1, max1);

            coin_num += coin_num1;
            coin_num = m1.iover(coin_num, 0, 99999999);

            value_change_coin.value1_add(-coin_num1, -99999999, 99999999);
        }
    }


    public void run1()
    {
        value_change_coin.run1();
    }

    public void draw1()
    {
        value_change_coin.draw1();
    }
}
