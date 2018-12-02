using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//キャラクターの管理
public class CharacterGroup : CharacterExtend
{    
    static int MAX1 = 8200;     //キャラクターの保存メモリの限界

    public Character1[] character1 = new Character1[MAX1];


    //保存事項------------
    //現在保存可能最大値
    public int character_save_max = 100;//プレイヤーの保存できるキャラクターの限界
    
    //------------

    public CharacterGroup(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

        {
            int level1 = 1;//s.dungeon_data.debug_member_level;

            int[] type1_box = { 1, 2, 3, 4, 5, 6, 0, 0, 0, 0 };
            //   int[] race_box = { 1, 15, 3, 4, 5, 6, 0, 0, 0, 0 };
            //int[] race_box = { 4, 12, 66, 87, 128, 169, 96, 46, 7, 1 };

            /*
            for (int t1 = 0; t1 < 6; t1++)
            {
                character_construct_set(t1);
                character1[t1].status_create(type1_box[t1], level1, 0, 0);
            }*/

            
            for (int t1 = 0; t1 < 18; t1++)
            {
                character_construct_set(t1);
                character1[t1].status_create(t1+1, level1, 0, 0);
            }


            character1[0].status_box[SKILL_2] = 2;
        }
    }

    //デバッグ用
    public void init2()
    {
    //    character1[0].equipment_change(0, 0);
    //    character1[0].equipment_change(1, 1);
    //    character1[0].equipment_change(2, 2);
    }


    public int character_null_check(int num1)
    {
        int nt = 0;

        if (num1 != s1.am1.character_null_num())
        {
            if (character1[num1] == null)
            {
                nt = 1;
            }
        }else
        {
            nt = 1;
        }

        return nt;
    }

    public void character_construct_set(int num1)
    {
        if (character_null_check(num1) == 1)
        {
            character1[num1] = new Character1(s1, num1);
            character1[num1].init1();
        }
    }


    public int call_character_status(int num1,int status_type1)
    {
        int nt = 0;

        character_construct_set(num1);

        if (status_type1 < STATUS_MHP)
        {
            nt = character1[num1].call_status_box(status_type1);
        }
        else
        {
            nt = character1[num1].call_status(status_type1);
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
                nt = s1.data_magagement.character_data.status_call(type1, s1.data_magagement.character_data.STATUS_MHP);
            }

            if (status_type1 == STATUS_MMP)
            {
                nt = s1.data_magagement.character_data.status_call(type1, s1.data_magagement.character_data.STATUS_MMP);
            }

            if (status_type1 == STATUS_ATK)
            {
                nt = s1.data_magagement.character_data.status_call(type1, s1.data_magagement.character_data.STATUS_ATK);
            }

            if (status_type1 == STATUS_INT)
            {
                nt = s1.data_magagement.character_data.status_call(type1, s1.data_magagement.character_data.STATUS_INT);
            }

            if (status_type1 == STATUS_ATTRIBUTE_1)
            {
                nt = s1.data_magagement.character_data.status_call(type1, s1.data_magagement.character_data.STATUS_ATTRIBUTE_1);
            }

            if (status_type1 == STATUS_ATTRIBUTE_2)
            {
                nt = s1.data_magagement.character_data.status_call(type1, s1.data_magagement.character_data.STATUS_ATTRIBUTE_2);
            }

            if (status_type1 == STATUS_TEC)
            {
                nt = s1.data_magagement.character_data.status_call(type1, s1.data_magagement.character_data.STATUS_TEC);
            }
        }

        return nt;
    }


    public void run1()
    {
    }

    public void draw1()
    {
    }
}
