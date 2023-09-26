using System.Collections;
using System.Collections.Generic;


//enum is a class with constant membervariables
public enum tNodeState{
    RUNNING,
    SUCCESS,
    FAILURE
}

public class tNode
{

    protected tNodeState state;
    //public tNode parent;
    protected List<tNode> children;

    public tNode(){
        //parent = null;
        children = new List<tNode>();
    }

    public void attach(tNode tNode){
        //tNode.parent = this;
        children.Add(tNode);
    }
    
    //Will be written over by subclasses. Each tNode will have its own evaluate.
    public virtual tNodeState evaluate() => tNodeState.FAILURE;

}
