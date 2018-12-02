using System;
using System.Collections.Generic;
using System.Drawing;

//using System.Linq;
//using System.Text;

using System.IO;

using DxLibDLL;

using System.Runtime.InteropServices;


public class MainCanvas1
{
    public int screen_img1 = -1;//特定の新規画像領域に生成して、描画をそこにしたい場合は、これを使用

    int point_x = 0;
    int point_y = 0;
    int color = 0;

    static int display_w = 1050;
    static int display_h = 640;

    int world_w = display_w;
    int world_h = display_h;

    int turnflag = 0;

    int fonttype = 0;
    int[] fontbox = new int[124];

    //画面のゆれ
    int swing_wait;
    int swing_wait_max;
    int swing_type;
    int swing_power;
    int swing_x;
    int swing_y;

    //画面を暗く
    // int dark_up_down;
    //int dark;

//    public int F_SCORE_STR = 102;

    public int FONT_1_MAIN_STR = 2;
    public int FONT_1_MIDDLE_STR = 3;
    public int FONT_1_SMALL_STR = 4;
    public int FONT_1_VERY_SMALL_STR = 5;


    /*
    public int FSTATUSSTR = 2;
    public int FNORMALSTR = 3;
    public int FNAMEDRAW = 4;
    public int FSTATUSHP = 6;
    public int FSTATUSHPMAX = 7;
    //    public int FTMESSAGE = 8;
    public int FNORMALSTR3 = 8;
    public int STORYSTR = 9;
    public int FNORMALSTR2 = 10;
    public int FHITPERSTR = 11;
    public int STORYSTR2 = 12;
    public int FMINISTR = 13;
    */

    //スクリーンキャプチャ
    public int cap_image = -1;

    //キャプチャをばらす
    public int[][] cap_image_div = new int[16][];
    public int[][] cap_image_div2 = new int[16][];


    //保存したスクリーンキャプチャのメモ
    public String scrcap_dir = "";
    public String scrcap_name = "";


    public int clear_count;

    public int[] clear_count_memo = new int[8];
    public int clear_memo;



    Misc1 m1 = new Misc1();
    Summary1 s1 = new Summary1();

    public void init1()
    {
        for (int t = 0; t < 16; t++)
        {
            cap_image_div[t] = new int[16];
            cap_image_div2[t] = new int[12];
        }

        setClear2_count_reset();

        {
            for (int t = 0; t < 8; t++)
            {
                clear_count_memo[t] = 0;
            }

            clear_memo = 255;
        }


        if (s1.font_load != 0)
        {
            SetPrivateFont();
        }


        fonttype = 0;

        fontbox[0] = createfont(-1, -1, 0, 0);//createfont(16, 2, 0, 0);


        if (s1.font_load != 0)
        {
            //    fontbox[1] = createfont(21, 2, 3, 1);

        //    fontbox[FSTATUSSTR] = createfont(20, 2, 3, 2);
        }

        /*
        if (s.font_load != 0)
        {
 //           fontbox[1] = createfont(21, 2, 3, 1);


         //   fontbox[FSTATUSSTR] = createfont(26, 2, 3, 2);
         //   fontbox[FSTATUSSTR] = createfont(22, 2, 3, 2);
         
            fontbox[FSTATUSSTR] = createfont(22, 4, 3, 3);

            fontbox[FNORMALSTR] = createfont(22, 2, 3, 3);

            //後者は……

            //この辺いらないかも
            {
            //    fontbox[FNAMEDRAW] = createfont(24, 2, 3, 2);
                fontbox[FNAMEDRAW] = createfont(24, 2, 3, 2);

            //    fontbox[FSTATUSHP] = createfont(32, 2, 3, 2);
              //  fontbox[FSTATUSHPMAX] = createfont(24, 2, 3, 2);
                fontbox[FSTATUSHP] = createfont(20, 2, 3, 2);
                fontbox[FSTATUSHPMAX] = createfont(16, 2, 3, 2);

            //    fontbox[FTMESSAGE] = createfont(24, 2, 3, 3);
            }

            
            {
            //    fontbox[FNAMEDRAW] = createfont(24, 2, 3, 2);
//                fontbox[FNAMEDRAW] = createfont(24, 2, 3, 2);

            //    fontbox[FSTATUSHP] = createfont(32, 2, 3, 2);
              //  fontbox[FSTATUSHPMAX] = createfont(24, 2, 3, 2);
  //              fontbox[FSTATUSHP] = createfont(20, 2, 3, 2);
    //            fontbox[FSTATUSHPMAX] = createfont(16, 2, 3, 2);

            //    fontbox[FTMESSAGE] = createfont(24, 2, 3, 3);
            } 
            

            fontbox[STORYSTR] = createfont(27, 2, 3, 3);
          
              fontbox[FNORMALSTR2] = createfont(24, 2, 3, 3);
              fontbox[FNORMALSTR3] = createfont(20, 2, 3, 3);

           fontbox[FHITPERSTR] = createfont(14, 2, 3, 2);
       //    fontbox[FHITPERSTR2] = createfont(18, 2, 3, 2);
            

            //  fontbox[FSTATUSHPMAX] = createfont(18, 2, 3, 3);
        }
        */

        setfont(0);


        swing_wait = -1;
        swing_wait_max = 1;
        swing_type = 0;
        swing_power = 0;
        swing_x = 0;
        swing_y = 0;

        //  dark_up_down = 0;
        //dark = 255;
    }



