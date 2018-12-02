using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//ゲーム進行管理クラス
public class MainRun1 : SetVoid1
{
    //どのゲームシーンにしているかの選択
    public int game_type = 3;


    public int GAME_TITLE = 0;
    public int GAME_BASE = 1;

    public int GAME_BATTLE = 3;


    public int game_type_call() { return game_type; }


    public MainRun1(Summary1 s1)
    {
        set1(s1);        
    }    

    public void init1()
    {
        if (game_type_call() == GAME_TITLE)
        {
            if (s1.title_run == null)
            {
                s1.title_run = new TitleRun(s1);
            }

            s1.title_run.init1();

        //    m1.msbox();
        }

        if (game_type_call() == GAME_BASE)
        {
            if (s1.base_run == null)
            {
                s1.base_run = new BaseRun(s1);
            }

            s1.base_run.init1();
        }

        if (game_type_call() == GAME_BATTLE)
        {
            if (s1.battle_run == null)
            {
                s1.battle_run = new BattleRun1(s1);
            }

            s1.battle_run.init1();
        }
    }

    public void game_type_change(int type1)
    {
        game_type = type1;

        init1();
    }


    public void run1()
    {
        if (game_type_call() == GAME_TITLE)
        {
            s1.title_run.run1();
        }

        if (game_type_call() == GAME_BASE)
        {
            s1.base_run.run1();
        }

        if (game_type_call() == GAME_BATTLE)
        {
            s1.battle_run.run1();
        }
    }

    public void draw1()
    {
        if (game_type_call() == GAME_TITLE)
        {
            s1.title_run.draw1();
        }

        if (game_type_call() == GAME_BASE)
        {
            s1.base_run.draw1();
        }

        if (game_type_call() == GAME_BATTLE)
        {
            s1.battle_run.draw1();
        }


    }
}

