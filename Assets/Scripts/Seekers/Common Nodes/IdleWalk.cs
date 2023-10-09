using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalk : tNode
{

    private idlePaths idlePathsPositions;

    private PathManager pathManager;

    public bool onAPath;

    public string seekerName;

    public IdleWalk(idlePaths _idlePathsPositions, PathManager _pathManager, bool _onAPath, string inSeekerName)
    {
        idlePathsPositions = _idlePathsPositions;
        pathManager = _pathManager;
        onAPath = _onAPath;
        seekerName = inSeekerName;
    }

    public override tNodeState evaluate()
    {

        if (!AIBrain.onAPath(seekerName))
        {
            Vector3 targetPos = idlePathsPositions.GetIdleTargetPos();
            AIBrain.setOnAPath(seekerName, true);
            pathManager.UpdatePath(targetPos);
            AIBrain.setCurrentlyIdleWalking(seekerName, true);
            //Debug.Log("Idlewalk");
            return tNodeState.RUNNING;
        }
        else if (pathManager.path.Length != null && pathManager.done == true)
        {
            AIBrain.setOnAPath(seekerName, false);
            return tNodeState.SUCCESS;
        }
        else
        {
            return tNodeState.RUNNING;
        }

    }


}
