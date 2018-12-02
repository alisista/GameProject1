using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//中継役の置物クラス
public class DataManagement1 : SetVoid1
{
    public CharacterDrawPoint character_draw_point;

    //ダンジョン系
    public EnemyDrawPoint enemy_draw_point;
    public DungeonData dungeon_data;
    public EnemyData enemy_data;

    //キャラクターの確認
    public CharacterData character_data;
    public EquipmentData equipment_data;
    public EnchantmentData enchantment_data;
    public SkillData skill_data;


    public DataManagement1(Summary1 s1)
    {
        set1(s1);

        character_draw_point = new CharacterDrawPoint(s1);
        enemy_draw_point = new EnemyDrawPoint(s1);
        character_data = new CharacterData(s1);
        equipment_data = new EquipmentData(s1);
        enchantment_data = new EnchantmentData(s1);
        skill_data = new SkillData(s1);

        enemy_data = new EnemyData(s1);




        dungeon_data = new DungeonData(s1);
    }

    public void init1()
    {
        character_draw_point.init1();
        enemy_draw_point.init1();
        character_data.init1();
        equipment_data.init1();
        enchantment_data.init1();
        skill_data.init1();

        enemy_data.init1();




        dungeon_data.init1();
    }
}