    //DXlibでオリジナルフォントの使用

    //フィールドにPrivateFontCollectionを用意
    private System.Drawing.Text.PrivateFontCollection fontCollection;

    [DllImport("gdi32.dll")]
    extern static IntPtr AddFontMemResourceEx(IntPtr pFileView, uint cjSize, IntPtr pvResrved, IntPtr pNumFonts);

    //フォントファイルの読み込み　これに登録することで、以降、名前呼び出しするだけで引用可能
    private void SetPrivateFont()
    {
        fontCollection = new System.Drawing.Text.PrivateFontCollection();

        for (int t = 0; t <= 2; t++)
        {
            string fontPath = "";
            //    if (t == 0) fontPath="system/mika.ttf";
            //if (t == 1) fontPath = s.gamedata_directry() + "font/" + "azuki.ttf";

        //    if (t == 1) fontPath = s1.gamedata_directry() + "font/" + "mplus-1c-black.ttf";
            if (t == 2) fontPath = s1.gamedata_directry() + "font/" + "mplus-1c-bold.ttf";

            if (m1.strlength(fontPath) >= 1)
            {
                IntPtr fontResourceHandle;

                byte[] fileImage = System.IO.File.ReadAllBytes(fontPath);
                unsafe
                {
                    fixed (byte* fileImageP = fileImage)
                    {
                        int fonts = 0;
                        int* fontsP = &fonts;
                        fontResourceHandle = AddFontMemResourceEx((IntPtr)fileImageP, (uint)fileImage.Length, (IntPtr)0, (IntPtr)fontsP);
                    }
                }
            }
        }
    }



    public void run()
    {
        swing_x = 0;
        swing_y = 0;

        if (swing_wait >= 0)
        {
            swing_wait--;

            if (swing_type == 1)
            {
                swing_x = m1.rand2((int)m1.cos_r(swing_power, (swing_wait_max - swing_wait) * 180 / swing_wait_max));
                swing_y = m1.rand2((int)m1.sin_r(swing_power, (swing_wait_max - swing_wait) * 180 / swing_wait_max));
            }

            if (swing_type == 2)
            {
                swing_y = (int)m1.sin_r(swing_power, (swing_wait_max - swing_wait) * 180 / swing_wait_max);
                if (swing_wait % 4 <= 1)
                {
                    swing_y *= -1;
                }
            }
        }


        //  m.end();
        /*
        if (dark_up_down != 0)
        {
            dark += dark_up_down*6;
            m.iover(dark,168,
        }
        */
    }

    public void swing_set(int type, int power, int tm)
    {
        swing_type = type;
        swing_power = power;
        swing_wait = tm;
        swing_wait_max = tm;
    }





    public void turn()
    {
        turnflag = 1;
    }
    public void turnre()
    {
        turnflag = 0;
    }





    //色かえ(指定)
    public void sc(int all) { setcolor(all); }
    public void sc(int red, int green, int blue) { setcolor(red, green, blue); }
    public void setcolor(int all) { setcolor(all, all, all); }

    public void setcolor(int red, int green, int blue)
    {
        int[] x = new int[3];
        x[0] = red; x[1] = green; x[2] = blue;
        for (int t = 0; t <= 2; t++)
        {
            if (x[t] < 0) x[t] = 0;
            if (x[t] > 255) x[t] = 255;
        }

        color = (int)DX.GetColor(x[0], x[1], x[2]);
    }

    //色かえ(黒)(白)
    public void sc0() { setcolor(0, 0, 0); }
    public void sc1() { setcolor(255, 255, 255); }




    public void drawLine(float x1, float y1, float x2, float y2)
    {
        DX.DrawLine((int)x1, (int)y1, (int)x2, (int)y2, (uint)color);
    }


    //四角形
    public void drawRect(float x, float y, float w, float h)
    {
        x += point_x;
        y += point_y;

        DX.DrawBox((int)x, (int)y, (int)(x + w), (int)(y + h), (uint)color, 1);
        //    g.drawRect(x, y, w, h);
    }


    //四角形
    public int drawRect(float x, float y, float w, float h, int Center, int FillFlag)
    {

        if (Center != 0) { x -= (w / 2); y -= (h / 2); }

        //範囲内
        int rang = 1;
        int flag = 0;

        if (Center == 0)
        {
            if (x + w >= -rang && x <= display_w + rang)
            {
                if (y + h >= -rang && y <= display_h + rang)
                {
                    flag = 1;
                }
            }
        }

        else
        {
            if (x + w >= -rang && x - w <= display_w + rang)
            {
                if (y + h >= -rang && y - h <= display_h + rang)
                {
                    flag = 1;
                }
            }
        }

        if (flag == 1)
        {
            x += point_x;
            y += point_y;

            DX.DrawBox((int)x, (int)y, (int)(x + w), (int)(y + h), (uint)color, FillFlag);

            //	if (FillFlag==0)g.drawRect(x,y,w,h);
            //if (FillFlag==1)g.fillRect(x,y,w,h);
        }

        return flag;
    }


