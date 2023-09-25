using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : Node
{
    private GameObject Watcher;

    public Walk(GameObject inWatcher){
        Watcher = inWatcher;
    }
    
    public override NodeState evaluate(){

        Vector2 currentPos = Watcher.transform.position;
        float xPos = currentPos.x;
        float yPos = currentPos.y;
        Watcher.transform.position = new Vector2(xPos+0.01f,yPos);
        Debug.Log("walked");
        return NodeState.SUCCESS;
        //Transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

}
