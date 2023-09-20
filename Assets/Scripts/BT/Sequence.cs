using System.Collections;
using System.Collections.Generic;

public class Sequence : Node
{

    public override NodeState evaluate(){
        foreach(Node node in children){
            state = node.evaluate();
            if (state == NodeState.FAILURE){
                return state;

            } else if(state == NodeState.RUNNING){
                return state;
            }
        }
        //Last 
        return NodeState.SUCCESS;
    }
}
