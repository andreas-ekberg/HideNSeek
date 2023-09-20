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


    void Awake()
    {
        radiusCircleParent.transform.position = transform.position;

    }
    private void Start()
    {

        radiusCircleParent.transform.position = transform.position;
    }

    private void Update()
    {

        radiusCircleParent.transform.position = transform.position;
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
        Vector3 currentWaypoint = path[0];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                Debug.Log(currentWaypoint);

                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    path = new Vector3[0];
                    targetIndex = 0;
                    currentlyWalking = false;
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
        }
    }



}