using System.Collections;
using System.Collections.Generic;

public class Sequence : tNode
{
    public Sequence() : base(){
    }

    public override tNodeState evaluate(){
        foreach(tNode tNode in children){
            state = tNode.evaluate();
            if (state == tNodeState.FAILURE){
                return state;

            } else if(state == tNodeState.RUNNING){
                return state;
            }
        }
        //Last 
        return tNodeState.SUCCESS;
    }
}
