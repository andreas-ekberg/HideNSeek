using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idlePaths : MonoBehaviour
{
    public Transform[] idlePathsTargetPos = new Transform[8];

    public Vector3 GetIdleTargetPos()
    {
        return idlePathsTargetPos[Random.Range(0, idlePathsTargetPos.Length)].position;
    }
}
