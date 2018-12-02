using System;
using System.Collections.Generic;
using System.Windows.Forms;

using DxLibDLL;

namespace game1
{
    class Start
    {
        [STAThread]
        static void Main(string[] args)
        {
            int full_screen = 0;			//フルスクリーンの有無の確認

            int FALSE = 0;
            int TRUE = 1;
            

            DX.SetOutApplicationLogValidFlag(FALSE);        //ログの出力	


            //フルスクリーンの確認
            int full_screen_on = 0;

            if (full_screen != 0)
                full_screen_on = init_dialog();

            if (full_screen_on == 2)
            {
                return;
            }


            {
                Summary1 s = new Summary1();

                //画面サイズ設定
                //一応32bit fullスク無しは16bit
                if (full_screen != 0)
                {
                    DX.SetGraphMode(s.display_w, s.display_h, 32);
                }
                else
                {
                    DX.SetGraphMode(s.display_w, s.display_h, 16);
                }

                if (full_screen_on != 1)
                    DX.ChangeWindowMode(TRUE);                  //最大化の防止


                DX.SetWindowText(s.title_name2());                 //タイトル名
                                                                //   DX.SetAlwaysRunFlag(TRUE);						//画面切り替えでも動作
                                                                //	int SetMultiThreadFlag( int Flag );			//draw部のマルチ化	（しない）
                                                                //   DX.SetBasicBlendFlag(TRUE);					    //透過描画の高速化(透過処理が落ちる)
                                                                //	SetWindowStyleMode( 2 ) ;					//タイトルバー消滅
               
                DX.SetWindowSizeChangeEnableFlag(TRUE);         //画面サイズの任意変更
                                                                //   DX.SetUseASyncChangeWindowModeFunction(TRUE, unsafe ChangeCallback,null);

                DX.SetDoubleStartValidFlag(TRUE);//多重起動許可


                //DXlibスタート

                if (DX.DxLib_Init() == -1)      // ＤＸライブラリ初期化処理
                {
                    return;         // エラーが起きたら直ちに終了
                }
                //    debugInitAfterDxLib_Init();

                
                //DXlib ver3.x以降、透過設定の形式が変更されていたみたいなので、こちらを使用
                {
                    DX.SetUsePremulAlphaConvertLoad(TRUE);      // 画像を読み込んだ後、乗算済みアルファ画像に変換する設定を有効にする
                    DX.SetFontCacheUsePremulAlphaFlag(TRUE);        //フォントをDX_BLENDMODE_PMA_ALPHAに適応
                    DX.SetDrawBlendMode(DX.DX_BLENDMODE_PMA_ALPHA, 255); //DxLib_Initの前に書くとリセットされるので注意
                }


                //裏描画
                DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            }



            MainFrame1 mf1 = new MainFrame1();

            mf1.run1();


        //    DX.WaitKey();				// キー入力待ち

            DX.DxLib_End();
        }



        //最大化要求ダイアログ

        static int init_dialog()
        {
            int nt = 0;
            DialogResult result = MessageBox.Show("フルスクリーンにしますか？","画面確認",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                nt = 1;
            }
            else if (result == DialogResult.No)
            {
                nt = 0;
            }
            else if (result == DialogResult.Cancel)
            {
                nt = 2;
            }

            return nt;
        }
    }
}
