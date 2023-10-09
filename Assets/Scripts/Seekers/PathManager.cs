using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{

    public GameObject Seeker;
    private GameObject Player;

    public int targetIndex;

    public Vector3[] path = new Vector3[10];

    float speed = 1f;
    public bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerCharachter");
    }


    public void UpdatePath(Vector3 targetPos)
    {
        path = new Vector3[0];
        targetIndex = 0;
        PathRequestManeger.RequestPath(Seeker.transform.position, targetPos, OnPathFound);

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


    private IEnumerator FollowPath()
    {
        done = false;
        if (path == null || path.Length == 0)
        {
            done = true;
            yield break;

        }
        targetIndex = 0;
        Vector3 currentWaypoint = path[targetIndex];
        while (true)
        {
            AIBrain.setOnACheckpoint(Seeker.name, false);
            if (Seeker.transform.position == currentWaypoint)
            {
                AIBrain.setOnACheckpoint(Seeker.name, true);

                targetIndex++;
                if (targetIndex >= path.Length)
                {

                    // ResetPath();
                    done = true;
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            Seeker.transform.position = Vector3.MoveTowards(Seeker.transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
        }
    }

    public void ResetPath()
    {
        path = new Vector3[0];
        targetIndex = 0;
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
                    Gizmos.DrawLine(Seeker.transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }


}
