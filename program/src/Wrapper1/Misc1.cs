using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;

using System.IO;

//using System.Math;
//using System.IO;

using DxLibDLL;

public class Misc1
{
    public int end_flag = 0;


    public void init1()
    {
        end_flag = 0;
    }

    //スリープ
    public void wait(int frame)
    {
        DX.WaitTimer(frame);
    }



    public void wait(long stime, long etime, int wait_time)
    {

        int FLAME_TIME = wait_time; //≒15 FPS (1000/66)			//1000/80 12.5FPS

        long n1 = FLAME_TIME - (etime - stime);

        if (n1 > 0) { wait((int)n1); }
        else
        {
            wait(10);//10
        }
    }



    //タイマー測定
    long[] FpsTime = new long[2];
    long FpsTime_i = 0;
    int Fps = 0;


    public long FpsTimeFanction()
    {

        if (FpsTime_i == 0)
        {
            FpsTime[0] = get_time();                           //1周目の時間取得
        }

        if (FpsTime_i >= 10)
        {// && (FpsTime[1] - FpsTime[0])>=1){
            FpsTime[1] = get_time();  						 //10周目の時間取得
            if ((FpsTime[1] - FpsTime[0]) > 0)
                Fps = (1000 * 10 * 100) / ((int)(FpsTime[1] - FpsTime[0]));//測定した値からfpsを計算
            Fps /= 100;

            FpsTime_i = 0;
        }
        else
        {
            FpsTime_i++;                                          //現在何周目かカウント
        }

        //	return (long)(FpsTime[1] - FpsTime[0]);//811
        return (long)(Fps);
    }


    //現在の時間取得
    public long get_time()
    {
        // return GetNowCount();
        return DX.GetNowCount();
    }

    public long get_time_sec()
    {
        // return GetNowCount();
        return DX.GetNowCount() / 1000;
    }



    //乱数       
    public int rand(int Rand)
    {
        if (Rand < 0) Rand = 0;
        return DX.GetRand(Rand);
    }

    public int rand2(int Rand)
    {
        return rand(Rand * 2) - Rand;
    }

    public float rand(float Rand)
    {
        return (float)(rand((int)(Rand * 1000))) / 1000;
    }

    public float rand2(float Rand)
    {
        return (float)(rand2((int)(Rand * 1000))) / 1000;
    }

    //double型は使用できない
    //	public double rand(double Rand){
    //		return (double)(rand((int)(Rand*1000)))/1000;
    //	}

    //	public double rand2(double Rand){
    //		return ((double)(rand((int)(Rand*2*1000)))-Rand*1000)/1000;
    //	}

    public int rand2_1()
    {
        int nn = -1;
        if (rand(8) <= 3) nn = 1;
        return nn;
    }


    //もう一つの乱数(.NETから)、種の設定が可能
    Random rnd = new Random();

    public int myrand = 0;
    public int yourand = 0;

    //0~Randまで返す
    public int a_rand(int Rand)
    {
        int nt = rnd.Next(Rand + 1);
        myrand = nt % 255;
        return nt;
    }

    public void a_rand_seed(int seed)
    {
        rnd = new Random(seed);
    }

    public int a_rand2(int Rand)
    {
        return a_rand(Rand * 2) - Rand;
    }

    public float a_rand(float Rand)
    {
        return (float)(a_rand((int)(Rand * 1000))) / 1000;
    }

    public float a_rand2(float Rand)
    {
        return (float)(a_rand2((int)(Rand * 1000))) / 1000;
    }



    //終了
    public void end()
    {
        //    Application.Exit();
        //    DX.DxLib_End();        
        end_flag = 1;
    }


    //２乗
    public float pow2(float value)
    {
        return value * value;
    }

    //ｎ乗
    /*
    public float pow_n(float value, float n)
    {
    return (int)Math.Pow((float)(value), (float)(n));
}
     */


    public float abs(float num)
    {
        if (num < 0) num *= -1;
        return num;
    }
    public int abs(int num)
    {
        if (num < 0) num *= -1;
        return num;
    }



