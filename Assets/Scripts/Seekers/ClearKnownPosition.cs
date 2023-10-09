using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearKnownPosition : tNode
{
    public override tNodeState evaluate()
    {
        Debug.Log("Clearing pos in brain");

        AIBrain.clearPosition();
        return tNodeState.SUCCESS;
    }
}
