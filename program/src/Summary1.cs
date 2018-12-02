using System;
using System.Collections.Generic;

//すべてのクラスを利用できる汎用クラス
//重要な変数とかも保存
public class Summary1
{
    public int version_num = 00010; // 01010 = ver 1.01

    public int bgm_on = 0;

    public int savedata_loadflag = 0;
    public int auto_save = 1;


    public int debug_all_check(int nt) { return nt * 1; } //0 で実際のゲーム    1 でデバッグ色々

    public int debug_on() { return debug_all_check(1); }     //デバッグの設定
    public int debug_frame_control_on() { return debug_all_check(1); }     //デバッグの設定 フレームスキップ
    public int debug_draw() { return 1 * debug_all_check(0); }     //デバッグの表示

    
    //タイマー
    public long tm1;

    //自分用のラッパークラス
    public Misc1 m1;
    public MainCanvas1 g1;

    //音楽のラッパークラス


    //ラッパーその２
    public Input1 input1;
    public ImageControl1 ic1;
    public TouchInput touch_input;

    public SoundEffect1 sound_effect1;
    public SoundEffectOperation sound_effect_operation;
    public SoundEffectControl sound_effect_control1;

    public BGM1 bgm1;
    public BGMOperation bgm_operation;
    public BGMControl bgm_control1;


    public ApplicationMisc am1;
    public DrawMisc dm1;
    public SoundMisc sm1;

    public TitleRun title_run;
    public BaseRun base_run;
    public BattleRun1 battle_run;
    //    public BattleEnemyGroup battle_enemy_group;

    public EffectGroup effect_group;

    public DialogWindow dialog_window1;

    public AppVariable1 app_variable1;

    public FadeRun fade_run;

    public WaitAction wait_action;

    public CsvManager csv_manager;

    public Camera2D cam_2d;

    public ScrollBar1 scroll_bar1;
    public ScrollBar2 scroll_bar2;



    public CharacterGroup character_group;
    public EquipmentGroup equipment_group;

    public SaveDataControl save_data_control;

    public String version_name() { return "ver " + ((float)(version_num) / 1000); }
    public String version_name_call() { return version_name(); }
    public String save_version_name() { return "ver " + ((float)(savedata_version_num) / 1000); }

    public String title_name1()
    {
        return "アリスプランズ " + version_name();
    }

    public String title_name2()
    {
        String add_name = "";

        if (debug_on() == 1 || debug_frame_control_on() == 1 || debug_draw() == 1)
        {
            add_name = "  Debug : "+ debug_on()+" / "+ debug_frame_control_on()+ " / "+ debug_draw();
        }

        return "アリスプランズ " + version_name() + add_name;
    }

    //可変 動作させるときの画面のサイズ 起動時に取得する
    public int display_w = 960; //1050 / 1;//* 9 / 10;// * 2 / 3 / nm;
    public int display_h = 540; //630 / 1;//* 9 / 10;// * 2 / 3 / nm;

    //不変 このサイズの座標でゲームを作ってる
    public int game_display_w = 960;//1050;//1200;
    public int game_display_h = 540;//630;

    public int display_w_call() { return game_display_w; }
    public int display_h_call() { return game_display_h; }






    public int font_load = 1;           //フォントをしようするかどうか



    



    //描画回数
    public int draw_count = 0;


    //保存項目はロードしている限り上書き
    //保存項目------------------------------------

    //描画回数最大
    public int draw_count_max = 2;


    public int bgm_vol = 100;//50;
    public int se_vol = 60;

    public int pad_num;
    //保存項目ここまで------------------------------------



    //通常クラスの登録
    public MainRun1 mr1;


    //可変 *ここは変更しないでね 移動すべき範囲と画面の倍率
    public int move_display_x = 0;
    public int move_display_y = 0;
    public int move_display_w = 960;//0;
    public int move_display_h = 540;//0;
    public float move_display_meg = 1.0f;


    //その他のクラスの読み込み
    public DataManagement1 data_magagement;

    public FunctionScriptReaderControl function_script_reader_control;

    //頻繁に使いそうなクラスもここで宣言
    public ImageSaveCharacter image_save_character;
    public ImageSaveCharacterWindow image_save_character_window;
    public ImageSaveEquipment image_save_equipment;

    //セーブデータのバージョン
    public int savedata_version_num;

    /*
    public void set1(Misc1 m1, MainCanvas1 g1)//, Input1 input1)
    {
        this.m1 = m1;
        this.g1 = g1;
        //    this.input1 = input1;

        input1 = new Input1();
        ic1 = new ImageControl1();
        touch_input = new TouchInput();
    }
    */


