using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentTrail : MonoBehaviour
{
    Scent[] scentTrail = new Scent[6];
    public int currentIndex = 0;

    private void Start()
    {
        InvokeRepeating("AddScentEveryTwoSecond", 0f, 0.5f);
    }

    private void AddScentEveryTwoSecond()
    {
        AddSmell(transform.position);

    }
    public void AddSmell(Vector3 smellPosition)
    {
        Scent scentToAdd = new Scent(smellPosition, 5, currentIndex);
        scentTrail[currentIndex] = scentToAdd;
        if (currentIndex == 5)
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex++;
        }
    }


    public bool IsInsideScentCircle(Vector3 position)
    {
        if (scentTrail != null)
        {
            foreach (Scent s in scentTrail)
            {
                if (s != null)
                {
                    float distance = Vector3.Distance(position, s.scentPosition);
                    if (distance <= s.radius)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void OnDrawGizmos()
    {
        if (scentTrail != null)
        {
            foreach (Scent s in scentTrail)
            {
                if (s != null) // Check if the element is not null
                {
                    Gizmos.color = Color.white;
                    Gizmos.DrawSphere(s.scentPosition, s.radius);
                }
            }
        }
    }
}
