using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateOthers : tNode{


    public Vector3 position;

    public UpdateOthers(Vector3 inPosition){
        position = inPosition; //This will be an adress to a static variable?
    }
    


    public override tNodeState evaluate(){
            AIBrain.updatePosition(position);
            return tNodeState.SUCCESS;
    }
}
