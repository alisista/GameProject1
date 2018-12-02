using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class WaitActionExtend : SetVoid1
{
    public int DUNGEON_TO_BASE = 100010;    //ダンジョンからゲームオーバーでベースに帰る

    public int DUNGEON_CLEAR = 100020;

    public int BASE_MENU_CHANGE = 100100;


    public int TITLE_TO_BASE = 200010;
    public int BASE_TO_TITLE = 200020;
    public int BASE_TO_DUNGEON = 200030;
}
