using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree
{
    private Node root;

    public BehaviorTree(Node inRoot){
        root = inRoot;   
    }

    public NodeState runTree(){
        return root.evaluate();
    }

}
