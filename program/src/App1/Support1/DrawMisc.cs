using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DrawMisc : SetVoid1
{
    public void init_set1(Summary1 s1)
    {
        set1(s1);
        init1();
    }

    public void init1()
    {

    }

    public void character_draw(float dx, float dy, int type1, int free1,int large_type)
    {
        ImageData1 im1 = s1.image_save_character.loadcheck1(type1);
        int slot1 = s1.data_magagement.character_draw_point.load_slot(type1);

        float large_meg = 1.00f;

        int w2 = im1.call_w();
        int h2 = im1.call_h();

        //    int dx2 = (int)dx;
        //    int dy2 = (int)dy;

        int dx2 = (int)dx + (int)(s1.data_magagement.character_draw_point.character_draw_point_child[slot1].x_move);
        int dy2 = (int)dy + (int)(s1.data_magagement.character_draw_point.character_draw_point_child[slot1].y_move);

     //   int shadow_y_move = (int)(s1.data_magagement.enemy_draw_point.enemy_draw_point_child[slot1].shadow_y_move);
     //   float shadow_large1 = s1.data_magagement.enemy_draw_point.enemy_draw_point_child[slot1].shadow_large;
      
        //キャラ描画
        {
            //    g1.setClear(127);
            g1.drawImage(im1, (int)dx2, (int)dy2, large_meg, 0);
            //    g1.setClearre();
        }
    }


    //キャラクターウインドウを普通に描画する関数
    //但し、この関数の直接使用は止めたほうがいいかも。何らかのキャラ表示関数からこの大本を表示すべし
    public void character_window_draw(float dx, float dy, int type1, int free1, int size_type1, int att_ride_1, int att_ride_2, int free4)
    {
        if (m1.rect_decision(dx, dy, -100, -100, s1.game_display_w+200, s1.game_display_h + 200) == 1)
        {
            int att_type1 = 1;// s.race_data.status_call(race1, s.race_data.STATUS_ATTRIBUTE_1);//s.chg.ch[link_num].attribute_check1();
            int att_type2 = 1;// att2;//s.race_data.status_call(race1, s.race_data.STATUS_ATTRIBUTE_2);//s.chg.ch[link_num].attribute_check2();

            att_type1 = m1.iover(att_type1, 1, 6);
            att_type2 = m1.iover(att_type2, 1, 6);

            if (att_ride_1 >= 1) { att_type1 = m1.iover(att_ride_1, 1, 6); }
            if (att_ride_2 >= 1) { att_type2 = m1.iover(att_ride_2, 1, 6); }

            int w1 = 128;

            float large1 = 1.0f;

            if (size_type1 == 0) { large1 = 1.0f * 108 / w1; }//戦闘中の大きさ
            if (size_type1 == 1) { large1 = 1.0f * 90 / w1; }//編成画面の大きさ
            if (size_type1 == 2) { large1 = 1.0f * 80 / w1; }//パーティ編成の大きさ

            //キャラクターの描画
            if (type1 >= 1)
            {
                {
                //    m1.end();
                    

                    //キャラの描画
                    {
                        g1.drawImage2(s1.image_save_character_window.loadcheck1(type1), dx + 2, dy + 2, 0.95f * large1);
                    }
                }
            }

            //ウインドウの描画
            if (type1 >= 1)
            {
            //    int rect1 = 108;
            //    float large2 = (large1 * rect1 / w1);
                g1.drawImage(ic1.loadcheck(2, 2 + att_type1 - 1, 0 + att_type2 - 1), dx + large1 * w1 / 2, dy + large1 * w1 / 2, large1, 0);
            }
        }
    }


    public void battle_enemy_draw(float dx, float dy, int type1, int free1, int shadow_flag, int shadow_yp, int lock_flag, float large_meg)
    {
        ImageData1 im1 = s1.battle_run.battle_enemy_group.image_save_enemy.loadcheck1(type1);
        
        int slot1 = s1.data_magagement.enemy_draw_point.load_slot(type1);
        if (large_meg <= 0.1f) large_meg = 1.00f;

        //ここで先に、敵キャラの表示の最終倍率を出しておく
        large_meg = large_meg * s1.data_magagement.enemy_draw_point.enemy_draw_point_child[slot1].enemy_large;



        int w2 = im1.call_w();
        int h2 = im1.call_h();

    //    int dx2 = (int)dx;
    //    int dy2 = (int)dy;

        int dx2 = (int)dx + (int)(s1.data_magagement.enemy_draw_point.enemy_draw_point_child[slot1].x_move);
        int dy2 = (int)dy + (int)(s1.data_magagement.enemy_draw_point.enemy_draw_point_child[slot1].y_move);

        int shadow_y_move = (int)(s1.data_magagement.enemy_draw_point.enemy_draw_point_child[slot1].shadow_y_move);
        float shadow_large1 = s1.data_magagement.enemy_draw_point.enemy_draw_point_child[slot1].shadow_large;

        //影の描画
        if (shadow_flag == 1)
        {
            float large = shadow_large1 * w2 / 440 * 0.8f * large_meg;

            g1.drawImage(ic1.loadcheck(5, 0, 0), (int)dx, (int)dy + h2 / 2 + (shadow_y_move - 15) * 3 / 2, large * 0.9f, 0);

            //    g1.drawImage(ic1.loadcheck(5, 0, 0), (int)dx2, (int)dy + h2 / 2, large, 0);
        }

        //キャラ描画
        {
        //    g1.setClear(127);
            g1.drawImage(im1, (int)dx2, (int)dy2, large_meg, 0);
        //    g1.setClearre();
        }

        //ロックオン
        if (lock_flag != 0)
        {
        //    if (num1 == s1.battle_run.battle_enemy_group.target_lock_num)
            {
                int x4 = (int)dx;
                int y4 = (int)dy;

                float la3 = 1.0f;//0.80f;
                float th3 = -(int)(0.5f * s1.tm1);
                
                g1.setClear2(168);

                g1.drawImage(ic1.loadcheck(5, 4, 0), x4, y4, la3, th3);

            //    g1.str2("" + g1.clear_count ,x4, y4);

                g1.setClear2_re();

            //    g1.str2("" + g1.clear_count, x4, y4);
            //    g1.str2("" + g1.clear_memo, x4, y4+20);
            }
        }
    }

    public void equipment_draw(float dx, float dy, int type1, int free1, int size_type1, int att_ride_1, int att_ride_2, int free4)
    {
        if (m1.rect_decision(dx, dy, -100, -100, s1.game_display_w+200, s1.game_display_h+200) == 1)
        {
            int att_type1 = 1;// s.race_data.status_call(race1, s.race_data.STATUS_ATTRIBUTE_1);//s.chg.ch[link_num].attribute_check1();
            int att_type2 = 1;// att2;//s.race_data.status_call(race1, s.race_data.STATUS_ATTRIBUTE_2);//s.chg.ch[link_num].attribute_check2();
            
            if (att_ride_1 >= 1) { att_type1 = m1.iover(att_ride_1, 1, 6); }
            if (att_ride_2 >= 1) { att_type2 = m1.iover(att_ride_2, 1, 6); }

            int w1 = 64;

            float large1 = 1.0f;

            if (size_type1 == 0) { w1 = 48; }//戦闘中の大きさ
            if (size_type1 == 1) { w1 = 64; }//編成画面の大きさ

            large1 = 1.0f * w1 / 64;


            //ウインドウの描画
            if (type1 >= 1)
            {
                float large7 = 0.52f;//0.57f;

            //    if (size_type1 == 0) { large7 = 0.36f; }

                int rect1 = w1;
                float large2 = large7 * large1;//0.39f;//(large1 * large7 * rect1 / w1);

                 //   g1.setClear2(96);
                 //   g1.sc(32);
                 //   g1.drawRect(dx, dy, w1, w1, 0, 1);
                 //   g1.setClear2_re();

                //    boxdraw3(dx, dy, w1, w1, 0, 1);

                g1.drawImage(ic1.loadcheck(2, 2 + att_type1 - 1, 0 + att_type2 - 1), dx + 0 + w1 / 2, dy + 0 + w1 / 2, large2, 0);
            }

            //装備品の描画
            if (type1 >= 1)
            {
                {
                    //装備品の描画
                    {
                        g1.drawImage(s1.image_save_equipment.loadcheck1(type1), dx +w1/2, dy + w1 / 2, large1, 0);

                    }
                }
            }
        }
    }


    /*
    //キャラクターの描画 (全体)
    public void chara_draw(float dx, float dy, int race_type, int battle_type, int shadow_flag, int lock_on_flag, int lock_th, int shadow_yp, float large_meg)
    {
        int race1 = race_type;
        s.character_draw_point.character_draw_setting(race1);



        if (large_meg <= 0.1f) large_meg = 1.0f;

        float size1 = enemy_large_meg * s.character_draw_point.character_draw_point_child[race_type].enemy_large;

        Image im1 = s.image_save_character.loadcheck2(race_type);
        int w = call_chara_position(race_type, 2);//(int)(enemy_large_meg * g.Image_size_w(im1));
        int h = call_chara_position(race_type, 3);//(int)(enemy_large_meg * g.Image_size_h(im1));


        float la1 = 0.7f / 0.8f;
        float la2 = 0.8f / 0.8f;


        int x2 = (int)(la1 * s.character_draw_point.character_draw_point_child[race_type].x_move);
        int y2 = (int)(la1 * s.character_draw_point.character_draw_point_child[race_type].y_move);
        int y3 = (int)(la2 * s.character_draw_point.character_draw_point_child[race_type].shadow_y_move);
        float large1 = s.character_draw_point.character_draw_point_child[race_type].shadow_large * 1.1f;
        

        int x5 = 0;

        if (battle_type == 1)
        {
            x5 = -x2;
            x2 = 0;
        }



        //影の描画
        if (shadow_flag == 1)
        {
            float large = large1 * w / 440 * 0.8f * size1 * large_meg;

            g.drawImage(im.loadcheck(0, 2, 0), (int)dx + x5, (int)dy - 20 + y3 + shadow_yp, large, 0);
        }


        //キャラ描画
        {
            g.drawImage(im1, (int)dx + x2, (int)dy - h / 2 + y2, 1.0f * size1 * large_meg, 0);
        }


        //ロックオン
        if (lock_on_flag == 1)
        {
            int x4 = (int)dx + x2;
            int y4 = (int)dy - h / 2 + y2;// + (int)(la1 * h);

            float la3 = 0.80f;
            float th3 = lock_th;

            g.setClear(168);

            g.drawImage(im.loadcheck(0, 4, 0), x4, y4, la3, th3);

            g.setClearre();
        }


        //    m.msbox(race_type);
        //    m.end();
    }
    */


        //色々なウインドウ用
    public void boxdraw3(float x, float y, int w, int h, int draw_type, int fill_flag)
    {
        //    if (x + w >= -1 && y >= -1 && y <= 601)
        {
            int num1 = 1;
            int a1 = 16, a2 = 17, a3 = 18, a4 = 19, a5 = 20, a6 = 24;//15;

            if (draw_type == 1) { a6 = 25; }

            /*
            if (draw_type >= 10 && draw_type <= 19)
            {
                num1 = 2;

                //背景の変更
                if (draw_type == 11) { a6 = 22; }
                if (draw_type == 12) { a6 = 23; }
                //    if (draw_type == 13) { a6 = 24; }
                //    if (draw_type == 14) { a6 = 25; }
            }
            */


            if (fill_flag == 1)
            {
                g1.setClear2(224);

                //    g.drawrectImage(im.loadcheck(num1, a6, 0), x, y, 0, 0, w, h);
                /*
                if (draw_type == 2)
                {
                    a6 = 22;
                }

                if (draw_type == 3)
                {
                    a6 = 26;
                }

                if (draw_type == 4)
                {
                    a6 = 27;
                }
                */

                g1.drawImage(ic1.loadcheck(num1, a6, 0), x, y, x + w, y, x + w, y + h, x, y + h);


            //    g1.str2("" + g1.clear_count + " , "+g1.clear_memo, x, y);

                g1.setClear2_re();

            //    g1.str2("" + g1.clear_count + " , " + g1.clear_memo, x, y+32);
            }


            int len = 4;//6

            g1.drawrectImage(ic1.loadcheck(num1, a1, 0), x, y - len - 2, 0, 0, w, len + 2);
            g1.drawrectImage(ic1.loadcheck(num1, a2, 0), x, y + h, 0, 0, w, len);
            g1.drawrectImage(ic1.loadcheck(num1, a3, 0), x - len - 2, y, 0, 0, len + 2, h);
            g1.drawrectImage(ic1.loadcheck(num1, a4, 0), x + w, y, 0, 0, len, h);

            g1.drawImage(ic1.loadcheck(num1, a5, 0), x - len / 2 - 1, y - len / 2 - 1);
            g1.drawImage(ic1.loadcheck(num1, a5, 0), x - len / 2 - 1, y + h + len / 2 + 1, 1, 90);
            g1.drawImage(ic1.loadcheck(num1, a5, 0), x + w + len / 2 + 1, y + h + len / 2 + 1, 1, 180);
            g1.drawImage(ic1.loadcheck(num1, a5, 0), x + w + len / 2 + 1, y - len / 2 - 1, 1, 270);
        }
    }


    //1~6
    public void attribute_draw(int x, int y, int type, float large_meg, int free1, int free2)
    {
        if (type >= 0)
        {
            if (large_meg <= 0.1f) large_meg = 1.0f;

            float la1 = 0.50f * large_meg;

            int type3 = m1.iover(type - 1, 0, 5);
            int type4 = 0;

            if (type3 == 0) { type4 = 0; }
            if (type3 == 1) { type4 = 1; }
            if (type3 == 2) { type4 = 2; }
            if (type3 == 3) { type4 = 3; }
            if (type3 == 4) { type4 = 4; }
            if (type3 == 5) { type4 = 5; }


            g1.drawImage(ic1.loadcheck(2, 0, type4), x, y, la1, 0);
        }
    }

    //1~2
    public void hp_and_mp(int x, int y, int type, float large_meg, int free1, int free2)
    {
        if (type >= 0)
        {
            if (large_meg <= 0.1f) large_meg = 1.0f;

            float la1 = 0.50f * large_meg;

            int type3 = m1.iover(type - 1, 0, 1);
            int type4 = 0;
            int y30 = 0;

            if (type3 == 0) { type4 = 0; y30 = 1; }
            if (type3 == 1) { type4 = 1; }
            
            g1.drawImage(ic1.loadcheck(2, 1, type4), x, y+y30, la1, 0);
        }
    }


    public void gauge_window_draw1(float x, float y, int w,int per1, int color_type, int size1_h1,int line_draw_no_flag,int back_draw_no_flag)
    {
        int type3 = color_type;
        int type4 = 0;

        if (type3 == 1) { type4 = 0; }
        if (type3 == 2) { type4 = 1; }
        if (type3 == 3) { type4 = 2; }
        if (type3 == 4) { type4 = 3; }
        if (type3 == 5) { type4 = 4; }
    //    if (type3 == 6) { type4 = 5; }

        if (type3 == 101) { type4 = 6; }
        if (type3 == 102) { type4 = 7; }

        int nt1 = size1_h1;//30;//16;//大きさ

        int w2 = m1.iover(w * per1 / 100, 0, w);
        int w3 = m1.iover(w * (per1 - 100) / 100, 0, w);

        //色塗り
        {
            //背景
            if (back_draw_no_flag == 0)
            {
                g1.drawImage2(ic1.loadcheck(3, type4 * 3 + 1 + 1, 0), x, y, w, nt1);
            }

            //左右の枠
            if (!(back_draw_no_flag != 0 && w3 >= 0))
            {
                g1.drawImage2(ic1.loadcheck(3, type4 * 3 + 1, 0), x, y, w2, nt1);
            }

            //オーバーチャージ
            g1.drawImage2(ic1.loadcheck(3, type4 * 3 + 2 + 1, 0), x, y, w3, nt1);
        }

        //枠
        if (line_draw_no_flag == 0)
        {
            //中央線
            g1.drawImage2(ic1.loadcheck(3, 26, 0), x, y, w, nt1);

            //左右の枠
            g1.drawImage2(ic1.loadcheck(3, 26 - 1, 0), x, y, nt1, nt1);
            g1.drawImage2(ic1.loadcheck(3, 26 + 1, 0), x + w - nt1, y, nt1, nt1);
        }
    }


    //数字を画像で表示する関数
    public void num_img_draw(int dx, int dy, int num1, int length, int img_type, int draw_0_flag, float large1, int free0)
    {
        int p1 = 0, p2 = 0, lp = 0;


        //   if (img_type == 0) { p1 = 0; p2 = 28; lp = 16; }

        //    if (img_type == 0) { p1 = 0; p2 = 2; lp = 48; }//turnの文字
        //    if (img_type == 1) { p1 = 0; p2 = 3; lp = 30; }//scoreの文字
        //    if (img_type == 2) { p1 = 0; p2 = 16; lp = 24; }//stageの文字

        //    if (img_type == 2) { p1 = 0; p2 = 7; lp = 14; }
        //    if (img_type == 3) { p1 = 0; p2 = 8; lp = 14; }
        //     if (img_type == 0) { p1 = 0; p2 = 5; lp = 14; }

        if (img_type == 1) { p1 = 5; p2 = 20 + 1; lp = 14; }
        if (img_type == 2) { p1 = 5; p2 = 20 + 2; lp = 14; }
        if (img_type == 3) { p1 = 5; p2 = 20 + 3; lp = 14; }
        if (img_type == 4) { p1 = 5; p2 = 20 + 4; lp = 14; }
        if (img_type == 5) { p1 = 5; p2 = 20 + 5; lp = 14; }
        if (img_type == 6) { p1 = 5; p2 = 20 + 6; lp = 14; }
        if (img_type == 7) { p1 = 5; p2 = 20 + 7; lp = 14; }
        if (img_type == 8) { p1 = 5; p2 = 20 + 8; lp = 14; }

       
        {
            lp = (int)(large1 * lp) + 1;
        }


        for (int t1 = 0; t1 < length; t1++)
        {
            int n2 = (length - 1) - t1;

            int n3 = num1 % (m1.pow_n(10, n2 + 1));
            int n1 = (n3 / (m1.pow_n(10, n2)));
            n1 = m1.iover(n1, 0, 9);

            int n4 = num1 / (m1.pow_n(10, n2 + 0));

            if (draw_0_flag == 1 && (n4 >= 0 || t1 == (length - 1)) || draw_0_flag != 1 && (n4 > 0 || t1 == (length - 1)))
            {
                    g1.drawImage2(ic1.loadcheck(p1, p2, n1), -4 + dx + t1 * lp - 4, dy, large1);
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