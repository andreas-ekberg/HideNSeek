using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalk : tNode
{

    private Vector3 SeekerPos;
    private bool onAPath = false;

    private idlePaths idlePathsPositions;

    private int targetIndex;

    float speed = 10f;

    private MonoBehaviour monoBehaviour;

    private GameObject PlayerCharachter;

    public IdleWalk(Vector3 _SeekerPos, idlePaths _idlePathsPositions, MonoBehaviour _monoBehaviour, GameObject _PlayerCharachter){
        SeekerPos = _SeekerPos;
        idlePathsPositions = _idlePathsPositions;
        monoBehaviour = _monoBehaviour;
        PlayerCharachter = _PlayerCharachter;
    }

    public override tNodeState evaluate(){

        if(!onAPath){
            Vector3 targetPos = idlePathsPositions.GetIdleTargetPos();
            onAPath = true;
            //Debug.Log(targetPos);
            ListenerTree.UpdatePath(monoBehaviour.transform.position, PlayerCharachter.transform.position);
            //Debug.Log(path);
            return tNodeState.RUNNING;
        }
        else if(ListenerTree.path.Length != null && ListenerTree.path.Length == 0){
            onAPath = false;
            return tNodeState.SUCCESS;
        }
        else{
            return tNodeState.RUNNING;
        }

    }


}
