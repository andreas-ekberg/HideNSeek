using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIBrain
{

// Static fields to store shared data
private static Vector3 knownPosition = Vector3.zero;
private static bool weKnow = false;

public static bool doWeKnow (){
    return (weKnow);
}

public static Vector3 getKnownPosition(){
    return knownPosition;
}

public static void updatePosition(Vector3 inPosition){
    weKnow = true;
    knownPosition = inPosition;
}

public static void clearPosition(){
    weKnow = false;
}
}
