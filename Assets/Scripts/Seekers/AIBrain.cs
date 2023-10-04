using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBrain : MonoBehaviour
{


private struct playerInfo{
    public static Vector3 position = new Vector3();
    public static bool doWeKnow = false;
}

public bool doWeKnow (){
    return (playerInfo.doWeKnow);
}

public Vector3 getKnownPosition(){
    return playerInfo.position;
}

public void updatePosition(Vector3 inPosition){
    playerInfo.position = inPosition;
}

public void clearPosition(){
    playerInfo.doWeKnow = false;
}
}
