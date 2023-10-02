using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasSmelledPlayer : tNode
{


    public override tNodeState evaluate()
    {
        if (SnifferTree.hasSmelled)
        {

            return tNodeState.SUCCESS;
        }
        else
        {
            return tNodeState.FAILURE;
        }
    }

}
