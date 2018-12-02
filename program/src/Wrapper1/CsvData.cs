using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CsvData : SetVoid1
{
    char aa = '"';
    
    public String filename;

    public int row_length1;
    public int column_length1;

    public int load_flag;

    //格納は、行(row)、列(column)の順
    public String[][] stbox;

    //    public int length1;//縦
    //    public int length2;//横

    public String[] csv_str_box;
    public int[] row_load_check;



    public int error_memo;

     //個別の番号
    int num1;

    public CsvData(Summary1 s1, int num1)
    {
        set1(s1);
        this.num1 = num1;
    }

    public void init1()
    {
        load_flag = 0;
        error_memo = 0;

        row_length1 = 0;
        column_length1 = 0;
    }


    public void strboxcreate(int lengthA, int lengthB)
    {
        row_length1 = lengthA;
        column_length1 = lengthB;

        stbox = new String[row_length1][];

        for (int t1 = 0; t1 < row_length1; t1++)
        {
            stbox[t1] = new String[column_length1];

            for (int t2 = 0; t2 < column_length1; t2++)
            {
                stbox[t1][t2] = "";
            }
        }
    }

    public void load_check()
    {
        if (load_flag == 0)
        {
            load_flag = 1;

            long time1 = m1.get_time();

            //    m1.msbox("" + filename);

            if (m1.strbyte(filename) >= 1)
            {
                //    m1.msbox();

                String filename2 = filename;
                int length2 = column_length1;

                String filename3 = "" + s1.gamedata_directry() + "csvdata/" + filename2;

                //    String[] data = m1.txt_line_read(filename3);
                csv_str_box = m1.txt_line_read(filename3);

                //     int row1 = m1.line_num_check(filename3);

                //    m1.msbox("" + (m1.get_time() - time1));

                //  String[] data = { "123", "456" };

                int row1 = csv_str_box.Length;

                row_load_check = new int[row1];

                for (int t1 = 0; t1 < row1; t1++)
                {
                    row_load_check[t1] = 0;
                }

                //    m1.msbox("data.Length:" + data.Length);
                //    m1.msbox("row1:" + row1);

                //  m.msbox("filenum" + filenum);
                //  m.msbox("length"+nt);

                strboxcreate(row1, column_length1);

                /*
                //縦の読み込み
                for (int t1 = 0; t1 < row1; t1++)
                {
                    {
                        //横の読み込み
                        for (int t2 = 0; t2 < length2; t2++)
                        {
                            if (data[t1] != null)
                            {
                                int nn1 = m1.indexof(data[t1], ",");

                                //一行データを分解する
                                if (nn1 >= 0)
                                {
                                    stbox[t1][t2] = m1.substring(data[t1], 0, nn1);

                                    data[t1] = m1.substring(data[t1], nn1 + 1);
                                }
                                else
                                {
                                    break;
                                }

                                //    if (t1==2)
                                //    m.msbox(""+filenum+","+t1+","+t2+"," + cd[filenum].stbox[t1][t2]);
                            }
                        }
                    }


                    //    m.write_txt("test.txt", save_test);
                }
                */

                //    m1.msbox((m1.get_time() - time1));

                //    m1.msbox("" + (m1.get_time() - time1));
                //    m1.msbox("row1:" + row1 + " , length2:" + length2);
            }
        }
    }


    public void row_load(int row1)
    {
        if (row_load_check[row1] == 0)
        {
            row_load_check[row1] = 1;

            int length2 = column_length1;

            int t1 = row1;

            //横の読み込み
            for (int t2 = 0; t2 < length2; t2++)
            {
                if (csv_str_box[t1] != null)
                {
                    int nn1 = m1.indexof(csv_str_box[t1], ",");

                    //一行データを分解する
                    if (nn1 >= 0)
                    {
                        stbox[t1][t2] = m1.substring(csv_str_box[t1], 0, nn1);

                        csv_str_box[t1] = m1.substring(csv_str_box[t1], nn1 + 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    } //row_load


    public int call_int(int row1, int column1)
    {
        int nt = 0;
        
        try
        {
            load_check();
            row_load(row1);

            String st = call_str(row1, column1);
            
            //        m.msbox(st);

            if (m1.strlength(st) >= 1)
            {
                int nt2 = m1.indexof(st, "" + aa);
                int nt3 = m1.indexof(st, ".");


                if (nt2 <= -1 && nt3 <= -1)
                {
                    nt = m1.ci(st);
                }
            }
        }
        catch (Exception e)
        {

        }

        return nt;
    }

    public String call_str(int row1, int column1)
    {
        String st = "";

        try
        {
            load_check();
            row_load(row1);

            //   cd[filenum].stbox[line][num] = "1";

            st = (stbox[row1][column1]);

            //    int b = 0;
            //    int a = 1 / b;
        }
        catch (Exception e)
        {
            if (error_memo == 0)
            {
                error_memo = 1;
                m1.msbox("csv str error! " + num1 + " , " + row1 + " , " + column1);
                //    m.msbox("line: " + st);
            }

            st = "null";
        }

        {
            Char a1 = '"';
            if (m1.indexof(st, "" + a1) >= 0)
            {
                st = m1.Cleanly(stbox[row1][column1], '"');
            }
        }

        return st;
    }
    
    public int call_row_max()
    {
        call_int(0, 0);
        return row_length1;
    }

    public int call_column_max()
    {
        call_int(0, 0);
        return column_length1;
    }


    public void run1()
    {
    }

    public void draw1()
    {
    }
}
