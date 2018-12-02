using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DxLibDLL;


public class Input1 : SetVoid1
{
    Misc1 m;
    MainCanvas1 g;
    Summary1 s;

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
        init();
    }

    //final
    public int UP = 1;
    public int DOWN = 3;
    public int LEFT = 2;
    public int RIGHT = 0;
    public int DECIDE = 4;
    public int CANCEL = 5;
    public int MENU = 6;
    public int SUPPORT = 7;//23   
    public int START = 8;//7
    //    public int SELECT = 8;

    public int INPUT_Z = 4;
    public int INPUT_X = 5;
    public int INPUT_C = 6;
    public int INPUT_V = 7;
    public int INPUT_LSHIFT = 23;
    public int INPUT_SPACE = 8;

    public int INPUT_Q = 15;
    public int INPUT_A = 19;
    public int INPUT_S = 20;
    public int INPUT_N = 28;
    public int INPUT_D = 21;
    public int INPUT_W = 16;
    public int INPUT_E = 17;

    //max=31
    static int INPUT_MAX = 30;

    public int input_wait = 0;
    public int[][] input_box = new int[INPUT_MAX][];
    public int[][] key_on_box = new int[INPUT_MAX][];
    int[][] key_con_box = new int[INPUT_MAX][];
    public int[][] key_push_tm = new int[INPUT_MAX][];


    //入力項目の保存
    public int[][] input_save_box = new int[INPUT_MAX][];




    /*
     int[,] input_box=new int[16,1];
    int[,] key_on_box=new int[16,1];
    int[,] key_con_box=new int[16,1];
    int[,] key_push_tm=new int[16,1];
    int[,] input_save_box=new int[16,1];
     */

    int[] key_input = new int[4];
    public int key_all_on_box = 0;
    int key_all_sei = 0;

    //入力したもののメモ
    public int key_box1;

    public int joypad_flag;

    //どのゲームパッドを判断するか //使わない？
    public int use_joypad_num;

    public int change_pad_flag;
    


    public void init()
    {

        //多重配列宣言
        for (int t = 0; t < INPUT_MAX; t++)
        {
            input_box[t] = new int[1];
            key_on_box[t] = new int[1];
            key_con_box[t] = new int[1];
            key_push_tm[t] = new int[1];
            input_save_box[t] = new int[1];
        }

        for (int t = 0; t < 8; t++)
        {
            //   input_pad_box[t] = new int[1];
        }

        input_wait = 0;
        //	key_input=0;

        joypad_flag = 0;

        for (int t = 0; t < INPUT_MAX; t++)
        {
            input_box[t][0] = 0;

            key_on_box[t][0] = 0;
            key_con_box[t][0] = 0;

            key_push_tm[t][0] = 0;

            input_save_box[t][0] = 0;
        }

        input_save_box[0][0] = 16;
        input_save_box[1][0] = 32;
        input_save_box[2][0] = 64;
        input_save_box[3][0] = 128;
        input_save_box[4][0] = 256;


        for (int t = 0; t < 8; t++)
        {
            //  input_pad_box[t][0] = 0;
        }


        use_joypad_num = 0;

        key_input[0] = 0;
        //	key_input[1]=0;

        key_all_on_box = 0;
        key_box1 = 0;

        change_pad_flag = 0;
    }

    //めんどうなので、関数用意(ずっと、一瞬、押してる長さ)
    public int rinput(int type, int num)
    {
        if (num >= 0 && num < INPUT_MAX)
        {
            if (type <= 2)
            {
                if (type == 0)
                {

                    return input_box[num][0];
                }

                if (type == 1)
                {
                    return key_on_box[num][0];
                }

                if (type == 2)
                {
                    return key_push_tm[num][0];
                }
            }
        }

        return -1;
    }


    public void wait(int frane)
    {
        input_wait = frane;
    }

    public void key_push_tm_reset()
    {
        for (int t = 0; t < INPUT_MAX; t++)
        {
            key_push_tm[t][0] = 0;
        }
    }


    //どのコントローラーから入力を得ているのかの取得
    public int where_gamepad()
    {
        int num1 = s.pad_num;

        for (int t = 1; t <= 4; t++)
        {
            int nt = 0;

            if (t == 1) { nt = DX.GetJoypadInputState(DX.DX_INPUT_PAD1); }
            if (t == 2) { nt = DX.GetJoypadInputState(DX.DX_INPUT_PAD2); }
            if (t == 3) { nt = DX.GetJoypadInputState(DX.DX_INPUT_PAD3); }
            if (t == 4) { nt = DX.GetJoypadInputState(DX.DX_INPUT_PAD4); }

            if (nt >= 1)
            {
                num1 = t;
                break;
            }
        }

        return num1;
    }


    public void run1()
    {
        if (change_pad_flag == 1)
        {
            s.pad_num = where_gamepad();
        }

        change_pad_flag = 0;


        //DXライブラリの関数使用
        //key_input = GetJoypadInputState(DX_INPUT_KEY_PAD1);
        //key_input[0] = DX.GetJoypadInputState(DX.DX_INPUT_PAD1);
        //key_input[0] = GetJoypadInputState(DX_INPUT_KEY_PAD1);

        if (s.pad_num == 1)
        {
            key_input[0] = DX.GetJoypadInputState(DX.DX_INPUT_PAD1);
        }
        if (s.pad_num == 2)
        {
            key_input[0] = DX.GetJoypadInputState(DX.DX_INPUT_PAD2);
        }
        if (s.pad_num == 3)
        {
            key_input[0] = DX.GetJoypadInputState(DX.DX_INPUT_PAD3);
        }
        if (s.pad_num == 4)
        {
            key_input[0] = DX.GetJoypadInputState(DX.DX_INPUT_PAD4);
        }

        //keybord_input = 0;

        int n = 0;
        int[] input_box_send = new int[1];

        //キーボード入力
        input_box_send[n] = 0;
        joypad_flag = 1;
        if (DX.CheckHitKey(DX.KEY_INPUT_RIGHT) == 1) { input_box_send[n] += m.pow_n(2, 0); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_UP) == 1) { input_box_send[n] += m.pow_n(2, 1); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_LEFT) == 1) { input_box_send[n] += m.pow_n(2, 2); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_DOWN) == 1) { input_box_send[n] += m.pow_n(2, 3); joypad_flag = 0; }

        if (DX.CheckHitKey(DX.KEY_INPUT_Z) == 1) { input_box_send[n] += m.pow_n(2, 4); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_X) == 1) { input_box_send[n] += m.pow_n(2, 5); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_C) == 1) { input_box_send[n] += m.pow_n(2, 6); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_S) == 1) { input_box_send[n] += m.pow_n(2, 10); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_LSHIFT) == 1) { input_box_send[n] += m.pow_n(2, 23); joypad_flag = 0; }//8
        if (DX.CheckHitKey(DX.KEY_INPUT_A) == 1) { input_box_send[n] += m.pow_n(2, 9); joypad_flag = 0; }
        //   if (DX.CheckHitKey(DX.KEY_INPUT_RSHIFT) == 1) { input_box_send[n] += m.pow_n(2, 10); joypad_flag = 0; }

        if (DX.CheckHitKey(DX.KEY_INPUT_SPACE) == 1) { input_box_send[n] += m.pow_n(2, 8); joypad_flag = 0; }//7

        //作業用の入力装置
        if (DX.CheckHitKey(DX.KEY_INPUT_Q) == 1) { input_box_send[n] += m.pow_n(2, 15); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_W) == 1) { input_box_send[n] += m.pow_n(2, 16); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_E) == 1) { input_box_send[n] += m.pow_n(2, 17); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_R) == 1) { input_box_send[n] += m.pow_n(2, 18); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_A) == 1) { input_box_send[n] += m.pow_n(2, 19); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_S) == 1) { input_box_send[n] += m.pow_n(2, 20); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_D) == 1) { input_box_send[n] += m.pow_n(2, 21); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_F) == 1) { input_box_send[n] += m.pow_n(2, 22); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_V) == 1) { input_box_send[n] += m.pow_n(2, 7); joypad_flag = 0; }//23
        if (DX.CheckHitKey(DX.KEY_INPUT_T) == 1) { input_box_send[n] += m.pow_n(2, 24); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_Y) == 1) { input_box_send[n] += m.pow_n(2, 25); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_G) == 1) { input_box_send[n] += m.pow_n(2, 26); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_H) == 1) { input_box_send[n] += m.pow_n(2, 27); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_N) == 1) { input_box_send[n] += m.pow_n(2, 28); joypad_flag = 0; }
        if (DX.CheckHitKey(DX.KEY_INPUT_B) == 1) { input_box_send[n] += m.pow_n(2, 29); joypad_flag = 0; }
        //   if (DX.CheckHitKey(DX.k) == 1) { input_box_send[n] += m.pow_n(2, 27); joypad_flag = 0; }

        /*
        //ジョイパッド入力、ただし、キー入力がない場合のみ
        if (joypad_flag==1){//CheckHitKeyAll()==0){
            if ((key_input[0] & m.pow_n(2,0)) !=0){
                input_box_send[n]+=m.pow_n(2,3);
            }
        }
        */

        //ジョイパッド入力、ただし、キー入力がない場合のみ
        if (joypad_flag == 1)
        {
            int key = key_input[0];
            if ((key & DX.PAD_INPUT_RIGHT) != 0) { input_box_send[n] += m.pow_n(2, 0); }
            if ((key & DX.PAD_INPUT_UP) != 0) { input_box_send[n] += m.pow_n(2, 1); }
            if ((key & DX.PAD_INPUT_LEFT) != 0) { input_box_send[n] += m.pow_n(2, 2); }
            if ((key & DX.PAD_INPUT_DOWN) != 0) { input_box_send[n] += m.pow_n(2, 3); }
        }


        //保存データからパッドの入力取得
        if (joypad_flag == 1)
        {
            int key = key_input[0];

            for (int t = 0; t <= 5; t++)
            {
                //    if ((key & m.pow_n(2, input_save_box[t][0])) != 0)
                if ((key & input_save_box[t][0]) != 0)
                {
                    input_box_send[n] += m.pow_n(2, (4 + t));
                }
            }
        }



        for (int t = 0; t < INPUT_MAX; t++)
        {
            input_box[t][n] = 0;
        }




        for (int t = 0; t < INPUT_MAX; t++)
        {

            if (input_box_send[n] % m.pow_n(2, t + 1) >= m.pow_n(2, t))
            {
                //	if (input_box_send[n]%m.pow_n(2,2)>=1){//m.pow_n(2,t)){
                input_box[t][n] = 1;
                //	m.end();
                //  m.msbox("" + input_box_send[n]);
            }
            //m.end();
        }



        //押した時の確認(1フレーム後に解除)
        //		for (int t2=0;t2<=1;t2++){
        {
            int t2 = 0;
            for (int t = 0; t < INPUT_MAX; t++)
            {
                int key_n = 0;

                key_n = input_box[t][n];


                /*
                if (input_wait>0){
                    key_n=false;
                }
                */

                key_on_box[t][t2] = 0;
                if (key_n == 1 && key_on_box[t][t2] == 0 && key_con_box[t][t2] == 0)
                {
                    key_on_box[t][t2] = 1; key_con_box[t][t2] = 1;
                }
                if (key_n == 0)
                {
                    key_con_box[t][t2] = 0;
                }



                //if (*point!=0){*point=key_on_box[t][t2];}

                //	input_box[n][t]=key_on_box[t][t2];


                //押している長さの計測
                if (input_box[t][n] == 1) key_push_tm[t][t2] += 1;
                if (input_box[t][n] == 0) key_push_tm[t][t2] = 0;

            }
            //	}
        }



        //キー入力の全取得
        {
            key_all_on_box = 0;
            key_box1 = key_input[0];
            //static int key_all_sei=0;

            if (key_box1 != 0 && key_all_on_box == 0 && key_all_sei == 0)
            {
                key_all_on_box = 1; key_all_sei = 1;
            }
            if (key_box1 == 0)
                key_all_sei = 0;
        }


        //input_waitによる、入力の停止
        if (input_wait > 0)
        {
            for (int t = 0; t < INPUT_MAX; t++)
            {
                input_box[t][n] = 0;
                key_on_box[t][n] = 0;
                key_push_tm[t][n] = 0;
            }
        }


        if (input_wait >= -1)
        {
            input_wait--;
        }
    }

    public void draw1()
    {

        g.sc(210);
        //	g.str(m.cs(key_input[0]),560,400);

        //	if (key_on_box[4][0]==true){
        //		g.str(m.cs(key_on_box[4][0]),560,380);
        //	}
    }
}
