using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EquipmentGroup : EquipmentExtend
{
    static int MAX1 = 8200;     //装備品の保存メモリの限界 (保存 8020まで ショップ 8030 ～ 8130 コピー番号 8199)
    public int max1() { return MAX1; }

    public int hold_box_num_max() { return 8020; }
    public int shop_box_start_num() { return 8030; }


    public Equipment1[] equipment1 = new Equipment1[MAX1];


    //保存事項------------
    //現在保存可能最大値
    public int save_max = 100;//プレイヤーの保存できるキャラクターの限界

    //------------

    public EquipmentGroup(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

        {
            int level1 = 1;//s.dungeon_data.debug_member_level;

            int[] type1_box = { 1, 2, 3, 4, 5, 6, 1, 3, 5, 1, 1, 1, 0, 0 };
            //   int[] race_box = { 1, 15, 3, 4, 5, 6, 0, 0, 0, 0 };
            //int[] race_box = { 4, 12, 66, 87, 128, 169, 96, 46, 7, 1 };

            /*
            for (int t1 = 0; t1 < 12; t1++)
            {
                equipment_construct_set(t1);
                equipment1[t1].status_create(type1_box[t1], 0, 0);
            }*/

            for (int t1 = 0; t1 < 60; t1++)
            {
                equipment_construct_set(t1);
                equipment1[t1].status_create(t1 + 1, 0, 0);
            }


            //   for (int t1 = 12; t1 < 36; t1++)

            /*
            for (int t1 = 12; t1 < 24; t1++)
            {
                equipment_construct_set(t1);
                equipment1[t1].status_create(6, 0, 0);
            }
            */

            //    equipment1[0].status_box[SKILL_2] = 2;
        }
    }


    public int equipment_null_check(int num1)
    {
        int nt = 0;

        if (num1 < max1())
        {
            if (equipment1[num1] == null)
            {
                nt = 1;
            }
        }

        return nt;
    }

    public void equipment_construct_set(int num1)
    {
        if (equipment_null_check(num1) == 1)
        {
            equipment1[num1] = new Equipment1(s1, num1);            
        }

        equipment1[num1].init1();
    }

    //特定の場所にアイテム生成
    public void equipment_create(int num1,int type1)
    {
        int t1 = num1;

        {
            int flag1 = 0;

            if (equipment_null_check(t1) == 1) { flag1 = 1; equipment_construct_set(t1); }
            if (equipment_null_check(t1) == 0) if (equipment1[t1].on == 0) { flag1 = 1; }

            if (flag1 == 1)
            {
                if (equipment1[t1].on == 0)
                {
                    equipment1[t1].status_create(type1, 0, 0);
                }
            }
        }
    }

    //とりあえず、アイテム生成。こちらは番号がずれる可能性もある
    public int equipment_create() { return equipment_create(0); }
    public int equipment_create(int type1)
    {
    //    equipment_construct_set(t1);

        int link_num = 0;

        for (int t1 = 0; t1 < max1(); t1++)
        {
            int flag1 = 0;

            if (equipment_null_check(t1) == 1) { flag1 = 1; equipment_construct_set(t1); }
            if (equipment_null_check(t1) == 0) if (equipment1[t1].on == 0) { flag1 = 1; }

            if (flag1 == 1)
            {
                if (equipment1[t1].on == 0)
                {
                    link_num = t1;

                    equipment1[t1].status_create(type1, 0, 0);
                    
                    break;
                }
            }
        }

        return link_num;
    }


    public int call_equipment_status(int num1, int status_type1)
    {
        int nt = 0;

        equipment_construct_set(num1);

        if (status_type1 < STATUS_MHP)
        {
            nt = equipment1[num1].call_status_box(status_type1);
        }
        else
        {
            nt = equipment1[num1].call_status(status_type1);
        }

        return nt;
    }


    //そのキャラクターの最終ステータスを返す
    public int call_create_status(int type1, int level1, int status_type1)
    {
        int nt = 100;

        {
            if (status_type1 == STATUS_MHP)
            {
                nt = s1.data_magagement.equipment_data.int_call(type1, s1.data_magagement.equipment_data.STATUS_MHP);
            }

            if (status_type1 == STATUS_MMP)
            {
                nt = s1.data_magagement.equipment_data.int_call(type1, s1.data_magagement.equipment_data.STATUS_MMP);
            }

            if (status_type1 == STATUS_ATK)
            {
                nt = s1.data_magagement.equipment_data.int_call(type1, s1.data_magagement.equipment_data.STATUS_ATK);
            }

            if (status_type1 == STATUS_INT)
            {
                nt = s1.data_magagement.equipment_data.int_call(type1, s1.data_magagement.equipment_data.STATUS_INT);
            }

            if (status_type1 == STATUS_ATTRIBUTE_1)
            {
                nt = s1.data_magagement.equipment_data.int_call(type1, s1.data_magagement.equipment_data.STATUS_ATTRIBUTE_1);
            }

            if (status_type1 == STATUS_ATTRIBUTE_2)
            {
                nt = s1.data_magagement.equipment_data.int_call(type1, s1.data_magagement.equipment_data.STATUS_ATTRIBUTE_2);
            }

            if (status_type1 == STATUS_TEC)
            {
                nt = 10;
            }
        }

        return nt;
    }


    public void sell_flag_reset()
    {
        for (int t1 = 0; t1 < max1(); t1++)
        {
            if (equipment_null_check(t1) == 0)
            {
             //   if (equipment1[t1].on != 0)
                {
                    equipment1[t1].sell_flag = 0;
                }
            }
        }
    }

    public int sell_multi_num_call()
    {
        int nt = 0;

        for (int t1 = 0; t1 < max1(); t1++)
        {
            if (equipment_null_check(t1) == 0)
            {
                if (equipment1[t1].on != 0)
                {
                    if (equipment1[t1].sell_flag == 1) { nt += 1; }
                }
            }
        }

        return nt;
    }

    public int sell_multi_coin_call()
    {
        int nt = 0;

        for (int t1 = 0; t1 < max1(); t1++)
        {
            if (equipment_null_check(t1) == 0)
            {
                if (equipment1[t1].on != 0)
                {
                    if (equipment1[t1].sell_flag == 1) { nt += equipment1[t1].call_sell_coin_num(); }
                }
            }
        }

        return nt;
    }

    public void sell_multi()
    {
        s1.app_variable1.coin_add(sell_multi_coin_call());

        for (int t1 = 0; t1 < max1(); t1++)
        {
            if (equipment_null_check(t1) == 0)
            {
                if (equipment1[t1].on != 0)
                {
                    if (equipment1[t1].sell_flag == 1) { equipment1[t1].delete1(); }
                }
            }
        }

        sell_flag_reset();
    }


    public int equipment_all_num()
    {
        int nt = 0;

        for (int t1 = 0; t1 < hold_box_num_max(); t1++)
        {
            if (equipment_null_check(t1) == 0)
            {
                if (equipment1[t1].on != 0)
                {
                    nt++;
                }
            }
        }

        return nt;
    }

    public void equipment_copy(int target_link,int copy_data_link)
    {
        int t1 = target_link;
        {
            if (equipment_null_check(t1) == 0)
            {
                if (equipment1[t1].on != 0)
                {
                    equipment_create(t1, 1);

                    equipment1[t1].on = equipment1[copy_data_link].on;

                    for (int t2 = 0; t2 < equipment1[0].status_max(); t2++)
                    {
                        equipment1[t1].status_box[t2] = equipment1[copy_data_link].status_box[t2];
                    }
                }
            }
        }
    }

    public void equipment_move(int target_link, int copy_data_link)
    {
        int t1 = target_link;
        {
            if (equipment_null_check(t1) == 0)
            {
                if (equipment1[t1].on != 0)
                {
                    equipment_copy(t1, copy_data_link);

                    equipment1[copy_data_link].delete1();
                }
            }
        }        
    }



    public void run1()
    {
    }

    public void draw1()
    {
    }
}
