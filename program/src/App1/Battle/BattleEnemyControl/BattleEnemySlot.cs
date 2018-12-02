using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//敵の出現情報の変数を入れておくだけのもの
public class BattleEnemySlot
{
    public int type1;
    public int strength1;

    public int leader_flag;

    //1-中ボス 2-ボス
    //    public int boss_level;

    //ステ全体強化
    //public int strength_per;

    //HPだけ強化
    public int hp_per;

    public void init1()
    {
        type1 = 0;
        strength1 = 0;

        leader_flag = 0;

    //    strength_per = 100;

    //    hp_per = 100;

        //        boss_level = 0;
    }
}
