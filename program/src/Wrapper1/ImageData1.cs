using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;

using DxLibDLL;


public class ImageData1
{
    //DXライブラリの画像アドレス 
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


    public int call_w()
    {
        int w = 0, h;

        if (address1 != -1)
            DX.GetGraphSize(address1, out w, out h);

        return w;
    }

    public int call_h()
    {
        int w, h = 0;

        if (address1 != -1)
            DX.GetGraphSize(address1, out w, out h);

        return h;
    }
}

