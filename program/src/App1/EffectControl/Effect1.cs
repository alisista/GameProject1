using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//細かく動いている画像パーツ
public class Effect1 : EffectExtend
{
    //自分自身の変数番号
    public int num1;

    public int on;
    public float x1;
    public float y1;
    public int type1;
    public int type2;
    public int type3;
    public int type4;
    public int priority;//描画の優先度
    public int tm1;

    public int auto_delete_tm; //0は無制限、1は480、2以降は任意

    public String freestr;
    public int[] freei = new int[12];
    public float[] freef = new float[12];

    public float speed1;
    public float theta1;

    public int clear;
    public int clear_up_down;
    public int clear_sp;

    public float large1 = 1.0f;
    public int on_wait;

    public ClearChange clear_change;


    public Effect1(Summary1 s1, int num1)
    {
        this.num1 = num1;

        set1(s1);

        clear_change= new ClearChange(s1);
    }

    public void init1()
    {
        on = 0;
        x1 = 0;
        y1 = 0;        

        priority = 0;

        type1 = 0;
        type2 = 0;
        type3 = 0;
        type4 = 0;
        tm1 = 0;

        for (int t = 0; t < 12; t++)
        {
            freei[t] = 0;
            freef[t] = 0;
        }

        speed1 = 0;
        theta1 = 0;

        
        large1 = 1.0f;
        on_wait = -2;
        
        clear_change.init1();
    }

    public void create()
    {
     //   init1(); //生成時に行われているので不要

        on = 1;
        tm1 = 0;
        
        if (auto_delete_tm == 1) { auto_delete_tm = 480; }



    //    m1.end();
    }

    public void delete1()
    {
        on = 0;
    }


    public void run1()
    {
        clear_change.run1();

        {
            run2();
        }


        if (tm1 >= auto_delete_tm && auto_delete_tm >= 1)
        {
            delete1();
        }

        tm1++;

    }//run1()

    public void draw1()
    {
        clear_change.clear_call();

        {
            draw2();           
        }

        clear_change.clear_call_re();

    }//draw1()



    public void run2()
    {
        if (type1 == DAMAGE_NUM1 || type1 == DAMAGE_NUM1_LARGE || type1 == DAMAGE_NUM1_SMALL)
        {
            //type2 色（タイプ）
            //type3 値
            //type4 

            if (tm1 == 0) { }

            //この中に時間表示していも含まれてる
            {
                int damage = type3;//+m.rand2(1);//m.rand(2000);//type2;//1024;
                int len = m1.strbyte("" + damage);
                int xl = 16;//16;//16;//16

                if (type1 == DAMAGE_NUM1) { xl = 16; }
                if (type1 == DAMAGE_NUM1_LARGE) { xl = 24; }
                if (type1 == DAMAGE_NUM1_SMALL) { xl = 12; }

                for (int t = 1; t <= len; t += 1)
                    if (tm1 == 0 + (t - 1) * 4)
                    {
                        //   for (int t = 1; t <= len; t += 1)
                        {
                            int num = damage % (m1.pow_n(10, (len + 1 - t))) / (m1.pow_n(10, ((len + 1 - t) - 1)));
                            //   s.efg.create((int)(x - xl * len / 2 + t * xl - 2), (int)y, type + 1, num, 0);
                            //    s.efg.create((int)(x - 21 * len /2 + t * xl), (int)y, type + 1, num, 0);

                            int on_time = 180;

                            if (type1 == DAMAGE_NUM1)
                            {
                                int tr = s1.effect_group.create((int)(x1 - xl * len / 2 + t * xl - xl + 2), (int)y1 + 16 - xl, DAMAGE_NUM2, type2, num, type4, on_time, 0);
                            }

                            if (type1 == DAMAGE_NUM1_LARGE)
                            {
                                int tr = s1.effect_group.create((int)(x1 - xl * len / 2 + t * xl - xl + 2), (int)y1 + 16 - xl, DAMAGE_NUM2_LARGE, type2, num, type4, on_time, 0);
                            }

                            if (type1 == DAMAGE_NUM1_SMALL)
                            {
                                int tr = s1.effect_group.create((int)(x1 - xl * len / 2 + t * xl - xl + 2), (int)y1 + 16 - xl, DAMAGE_NUM2_SMALL, type2, num, type4, on_time, 0);
                            }
                        }
                    }
            }
        }

        if (type1 == DAMAGE_NUM2 || type1 == DAMAGE_NUM2_LARGE || type1 == DAMAGE_NUM2_SMALL)
        {
            int max = 60;
            //    int c_tm = 48;
            //    if (tm1 >= max && tm1 <= max + c_tm)
            if (tm1 == max)
            {
                clear_change.change_set(255, -8);
                //    g1.setClear(255 - (tm1 - max) * 255 / c_tm);
            }
        }

        if (type1 == DAMAGE_STR1)
        {

        }


        if (type1 == BATTLE_NEXT_AREA_NAME_LOGO)
        {
            if (tm1 == 0)
            {
                //;
                y1 = 150;//120;

                clear_change.change_set(0, 16);
            }

            x1 = s1.battle_run.battle_window_w_call() / 2;

            {
                int n1 = 30;
                if (tm1 <= n1)
                {
                    int r1 = 60;

                    x1 += +r1 + m1.sin_r(r1, 90 + 90 * (n1 - tm1) / n1);
                }
            }

            {
                int n2 = 30;
                int n1 = 90 - 20;
                if (tm1 == n1+15)
                {
                    clear_change.change_set(255, -16);
                }

                if (tm1 >= n1 && tm1 <= n1 + n2)
                {
                    int r1 = 60;

                    x1 += -r1 - m1.sin_r(r1, 90 + 90 * ((tm1 - n1)) / n2);
                }
            }
        }

        if (type1 == STAGE_CLEAR)
        {
            int n1 = 8 + s1.battle_run.battle_window_center_x_call(), n2 = 40;//105, n2 = 64;
            int m1 = s1.battle_run.logo_center_y();//240;

            n1 -= n2 * 10 / 2;

            if (tm1 == 0)
            {

                for (int t1 = 0; t1 <= 9; t1++)
                {
                    int n3 = 0;

                    if (t1 >= 5) n3 = 20;

                    int tr = s1.effect_group.create(n1 + t1 * n2 + n3, m1, STAGE_CLEAR_PARTS, t1, 0, 0, 0, 0);
                    s1.effect_group.effect1[tr].tm1 = -t1 * 3;
                }
            }
            

            /*
            if (tm1 >= 56)
            {
                //    if (tm % 2 == 0)
                s1.effect_group.create(s1.battle_run.battle_window_center_x_call(), m1, s.effect_group.CLEAR_STAR_3, m.rand(7), 0, 0, 0);
            }
            */
        }

        if (type1 == STAGE_CLEAR_PARTS)
        {
            if (tm1 == 0)
            {
                //    y = -120;

                //    freef[0] = 0;
                clear_change.change_set(0, 8);

                //    large = 20.0f;
            }

            if (tm1 >= 0)
            {
                int tm_max = 40;
                int tm7 = m1.iover(tm1, 0, tm_max);
                float f1 = 20.0f;
                large1 = f1 + m1.sin_r(f1 - 1.0f, tm7 * 90 / tm_max);

                //    large -= 0.5f;
                if (large1 < 1.0f) large1 = 1.0f;

                //    m.end();
            }
        }
    }//run2()

