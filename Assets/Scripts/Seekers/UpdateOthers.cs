using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateOthers : tNode{


    public Vector3 position;

    public UpdateOthers(Vector3 inPosition){
        position = inPosition; //This will be an adress to a static variable?
        Debug.Log(position);
    }
    


    public override tNodeState evaluate(){
            AIBrain.updatePosition(position);
            Debug.Log("Updated position to: " + AIBrain.getKnownPosition());
            return tNodeState.SUCCESS;
    }
}
