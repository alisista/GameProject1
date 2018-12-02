using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//未使用クラス、コピペ用
public class Null1 : SetVoid1
{
    public Null1(Summary1 s1)
    {
        set1(s1);
    }

    public void init1()
    {

    }

    public void run1()
    {
    }

    public void draw1()
    {
    }
}


public class Null2 : SetVoid1
{
    //個別の番号
    int num1;

    public Null2(Summary1 s1,int num1)
    {
        set1(s1);
        this.num1 = num1;
    }

    public void init1()
    {

    }

    public void run1()
    {
    }

    public void draw1()
    {
    }
}