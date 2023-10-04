using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmIOnPosition : tNode
{

private GameObject seeker;

public AmIOnPosition(GameObject inSeeker){
    seeker = inSeeker;
}

    public override tNodeState evaluate(){

        if (seeker.transform.position == AIBrain.getKnownPosition()){
            return tNodeState.SUCCESS;
        } else {
            return tNodeState.FAILURE;
        }
        
    }
}
