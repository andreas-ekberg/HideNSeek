using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherTree : MonoBehaviour
{

    public BehaviorTree Tree;

    private Vector3 nextPosition;

    private GameObject PlayerCharachter;

    public PathManager pathManager;

    public static bool hasSeen = false;
    public static bool onAPath = false;
    



    // Start is called before the first frame update
    void Start()
    {
        PlayerCharachter = GameObject.Find("PlayerCharachter");
        idlePaths IdleScript = GetComponent<idlePaths>();

        IdleWalk _IdleWalk = new IdleWalk(transform.position,  IdleScript, this, PlayerCharachter, pathManager);
        HasSeenPlayer _HasSeenPlayer = new HasSeenPlayer();
        LookAround _LookAround = new LookAround(gameObject, PlayerCharachter);
        Chase _Chase = new Chase(this, PlayerCharachter, pathManager);

        Sequence SEQ1 = new Sequence();
        Selector SEL1 = new Selector();
        Selector SEL2 = new Selector();

        SEL2.attach(_HasSeenPlayer);
        SEL2.attach(_LookAround);
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
}
