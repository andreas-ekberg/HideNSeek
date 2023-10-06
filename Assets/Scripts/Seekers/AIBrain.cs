using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIBrain
{

// Static fields to store shared data
private static Vector3 knownPosition = Vector3.zero;
private static bool weKnow = false;

//0=Watcher, 1=Listener, 2=Smeller
private static List<bool> watcherOnAPatch = new List<bool>{false,false,false};

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

public static bool onAPath(string seekerName){
    switch (seekerName){
        case "Watcher":
            return watcherOnAPatch[0];
            break;
        case "Listener":
            return watcherOnAPatch[1];
            break;
        case "Smeller":
            return watcherOnAPatch[2];
            break;
        default:
            Debug.Log("Fel inmatning");
            return false;
            break;
    }
}

public static void setOnAPath(string seekerName, bool trueOrFalse){
    switch (seekerName){
        case "Watcher":
            watcherOnAPatch[0] = trueOrFalse;
            break;
        case "Listener":
            watcherOnAPatch[1] = trueOrFalse;
            break;
        case "Smeller":
            watcherOnAPatch[2] = trueOrFalse;
            break;
        default:
            Debug.Log("Fel inmatning");
            break;
    }
}
}
