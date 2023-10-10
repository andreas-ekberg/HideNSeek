using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelling : tNode
{
    private GameObject Smeller;
    private GameObject PlayerCharachter;

    private ScentTrail scentTrail;

    public Smelling(GameObject _Smeller, ScentTrail _scentTrail, GameObject _PlayerCharachter)
    {
        Smeller = _Smeller;
        scentTrail = _scentTrail;
        PlayerCharachter = _PlayerCharachter;
    }

    public override tNodeState evaluate()
    {
        SnifferTree.isInsideScentCircle = scentTrail.IsInsideScentCircle(Smeller.transform.position);
        if (SnifferTree.isInsideScentCircle)
        {
            Debug.Log("I smell fear");
            AIBrain.updatePosition(PlayerCharachter.transform.position);
            AIBrain.setOnAPath(Smeller.name, false);
            return tNodeState.SUCCESS;
        }
        else
        {
            return tNodeState.FAILURE;
        }

    }
}
