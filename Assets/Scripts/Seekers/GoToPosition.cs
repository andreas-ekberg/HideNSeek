using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GoToPosition : tNode
{

    private PathManager pathManager;
    public string seekerName;

    public GoToPosition(string inSeekerName, PathManager inPathManager)
    {
        pathManager = inPathManager;
        seekerName = inSeekerName;
    }

    public override tNodeState evaluate()
    {

        if (!AIBrain.onAPath(seekerName))
        {
            //Here i want to pause for 1 sec
            //SomeAsyncMethod();

            pathManager.UpdatePath(AIBrain.getKnownPosition());
            AIBrain.setCurrentlyIdleWalking(seekerName, false);

            //Debug.Log("GoToPosition");


            AIBrain.setOnAPath(seekerName, true);
            return tNodeState.SUCCESS;
        }
        else
        {
            //Debug.Log("I am currently chasing!");
            return tNodeState.RUNNING;
        }

    }

    public async Task SomeAsyncMethod()
    {
        // This will introduce a delay of 1 second (1000 milliseconds)
        await Task.Delay(500);

        // Code here will execute after waiting for 1 second
        //Console.WriteLine("Waited for 1 second.");
    }
}