    public void drawTriangle(int x1, int y1, int x2, int y2, int x3, int y3, int FillFlag)
    {
        DX.DrawTriangle(x1, y1, x2, y2, x3, y3, (uint)color, FillFlag);
    }


    public void drawCircle(float x, float y, float r, int FillFlag)
    {
        DX.DrawCircle((int)x, (int)y, (int)r, (uint)color, FillFlag);
    }


    //文字
    public void str(String st, float x, float y)
    {
        x += swing_x;
        y += swing_y;

        {
            //   DX.DrawString((int)x,(int)y,st,color);

            DX.DrawStringToHandle((int)x, (int)y, st, (uint)color, fontbox[fonttype]);
        }
    }

    public void str2(String st, float x, float y)
    {
        x += swing_x;
        y += swing_y;

        {
            for (int t1 = -1; t1 <= 1; t1 += 2)
            {
                for (int t2 = -1; t2 <= 1; t2 += 2)
                {
                    //   DX.DrawString((int)(x+t1), (int)(y+t2), st, DX.GetColor(0, 0, 0));
                    DX.DrawStringToHandle((int)(x + t1), (int)(y + t2), st, DX.GetColor(0, 0, 0), fontbox[fonttype]);
                }
            }

            DX.DrawStringToHandle((int)(x), (int)(y), st, (uint)color, fontbox[fonttype]);
            //    str(st, x, y);
        }
    }

    //透過対策の枠表示
    public void str4(string st, float x, float y)
    {
        str2(st, x, y);
        str(st, x, y);
    }

    public void str2_center(String st, float x, float y)
    {
        str2_center(st, x, y, font_w_size_call());
    }

    public void str2_center(String st, float x, float y, float size1)
    {
        int len1 = m1.strbyte(st);

        str2(st, x - len1 * size1 / 4, y);
    }


        int[] fontinitflag = new int[124];

    public void setfont_create(int type)
    {
        if (fontinitflag[type] == 0 && type >= 1)
        {
            fontinitflag[type] = 1;

            int type2 = type;

            if (type2 == FONT_1_MAIN_STR) { fontbox[type2] = createfont(24, 7, 3, 1); }
            if (type2 == FONT_1_MIDDLE_STR) { fontbox[type2] = createfont(20, 7, 3, 1); }            
            if (type2 == FONT_1_SMALL_STR) { fontbox[type2] = createfont(18, 7, 3, 1); }
            if (type2 == FONT_1_VERY_SMALL_STR) { fontbox[type2] = createfont(14, 7, 3, 1); }
            


//            if (type2 == FONT_SMALL_STR) { fontbox[type2] = createfont(26, 7, 3, 2); }

            /*
            if (type2 == FSTATUSSTR) fontbox[type2] = createfont(22, 4, 3, 3);
            if (type2 == FNORMALSTR) fontbox[type2] = createfont(22, 2, 3, 3);
            if (type2 == FNAMEDRAW) fontbox[type2] = createfont(24, 2, 3, 2);
            if (type2 == FSTATUSHP) fontbox[type2] = createfont(20, 2, 3, 2);
            if (type2 == FSTATUSHPMAX) fontbox[type2] = createfont(16, 2, 3, 2);
            if (type2 == STORYSTR) fontbox[type2] = createfont(27, 2, 3, 3);
            if (type2 == FNORMALSTR2) fontbox[type2] = createfont(24, 2, 3, 3);
            if (type2 == FNORMALSTR3) fontbox[type2] = createfont(20, 2, 3, 3);
            if (type2 == FHITPERSTR) fontbox[type2] = createfont(14, 2, 3, 2);
            if (type2 == STORYSTR2) fontbox[type2] = createfont(64, 2, 3, 3);
            if (type2 == FMINISTR) fontbox[type2] = createfont(14, 6, 3, 3);
            */

        }
    }

    public float font_w_size_call()
    {
        return font_w_size_call(0);
    }

    public float font_w_size_call(int font_type1)
    {
        float nt = 0;
        if (font_type1 == 0) { font_type1 = fonttype; }
        if (font_type1 == FONT_1_MAIN_STR) { nt = 25; }
        if (font_type1 == FONT_1_MIDDLE_STR) { nt = 21; }
        if (font_type1 == FONT_1_SMALL_STR) { nt = 19; }
        if (font_type1 == FONT_1_VERY_SMALL_STR) { nt = 15; }

        return nt;
    }


    public void setfont(int fonttype1)
    {
        setfont_create(fonttype1);

        if (fonttype1 == 1)
        {
        //    m1.end();
        }

        fonttype = fonttype1;

        if (s1.font_load == 0) fonttype = 0;
    }

    public void setfont_re()
    {
        setfont(0);
    }


