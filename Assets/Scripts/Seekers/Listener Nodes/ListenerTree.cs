using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerTree : MonoBehaviour
{
    public BehaviorTree Tree;

    private GameObject PlayerCharachter;

    public static bool hasHeard = false;
    public static bool onAPath = false;

    public PathManager pathManager;





    // Start is called before the first frame update
    void Start()
    {
        PlayerCharachter = GameObject.Find("PlayerCharachter");
        idlePaths IdleScript = GetComponent<idlePaths>();


        IdleWalk _IdleWalk = new IdleWalk(transform.position, IdleScript, this, PlayerCharachter, pathManager);
        HasHeardPlayer _HasHeardPlayer = new HasHeardPlayer();
        Listen _Listen = new Listen(gameObject, PlayerCharachter);
        Chase _Chase = new Chase(this, PlayerCharachter, pathManager);

        Sequence SEQ1 = new Sequence();
        Selector SEL1 = new Selector();
        Selector SEL2 = new Selector();

        SEL2.attach(_HasHeardPlayer);
        SEL2.attach(_Listen);
        SEQ1.attach(SEL2);
        SEQ1.attach(_Chase);
        SEL1.attach(SEQ1);
        SEL1.attach(_IdleWalk);

        Tree = new BehaviorTree(SEL1);
    }

    // Update is called once per frame
    void Update()
    {
        Tree.runTree();
    }


    // ------------------- PATH MANAGER -----------------




    /* public static void UpdatePath(Vector3 SeekerPos, Vector3 PlayerPos)
    {
        path = new Vector3[0];
        targetIndex = 0;
        PathRequestManeger.RequestPath(SeekerPos, PlayerPos, OnPathFound);

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
            if (transform.position == currentWaypoint)
            {

                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    ResetPath();
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
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
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        } 
    }*/
}
