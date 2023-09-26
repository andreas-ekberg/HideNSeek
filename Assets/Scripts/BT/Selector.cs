using System.Collections;
using System.Collections.Generic;

public class Selector : tNode
{

    public override tNodeState evaluate(){
        foreach(tNode tNode in children){
            state = tNode.evaluate();
            if (state == tNodeState.SUCCESS){
                return state;

            } else if(state == tNodeState.RUNNING){
                return state;
            }
        }
        return tNodeState.FAILURE;
    }
}
