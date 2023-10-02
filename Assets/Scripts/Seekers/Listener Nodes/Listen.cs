using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listen : tNode
{
    private GameObject Listener;
    private GameObject PlayerCharachter;

    public Listen(GameObject _Listener, GameObject _PlayerCharachter)
    {
        Listener = _Listener;
        PlayerCharachter = _PlayerCharachter;
    }

    public override tNodeState evaluate()
    {
        // Check if the bounds of the two colliders intersect.
        //Debug.Log("Inne i Listen!!!");
        if (Vector3.Distance(PlayerCharachter.transform.position, Listener.transform.position) < 4.2f)
        {
            ListenerTree.hasHeard = true;
            return tNodeState.SUCCESS;
        }
        else
        {
            return tNodeState.FAILURE;
        }

    }
}
