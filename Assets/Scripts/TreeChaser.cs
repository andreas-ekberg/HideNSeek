using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChaser : MonoBehaviour
{
    public GameObject Watcher;
    public GameObject PlayerCharachter;
    // Start is called before the first frame update
    public BehaviorTree chase;
    private Watch watch;
    private Walk walk;
    private Follow follow;
    private Sequence sequence1;
    private Selector selector1;

    void Start()
    {
        watch = new Watch(Watcher, PlayerCharachter);
        walk = new Walk(Watcher);
        follow = new Follow(Watcher,PlayerCharachter);
        sequence1 = new Sequence();
        selector1 = new Selector();

        //Build tree
        sequence1.attach(watch);
        sequence1.attach(follow);

        //Längst upp i trädet är Selector1. Första noden är sequence 1 som består av två nodes. Sen till höger är walk noden
        selector1.attach(sequence1);
        selector1.attach(walk);


        chase = new BehaviorTree(selector1);
    }

    // Update is called once per frame
    void Update()
    {
        chase.runTree();
    }
}
