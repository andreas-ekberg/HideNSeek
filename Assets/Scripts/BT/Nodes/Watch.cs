using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : tNode
{
    private GameObject Watcher;
    private GameObject PlayerCharachter;

    public Watch(GameObject inWatcher, GameObject inPlayerCharachter){
        Watcher = inWatcher;
        PlayerCharachter = inPlayerCharachter;
    }
    
    public override tNodeState evaluate(){
        // Check if the bounds of the two colliders intersect.

            Collider2D collider1 = Watcher.GetComponent<Collider2D>();
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
