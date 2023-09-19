using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scent
{
    public Vector3 scentPosition;
    public float timeStayingOnGround;
    public int radius = 1;
    public int scentIndex;


    public Scent(Vector3 _pos, float _time, int index)
    {
        scentPosition = _pos;
        timeStayingOnGround = _time;
        scentIndex = index;
    }


}