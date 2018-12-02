using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//現在は継承を含めて未使用。後で使うかな？
public class FunctionScriptReaderControl : FunctionScriptReader
{
//    String load_data;

    public int SCRIPT_ENEMY_POSITION1 = 1;


    public FunctionScriptReaderControl(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {
        data_set();
    }

    public void data_set()
    {
    //    data_set2(1, "enemy_position1.txt");
    }





    public void test1()
    {
        m1.msbox("test");
    }
}


/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//スクリプトになっている関数を呼び出せる
public class ScriptFunction : SetVoid
{
    String load_data;

    public int SCRIPT_CHARACTER_POSITION = 1;
    public int SCRIPT_BATTLE_DEBUG_SET = 2;


    //読み込んだ関数のスタック
    String read_void_name;

    static int READ_MAX = 16;
    String[] box = new String[READ_MAX];
    int[] nbox = new int[READ_MAX];


    public void init()
    {
        data_set();
    }

    public void data_set()
    {
        data_set2(1, "character_position.txt");
    }


    public String[] filename = new String[READ_MAX];


    
    public void data_set2(int num1, String filename1)
    {
        filename[num1] = filename1;
    }


    public void read_function(int type)
    {
        String filename1 = "";


        if (s.tool_type >= 1)
        {
            if (s.tool_type == s.TOOL_ENEMY_POSITION_CREATE)
            {
                filename1 = filename[1];
            }

            if (s.tool_type == s.TOOL_BATTLE_DEBUG_SET)
            {
                filename1 = "battle_debug.txt";
            //    m.msbox(200);
            }
        }



     //   if (s.tool_type == 0)
        {
            if (s.tool_type != s.TOOL_ENEMY_POSITION_CREATE)
            {
                if (type == SCRIPT_CHARACTER_POSITION)
                {
                    filename1 = "downloadgamedata/scriptdata/" + filename[1];
                }
            }
        }


        load_data = m.read_txt(filename1);


        //読み込んだファイルをそのまま別のフォルダに保存
        if (s.tool_type == s.TOOL_ENEMY_POSITION_CREATE)
        {
            String path2 = "downloadgamedata/scriptdata/" + filename1;
            m.write_txt(path2, load_data);
        }


        voidcheck(type);

    }//read_function




    //解析した関数を走らせる
    public void script_void_run(int type)
    {
        String name = read_void_name;

        {
        //    m.msbox(name);
        //    m.msbox(nbox[0] + "," + nbox[1] + "," + nbox[2] + "," + nbox[3] + "," + nbox[4] + "," + nbox[5] + "," + nbox[6] + "," + nbox[7] + "," + nbox[8]);
        }

        //敵キャラ座標の読み込み
        if (type == SCRIPT_CHARACTER_POSITION)
        {
            if (m.str_equals(name, "race_create") == 1)
            {
                if (s.battle_enemy_group!=null)
                s.battle_enemy_group.test_race_set(nbox[0], nbox[1], nbox[2], nbox[3]);
            }

            if (m.str_equals(name, "position_create") == 1)
            {
                s.character_draw_point.position_create(nbox[0], nbox[1], nbox[2], nbox[3], nbox[4], nbox[5], nbox[6], nbox[7]);
            }

            if (m.str_equals(name, "position_copy") == 1)
            {
                s.character_draw_point.position_copy(nbox[0], nbox[1]);
            }
        }


        if (type == SCRIPT_BATTLE_DEBUG_SET)
        {
            if (m.str_equals(name, "race_create") == 1)
            {
            //    m.msbox();

                s.battle_enemy_group.test_flag = 1;

                s.battle_enemy_group.test_race_set(nbox[0], nbox[1], nbox[2], nbox[3]);
            }

            if (m.str_equals(name, "use_dungeon") == 1)
            {
                s.dungeon_data.dungeon_num = nbox[0];
            }

            if (m.str_equals(name, "floor_set") == 1)
            {
                s.dungeon_data.dungeon_floor = nbox[0];            
            }

            if (m.str_equals(name, "battle_num") == 1)
            {
                s.dungeon_data.dungeon_battle_num = nbox[0];
            }

            if (m.str_equals(name, "enemy_appear") == 1)
            {
                for (int t1 = 0; t1 <12; t1++)
                {
                    s.battle_enemy_group.debug_enemy_box[t1] = nbox[t1];
                }
            }
        }

    }//script_void_run()














    public void voidcheck(int type)
    {
        for (int t = 0; t < READ_MAX; t++)
        {
            box[t] = "";
            nbox[t] = 0;
        }

        if (m.strlength(load_data) >= 1)
        {
            //   m.msbox(load_data);

            //1回に読める量は100行まで
            for (int t2 = 0; t2 < 3000; t2++)
            {
                //1命令読み込む
                String str2 = readLine(1);

                //関数だったら分解する
                if (scriptRead(str2) == 1)
                {
                    script_void_run(type);
                }

                if (m.strlength(load_data) <= 0)
                    break;
            }
        }
    }





