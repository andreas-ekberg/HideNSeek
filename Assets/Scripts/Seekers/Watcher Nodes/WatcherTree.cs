using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherTree : MonoBehaviour
{

    public BehaviorTree Tree;

    private Vector3 nextPosition;



    // Start is called before the first frame update
    void Start()
    {
        idlePaths IdleScript = GetComponent<idlePaths>();
        IdleWalk IdleWalk1 = new IdleWalk(transform.position,  IdleScript, this);
        Tree = new BehaviorTree(IdleWalk1);
    }

    // Update is called once per frame
    void Update()
    {
        Tree.runTree();
    }
}
