using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//他のデータ管理と違い、BGMには実質、音楽が２つ入っている。イントロとループ。他のソース移植の時に注意
public class BGMData1
{
    //DXライブラリの音楽アドレス 
    int address1 = -1;


    //DXライブラリのint型に合わせて送る
    public int call()
    {
        int nt = address1;

        return nt;
    }


    public void adress_delete1()
    {
        address1 = -1;
    }

    //DXライブラリは読み込んだものがintで返ってくるため、そちらを覚える
    public void adress_set(int adress2)
    {
        address1 = adress2;
    }
}

