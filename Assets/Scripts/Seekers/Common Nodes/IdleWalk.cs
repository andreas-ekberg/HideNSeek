using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalk : tNode
{

    private Vector3 SeekerPos;
    private bool onAPath = false;

    private idlePaths idlePathsPositions;

    private int targetIndex;

    private Vector3[] path = new Vector3[10];

    float speed = 10f;

    private MonoBehaviour monoBehaviour;

    public IdleWalk(Vector3 _SeekerPos, idlePaths _idlePathsPositions, MonoBehaviour _monoBehaviour){
        SeekerPos = _SeekerPos;
        idlePathsPositions = _idlePathsPositions;
        monoBehaviour = _monoBehaviour;
    }

    public override tNodeState evaluate(){

        if(!onAPath){
            Vector3 targetPos = idlePathsPositions.GetIdleTargetPos();
            onAPath = true;
            Debug.Log(targetPos);
            PathRequestManeger.RequestPath(SeekerPos, targetPos, OnPathFound);
            Debug.Log(path);
            return tNodeState.RUNNING;
        }
        else if(path.Length != null && path.Length == 0){
            return tNodeState.SUCCESS;
        }
        else{
            return tNodeState.RUNNING;
        }

    }



    public void OnPathFound(Vector3[] newPath, bool pathSucessful)
    {
        if (pathSucessful)
        {

            path = newPath;
            Debug.Log(newPath[2]);
            monoBehaviour.StopCoroutine(FollowPath());
            monoBehaviour.StartCoroutine(FollowPath());
        }
    }
    private IEnumerator FollowPath()
    {
        if (path == null || path.Length == 0)
        {
            // Path is invalid or empty, so exit the coroutine
            /* if (idleWalking)
            {
                idleWalking = false;
            } */
            yield break;
        }
        targetIndex = 0;
        Vector3 currentWaypoint = path[targetIndex];
        while (true)
        {
            if (monoBehaviour.transform.position == currentWaypoint)
            {

                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    //path = new Vector3[0];
                    //ResetPath();
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            monoBehaviour.transform.position = Vector3.MoveTowards(monoBehaviour.transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
        }
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], new Vector3(0.5f, 0.5f, 1f));

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(monoBehaviour.transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }

}