    public float th_set(float n1)
    {
        while (n1 < 0 || n1 > 360)
        {
            if (n1 < 0) n1 += 360;
            if (n1 > 360) n1 -= 360;
        }

        float pai = 3.141592f;
        n1 = 2 * pai * n1 / 360;

        return n1;
    }


    public float cos(float rad)
    {
        return (float)Math.Cos(rad);
    }
    public float sin(float rad)
    {
        return (float)Math.Sin(rad);
    }

    public float cos_r(float r, float th)
    {
        return r * cos(th_set(th));
    }

    public float sin_r(float r, float th)
    {
        return -r * sin(th_set(th));
    }

    public float sin_r2(float r, float th)
    {
        return -sin_r(r, th) * sin_r(r, th);
    }


    public float sqrt(float x)
    {
        return (float)Math.Sqrt(x);
    }

    public float length(float x, float y)
    {
        return sqrt(pow2(x) + pow2(y));
    }

    //距離計算
    public float length(float x1, float y1, float x2, float y2)
    {
        return sqrt(pow2(x2 - x1) + pow2(y2 - y1));
    }


    //距離から角度(θ)を返す
    public float th_cal(float x, float y)
    {
        float r = length(x, y);
        float pai = 3.141592f;

        if (!(x == 0 && y == 0))
        {
            float a = (float)(Math.Atan2(-y, x)) / pai / 2 * 360;

            return a;
        }
        else
        {
            return (1.5f) * pai;
        }
    }


    //360超えてる場合の調整
    public float rad_supx(float n1)
    {
        while (n1 < 0)
        {
            n1 += 360;
        }
        while (n1 >= 360)
        {
            n1 -= 360;
        }

        return n1;
    }


    //x1-y1からx2-y2の距離を求め角度を返す
    public float search(float x1, float y1, float x2, float y2)
    {
        return th_cal(x2 - x1, y2 - y1);
    }




    public void msbox()
    {
        DialogResult result = MessageBox.Show("test", "確認", MessageBoxButtons.OK);
    }

    public void msbox(String str)
    {
        DialogResult result = MessageBox.Show("" + str, "確認", MessageBoxButtons.OK);
    }

    public void msbox(float nt)
    {
        DialogResult result = MessageBox.Show("" + nt, "確認", MessageBoxButtons.OK);
    }

