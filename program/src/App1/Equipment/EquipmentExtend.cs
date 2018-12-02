using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EquipmentExtend : SetVoid1
{
    //保存事項-- 0~8  20 * 8200  164K ?
    //0 空き Int
    public int GET_DATE_1 = 1;///Int  /入手した日にち 2018y 01m 01d
    public int GET_DATE_2 = 2;//Int  //入手した時間帯 24h 24m 24s num2
    public int TYPE1 = 3;//SHORT
    public int CHARACTER_LINK = 4;//SHORT
    public int INFINITE_FLAG = 5;//Byte


    //保存しない登録だけの番号---------------------------- 
    //1000~1003 固定
    public int STATUS_MHP = 1000;
    public int STATUS_MMP = 1001;
    public int STATUS_ATK = 1002;
    public int STATUS_INT = 1003;

    public int STATUS_ATTRIBUTE_1 = 1011;
    public int STATUS_ATTRIBUTE_2 = 1012;

    public int STATUS_TEC = 1020;
}
