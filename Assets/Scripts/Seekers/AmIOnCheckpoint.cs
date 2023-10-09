using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AmIOnCheckpoint : tNode{

    public string seekerName;
    public AmIOnCheckpoint(string inSeekerName){
        seekerName = inSeekerName;
    }

    public override tNodeState evaluate(){

        if(AIBrain.onACheckPoint(seekerName)){
            
            return tNodeState.SUCCESS;

        }
        else{
            //Kör bara det här när någon chasar. 
            //Debug.Log("I am failure.");
            return tNodeState.FAILURE;
        }

    }

}