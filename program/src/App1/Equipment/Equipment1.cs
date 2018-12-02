using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Equipment1 : EquipmentExtend
{
    static int STATUS_MAX = 16;
    public int status_max() { return STATUS_MAX; }
    public int[] status_box = new int[STATUS_MAX];

    //個別の番号
    public int num1;

    public int on;

    public int sell_flag;

    public Equipment1(Summary1 s1, int num1)
    {
        set1(s1);
        this.num1 = num1;
    }


    public void init1()
    {
        on = 0;

        sell_flag = 0;

        for (int t1 = 0; t1 < status_max(); t1++)
        {
            status_box[t1] = 0;
        }

        {
            status_box[CHARACTER_LINK] = s1.am1.equipment_null_num();
        }

    }//init1()


    public void delete1()
    {
        on = 0;
    }


    public void status_create(int type1, int free1, int free2)
    {
        init1();

        on = 1;

        status_box[TYPE1] = type1;

        /*
        status_box[LEVEL1] = level1;
        status_box[TYPE1] = type1;

        status_box[SKILL_1] = type1;
        status_box[SKILL_2] = 0;
        */

        //タイムスタンプ
        {
            status_box[GET_DATE_1] = m1.time_stanp_1();
            status_box[GET_DATE_2] = m1.time_stanp_2();

        //    if (num1 <= 0)
        //        m1.msbox("" + status_box[GET_DATE_1] + "," + status_box[GET_DATE_2]);
        }

    }//status_create()



    public int call_status_box(int status_type1) { return status_box[status_type1]; }

    //そのキャラクターの最終ステータスを返す。但しGroup以外では使わないこと
    public int call_status(int status_type1)
    {
        int nt = 0;
        
//        int level1 = status_box[LEVEL1];
        int type1 = status_box[TYPE1];

        if (status_type1 >= STATUS_MHP)
        {
            nt = s1.equipment_group.call_create_status(type1, 1, status_type1);
        }
        else
        {
            nt = call_status_box(status_type1);
        }

        return nt;
    }
    

    public String call_name() { return s1.data_magagement.equipment_data.equipment_name(call_type1()); }
    public int call_type1() { return call_status(TYPE1); }
    public int call_attribute_1() { return call_status(STATUS_ATTRIBUTE_1); }
    public int call_attribute_2() { return call_status(STATUS_ATTRIBUTE_2); }
    
    public int call_mhp() { return call_status(STATUS_MHP); }
    public int call_mmp() { return call_status(STATUS_MMP); }
    public int call_tec() { return call_status(STATUS_TEC); }
    public int call_atk() { return call_status(STATUS_ATK); }
    public int call_int() { return call_status(STATUS_INT); }

    public int call_character_link() { return call_status(CHARACTER_LINK); }

    public int call_time_stamp1() { return call_status(GET_DATE_1); }
    public int call_time_stamp2() { return call_status(GET_DATE_2); }

    public int call_buy_coin_num() { return 1000; }
    public int call_sell_coin_num() { return 100; }

    public void equipment_change(int character_link1)
    {
        //装備の解除
        if (character_link1 == s1.am1.equipment_null_num())
        {
            status_box[CHARACTER_LINK] = s1.am1.equipment_null_num();
        }
        //装備の設定
        else
        {
            status_box[CHARACTER_LINK] = character_link1;
        }
    }


    public void run1()
    {
    }

    public void draw1()
    {
    }
}
