using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : tNode
{


    private MonoBehaviour Seeker;
    private GameObject PlayerCharachter;

    private bool currentlyChasing = false;


    public Chase(MonoBehaviour _Seeker, GameObject _PlayerCharachter){
        Seeker = _Seeker;
        PlayerCharachter = _PlayerCharachter;
    }

    public override tNodeState evaluate(){
        Debug.Log("Inne i Chase!!!");
        if(ListenerTree.targetIndex >= ListenerTree.path.Length){
            currentlyChasing = false;
            ListenerTree.hasHeard = false;
            return tNodeState.FAILURE;
        }
        else if(Vector3.Distance(PlayerCharachter.transform.position, Seeker.transform.position) < 0.5f){
            return tNodeState.SUCCESS;
        }
        else if(!currentlyChasing){
            ListenerTree.UpdatePath(Seeker.transform.position, PlayerCharachter.transform.position);
            currentlyChasing = true;
            return tNodeState.RUNNING;
        }
        else{
            return tNodeState.RUNNING;
        }

    }


}
