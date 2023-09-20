using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ears : MonoBehaviour
{
    //För Pathfinding
    public Transform traget;
    public float speed = 10;
    Vector3[] path;
    int targetIndex;
    bool currentlyWalking = false;




    // För Gustav Ears
    public GameObject radiusCircleParent; // Adjust this radius as need
    public float detectionRadius;

    public Transform mainCharacterPos;
    public idlePaths idlePath;
    bool idleWalking = false;
    private void Start()
    {

        radiusCircleParent.transform.position = transform.position;
    }

    private void Update()
    {

        radiusCircleParent.transform.position = transform.position;
        if (!idleWalking)
        {
            idleWalking = true;
            Vector3 newTargetPos = idlePath.GetIdleTargetPos();
            PathRequestManeger.RequestPath(transform.position, newTargetPos, OnPathFound);

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision involves another character with a radius
        CircleCollider2D otherCharacterCollider = other.GetComponent<CircleCollider2D>();
        //Debug.Log(otherCharacterCollider.radius);

        if (otherCharacterCollider != null)
        {
            //Debug.Log(otherCharacterCollider.radius);

            if (otherCharacterCollider.radius == 2)
            {
                Debug.Log("Collision Detected! Enemy hears player!");
                PathRequestManeger.RequestPath(transform.position, mainCharacterPos.position, OnPathFound);
            }

        }
    }

    public void OnPathFound(Vector3[] newPath, bool pathSucessful)
    {
        if (pathSucessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }
    IEnumerator FollowPath()
    {
        if (path == null || path.Length == 0)
        {
            // Path is invalid or empty, so exit the coroutine
            if (idleWalking)
            {
                idleWalking = false;
            }
            yield break;
        }
        targetIndex = 0;
        Vector3 currentWaypoint = path[targetIndex];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {

                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    //path = new Vector3[0];
                    targetIndex = 0;
                    currentlyWalking = false;
                    if (idleWalking)
                    {
                        idleWalking = false;
                    }
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
        }
    }



}