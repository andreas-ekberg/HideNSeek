using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerTree : MonoBehaviour
{
    public BehaviorTree Tree;

    private GameObject PlayerCharachter;

    public static bool onAPath = false;

    public PathManager pathManager;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCharachter = GameObject.Find("PlayerCharachter");
        idlePaths IdleScript = GetComponent<idlePaths>();


        IdleWalk idleWalk = new IdleWalk(IdleScript, pathManager, onAPath);
        GoToPosition goToPosition = new GoToPosition("Listener",pathManager);
        ClearKnownPosition clearKnownPosition = new ClearKnownPosition();
        AmIOnPosition amIOnPosition = new AmIOnPosition(gameObject);
        PlayerPositionKnown playerPositionKnown = new PlayerPositionKnown();
        //UpdateOthers updateOthers = new UpdateOthers(lastKnownPosition);
        Listen listen = new Listen(gameObject, PlayerCharachter);
        
        //GAMMALT OCH SKA ÄNDRAS HELT?!
        //Chase _Chase = new Chase(this, PlayerCharachter, pathManager);

        Sequence SEQ1 = new Sequence();
        Sequence SEQ2 = new Sequence();
        Sequence SEQ3 = new Sequence();

        Selector SEL1 = new Selector();
        Selector SEL2 = new Selector();
        Selector SEL3 = new Selector();

        SEQ2.attach(listen);
        //SEQ2.attach(updateOthers);

        SEL2.attach(SEQ2);
        SEL2.attach(playerPositionKnown);

        SEQ1.attach(SEL2);

        SEQ3.attach(amIOnPosition);
        SEQ3.attach(clearKnownPosition);

        SEL3.attach(SEQ3);
        SEL3.attach(goToPosition);

        SEQ1.attach(SEL3);
        SEL1.attach(SEQ1);
        SEL1.attach(idleWalk);

        

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
