using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionKnown : tNode
{
    public string seekerName;
    public Listen(string inSeekerName){
        seekerName = inSeekerName;
    }
    public override tNodeState evaluate(){
        //Debug.Log("Inside PlayerPosKnown");
        if (AIBrain.doWeKnow() && AIBrain.currentlyIdleWalking(seekerName)){
            AIBrain.setOnAPath("all", false);
            return tNodeState.SUCCESS;
        }
        else if(AIBrain.doWeKnow() && !AIBrain.currentlyIdleWalking(seekerName)){
            return tNodeState.SUCCESS;
        }else{
            return tNodeState.FAILURE;
        }
    }
}
