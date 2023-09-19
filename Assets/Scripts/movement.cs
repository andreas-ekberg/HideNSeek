using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from arrow keys.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction.
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Normalize the movement vector to avoid diagonal movement being faster.
        movement.Normalize();

        // Move the GameObject using Transform.
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
