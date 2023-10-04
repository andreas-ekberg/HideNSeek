using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnifferTree : MonoBehaviour
{
    public BehaviorTree Tree;

    private GameObject PlayerCharachter;

    public static bool hasSmelled = false;
    public static bool onAPath = false;
    public ScentTrail scentTrail;
    public static bool isInsideScentCircle = false;

    public PathManager pathManager;





    // Start is called before the first frame update
    void Start()
    {
        PlayerCharachter = GameObject.Find("PlayerCharachter");
        idlePaths IdleScript = GetComponent<idlePaths>();


        IdleWalk _IdleWalk = new IdleWalk(IdleScript, pathManager, onAPath);
        HasSmelledPlayer _HasSmelledPlayer = new HasSmelledPlayer();
        Smelling _Smelling = new Smelling(gameObject, scentTrail, PlayerCharachter);

        Sequence SEQ1 = new Sequence();
        Selector SEL1 = new Selector();
        Selector SEL2 = new Selector();

        SEL2.attach(_HasSmelledPlayer);
        SEL2.attach(_Smelling);
        SEL1.attach(SEL2);
        SEL1.attach(_IdleWalk);

        Tree = new BehaviorTree(SEL1);
    }

    // Update is called once per frame
    void Update()
    {
        Tree.runTree();
    }

}