    public String readLine(int next_on)
    {
        String str = "";
        int coment_check = 0;

        //255行まで予測して読み込む
        for (int t = 0; t <= 255; t++)
        {
            str = "";

            //1行読み込み
            int s1 = m.indexof(load_data, "\n");
            int s2 = m.indexof(load_data, ";");//+1;
            if (s2 < s1 && s2 >= 0) { s1 = s2 + 1; }
            //	if (s2<s1){s1=s2;}

            if (s1 >= 0)
            {
                str = m.substring(load_data, 0, s1);

                //    m.msbox(str);

                if (next_on != 0)
                {
                    load_data = m.substring(load_data, s1 + 1);
                    //now_line += 1;
                    // 	m.msbox(load_data);
                }

                //	m.msbox(str);
            }

            int flag = 1;


            //無効にする文を発見した場合、読み込んだことにしない
            {
                //改行のみは無視
                if (m.strlength(str) <= 1)
                {
                    flag = 0;
                }

                if (m.indexof(str, "//") >= 0)
                {
                    flag = 0;
                }
                else if (m.indexof(str, "/ *") >= 0)
                {
                    coment_check = 1;
                    flag = 0;
                }
                else if (m.indexof(str, "* /") >= 0)
                {
                    coment_check = 0;
                    flag = 0;
                }

                if (coment_check == 1)
                {
                    flag = 0;
                }
            }

            if (flag == 1)
            {
                break;
            }

            if (t == 255)
            {
                str = "";
                //       s.talk.mw.on = 0;
                //   m.msbox("無効にできる分の最大を超えました");
                //   m.end();
            }
        }

        //    memo = str;
        // str = s.sc.ts.tabClear(str);
    //    str = s.scm.tabClear(str);

        //    m.msbox(str);

        return str;
    }


    //スクリプト関数を１つ解析する (成功 1 失敗 -1)
    int scriptRead(String str)
{
    int flag = -1;

    //   m.msbox(str);
    try
    {
        String st1 = "";

        //この関数は 1行読み込んで、
        //関数なら、関数名と、カッコ内の数字を全部抽出してどこかに保存する関数

        //"文字消しておく
        str = m.Cleanly(str, '"');

        //置換したいことがあったらここに記述
        {
            //名前ボックスは変更
            //    if (m.indexof(str, "NAME") >= 0)
            {
                //   m.msbox(str);
                //   str = m.Cleanly(str, ',');
                //     str = s.sc.ts.stringNamechange(str);
                //   m.msbox(str);
            }
        }

        //プログラムは１度関数を探し、変換させる
        //関数読み込み (function)
        if (m.indexof(str, "(") >= 0)
        {
            //    m.msbox(str);

            String re = "", back = "";
            //    st1 = "hoge";

            //    for (int t = 0; t <= 30; t++)
            {
                //   int tn = t, max = 0;
                int max = 0;
                //    st1 = "hoge";
                //    if (tn == 0) { st1 = "createChara"; }
                //    if (tn == 1) { st1 = "deleteChara"; }


                //  int nt = m.indexof(str, st1);
                //  int nt2 = m.indexof(str, st1 + "(");

                st1 = m.substring(str, 0, m.indexof(str, "("));

                read_void_name = st1;

                //  m.msbox(st1);

                //  if (nt2 >= 0)
                {
                    //   m.end();
                    String str3 = str;

                    //  back = m.substring(str3, 0, m.indexof(str3, st1));

                    //     m.msbox(str3);

                    str3 = m.Cleanly(str3);


                    for (int te = 0; te < READ_MAX; te++) box[te] = "";

                    //関数解析して、内容を入れる
                    {
                        //	str3 = str3.substring((int)str3.indexOf("(")+1);
                        str3 = m.substring(str3, ((m.indexof(str3, "(") + 1)));


                        for (int ty = 0; ty < READ_MAX; ty++)
                        {
                            //	int nb=(int)str3.indexOf(",");
                            int nb = m.indexof(str3, ",");

                            if (nb < 0)
                            {
                                //	nb=(int)str3.indexOf(")");
                                nb = m.indexof(str3, ")");
                            }

                            if (nb >= 0)
                            {

                                {
                                    //	m.msbox(str);
                                    //	box[ty]=str3.substring(0,nb);
                                    box[ty] = m.substring(str3, 0, nb);
                                }

                                //		str3=str3.substring(nb+1);
                                str3 = m.substring(str3, nb + 1);
                            }
                            else
                            {
                                max = ty - 1;
                                break;
                            }
                        }
                    }

                    //実際の関数に投入
                    {
                        for (int tq = 0; tq <= max; tq++)
                        {
                            nbox[tq] = -1;

                            try
                            {
                                nbox[tq] = m.ci(box[tq]);
                            }
                            catch (Exception e) { nbox[tq] = -1; }
                        }
                    }

                    //	m.msbox(""+box[0]+","+box[1]+","+box[2]+","+box[3]);

                    //  str = back + re + ";";//str;
                    //	m.msbox(str);

                    //	m.msbox(str+","+tn);

                    flag = 1;

                }
            }
        }

    }
    catch (Exception e)
    {
        m.msbox("スクリプト実行エラー");// \n\n" + name_box + "\n\n" + (now_line - 1) + "," + memo);
        m.end();
    }

    return flag;
}
}


*/