    public void init_set1(Summary1 s1)
    {
        long time1 = m1.get_time();


        {
            s1.sound_effect1 = new SoundEffect1(s1);
            s1.sound_effect1.init1();

            s1.bgm1 = new BGM1(s1);
            s1.bgm1.init1();

            s1.input1 = new Input1();
            s1.input1.init_set1(s1);

            s1.ic1 = new ImageControl1();
            s1.ic1.init_set1(s1);

            s1.touch_input = new TouchInput();
            s1.touch_input.init_set1(s1);            

            s1.sound_effect_operation = new SoundEffectOperation(s1);
            s1.sound_effect_operation.init1();

            s1.sound_effect_control1 = new SoundEffectControl(s1);
            s1.sound_effect_control1.init1();

            s1.bgm_operation = new BGMOperation(s1);
            s1.bgm_operation.init1();

            s1.bgm_control1 = new BGMControl(s1);
            s1.bgm_control1.init1();
        }

        {
            s1.dm1 = new DrawMisc();
            s1.dm1.init_set1(s1);

            s1.am1 = new ApplicationMisc();
            s1.am1.init_set1(s1);

            s1.sm1 = new SoundMisc(s1);
            s1.sm1.init1();
       }

        {
            s1.mr1 = new MainRun1(s1);

            s1.csv_manager = new CsvManager(s1);
            s1.data_magagement = new DataManagement1(s1);

            //    s1.function_script_reader_control = new FunctionScriptReaderControl(s1);
            s1.image_save_character = new ImageSaveCharacter(s1);
            s1.image_save_character_window = new ImageSaveCharacterWindow(s1);
            s1.image_save_equipment = new ImageSaveEquipment(s1);
            s1.effect_group = new EffectGroup(s1);
            s1.dialog_window1 = new DialogWindow(s1);
            s1.app_variable1 = new AppVariable1(s1);
            s1.fade_run = new FadeRun(s1);
            s1.wait_action = new WaitAction(s1);
            s1.cam_2d = new Camera2D(s1);
            s1.scroll_bar1 = new ScrollBar1(s1);
            s1.scroll_bar2 = new ScrollBar2(s1);

            s1.character_group = new CharacterGroup(s1);
            s1.equipment_group = new EquipmentGroup(s1);

            s1.save_data_control = new SaveDataControl(s1);

            s1.character_group.init1();
            s1.equipment_group.init1();

            s1.character_group.init2();


            s1.csv_manager.init1();
            s1.data_magagement.init1();

            //36f

            //    s1.function_script_reader_control.init1();
            s1.image_save_character.init1();
            s1.image_save_character_window.init1();
            s1.image_save_equipment.init1();
            s1.effect_group.init1();
            s1.dialog_window1.init1();
            
            s1.app_variable1.init1();
            s1.fade_run.init1();
            s1.wait_action.init1();
            s1.cam_2d.init1();
            s1.scroll_bar1.init1();
            s1.scroll_bar2.init1();


            //39f

            s1.save_data_control.init1();

            s1.mr1.init1();

        //    m1.msbox((m1.get_time() - time1));
        }

        {
           


            
        }

      //  m1.msbox((m1.get_time()-time1));
    }//init_set1


    public void init1()
    {
        tm1 = 0;

        /*
        s.so = new Sound();
        s.so.set(m, g, im, input, s);
        s.so.init();


        s.gm = new GameMisc();
        s.gm.set(m, g, im, input, s);
        s.gm.init();


        s.tc = new TagControl();
        s.tc.set(m, g, im, input, s);
        s.tc.init();

        s.ti = new TouchInput();
        s.ti.set(m, g, im, input, s);
        s.ti.init();
        */


    }




    //拡大倍率後の左上の場所
    public int display_px()
    {
        int nt = move_display_x;
        return nt;
    }

    public int display_py()
    {
        int nt = move_display_y;
        return nt;
    }

    public int display_pw()
    {
        int nt = move_display_w;
        return nt;
    }

    public int display_ph()
    {
        int nt = move_display_h;
        return nt;
    }

    //x描画座標から、割合変換
    public float x_x_per_change(int x1)
    {
        float fl = 1.0f * x1 / game_display_w * 100;

        return fl;
    }

    //y描画座標から、割合変換
    public float y_y_per_change(int y1)
    {
        float fl = 1.0f * y1 / game_display_h * 100;

        return fl;
    }

    //xper座標から、描画座標変換
    public float x_per_x_change(float x_per)
    {
        float fl = 1.0f * x_per * game_display_w / 100;

        return fl;
    }

    //yper座標から、描画座標変換
    public float y_per_y_change(float y_per)
    {
        float fl = 1.0f * y_per * game_display_h / 100;

        return fl;
    }



    public void run1()
    {
        tm1++;

        input1.run1();

        touch_input.run1();

        sound_effect_operation.run1();

        bgm_operation.run1();

        mr1.run1();

        effect_group.run1();

        dialog_window1.run1();

        app_variable1.run1();

        fade_run.run1();

        wait_action.run1();


        scroll_bar1.run1();
        scroll_bar2.run1();

        cam_2d.run1();

        





        character_group.run1();

        equipment_group.run1();
    }

    public void draw1()
    {
        input1.draw1();

        touch_input.draw1();

        sound_effect_operation.draw1();

        bgm_operation.draw1();

        mr1.draw1();

        effect_group.draw1();

        dialog_window1.draw1();

        app_variable1.draw1();

        fade_run.draw1();

        wait_action.draw1();


     //   scroll_bar1.draw1();//baseで描画

        cam_2d.draw1();

        





        character_group.draw1();

        equipment_group.draw1();
    }





    //ゲームのデータがはいっている場所    
    public String gamedata_directry()
    {
        String st1 = "gamedata/";
        String st2 = "";

        return st1 + st2;
    }


    public String res_pass()
    {
        return gamedata_directry() + "" + "img/00540p/";
    }

    public String system_pass()
    {
        String st1 = "systemdata/";
        String st2 = "";//"orthogonal/";

        return st1 + st2;
    }
}
