using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnifferTree : MonoBehaviour
{
    public BehaviorTree Tree;

    private GameObject PlayerCharachter;

    public static bool onAPath = false;
    public ScentTrail scentTrail;
    public static bool isInsideScentCircle = false;

    public PathManager pathManager;





    // Start is called before the first frame update
    void Start()
    {
        PlayerCharachter = GameObject.Find("PlayerCharachter");
        idlePaths IdleScript = GetComponent<idlePaths>();

        Smelling smelling = new Smelling(gameObject, scentTrail, PlayerCharachter);
        IdleWalk idleWalk = new IdleWalk(IdleScript, pathManager, onAPath, "Smeller");
        GoToPosition goToPosition = new GoToPosition("Smeller",pathManager);
        ClearKnownPosition clearKnownPosition = new ClearKnownPosition();
        PlayerPositionKnown playerPositionKnown = new PlayerPositionKnown("Smeller");
        AmIOnPosition amIOnPosition = new AmIOnPosition(gameObject);
        AmIOnCheckpoint amIOnCheckpoint = new AmIOnCheckpoint("Smeller");

        Sequence SEQ1 = new Sequence();
        Selector SEL1 = new Selector();
        Selector SEL2 = new Selector();
        Selector SEL3 = new Selector();
        Sequence SEQ2 = new Sequence();
        Sequence SEQ3 = new Sequence();
        Sequence SEQ4 = new Sequence();

        SEQ2.attach(smelling);

        SEL2.attach(SEQ2);
        SEL2.attach(SEQ4);

        SEQ4.attach(amIOnCheckpoint);
        SEQ4.attach(playerPositionKnown);

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
