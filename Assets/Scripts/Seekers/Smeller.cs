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

    void Start()
    {
        PathRequestManeger.RequestPath(transform.position, traget.position, OnPathFound);
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
            //DrawGizmos();
            Debug.Log("to " + playerTraget.position);
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
        Vector3 currentWaypoint = path[0];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {

                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    path = new Vector3[0];
                    targetIndex = 0;
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
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


