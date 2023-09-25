using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smeller : MonoBehaviour
{
    public ScentTrail scentTrail;
    private bool isInsideScentCircle = false;
    public Transform traget;
    public Transform playerTraget;
    public float speed = 10;
    Vector3[] path;
    int targetIndex;
    bool walkingBetweenTrails = false;

    bool idleWalking = false;
    bool chasingTarget = false;
    public idlePaths idlePath;
    public AiController aiController;

    void Start()
    {
        //PathRequestManeger.RequestPath(transform.position, traget.position, OnPathFound);
    }

    private void Update()
    {
        isInsideScentCircle = scentTrail.IsInsideScentCircle(transform.position);

        if (isInsideScentCircle && !walkingBetweenTrails)
        {
            walkingBetweenTrails = true;
            Debug.Log("I smell fear");
            PathRequestManeger.ClearQueue();
            targetIndex = 0;
            PathRequestManeger.RequestPath(transform.position, playerTraget.position, OnPathFound);
            aiController.UpdateAllEnemyTarget(gameObject, playerTraget.position);
        }

        if (!idleWalking && !chasingTarget)
        {
            idleWalking = true;
            Vector3 newTargetPos = idlePath.GetIdleTargetPos();
            PathRequestManeger.RequestPath(transform.position, newTargetPos, OnPathFound);

        }
    }
    public void OnPathFound(Vector3[] newPath, bool pathSucessful)
    {
        if (pathSucessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }

    }
    IEnumerator FollowPath()
    {
        if (path == null || path.Length == 0)
        {
            // Path is invalid or empty, so exit the coroutine
            if (idleWalking)
            {
                idleWalking = false;
            }
            yield break;
        }
        targetIndex = 0;
        Vector3 currentWaypoint = path[targetIndex];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {

                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    //path = new Vector3[0];
                    if (idleWalking)
                    {
                        idleWalking = false;
                    }
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
        }

    }
    public void UpdatePath(Vector3 newTargetPos)
    {
        chasingTarget = true;
        ResetPath();
        PathRequestManeger.RequestPath(transform.position, newTargetPos, OnPathFound);

    }

    public void ResetPath()
    {
        path = new Vector3[0];
        targetIndex = 0;
        if (idleWalking)
        {
            idleWalking = false;
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
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}