    //yesnoダイアログ
    public int dialog_yesno(String question)
    {
        int nt = 0;
        DialogResult result = MessageBox.Show(question, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

        //何が選択されたか調べる
        if (result == DialogResult.Yes)
        {
            nt = 1;
        }
        else if (result == DialogResult.No)
        {
            nt = 0;
        }

        return nt;
    }


    public int pow_n(int value, int n)
    {
        int nt = value;
        if (n <= 0)
        {
            nt = 1;
        }
        else if (n == 1)
        {
            nt = value;
        }
        else
        {
            for (int t = 2; t <= n; t++)
            {
                nt *= value;
            }
        }

        return nt;
        //return (int)Math.Pow((int)(value), (int)(n));
    }

    public String filename_make()
    {
        String timemake = "";
        {
            //    DateTime dt1 = new DateTime();
            timemake += "" + this.add_space_str1("" + System.DateTime.Today.Year, 4, 0, "0");
            timemake += "" + this.add_space_str1("" + System.DateTime.Today.Month, 2, 0, "0");
            timemake += "" + this.add_space_str1("" + System.DateTime.Today.Day, 2, 0, "0");
            timemake += "" + this.add_space_str1("" + System.DateTime.Now.Hour, 2, 0, "0");
            timemake += "" + this.add_space_str1("" + System.DateTime.Now.Minute, 2, 0, "0");
            timemake += "" + this.add_space_str1("" + System.DateTime.Now.Second, 2, 0, "0");
        }
        return timemake;
    }

    public int time_stanp_1()
    {
        int timemake = 0;

        timemake += System.DateTime.Today.Day;
        timemake += System.DateTime.Today.Month * 100;
        timemake += System.DateTime.Today.Year * 100 * 100;
        
        return timemake;
    }

    public int time_stanp_2()
    {
        int timemake = 0;

        timemake += System.DateTime.Now.Second;
        timemake += System.DateTime.Now.Minute * 100;
        timemake += System.DateTime.Now.Hour * 100 * 100;
        
        return timemake;
    }


    /*
    public long time_call()
    {
        long time1 = 0;

        {
            time1 += System.DateTime.Today.Year * 10000000000;
            time1 += System.DateTime.Today.Month * 100000000;
            time1 += System.DateTime.Today.Day * 1000000;
            time1 += System.DateTime.Now.Hour * 10000;
            time1 += System.DateTime.Now.Minute * 100;
            time1 += System.DateTime.Now.Second;
        }

        return time1;
    }
    */


    //UNIX時刻を利用
    //long 値は 1970 年 1 月 1 日 00:00:00 GMT からの 経過秒数をとる

    //こいつは精度が甘すぎるが気にしない (更新は２分に一回ぐらい)
    public long get_second_all_time()
    {
        long unixTime = 0;

        {
            DateTime targetTime = DateTime.Now;
            //    DateTime targetTime = new DateTime(2015, 2, 24, 0, 0, 0, 0);//DateTime.Now;
            //    DateTime targetTime = new DateTime(1970, 1, 2, 0, 0, 0, 0);//DateTime.Now;

            {
                DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

                // UTC時間に変換
                targetTime = targetTime.ToUniversalTime();

                // UNIXエポックからの経過時間を取得
                TimeSpan elapsedTime = targetTime - UNIX_EPOCH;

                // 経過秒数に変換
                unixTime = (long)elapsedTime.TotalSeconds;
            }
        }

        return unixTime;
    }

    //経過した日程を教える
    public long get_day_all_time()
    {
        return get_second_all_time() / 60 / 60 / 24;
    }

    public long get_hour_all_time()
    {
        return get_second_all_time() / 60 / 60;
    }

    public long get_minitue_all_time()
    {
        return get_second_all_time() / 60;
    }




    //テキスト読み込み

    //(ポインタの方がいいんじゃｗ)
    //指定したテキストファイルの読み込み (横は128文字まで)
    /*
public string read_txt(string filename){

	int FileHandle ;
	string read_string="";
//	char String[128] ;
    System.Text.StringBuilder st1 = new System.Text.StringBuilder();

	// test.cpp ファイルを開く
    FileHandle = DX.FileRead_open(filename);

	// 一行読む
	while(DX.FileRead_gets( st1, 128, FileHandle )!=-1){
        read_string += st1;
		read_string+="\n";
	}
	
	//返りはstringそのまま
	return read_string;
}
     */

    //テキストファイル全部読み込み
    public String read_txt(String filename)
    {
        //   msbox(filename);

        //文字コード(ここでは、Shift JIS)
        System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");

        //テキストファイルの中身をすべて読み込む
        return System.IO.File.ReadAllText(filename, enc);
    }

    //テキストファイル全部書き込み
    public void write_txt(String filename, String data)
    {
        //文字コード(ここでは、Shift JIS)
        System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");

        //テキストファイルの中身をすべて読み込む
        System.IO.File.WriteAllText(filename, data, enc);
    }

    //テキスト内の改行、スペースを全消し
    //文字の空白をなくす("も)
    public String Cleanly(String str)
    {
        for (int t = 0; t <= 10000; t++)
        //   while ((int)str.IndexOf(" ")>=0)
        {
            //    int nt = (int)str.indexOf(" ");
            int nt = (int)str.IndexOf(" ");
            if (nt >= 0)
            {
                //    str = str.substring(0, nt) + str.substring(nt + 1);
                str = str.Substring(0, nt) + str.Substring(nt + 1);
            }
            else
            {
                break;
            }
        }

        /*
        for (int t = 0; t <= 10000; t++)
        {
            int nt = (int)str.IndexOf("\n");
            if (nt >= 0)
            {
             //     msbox(""+nt);
                  str = str.Substring(0, nt) + str.Substring(nt + 1);//1);
            }
            else
            {
                break;
            }
        }
        */

        return str;
    }


    //読み込んだ文字から指定の文字を消去する
    public String Cleanly(String str, String clenstr)
    {
        for (int t = 0; t <= 10000; t++)
        {
            int nt = (int)str.IndexOf(clenstr);
            if (nt >= 0)
            {
                str = str.Substring(0, nt) + str.Substring(nt + 1);
            }
            else
            {
                break;
            }
        }

        return str;
    }

    public String Cleanly(String str, Char clenstr)
    {
        for (int t = 0; t <= 10000; t++)
        {
            int nt = (int)str.IndexOf(clenstr);
            if (nt >= 0)
            {
                str = str.Substring(0, nt) + str.Substring(nt + 1);
            }
            else
            {
                break;
            }
        }

        return str;
    }

    public String Change(String str, String s1, String s2)
    {
        for (int t = 0; t <= 10000; t++)
        {
            int nt = (int)str.IndexOf(s1);
            if (nt >= 0)// && str.IndexOf(s2)>=0)
            {
                str = str.Substring(0, nt) + s2 + str.Substring(nt + strlength(s1));// );
            }
            else
            {
                break;
            }
        }

        return str;
    }

    public String ChangeSpecial(String str, String s1, String s2)
    {
        for (int t = 0; t <= 10000; t++)
        {
            int nt = (int)str.IndexOf(s1);
            if (nt >= 0)// && str.IndexOf(s2)>=0)
            {
                try
                {
                    str = str.Substring(0, nt - 1) + s2 + str.Substring(nt + 1);
                }
                catch (Exception e) { break; }
            }
            else
            {
                break;
            }
        }

        return str;
    }


    public String Change_once(String str, String s1, String s2)
    {
        for (int t = 0; t <= 0; t++)
        {
            int nt = (int)str.IndexOf(s1);
            if (nt >= 0)// && str.IndexOf(s2)>=0)
            {
                str = str.Substring(0, nt) + s2 + str.Substring(nt + strlength(s1));// );
            }
            else
            {
                break;
            }
        }

        return str;
    }


    //自分のWp専用 特殊な置換専用 "----"を発見した瞬間機能しなくなる。
    public String ChangeWordpressSp(String str, String s2)
    {
        for (int t = 0; t <= 10000; t++)
        {
            String s1 = "---";
            int nt = (int)str.IndexOf(s1);
            int nt2 = (int)str.IndexOf("----");
            if (nt >= 0)// && (nt2 <= -1 && abs(nt-nt2)<=2))
            {
                str = str.Substring(0, nt) + s2 + str.Substring(nt + strlength(s1));// );
            }
            else
            {
                break;
            }
        }

        return str;
    }





    //コメント文の消去
    public String comment_del(String str1)
    {
        String st2 = "";
        //   int no_load_flag = 0;

        for (int t = 0; t < 10000; t++)
        {
            //1行読み込み
            int s1 = indexof(str1, "\n");
            if (s1 >= 0)
            {
                //    if (no_load_flag == 0)
                {
                    String str = substring(str1, 0, s1 + 1);

                    //   int s3 = indexof(str, "/*");
                    //   if (s3 < 0)
                    {
                        for (int t2 = 0; t2 <= 0; t2++)
                        {
                            int nn = indexof(str, "//");
                            if (nn >= 0)
                            {
                                st2 = st2 + substring(str, 0, nn) + "\n";//;
                            }
                            else
                            {
                                st2 += str;// + "\n";

                                break;
                            }
                        }
                    }
                    /*
                else
                {
                    no_load_flag = 1;
                }*/

                    {
                        str1 = substring(str1, s1 + 1);
                    }
                }
                /*
                else
                {
                    int s3 = indexof(str1, "");
                    if (s3 >= 0) no_load_flag = 0;

                    {
                        str1 = substring(str1, s1 + 1);
                    }
                }*/
            }
            else
            {
                st2 += str1;
                break;
            }

        }

        //    msbox(st2);

        st2 = strdel(st2, "/*", "*/", 1000);

        //  msbox(st2);

        return st2;
    }

    //indexof
    public int indexof(String str, String searchstr)
    {
        //    msbox("" + str);
        return (int)str.IndexOf(searchstr);
    }
    //sub1
    public String substring(String str, int num1)
    {
        return str.Substring(num1);
    }
    //sub2
    public String substring(String str, int num1, int num2)
    {
        return str.Substring(num1, num2);
    }

    //1行から変数抽出()
    public int iExtraction(String str, String searchstr)
    {
        String str1 = "0";
        if (indexof(str, searchstr) >= 0)
        {
            str = substring(str, indexof(str, searchstr) + strlength(searchstr) + 1);
            str1 = substring(str, 0, indexof(str, ";"));
        }

        return ci(str1);
    }

    //文字カット(抽出)
    public String strcut(String str, String searchstr)
    {
        return substring(str, indexof(str, searchstr) + strlength(searchstr));
    }
    public String strcut(String str, String searchstr1, String searchstr2)
    {
        String str2 = substring(str, indexof(str, searchstr1) + strlength(searchstr1));
        return substring(str2, 0, indexof(str2, searchstr2));
    }

    //A~Bまでの文字を消す (テスト中、まともにうごかないかも)    
    public String strdel(String str, String searchstr1, String searchstr2, int loopnum)
    {
        for (int t = 0; t < loopnum; t++)
        {
            if (indexof(str, searchstr1) >= 0 && indexof(str, searchstr2) >= 0)
            {
                str = strdel(str, searchstr1, searchstr2);
            }
            else
            {
                break;
            }
        }

        return str;
    }
    public String strdel(String str, String searchstr1, String searchstr2)
    {
        String str2 = substring(str, 0, indexof(str, searchstr1));
        String str3 = substring(str, indexof(str, searchstr2) + strlength(searchstr2));

        //     String str4 = substring(str, indexof(str, searchstr1 + strlength(searchstr1)));
        //   String str3 = substring(str4, indexof(str, searchstr2) + strlength(searchstr2));

        return str2 + str3;
    }


    //string→int
    public int ci(String str)
    {
        //    msbox(str);
        return int.Parse(str);
    }


    //文字の長さ返す
    public int strlength(String str)
    {
        return (int)str.Length;
    }

    //文字のバイト数を返す
    public int strbyte(String str)
    {
        //半角と全角が混ざっている場合、こっちのほうが正しい
        return System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(str);

        //    return System.Text.Encoding.Unicode.GetByteCount(str);
    }

    //文字が何のエンコードを使用しているか、捉えておく
    public byte[] encoding_getbyte(String str)
    {
        return System.Text.Encoding.GetEncoding("Shift_JIS").GetBytes(str);
        //    return System.Text.Encoding.Unicode.GetBytes(str);
    }

    public String encoding_getstring(byte[] byteArray)
    {
        return System.Text.Encoding.GetEncoding("Shift_JIS").GetString(byteArray);
        //    return System.Text.Encoding.Unicode.GetBytes(str);
    }



    //文字の先頭に、空文字を入れる
    public String add_space_str1(String str, int length, int before_0__after_1, String in_str)
    {
        int nt = (int)strlength(str);
        int nt2 = nt;

        for (int t = 0; t <= length; t++)
            if (nt < t)
            {
                if (before_0__after_1 == 1)
                {
                    str = str + in_str;
                }
                else
                {
                    str = in_str + str;
                }
            }

        return str;
    }

    //旧型
    /*
    public String add_space_str2(String str, int length, int before_0__after_1, String in_str)
    {
        int nt = (int)strlength(str);
        int nt2 = nt;

        for (int t = 0; t <= length; t++)
            if (nt < t)
            {
                if (before_0__after_1 != 1)
                {
                    str = str + in_str;
                }
                else
                {
                    str = in_str + str;
                }
            }

        return str;
    }
    */

    //文字列の比較 (1,成功 0,違う)
    public int str_equals(String str1, String str2)
    {
        int nt = 0;
        int iCompare = str1.CompareTo(str2);

        if (iCompare == 0)
        {
            nt = 1;
        }

        return nt;
    }


    //四角判定を調べる 成功 1 失敗 0
    public int rect_decision(float x1, float y1, float x2, float y2, float w2, float h2)
    {
        int nt = 0;

        //   if (x1 >= x2 - w2 && x1 <= x2 + w2 && y1 >= y2 - h2 && y1 <= y2 + h2)
        if (x1 >= x2 && x1 <= x2 + w2 && y1 >= y2 && y1 <= y2 + h2)
        {
            nt = 1;
        }

        return nt;
    }

    //円判定を調べる 成功 1 失敗 0
    public int circle_decision(float x1, float y1, float r1, float x2, float y2, float r2)
    {
        int nt = 0;
        if (pow2(x2 - x1) + pow2(y2 - y1) <= pow2(r1 + r2))
        {
            nt = 1;
        }

        return nt;
    }


    //文字の先頭に、任意の文字を入れる
    public String add_length_str(String str, int length, String intostr)
    {
        int nt = (int)strlength(str);
        int nt2 = nt;

        for (int t = 0; t <= length; t++)
        {
            if (nt < t)
            {
                str = intostr + str;
                //   nt--;
            }
        }

        return str;
    }



    public int iover(int num, int min, int max)
    {
        if (num < min) num = min;
        if (num > max) num = max;
        return num;
    }
    public long iover(long num, long min, long max)
    {
        if (num < min) num = min;
        if (num > max) num = max;
        return num;
    }
    public float iover(float num, float min, float max)
    {
        if (num < min) num = min;
        if (num > max) num = max;
        return num;
    }

    public int iloop(int num, int min, int max)
    {
        if (num < min) num = max;
        if (num > max) num = min;
        return num;
    }








    //そのファイル名が存在するかどうか (1 ある, 0 ない)
    public int file_check(String name)
    {
        int flag = 0;

        if (System.IO.File.Exists(name) == true)
        {
            flag = 1;

            //    msbox(name + ":あります");
        }
        else
        {
            //    msbox(name + ":ないよん");
        }

        return flag;
    }





    //改行ごとに区切って読み込み
    public String[] txt_line_read(String filename)
    {
    //    long time1 = get_time();

        int line_num = line_num_check(filename);

        String[] read_data = new String[line_num];

        //    msbox("" + (get_time() - time1));


        //コチラのほうが凄く早い
        {
            //文字コード(ここでは、Shift JIS)
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");

            //テキストファイルの中身をすべて読み込む
            String[] setLines;
            read_data = System.IO.File.ReadAllLines(filename, enc);

        //    co = setLines.Length + 1;

            //    msbox(co);
        }


        /*
        int FileHandle = DX.FileRead_open(filename);

        //    msbox(read_data.Length);

        System.Text.StringBuilder st1 = new System.Text.StringBuilder();
        int cap = 1024;//1024 * 100 + 1;
        st1.Capacity = cap;

        int co = 0;

        //long time1 = get_time();

        
        // 一行読む
        {
        //    read_txt(filename);
        }
        
        //   while (DX.FileRead_gets(st1, 1024, FileHandle) != -1)
        while (DX.FileRead_gets(st1, cap, FileHandle) != -1)
        {
            read_data[co] += st1.ToString();
            co++;
        }
        

        //   msbox("" + (get_time() - time1));


        DX.FileRead_close(FileHandle);
        */
        //    msbox(read_data.Length);

        return read_data;
    }




    //テキストから改行数を取得
    public int line_num_check(String filename)
    {
        int co = 0;

        //コチラのほうが凄く早い
        {
            //文字コード(ここでは、Shift JIS)
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");

            //テキストファイルの中身をすべて読み込む
            String[] setLines;
            setLines = System.IO.File.ReadAllLines(filename, enc);

            co = setLines.Length + 1;

        //    msbox(co);
        }

        /*
        

        String st1 = read_txt(filename);

        co = st1.Length;
        */
        //    msbox(co);

        /*
        int FileHandle = DX.FileRead_open(filename);

        System.Text.StringBuilder st1 = new System.Text.StringBuilder();
        int cap = 1024;//256;//1024 * 100 + 1;
        st1.Capacity = cap;

        // 一行読む
        //   while (DX.FileRead_gets(st1, 1024, FileHandle) != -1)
        while (DX.FileRead_gets(st1, cap, FileHandle) != -1)
        {
            co++;
        }

       //     msbox(co+" , "+ filename);

        DX.FileRead_close(FileHandle);
        */

        return co;
    }



    //文字列を改行毎に区切る
    public String[] txt_line_div(String str1)
    {
        int line_num = line_num_div(str1);

        String[] read_data = new String[line_num];

        for (int t1 = 0; t1 < line_num; t1++)
        {
            int nt1 = indexof(str1, "\n");
            if (nt1 <= -1)
            {
                read_data[t1] = str1;
                //    msbox(str1);
                break;
            }
            else
            {
                read_data[t1] = substring(str1, 0, nt1);
                str1 = substring(str1, nt1 + 1);
            }
        }

        return read_data;
    }


    //文字列から改行数を取得
    public int line_num_div(String str1)
    {
        int co = 0;

        for (int t1 = 0; t1 <= 1024; t1++)
        {
            int nt1 = indexof(str1, "\n");
            if (nt1 <= -1)
            {
                break;
            }
            else
            {
                str1 = substring(str1, nt1 + 1);
                co++;
            }
        }

        return co + 1;
    }






    //指定した1行だけ、テキストデータを読み込む
    public String txt_line_read(String name, int line)
    {
        //文字コード(ここでは、Shift JIS)
        System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");

        //テキストファイルの中身をすべて読み込む
        String[] txtdata = System.IO.File.ReadAllLines(name, enc);
        return txtdata[line];
    }


    long time1 = 0;// = m.get_time();

    public void timer_measure_set()
    {
        time1 = get_time();
    }

    public void timer_measure_set2()
    {
        long time2 = get_time() - time1;
        msbox(time2);
    }


    public int array_length(String[] str)
    {
        return str.Length;
    }

    //ガベージコレクション C#では使わない
    public void system_gc()
    {

    }



    public int directry_create(String dirPath)
    {
        int nt = 0;

        if (Directory.Exists(dirPath))
        {
            nt = 1;
        }
        else
        {
            Directory.CreateDirectory(dirPath);
        }

        return nt;
    }


    public int directry_check(String dirPath)
    {
        int nt = 0;

        if (Directory.Exists(dirPath))
        {
            nt = 1;
        }
        else { nt = 0; }

        return nt;
    }


    //数字の半角を全角に変更、結構強引
    public String num_half_full_change(int num1)
    {
        String st1 = "";
        int len1 = strbyte("" + num1);

        for (int t = 1; t <= len1; t += 1)
        {
            int num2 = num1 % (pow_n(10, (len1 + 1 - t))) / (pow_n(10, ((len1 + 1 - t) - 1)));

            {
                int t2 = t - 1;

                if (num2 == 0) { st1 += "０"; }
                if (num2 == 1) { st1 += "１"; }
                if (num2 == 2) { st1 += "２"; }
                if (num2 == 3) { st1 += "３"; }
                if (num2 == 4) { st1 += "４"; }
                if (num2 == 5) { st1 += "５"; }
                if (num2 == 6) { st1 += "６"; }
                if (num2 == 7) { st1 += "７"; }
                if (num2 == 8) { st1 += "８"; }
                if (num2 == 9) { st1 += "９"; }
            }
        }

        /*
        String st1 = "";
        String str2 = str1 + "　";

        String[] box1 = new String[32];
        for (int t = 0; t < 32; t++) { box1[t] = ""; }

        int len1 = strlength(str1);
        int len2 = len1;

        for (int t = 0; t < len2; t++) { box1[t] = substring(str2, t,1); }

        for (int t = 0; t < 10; t++)
        {
            if (t == 0) { }
        }

        for (int t = 0; t < len2; t++)
        {
            st1 += box1[t];
        }
        */

        return st1;
    }
}

