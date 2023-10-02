using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasSeenPlayer : tNode
{

    private GameObject Watcher;
    private GameObject PlayerCharachter;
    private Collider2D collider1;

    public HasSeenPlayer(GameObject _Watcher, GameObject _PlayerCharachter, Collider2D _watcherCollider){
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
                    Debug.Log("Intersection detected!");
                    // Do something when the objects intersect.
                    return tNodeState.SUCCESS;
                }
                else
                {
                    Debug.Log("No intersection.");
                    // Do something when the objects do not intersect.
                    return tNodeState.FAILURE;
                }
            } else{
                return tNodeState.FAILURE;
            }
    }

}
