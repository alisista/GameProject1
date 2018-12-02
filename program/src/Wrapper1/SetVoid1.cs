using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SetVoid1
{
    public Summary1 s1;

    public Misc1 m1;
    public MainCanvas1 g1;
    public ImageControl1 ic1;
    public Input1 input1;

    public void set1(Summary1 s1)
    {
        this.m1 = s1.m1;
        this.g1 = s1.g1;
        this.ic1 = s1.ic1;
        this.input1 = s1.input1;
        this.s1 = s1;
    }

        /*
        public void set(Misc1 m1, MainCanvas1 g1, ImageControl1 ic1, Input1 input1, Summary1 s1)
        {
            this.m1 = m1;
            this.g1 = g1;
            this.ic1 = ic1;
            this.input1 = input1;
            this.s1 = s1;
        }


        public void set(Summary1 s1)
        {
            this.s1 = s1;
        }
        */
    }
