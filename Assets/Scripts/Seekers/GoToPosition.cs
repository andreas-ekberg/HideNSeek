using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPosition : tNode
{

    private PathManager pathManager;
    public string seekerName;

    public GoToPosition(string inSeekerName, PathManager inPathManager){
        pathManager = inPathManager;
        seekerName = inSeekerName;
    }

    public override tNodeState evaluate(){

        if(!AIBrain.onAPath(seekerName)){
            pathManager.UpdatePath(AIBrain.getKnownPosition());
            AIBrain.setOnAPath(seekerName, true);
            return tNodeState.SUCCESS;
        } else {
            //Debug.Log("I am currently chasing!");
            return tNodeState.FAILURE;
        }

    }
}
