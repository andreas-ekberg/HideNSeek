using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasSeenPlayer : tNode
{

    public HasSeenPlayer(){
        
    }

    public override tNodeState evaluate(){
        //Debug.Log(ListenerTree.hasHeard);
        if(WatcherTree.hasSeen){

            return tNodeState.SUCCESS;
        }
        else{
            return tNodeState.FAILURE;
        }
    }

}