    //フォント作成 drawtypeは、基本３
    public int createfont(int size, int nick, int drawtype, int fonttype)//, string fontname)
    {
        //SetFontSize(x);
        //SetFontThickness(y);
        //if (x==0)
        //y=10;
        String fontname = "monofur";

        if (fonttype == 0)
        {
            fontname = null;
        }

        
        if (fonttype == 1)
        {
            fontname = "M+ 1c blod";
        }


        if (fonttype == 2)
        {
            fontname = "M+ 1c black";
        }


        /*
        if (type == 2)
        {
            fontname = "あずきフォント";
        }
        */

        if (drawtype == 0)
            // 第5引数CharSetは文字セット指定。リファレンスには載ってない。
            //return DX.CreateFontToHandle(fontname, x, y, DX.DX_FONTTYPE_NORMAL, DX.DX_CHARSET_DEFAULT);
            return DX.CreateFontToHandle(fontname, size, nick, DX.DX_FONTTYPE_NORMAL, DX.DX_CHARSET_DEFAULT);
        if (drawtype == 1)
            return DX.CreateFontToHandle(fontname, size, nick, DX.DX_FONTTYPE_EDGE, DX.DX_CHARSET_DEFAULT);
        if (drawtype == 2)
            //  return DX.CreateFontToHandle(fontname, x, y, DX.DX_FONTTYPE_ANTIALIASING, DX.DX_CHARSET_DEFAULT);
            return DX.CreateFontToHandle(fontname, size, nick, DX.DX_FONTTYPE_ANTIALIASING_EDGE, DX.DX_CHARSET_DEFAULT);

        if (drawtype == 3)
            return DX.CreateFontToHandle(fontname, size, nick, DX.DX_FONTTYPE_ANTIALIASING, DX.DX_CHARSET_DEFAULT);

        // DX_FONTTYPE_ANTIALIASING_EDGE
        return -1;

        //else
        //return CreateFontToHandle( NULL , x , y) ;
    }

    /*
    void str(string st,int x,int y,int type){
	    if (type==0)
		    str(st,x,y);
	    if (type>=1)
		    DrawStringToHandle(x,y,st.c_str(),color,font[type]);
    }
    */

    /*
    public void init()
    {

    }
    */


    public void load_image_back_color(int c1, int c2, int c3)
    {
        DX.SetTransColor(c1, c2, c3);
    }

    public int first_img_num = -1;

    //画像の読み込み
    public ImageData1 load_image(String name)
    {
        ImageData1 imgdata1 = new ImageData1();

        int nt = DX.LoadGraph(name);
        imgdata1.adress_set(nt);

        if (first_img_num == -1) first_img_num = nt;

        return imgdata1;
    }

    //画像読み込み2 分割されてない画像は、分割して読み込んだほうがDXライブラリでは速い…らしい
    //が、テストでは全く違いが感じられない
    //中身は、画像の読み込みと全く同じ
    public ImageData1 load_image2(String name)
    {
        int img1 = DX.LoadGraph(name);
        int w, h;
        DX.GetGraphSize(img1, out w, out h);

        int img2 = DX.DerivationGraph(0, 0, w, h, img1);

        ImageData1 imgdata1 = new ImageData1();
        ImageData1 imgdata2 = new ImageData1();

        imgdata1.adress_set(img1);
        imgdata2.adress_set(img2);

        delete_graph(imgdata1);

        return imgdata2;
    }

    public ImageData1 split_image(ImageData1 img, int x, int y, int w, int h)
    {
        int nt1 = 0;

        ImageData1 imgdata1 = new ImageData1();

        nt1 = DX.DerivationGraph(x, y, w, h, img.call());

        imgdata1.adress_set(nt1);

        return imgdata1;
    }


    //画像削除
    public int delete_graph(ImageData1 img)
    {
        int img2 = img.call();
        if (img2 != -1)
        {
            int nt1 = DX.DeleteGraph(img2);
            img.adress_delete1();

            return nt1;
        }
        else
        {
            return -1;
        }
    }

    //そのイメージが存在するかどうか (1,存在 0,無し)
    public int image_check(ImageData1 img)
    {
        int check_flag = 1;

        if (img.call() == -1) check_flag = 0;

        return check_flag;
    }

    //描画
    public int drawImage(ImageData1 img, float x, float y)
    {
        //  x += swing_x; 
        //  y += swing_y;

        int w, h;
        DX.GetGraphSize(img.call(), out w, out h);

        int flag = 0;

        //範囲内
        int rang = 60;
        //	int flag=0;
        if (x + w / 2 >= 0 - rang && x - w / 2 <= 0 + world_w + rang)
        {
            if (y + h / 2 >= 0 - rang && y - h / 2 <= 0 + world_h + rang)
            {
                flag = 1;
            }
        }


        if (flag == 1)
        {
            //return DX.DrawGraph((int)x-w/2,(int)y-h/2,img,1);
            return this.drawImage(img, (int)x, (int)y, 1, 0);
        }
        else
        {
            return -1;
        }
    }


    public int drawImage(ImageData1 img, float x, float y, float large, float angle)
    {
        x += swing_x;
        y += swing_y;

        //	if (explode_f==true){x+=explode_x;y+=explode_y;}
        int w, h;
        DX.GetGraphSize(img.call(), out w, out h);

        int flag = 0;

        //範囲内
        int rang = 60;
        //	int flag=0;
        if (x + w / 2 >= 0 - rang && x - w / 2 <= 0 + world_w + rang)
        {
            if (y + h / 2 >= 0 - rang && y - h / 2 <= 0 + world_h + rang)
            {
                flag = 1;
            }
        }

        if (flag == 1)
        {
            if (large <= 0.99f || large >= 1.01f) { Anti_aliasing();}

            float PI = 3.141592f;
            int ntt = 0;

            ntt = DX.DrawRotaGraph((int)x, (int)y, large, -angle / 360 * PI * 2, img.call(), 1, turnflag);

            if (large <= 0.99f || large >= 1.01f) { Anti_aliasing_re(); }

            return ntt;
        }
        else
        {
            return -1;
        }
    }

