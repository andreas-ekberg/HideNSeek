using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHeardPlayer : tNode
{

    public HasHeardPlayer(){
        
    }

    public override tNodeState evaluate(){
        //Debug.Log(ListenerTree.hasHeard);
        if(ListenerTree.hasHeard){

            return tNodeState.SUCCESS;
        }
        else{
            return tNodeState.FAILURE;
        }
    }

}
