using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIBrain
{


private struct playerInfo{
    public static Vector3 position = new Vector3();
    public static bool doWeKnow = false;
}

public static bool doWeKnow (){
    return (playerInfo.doWeKnow);
}

public static Vector3 getKnownPosition(){
    return playerInfo.position;
}

public static void updatePosition(Vector3 inPosition){
    playerInfo.position = inPosition;
}

public static void clearPosition(){
    playerInfo.doWeKnow = false;
}
}
