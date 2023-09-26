using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : tNode
{

    private GameObject Watcher;
    private GameObject PlayerCharachter;

    public LookAround(GameObject _Watcher, GameObject _PlayerCharachter){
        Watcher = _Watcher;
        PlayerCharachter = _PlayerCharachter;
    }

    public override tNodeState evaluate(){
        // Check if the bounds of the two colliders intersect.

            Collider2D collider1 = Watcher.GetComponent<Collider2D>();
            Collider2D collider2 = PlayerCharachter.GetComponent<Collider2D>();

            /* Vector3 moveDirection = Watcher.transform.position - _origPos;
            if (moveDirection != Vector3.zero) 
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            } */

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
