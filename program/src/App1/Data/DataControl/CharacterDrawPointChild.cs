﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//各キャラクターの座標保持
public class CharacterDrawPointChild : SetVoid1
{
    public int num1;

    //    public int num;
    //    public String name;

    //    public int[] status_box = new int[40];


    public int x_move;
    public int y_move;
    public float shadow_large;
    public int shadow_y_move;
    public float enemy_large;


    public CharacterDrawPointChild(Summary1 s1, int num1)
    {
        set1(s1);
        this.num1 = num1;
    }

    public void init1()
    {
        x_move = 0;
        y_move = 0;
        shadow_y_move = 0;
        shadow_large = 1.0f;

        enemy_large = 1.0f;
    }



    //X座標 Y座標 影の大きさ 影のY座標
    public void draw_setting(int x_move1, int y_move1, int large_per, int null1)
    {
        enemy_large = 1.0f * large_per / 100;

        x_move = x_move1;
        y_move = y_move1;
    }


    /*
    public void copy(int target_num)
    {
        x_move = s.character_draw_point.character_draw_point_child[target_num].x_move;
        y_move = s.character_draw_point.character_draw_point_child[target_num].y_move;
        shadow_large = s.character_draw_point.character_draw_point_child[target_num].shadow_large;
        shadow_y_move = s.character_draw_point.character_draw_point_child[target_num].shadow_y_move;
        enemy_large = s.character_draw_point.character_draw_point_child[target_num].enemy_large;
    }
    */
}
