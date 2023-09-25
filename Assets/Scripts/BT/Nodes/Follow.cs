using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : Node
{
    private GameObject Watcher;
    private GameObject PlayerCharachter;

    public Follow(GameObject inWatcher, GameObject inPlayerCharachter){
        Watcher = inWatcher;
        PlayerCharachter = inPlayerCharachter;
    }

    public override NodeState evaluate(){

        Watcher.transform.position = PlayerCharachter.transform.position;
        return NodeState.SUCCESS;
    }

}
