using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasSeenPlayer : tNode
{
    public HasSeenPlayer(){

    }

    public override tNodeState evaluate(){
        if (WatcherTree.hasSeen){
            return tNodeState.SUCCESS;
        } else {
            Debug.Log("FAIL");
            return tNodeState.FAILURE;
        }
    }


}
