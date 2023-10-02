using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : tNode
{


    private MonoBehaviour Seeker;
    private GameObject PlayerCharachter;

    private bool currentlyChasing = false;

    private PathManager pathManager;


    public Chase(MonoBehaviour _Seeker, GameObject _PlayerCharachter, PathManager _pathManager)
    {
        Seeker = _Seeker;
        PlayerCharachter = _PlayerCharachter;
        pathManager = _pathManager;
    }

    public override tNodeState evaluate()
    {
        Debug.Log("Inne i Chase!!!");
        if (pathManager.done == true)
        {
            currentlyChasing = false;
            ListenerTree.hasHeard = false;
            return tNodeState.FAILURE;
        }
        else if (Vector3.Distance(PlayerCharachter.transform.position, Seeker.transform.position) < 0.5f)
        {
            return tNodeState.SUCCESS;
        }
        else if (!currentlyChasing)
        {
            pathManager.UpdatePath(PlayerCharachter.transform.position);
            currentlyChasing = true;
            return tNodeState.RUNNING;
        }
        else
        {
            return tNodeState.RUNNING;
        }

    }


}
