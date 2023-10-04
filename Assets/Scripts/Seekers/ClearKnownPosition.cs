using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearKnownPosition : tNode
{
    public override tNodeState evaluate(){

        AIBrain.clearPosition();
        return tNodeState.SUCCESS;
    }
}