    public void draw2()
    {
        if (type1 == DAMAGE_NUM2 || type1 == DAMAGE_NUM2_LARGE || type1 == DAMAGE_NUM2_SMALL)
        {
            int num1 = type3;

            int yn = 0, nt = 20;
            if (tm1 >= 0 && tm1 <= nt)
            {
                yn = (int)(m1.sin_r(20, tm1 * 180 / nt));
            }
            if (tm1 >= nt + 1 && tm1 <= nt * 2)
            {
                yn = (int)(m1.sin_r(10, (tm1 - (nt + 1)) * 180 / nt));
            }

            {
                g1.sc(255);
                //    g.str2(""+type2, x1, y1+yn);

                //    if (type == BATTLE_DAMAGE_S)
                {
                    //    if (type2 >= 1) { s.dm.attribute_bright_set(type2); }

                    //    type4 = 1;

                    int img_type1 = 0;

                    float large1 = 1.0f;

                //    if (type4 == 0)
                    {
                        if (type1 == DAMAGE_NUM2) { large1 = 1.0f; }
                        if (type1 == DAMAGE_NUM2_LARGE) { large1 = 1.5f; }
                        if (type1 == DAMAGE_NUM2_SMALL) { large1 = 0.8f; }

                        if (type2 == 1) { img_type1 = 1; }
                        if (type2 == 2) { img_type1 = 2; }
                        if (type2 == 3) { img_type1 = 3; }
                        if (type2 == 4) { img_type1 = 4; }
                        if (type2 == 5) { img_type1 = 5; }
                        if (type2 == 6) { img_type1 = 6; }

                        if (type2 == 100) { img_type1 = 7; }
                        if (type2 == 101) { img_type1 = 8; }
                    }

               //     if (type4 == 1) { nump1 = 1; }

                    s1.dm1.num_img_draw((int)x1 + 4 + 2, (int)y1 + yn, num1, 1, img_type1, 0, large1, 0);

               //     m1.end();

                    //    if (type2 >= 1) { g.setBright(255); }

                    
                    //消しちゃダメ 文字表示板
                //    g1.setfont(1);
               //     g1.sc(255);
               //     g1.str2("" + num1, (int)x1, (int)y1 + yn);
               //     g1.str("" + num1, (int)x1, (int)y1 + yn);
                //    g1.setfont(0);
                    
                }
                /*
                if (type == BATTLE_CURE_S)
                {
                    g.drawImage(im.loadcheck(0, 25, type2), x1, y1 + yn);
                }
                if (type == BATTLE_MP_DAMAGE_S)
                {
                    g.drawImage(im.loadcheck(0, 26, type2), x1, y1 + yn);
                }
                if (type == BATTLE_MP_CURE_S)
                {
                    g.drawImage(im.loadcheck(0, 27, type2), x1, y1 + yn);
                }
                */
            }
        }

        if (type1 == DAMAGE_STR1)
        {
        //    g1.sc(255);
        //    g1.str2("test", x1, y1);
        }

        if (type1== BATTLE_NEXT_AREA_NAME_LOGO)
        {
            if (tm1 >= 1)
            {
                g1.setfont(g1.FONT_1_MAIN_STR);

                String st1 = s1.data_magagement.dungeon_data.battle_name_call();

                if (s1.data_magagement.dungeon_data.battle_num_last_check() == 0)
                {
                    g1.sc(255);                    
                }
                else
                {
                    g1.sc(255, 192, 192);
                    st1 = "Boss Battle!";
                }

                g1.str2_center("" + st1, x1 - 8, y1 + 24, g1.font_w_size_call());

                g1.setfont_re();
            }
        }


        if (type1 == STAGE_CLEAR_PARTS)
        {
            float la1 = 0.68f;

            if (tm1 >= 1)
            {
                g1.drawImage(ic1.loadcheck(7, 1, type2), (int)x1, (int)y1, large1 * 0.8f * la1, 0);
            }
        }

    }//draw2()
}
