using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionKnown : tNode
{
    public override tNodeState evaluate(){

        if (AIBrain.doWeKnow()){
            return tNodeState.SUCCESS;
        } else{
            return tNodeState.FAILURE;
        }
    }
}
