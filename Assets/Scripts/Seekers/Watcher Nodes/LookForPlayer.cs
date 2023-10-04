using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayer : tNode
{
    private GameObject Watcher;
    private GameObject PlayerCharachter;
    private Collider2D collider1;

    public LookForPlayer(GameObject _Watcher, GameObject _PlayerCharachter, Collider2D _watcherCollider){
        Watcher = _Watcher;
        PlayerCharachter = _PlayerCharachter;
        collider1 = _watcherCollider;

    }

    public override tNodeState evaluate(){
            Collider2D collider2 = PlayerCharachter.GetComponent<Collider2D>();

            if (collider1 != null && collider2 != null)
            {
                if (collider1.bounds.Intersects(collider2.bounds))
                {
                    // Do something when the objects intersect.
                    WatcherTree.hasSeen = true;
                    return tNodeState.SUCCESS;
                }
                else
                {
                    // Do something when the objects do not intersect.
                    WatcherTree.hasSeen = false;
                    return tNodeState.FAILURE;
                }
            } else{
                return tNodeState.FAILURE;
            }
    }

}
