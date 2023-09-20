using System.Collections;
using System.Collections.Generic;

public class Selector : Node
{

    public override NodeState evaluate(){
        foreach(Node node in children){
            state = node.evaluate();
            if (state == NodeState.SUCCESS){
                return state;

            } else if(state == NodeState.RUNNING){
                return state;
            }
        }
        return NodeState.FAILURE;
    }
}
