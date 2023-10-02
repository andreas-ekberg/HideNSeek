using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderRotation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    //public Vector3 rotation = new Vector3(0.0f, 0.0f, 280.0f);
    public Vector3 pos1 = new Vector3(1.0f, 1.0f, 0);
    public Vector3 pos2 = new Vector3(-1.5f,2.0f, 0);


    public void FlipVertically(string s)
    {
        if(s=="LEFT" && !spriteRenderer.flipX){
            spriteRenderer.flipX = !spriteRenderer.flipX;
        } else if (s=="RIGHT" && spriteRenderer.flipX){
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 direction = pos2 - pos1;
        float angleRadians = Mathf.Atan2(direction.y, direction.x);
        // Convert radians to degrees
        float angleDegrees = angleRadians * Mathf.Rad2Deg;
        float diff = angleDegrees - transform.eulerAngles.z;
        transform.eulerAngles += new Vector3(0.0f,0.0f,diff);

        

        //Rotera sprite
        if(transform.eulerAngles.z >= 90.0f && transform.eulerAngles.z <= 270){
            Debug.Log("SPRITE FACE TO THE LEFT");
            FlipVertically("LEFT");
        } else {
            Debug.Log("SPRITE FACE TO THE RIGHT");
            FlipVertically("RIGHT");
        }

    }
}