    public int drawImage4(int img, int x, int y, float large, float angle)
    {
        x += swing_x;
        y += swing_y;

        int w, h;
        DX.GetGraphSize(img, out w, out h);

        {
            float PI = 3.141592f;
            return DX.DrawRotaGraph((int)x, (int)y, large, -angle / 360 * PI * 2, img, 1, turnflag);
        }
    }



    public void drawImage(ImageData1 mx, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
    {
        DX.DrawModiGraph((int)x1, (int)y1, (int)x2, (int)y2, (int)x3, (int)y3, (int)x4, (int)y4, mx.call(), DX.TRUE);
    }

    public void drawImage2(ImageData1 mx, float x1, float y1, float w1, float h1)
    {
        drawImage(mx, x1, y1, x1 + w1, y1, x1 + w1, y1 + h1, x1, y1 + h1);
    }




    public int drawturnImage(int img, int x, int y)
    {
        x += swing_x;
        y += swing_y;

        int w, h;
        DX.GetGraphSize(img, out w, out h);

        int flag = 0;

        //範囲内
        int rang = 40;
        //	int flag=0;
        if (x + w / 2 >= 0 - rang && x - w / 2 <= 0 + world_w + rang)
        {
            if (y + h / 2 >= 0 - rang && y - h / 2 <= 0 + world_h + rang)
            {
                flag = 1;
            }
        }

        if (flag == 1)
        {
            return DX.DrawTurnGraph((int)x - w / 2, (int)y - h / 2, img, 1);
            //   return DX.DrawGraph((int)x - w / 2, (int)y - h / 2, img, 1);
        }
        else
        {
            return -1;
        }
    }



    public int drawImage2(ImageData1 img, float x, float y)
    {
        x += swing_x;
        y += swing_y;

        //	if (explode_f==true){a+=explode_x;b+=explode_y;}
        int w, h;
        DX.GetGraphSize(img.call(), out w, out h);
        int flag = 0;

        //範囲内
        int rang = 10;//81;
        //	int flag=0;
        if (x + w >= 0 - rang && x <= 0 + world_w + rang)
        {
            if (y + h >= 0 - rang && y <= 0 + world_h + rang)
            {
                flag = 1;
            }
        }

        /*
        int rang = 120;//81;
        //	int flag=0;
        if (x + w / 2 >= 0 - rang && x - w / 2 <= 0 + world_w + rang)
        {
            if (y + h / 2 >= 0 - rang && y - h / 2 <= 0 + world_h + rang)
            {
                flag = 1;
            }
        }
        */

        //	int w,h;
        //	GetGraphSize(mx ,&w ,&h);

        int n = 0;
        if (flag == 1)
        {
            n = DX.DrawGraph((int)x, (int)y, img.call(), 1);
        }
        return n;
    }



    public int drawImage2(ImageData1 img, float x, float y, float large)
    {
        x += swing_x;
        y += swing_y;

        //	if (explode_f==true){a+=explode_x;b+=explode_y;}
        int w, h;
        DX.GetGraphSize(img.call(), out w, out h);
        //    int flag = 1;

        Anti_aliasing();

        //	int w,h;
        //	GetGraphSize(mx ,&w ,&h);

        float PI = 3.141592f;
        int nt1=DX.DrawRotaGraph((int)(large * w / 2 + x), (int)(large * h / 2 + y), large, -0 / 360 * PI * 2, img.call(), 1, turnflag);

        Anti_aliasing_re();

        return nt1;
    }

    /*
    public int drawImage25(int img, float x, float y)
    {
        return DX.DrawGraphF(x, y, img, 1);
    }
    */

    


    //横回転
    public void draw_Xrad_Image(int img, float x, float y, float large, float rad)//int mx, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
    {
        x += swing_x;
        y += swing_y;

        //	if (explode_f==true){a+=explode_x;b+=explode_y;}
        int w2, h2;
        DX.GetGraphSize(img, out w2, out h2);

        float w = large * w2;
        float h = large * h2;

        /*
        int x1 = (int)x - (int)m.cos_r((w / 2), rad);
        int y1 = (int)y + (int)h / 2;
        int x2 = (int)x + (int)m.cos_r((w / 2), rad);
        int y2 = (int)y + (int)h / 2;
        int x3 = (int)x + (int)m.cos_r((w / 2), rad);
        int y3 = (int)y - (int)h / 2;
        int x4 = (int)x - (int)m.cos_r((w / 2), rad);
        int y4 = (int)y - (int)h / 2;
        */

        int x1 = (int)x - (int)m1.cos_r((w / 2), rad);
        int y1 = (int)y - (int)h / 2;
        int x2 = (int)x + (int)m1.cos_r((w / 2), rad);
        int y2 = (int)y - (int)h / 2;
        int x3 = (int)x + (int)m1.cos_r((w / 2), rad);
        int y3 = (int)y + (int)h / 2;
        int x4 = (int)x - (int)m1.cos_r((w / 2), rad);
        int y4 = (int)y + (int)h / 2;


        Anti_aliasing();

        if (turnflag == 1)
        {
            int memo = 0;
            memo = x1; x1 = x2; x2 = memo;
            memo = x3; x3 = x4; x4 = memo;
        }

        DX.DrawModiGraph(x1, y1, x2, y2, x3, y3, x4, y4, img, DX.TRUE);

        Anti_aliasing_re();
    }




    //縦横収縮
    public void draw_Xrad_Image(int img, float x, float y, float large, float w_mag, float h_mag)//int mx, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
    {
        x += swing_x;
        y += swing_y;

        //	if (explode_f==true){a+=explode_x;b+=explode_y;}
        int w2, h2;
        DX.GetGraphSize(img, out w2, out h2);

        float w = large * w2 * w_mag;
        float h = large * h2 * h_mag;

        int x1 = (int)x - (int)(w / 2);//(int)m.cos_r((w / 2), rad);
        int y1 = (int)y - (int)h / 2;
        int x2 = (int)x + (int)(w / 2);//(int)m.cos_r((w / 2), rad);
        int y2 = (int)y - (int)h / 2;
        int x3 = (int)x + (int)(w / 2);//(int)m.cos_r((w / 2), rad);
        int y3 = (int)y + (int)h / 2;
        int x4 = (int)x - (int)(w / 2);//(int)m.cos_r((w / 2), rad);
        int y4 = (int)y + (int)h / 2;

        Anti_aliasing();

        if (turnflag == 1)
        {
            int memo = 0;
            memo = x1; x1 = x2; x2 = memo;
            memo = x3; x3 = x4; x4 = memo;
        }

        DX.DrawModiGraph(x1, y1, x2, y2, x3, y3, x4, y4, img, DX.TRUE);

        Anti_aliasing_re();
    }


    public void draw_Xrad_Image2(int img, float x, float y, float large, float w_mag, float h_mag)//int mx, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
    {
        x += swing_x;
        y += swing_y;

        //	if (explode_f==true){a+=explode_x;b+=explode_y;}
        int w2, h2;
        DX.GetGraphSize(img, out w2, out h2);

        float w = large * w2 * w_mag;
        float h = large * h2 * h_mag;

        int x1 = (int)x - (int)(w / 2);//(int)m.cos_r((w / 2), rad);
        int y1 = (int)y - (int)h2 / 2;
        int x2 = (int)x + (int)(w / 2);//(int)m.cos_r((w / 2), rad);
        int y2 = (int)y - (int)h2 / 2;
        int x3 = (int)x + (int)(w / 2);//(int)m.cos_r((w / 2), rad);
        int y3 = (int)y + (int)h / 2;
        int x4 = (int)x - (int)(w / 2);//(int)m.cos_r((w / 2), rad);
        int y4 = (int)y + (int)h / 2;

        Anti_aliasing();

        if (turnflag == 1)
        {
            int memo = 0;
            memo = x1; x1 = x2; x2 = memo;
            memo = x3; x3 = x4; x4 = memo;
        }

        DX.DrawModiGraph(x1, y1, x2, y2, x3, y3, x4, y4, img, DX.TRUE);

        Anti_aliasing_re();
    }


    public int Image_size_w(int img)
    {
        int x1 = 0, y1 = 0;
        DX.GetGraphSize(img, out x1, out y1);

        return x1;
    }

    public int Image_size_h(int img)
    {
        int x1 = 0, y1 = 0;
        DX.GetGraphSize(img, out x1, out y1);

        return y1;
    }


    /*
public int drawImageUnder(int img, int x, int y)
{
    x += swing_x;
    y += swing_y;

    int w, h;
    DX.GetGraphSize(img, out w, out h);
    int flag = 0;

    //範囲内
    int rang = 10;//81;
    //	int flag=0;
    if (x + w >= 0 - rang && x <= 0 + world_w + rang)
    {
        if (y + h >= 0 - rang && y <= 0 + world_h + rang)
        {
            flag = 1;
        }
    }

    int n = 0;
    if (flag == 1)
    {
        n = DX.DrawGraph(x, y, img, 1);
    }
    return n;
}*/


    public void drawrectImage(ImageData1 img, float x, float y, int w1, int h1)
    {
        x += swing_x;
        y += swing_y;

        int w, h;
        DX.GetGraphSize(img.call(), out w, out h);
        int flag = 0;

        //範囲内
        int rang = 1280;
        //	int flag=0;
        if (x + w / 2 >= 0 - rang && x - w / 2 <= 0 + world_w + rang)
        {
            if (y + h / 2 >= 0 - rang && y - h / 2 <= 0 + world_h + rang)
            {
                flag = 1;
            }
        }

        int n = 0;
        if (flag == 1)
        {
            n = DX.DrawRectGraph((int)x, (int)y, 0, 0, w1, h1, img.call(), 1, turnflag);
        }
    }



    public void drawrectImage(ImageData1 img, float x, float y, float x2, float y2, int w2, int h2)
    {
        x += swing_x;
        y += swing_y;

        int w, h;
        DX.GetGraphSize(img.call(), out w, out h);
        int flag = 0;

        //範囲内
        int rang = 1280;
        //	int flag=0;
        if (x + w / 2 >= 0 - rang && x - w / 2 <= 0 + world_w + rang)
        {
            if (y + h / 2 >= 0 - rang && y - h / 2 <= 0 + world_h + rang)
            {
                flag = 1;
            }
        }

        int n = 0;
        if (flag == 1)
        {
            n = DX.DrawRectGraph((int)x, (int)y, (int)x2, (int)y2, w2, h2, img.call(), 1, turnflag);
        }
        //    return n;    
    }


    /*
public void setdrawarea(int x1,int y1,int x2,int y2)
{
    DX.SetDrawArea(x1, y1, x2, y2);
}*/

    //DXLIB画像データが存在しているかチェック yes,1 no,0
    public int img_check(int image)
    {
        int nt = 0;
        if (image != -1)
        {
            nt = 1;
        }
        return nt;
    }

    public int[] memo1 = new int[4];

    public void setdrawarea(int x1, int y1, int w1, int h1)
    {
        memo1[0] = x1;
        memo1[1] = y1;
        memo1[2] = w1;
        memo1[3] = h1;


        DX.SetDrawArea(x1, y1, x1 + w1, y1 + h1);
    }


    public void setdrawareare()
    {
        DX.SetDrawArea(0, 0, display_w, display_h);
    }

    public void setdrawarea2(int x1, int y1, int w1, int h1)
    {
        DX.SetDrawArea(x1, y1, x1 + w1, y1 + h1);
    }


    public void setdrawareare2()
    {
        setdrawarea(memo1[0], memo1[1], memo1[2], memo1[3]);
    }



    //透過設定
    public void setClear(int x)
    {
        clear_memo = x;

        //    DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, x);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_PMA_ALPHA, x);
    }

    public void setClearre()
    {
        clear_memo = 255;

        //   DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, 255);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_PMA_ALPHA, 255);
    }

    //透過設定その２。多重で使えるようにしておきたい
    public void setClear2(int x)
    {
        if (clear_count >= 1)
        {
            int clear1 = x;

            for (int t1 = 1; t1 <= clear_count; t1++)
            {
                clear1 = clear1 * clear_count_memo[t1 - 1] / 255;
            }

            setClear(clear1);
        }
        else
        {
            setClear(x);
        }

        /*
        if (clear_count >= 1)
        {
            clear_count_memo[clear_count] = x;
        }else
        {
            clear_count_memo[clear_count] = 255;//clear_memo;
        }
        */

        clear_count_memo[clear_count] = x;

        clear_count++;
    }

    public void setClear2_re()
    {
        clear_count -= 1;

        if (clear_count >= 1)
        {
            int clear1 = 255;

            for (int t1 = 1; t1 <= clear_count; t1++)
            {
                clear1 = clear1 * clear_count_memo[t1 - 1] / 255;
            }

            setClear(clear1);
        }
        else
        {
            setClear(255);
        }

        /*
        if (clear_count >= 1)
        {
            clear_count -= 1;

            if (clear_count >= 1)
            {
                setClear(clear_count_memo[clear_count - 1]);
            }else
            {
                setClear(255);
            }
        } else
        {
            m1.msbox("clear_error");
            m1.end();
        }
        */
    }

    public void setClear2_count_reset()
    {
        clear_count = 0;
    }

    

    public void setBright(int x1)
    {
        this.setBright(x1, x1, x1);
    }

    public void setBright(int x1, int x2, int x3)
    {
        DX.SetDrawBright(x1, x2, x3);
    }

    public void setBrightre()
    {
        this.setBright(255, 255, 255);
    }

    public void Anti_aliasing()
    {
        DX.SetDrawMode(DX.DX_DRAWMODE_BILINEAR);
    }

    public void Anti_aliasing_re()
    {
        DX.SetDrawMode(DX.DX_DRAWMODE_NEAREST);
    }

    /*
    //スクリーンキャプチャー
    public void Screen_capture()
    {
        ImageData1 img1 = new ImageData1();
        img1.adress_set(cap_image);

        if (cap_image != -1) delete_graph(img1);

        cap_image = DX.MakeGraph(640, 480);
        DX.GetDrawScreenGraph(0, 0, 640, 480, cap_image);
    }*/

    /*
    //キャプチャーした画像をバラす
    public void Screen_capture_div()
    {
        int nt = 40;

        for (int t1 = 0; t1 < 16; t1++)
        {
            for (int t2 = 0; t2 < 16; t2++)
            {
                if (cap_image_div[t1][t2] != -1) delete_graph(cap_image_div[t1][t2]);

                cap_image_div[t1][t2] = DX.DerivationGraph(t1 * nt, t2 * nt, nt, nt, cap_image);
            }
        }

        delete_graph(cap_image);
    }
    */

    /*
    //ばらし２ (fadeとの互換)
    public void Screen_capture_div2()
    {
        int nt = 40;

        for (int t1 = 0; t1 < 16; t1++)
        {
            for (int t2 = 0; t2 < 12; t2++)
            {
                if (cap_image_div2[t1][t2] != -1) delete_graph(cap_image_div2[t1][t2]);

                cap_image_div2[t1][t2] = DX.DerivationGraph(t1 * nt, t2 * nt, nt, nt, cap_image);
            }
        }

        delete_graph(cap_image);
    }
    */


    public int handlememo = -1;

    //描画空間を生成して、そこに自由に描画設定できるようにする
    //make_draw_img_reと、必ずセットで返すこと！ alphaは1で透過

    //DXlibでは画像を生成した後、intでリンクを繋ぐ
    //読み込んだ画像を消したい場合は、intをdelimgで、消えるっぽい
    //MakeScreenは重複しない
    public void make_draw_img(int w, int h, int alpha)
    {
        //    if (handlememo != -1) delete_graph(handlememo);

        int type1 = DX.TRUE;
        if (alpha == 0) type1 = DX.FALSE;

        handlememo = DX.MakeScreen(w, h, type1);

        DX.SetDrawScreen(handlememo);

        /*
        // 20x20サイズのアルファチャンネルなしの描画可能画像を作成する
        handle = DX.MakeScreen(20, 40);

        // 作成した画像を描画対象にする
        DX.SetDrawScreen(handle);

        // 画像に対して「あ」という文字を描画する
        DX.DrawString(0, 0, "あ", DX.GetColor(128, 128, 128));
        DX.DrawString(0, 20, "い", DX.GetColor(128, 128, 128));

        // 描画対象を表画面にする
        // SetDrawScreen(DX_SCREEN_FRONT);

        // 描画対象画像を画面いっぱいに拡大して描画する
        //DrawExtendGraph(0, 0, 640, 480, handle, FALSE);

        DX.SetDrawScreen(DX.DX_SCREEN_BACK);
        */
    }

    /*
    //元画像をコピーして生成
    public int make_img_copy(int img)
    {
        int type1 = DX.TRUE;

        int w, h;
        DX.GetGraphSize(img, out w, out h);
        handlememo = DX.MakeScreen(w, h, type1);

        DX.SetDrawScreen(handlememo);

        drawImage2(img, 0, 0);

        return make_draw_img_re();
    }*/


    //生成したimgメモリ番号を返す
    public int make_draw_img_re()
    {
        DX.SetDrawScreen(DX.DX_SCREEN_BACK);

        return handlememo;
    }


    //作った画像は消しておく
    public void make_draw_img_del()
    {
        if (handlememo != -1)
        {
            ImageData1 img1 = new ImageData1();
            img1.adress_set(handlememo);

            delete_graph(img1);
        }
    }

    /*
    0,DX_BLENDMODE_NOBLEND　:　ノーブレンド（デフォルト）
　　1,DX_BLENDMODE_ALPHA　　:　αブレンド
　　2,DX_BLENDMODE_ADD　　　:　加算ブレンド
　　3,DX_BLENDMODE_SUB　　　:　減算ブレンド
　　4,DX_BLENDMODE_MULA　　　:　乗算ブレンド
　　5,DX_BLENDMODE_INVSRC　　:　反転ブレンド
    */
    public void setblend(int type, int per)
    {
        int nt = DX.DX_BLENDMODE_NOBLEND;
        if (type == 1) { nt = DX.DX_BLENDMODE_ALPHA; }
        if (type == 2) { nt = DX.DX_BLENDMODE_ADD; }
        if (type == 3) { nt = DX.DX_BLENDMODE_SUB; }
        if (type == 4) { nt = DX.DX_BLENDMODE_MULA; }
        if (type == 5) { nt = DX.DX_BLENDMODE_INVSRC; }

        DX.SetDrawBlendMode(nt, per);
    }
    public void setblendre()
    {
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 255);
    }


