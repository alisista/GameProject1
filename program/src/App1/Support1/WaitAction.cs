using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class WaitAction : WaitActionExtend
{
    public int waitaction_type1 = 0;
    public int waitaction_wait_tm = 0;

    public int[] freei = new int[2];

    public WaitActionSupport wait_action_support;


    public int action_add;
    public int ACTION_ADD_PARTY_SET = 1;


    public WaitAction(Summary1 s1)
    {
        set1(s1);

        wait_action_support = new WaitActionSupport(s1);
    }

    public void init1()
    {
        waitaction_type1 = 0;
        waitaction_wait_tm = 0;

        for (int t1 = 0; t1 <= 1; t1++)
        {
            freei[t1] = 0;
        }

        action_add = -1;
    }

    public void waitact_set(int type, int tm)
    {
        init1();

        waitaction_type1 = type;
        waitaction_wait_tm = tm;
    }

    public void run1()
    {
        if (waitaction_wait_tm >= 1)
        {
            if (waitaction_wait_tm == 1)
            {
            //    if (waitact2_flag == 0)
                {
                    wait_action_support.waitact(waitaction_type1);
                }

                /*
                if (waitact2_flag == 1)
                {
                    waitact2(waitaction_type);
                }
                */
            }

            waitaction_wait_tm--;
        }
    }

    public void draw1()
    {
    }
}
