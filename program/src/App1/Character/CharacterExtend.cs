using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CharacterExtend : SetVoid1
{
    //保存事項-- 0~23   30byte * 8200 246K ?
    //0 空き Int
    public int GET_DATE_1 = 1;///Int  /入手した日にち 2018y 01m 01d
    public int GET_DATE_2 = 2;//Int  //入手した時間帯 24h 24m 24s num2
    public int LEVEL1 = 3; //SHORT  //レベル １～３００
    public int NOW_EXP = 4;  //Short
    public int TYPE1 = 5; //Short  //種族：１～９９９９
    public int EQUIPMENT_1 = 6; //Short
    public int EQUIPMENT_2 = 7; //Short
    public int EQUIPMENT_3 = 8; //Short
    public int EQUIPMENT_4 = 9; //Short
    public int SKILL_1 = 10; //Short
    public int SKILL_2 = 11; //Short
    //space1 12
    //space1 13
    


    //CREATE_VERSION

    //パズドラのソートに注意

    //    public int NOW_EXP = 2;  //SHORT


    //保存しない登録だけの番号---------------------------- 
    //1000~1003 固定
    public int STATUS_MHP = 1000;
    public int STATUS_MMP = 1001;
    public int STATUS_ATK = 1002;
    public int STATUS_INT = 1003;

    public int STATUS_ATTRIBUTE_1 = 1011;
    public int STATUS_ATTRIBUTE_2 = 1012;

    public int STATUS_TEC = 1020;

    //public int STATUS_TECHNIC = 1020;
}
