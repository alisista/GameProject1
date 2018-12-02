using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DialogWindowExtend : SetVoid1
{
    public int DIALOG_OK = 1;
    public int DIALOG_YESNO = 2;
    public int DIALOG_YES1_YES2_NO = 3;


    //番号 １～　９９９９９は、Csvデータからロードしてもいいと思う

    //100000~
    public int TEST_WINDOW1 = 100010;

    public int DIALOG_GAMEOVER_CONTINUE = 100100;

    public int DIALOG_SKILL_USE_CHECK = 100200;

    public int DIALOG_GOTO_TITLE_YESNO = 190010;
    

    public int DIALOG_EQUIPMENT_CHECK = 200200;
    public int DIALOG_EQUIPMENT_CHARACTER_EQ_CHANGE = 200210;

    public int CHARACTER_GET_1 = 210010;

    public int EQUIPMENT_OVER = 220010;
    public int LITTLE_COIN = 220020;
    public int EQUIPMENT_BUY = 220030;

}