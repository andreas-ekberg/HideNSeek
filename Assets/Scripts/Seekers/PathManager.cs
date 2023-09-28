using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{

    public GameObject Seeker;
    private GameObject Player;

    public int targetIndex;

    public Vector3[] path = new Vector3[10];

    float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerCharachter");
    }


    public void UpdatePath()
    {
        path = new Vector3[0];
        targetIndex = 0;
        PathRequestManeger.RequestPath(Seeker.transform.position, Player.transform.position, OnPathFound);

    }

    public void OnPathFound(Vector3[] newPath, bool pathSucessful)
    {
        if (pathSucessful)
        {

            path = newPath;
            //Debug.Log(newPath[2]);
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    private IEnumerator FollowPath()
    {
        if (path == null || path.Length == 0)
        {
            yield break;
        }
        targetIndex = 0;
        Vector3 currentWaypoint = path[targetIndex];
        while (true)
        {
            if (Seeker.transform.position == currentWaypoint)
            {

                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    ResetPath();
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

    /* public void OnDrawGizmos()
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
    } */


}
