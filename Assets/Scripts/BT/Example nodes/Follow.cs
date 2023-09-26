using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : tNode
{
    private GameObject Watcher;
    private GameObject PlayerCharachter;

    public Follow(GameObject inWatcher, GameObject inPlayerCharachter){
        Watcher = inWatcher;
        PlayerCharachter = inPlayerCharachter;
    }

    public override tNodeState evaluate(){

        Watcher.transform.position = PlayerCharachter.transform.position;
        return tNodeState.SUCCESS;
    }

}
