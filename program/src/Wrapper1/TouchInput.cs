using System;
using System.Text;

using DxLibDLL;

//タッチ入力管理クラス
public class TouchInput : SetVoid1
{
    Misc1 m;
    MainCanvas1 g;
    Summary1 s;

    //配列0は通常（クリックやタッチ）、配列1はキャンセルボタンに相当

    //２つのスイッチの切替により、一瞬だけ押したか（離したか）どうかのチェックを判定できる
    //どちらも 1になった瞬間が、触れた瞬間と判断される
    int[] a1 = new int[2];//押していると 2 → -1 離していると 2
    int[] b1 = new int[2];//押していると 2       離していると 2 → -1

    public int[] push_flag = new int[2];
    public int[] touch_tm = new int[2];

    public int touch_tm_call() { return touch_tm_call(0); }
    public int touch_tm_call(int type1) { return touch_tm[type1]; }

    public void init_set1(Summary1 s1)
    {
        set1(s1);
        init1();

        this.s = s1;
        this.m = s1.m1;
        this.g = s1.g1;
    }

    public void init1()
    {
        for (int t1 = 0; t1 <= 1; t1++)
        {
            a1[t1] = 0;
            b1[t1] = 0;

            push_flag[t1] = 0;
            touch_tm[t1] = 0;
        }
    }

    public int input_wait;
    
    


    //moveflagだけは、カメラ(cam_2d)が管理してる
    //public int move_flag = 0;



    //タッチされているX座標
    public int touch_x()
    {
        int x, y;
        DX.GetMousePoint(out x, out y);
        return x;
    }

    //タッチされているY座標
    public int touch_y()
    {
        int x, y;
        DX.GetMousePoint(out x, out y);
        return y;
    }


    /*
    public float touch_x_per()
    {
        float fl = 1.0f * touch_x() / s.display_w * 100;
        return fl;
    }

    public float touch_y_per()
    {
        float fl = 1.0f * touch_y() / s.display_h * 100;
        return fl;
    }
    */

    public float touch_x_per2()
    {
        float fl = 0;// 1.0f * touch_x() / s.display_w * 100;

        fl = 1.0f * (touch_x() - s1.display_px()) / s1.display_pw() * 100;

        return fl;
    }

    public float touch_y_per2()
    {
        float fl = 0;

        fl = 1.0f * (touch_y() - s1.display_py()) / s1.display_ph() * 100;

        return fl;
    }


    //座標の倍率を求めた後、ゲーム画面の大きさに合わせたサイズを返す
    public int touch_per2_change_x()
    {
        float fl = touch_x_per2();

        float fl2 = s1.x_per_x_change(fl);

        return (int)fl2;
    }


    //座標の倍率を求めた後、ゲーム画面の大きさに合わせたサイズを返す
    public int touch_per2_change_y()
    {
        float fl = touch_y_per2();

        /*
        if (s.ti.pull_check() == 1)
        {
            m.msbox(fl);
        }
        */

        float fl2 = s1.y_per_y_change(fl);

        return (int)fl2;
    }


    //最終計算した x 座標
    public int point_x1()
    {
        int i2 = touch_per2_change_x();

        return i2;
    }

    //最終計算した y 座標
    public int point_y1()
    {
        int i2 = touch_per2_change_y();

        return i2;
    }



    //タッチされているか？
    public int touch_check() { return touch_check(0); }
    public int touch_check(int pushB_0__cancelB_1)
    {
        int nt = 0;
        int t1 = pushB_0__cancelB_1;

        if (input_wait <= 0)
        {
            if (b1[t1] == 2)
            {
                nt = 1;
            }
        }

        if (nt == 0)
        {
            touch_tm[t1] = 0;
        }

        if (nt == 1)
        {
            touch_tm[t1]++;
        }

        return nt;
    }


    //押した瞬間
    public int push_check() { return push_check(0); }
    public int push_check(int pushB_0__cancelB_1)
    {
        int nt = 0;
        int t1 = pushB_0__cancelB_1;
        
        if (input_wait <= 0)
        {
            if (a1[t1] == 1)
            {
                nt = 1;
            }
        }

        return nt;
    }

    //離した瞬間の取得
    public int pull_check() { return pull_check(0);}
    public int pull_check(int pushB_0__cancelB_1)
    {
        int nt = 0;
        int t1 = pushB_0__cancelB_1;

        if (input_wait <= 0)
        {
            if (b1[t1] == 1)
            {
                if (push_flag[t1] == 1)
                {
                    //    m.msbox("++");
                    //    push_flag = 0;
                    nt = 1;
                }
            }
        }

        return nt;
    }

    //タッチした後に動かした形跡があるかどうか
  //  public int move_check()
  //  {
  //      int nt = move_flag;

   //     return nt;
   // }


    public void run1()
    {
        input_wait--;

        for (int t1 = 0; t1 <= 1; t1++)
        {
            //タッチフラグのメモ
            //コイツがないと、waitしてからボタンを離しても有効化されてしまう
            {
                if (a1[t1] == 1)
                {
                    if (input_wait <= 0)
                    {
                        push_flag[t1] = 1;
                    }
                }

                if (b1[t1] == 0)
                {
                    if (push_flag[t1] == 1)
                    {
                        //    m.msbox("++");
                        push_flag[t1] = 0;
                    }
                }
            }


            if (input_wait <= 0)
            {
                if ((DX.GetMouseInput() & DX.MOUSE_INPUT_LEFT) != 0 && t1==0
                 || (DX.GetMouseInput() & DX.MOUSE_INPUT_RIGHT) != 0 && t1 == 1)// || input.rinput(0, input.INPUT_Z) == 1)
                {
                    //    nt = 1;// 押されている
                    b1[t1] = 2;

                    if (a1[t1] >= 0) a1[t1]--;
                }
                else
                {
                    a1[t1] = 2;
                    //   nt = 0;// 押されていない

                    if (b1[t1] >= 0) b1[t1]--;
                }
            }
            else
            {
                a1[t1] = -1;
                b1[t1] = -1;
                push_flag[t1] = 0;

                //     m.msbox(120);
            }
        }



    }//run()


    public void wait(int tm)
    {
        input_wait = tm;
    }

    public void wait_min(int tm)
    {
        if (input_wait <= tm) { input_wait = tm; }
    }



    public void draw1()
    {

    }
}