    //モノトーンフィルタ
    public int graphfilter(int img, int type)
    {
        int FilterType = DX.DX_GRAPH_FILTER_MONO;
        DX.GraphFilter(img, FilterType);
        return img;
    }


    public void graphfilter_re(int img)
    {
        DX.GraphFilter(img, 0);
        //    return img;
    }


    public int screencap_flag = 0;

    //スクリーンキャプチャー
    public void screencapture()
    {
        screencap_flag = 1;
        //    DX.SaveDrawScreen(0, 0, 640, 480, "save.bmp");        
    }

    public void screencapture_save()
    {
        //   if (screencap_flag == 1)
        {
            {
                String filename = "";
                filename += s1.system_pass();
                filename += "scrcap/";

                scrcap_dir = filename;

                String timemake = m1.filename_make();
                scrcap_name = timemake + ".png";
            }

            String filename2 = "";
            filename2 += scrcap_dir;
            filename2 += scrcap_name;


            //キャプチャー画像の保存 + 古いファイルの消去
            {
                //キャプチャー画像の保存
                {
                    {
                        DX.SaveDrawScreenToPNG(0, 0, s1.display_w, s1.display_h, filename2, 1);
                    }

                    //    m.msbox(1);
                }
            }
        }
    }


    
    public void make_draw_screen_img(int w, int h)
    {
        screen_img1 = DX.MakeScreen(w, h, DX.TRUE);
        DX.SetDrawScreen(screen_img1);
    }
    public ImageData1 make_draw_screen_img_re()
    {
        DX.SetDrawScreen(DX.DX_SCREEN_BACK);

        ImageData1 id1 = new ImageData1();
        id1.adress_set(screen_img1);

        return id1;
    }
    public void make_draw_screen_img_del()
    {
        if (screen_img1 != -1)
        {
        //    ImageData1 id1 = new ImageData1();
        //    id1.adress_set(screen_img1);
        //    delete_graph(screen_img1);
        }
    }


}
