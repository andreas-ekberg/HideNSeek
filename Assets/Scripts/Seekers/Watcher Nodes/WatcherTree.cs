using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherTree : MonoBehaviour
{

    public BehaviorTree Tree;

    private Vector3 nextPosition;

    private GameObject PlayerCharachter;

    public PathManager pathManager;
    public Collider2D watcherCollider;

    //public static bool hasSeen = false;
    public static bool onAPath = false;
    



    // Start is called before the first frame update
    void Start()
    {
        PlayerCharachter = GameObject.Find("PlayerCharachter");
        idlePaths IdleScript = GetComponent<idlePaths>();

        IdleWalk idleWalk = new IdleWalk(IdleScript, pathManager, onAPath);
        GoToPosition goToPosition = new GoToPosition("Watcher",pathManager);
        ClearKnownPosition clearKnownPosition = new ClearKnownPosition();
        PlayerPositionKnown playerPositionKnown = new PlayerPositionKnown();
        AmIOnPosition amIOnPosition = new AmIOnPosition(gameObject);
        LookForPlayer lookForPlayer = new LookForPlayer(gameObject, PlayerCharachter, watcherCollider);


        Sequence SEQ1 = new Sequence();
        Selector SEL1 = new Selector();
        Selector SEL2 = new Selector();
        Selector SEL3 = new Selector();
        Sequence SEQ2 = new Sequence();
        Sequence SEQ3 = new Sequence();


        SEQ2.attach(lookForPlayer);

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
}
