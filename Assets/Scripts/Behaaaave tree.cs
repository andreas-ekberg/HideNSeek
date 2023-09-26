using UnityEngine;

public class Behaaaavetree : MonoBehaviour
{
    public GameObject objectToCheck; // Assign the GameObject you want to check for intersection with in the Inspector.

    private void Update()
    {
        // Check if the bounds of the two colliders intersect.
        if (objectToCheck != null)
        {
            Collider2D collider1 = GetComponent<Collider2D>();
            Collider2D collider2 = objectToCheck.GetComponent<Collider2D>();

            if (collider1 != null && collider2 != null)
            {
                if (collider1.bounds.Intersects(collider2.bounds))
                {
                    Debug.Log("Intersection detected!");
                    // Do something when the objects intersect.
                }
                else
                {
                    Debug.Log("No intersection.");
                    // Do something when the objects do not intersect.
                }
            }
        }
    }
}
