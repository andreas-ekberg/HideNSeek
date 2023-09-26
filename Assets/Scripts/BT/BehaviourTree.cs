using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree
{
    private tNode root;

    public BehaviorTree(tNode inRoot){
        root = inRoot;   
    }

    public tNodeState runTree(){
        return root.evaluate();
    }

}
