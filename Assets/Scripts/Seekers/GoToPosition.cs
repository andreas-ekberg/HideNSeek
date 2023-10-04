using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPosition : tNode
{

    private bool currentlyChasing = false;

    public override tNodeState evaluate(){

        if(!currentlyChasing){
            pathManager.UpdatePath(AIBrain.getKnownPosition());
            currentlyChasing = true;
            return tNodeState.SUCCESS;
        } else {
            return tNodeState.FAILURE;
        }

    }
}
