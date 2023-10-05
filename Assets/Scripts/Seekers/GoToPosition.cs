using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPosition : tNode
{

    public static bool currentlyChasing = false;
    private PathManager pathManager;

    public GoToPosition(PathManager inPathManager){
        pathManager = inPathManager;
    }

    public override tNodeState evaluate(){

        if(!currentlyChasing){
            pathManager.UpdatePath(AIBrain.getKnownPosition());
            currentlyChasing = true;
            return tNodeState.SUCCESS;
        } else {
            //Debug.Log("I am currently chasing!");
            return tNodeState.FAILURE;
        }

    }
}
