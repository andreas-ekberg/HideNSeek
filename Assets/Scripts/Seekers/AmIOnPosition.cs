using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmIOnPosition : tNode
{

private GameObject seeker;
public string seekerName;

public AmIOnPosition(GameObject inSeeker){
    seeker = inSeeker;
    seekerName = seeker.name;
}

    public override tNodeState evaluate(){
        float distance = Vector3.Distance(seeker.transform.position, AIBrain.getKnownPosition());
        if (distance < 1.0f){
            Debug.Log("I am on position!");
            //AIBrain.setOnAPath(seekerName,false);

            //These three commands allow "GoToPosition" to update the path of each Seeker to last known.
            //We need to place these somewhere smart so that they dont run every frame.
            //If they run every frame the game wont work.
            //They do not need to be in this Node.
            AIBrain.setOnAPath("Watcher",false);
            AIBrain.setOnAPath("Listener",false);
            AIBrain.setOnAPath("Smeller",false);
            return tNodeState.SUCCESS;
        } else {
            //Debug.Log("I am not in position");
            return tNodeState.FAILURE;
        }
        
    }
}
