using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalk : tNode
{

    private Vector3 SeekerPos;

    private idlePaths idlePathsPositions;

    private int targetIndex;

    float speed = 10f;

    private MonoBehaviour monoBehaviour;

    private GameObject PlayerCharachter;

    private PathManager pathManager;

    public IdleWalk(Vector3 _SeekerPos, idlePaths _idlePathsPositions, MonoBehaviour _monoBehaviour, GameObject _PlayerCharachter, PathManager _pathManager)
    {
        SeekerPos = _SeekerPos;
        idlePathsPositions = _idlePathsPositions;
        monoBehaviour = _monoBehaviour;
        PlayerCharachter = _PlayerCharachter;
        pathManager = _pathManager;
    }

    public override tNodeState evaluate()
    {
        if (!ListenerTree.onAPath)
        {
            Vector3 targetPos = idlePathsPositions.GetIdleTargetPos();
            ListenerTree.onAPath = true;
            pathManager.UpdatePath(targetPos);
            return tNodeState.RUNNING;
        }
        else if (pathManager.path.Length != null && pathManager.done == true)
        {
            ListenerTree.onAPath = false;
            return tNodeState.SUCCESS;
        }
        else
        {
            return tNodeState.RUNNING;
        }

    }


}
