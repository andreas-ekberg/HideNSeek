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
        float distance = Vector3.Distance(seeker.transform.position, AIBrain.getKnownPosition());
        if (distance < 1.0f){
            //Debug.Log("I am on position!");
            GoToPosition.currentlyChasing = false;
            return tNodeState.SUCCESS;
        } else {
            //Debug.Log("I am not in position");
            return tNodeState.FAILURE;
        }
        
    }
}
