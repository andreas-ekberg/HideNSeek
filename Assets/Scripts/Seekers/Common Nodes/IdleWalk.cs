using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalk : tNode
{

    private idlePaths idlePathsPositions;

    private PathManager pathManager;

    public bool onAPath;

    public IdleWalk(idlePaths _idlePathsPositions, PathManager _pathManager, bool _onAPath)
    {
        idlePathsPositions = _idlePathsPositions;
        pathManager = _pathManager;
        onAPath = _onAPath;
    }

    public override tNodeState evaluate()
    {
        if (!onAPath)
        {
            Vector3 targetPos = idlePathsPositions.GetIdleTargetPos();
            onAPath = true;
            pathManager.UpdatePath(targetPos);
            return tNodeState.RUNNING;
        }
        else if (pathManager.path.Length != null && pathManager.done == true)
        {
            onAPath = false;
            return tNodeState.SUCCESS;
        }
        else
        {
            return tNodeState.RUNNING;
        }

    }


}
