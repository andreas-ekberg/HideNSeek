using System.Collections;
using System.Collections.Generic;


//enum is a class with constant membervariables
public enum NodeState{
    RUNNING,
    SUCCESS,
    FAILURE
}

public class Node
{

    protected NodeState state;
    //public Node parent;
    protected List<Node> children;

    public Node(){
        //parent = null;
        children = new List<Node>();
    }

    public void attach(Node node){
        //node.parent = this;
        children.Add(node);
    }
    
    //Will be written over by subclasses. Each Node will have its own evaluate.
    public virtual NodeState evaluate() => NodeState.FAILURE;

}
