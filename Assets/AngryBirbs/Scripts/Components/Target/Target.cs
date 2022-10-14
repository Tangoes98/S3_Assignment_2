using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Range( 0, 20 )]
    public float MinimumBreakSpeed = 10;

    private void OnCollisionEnter2D( Collision2D collision )
    {
        // Declare the Colliding gameobject.
        var obj = collision.gameObject;

        // Get the velocity from the colliding gameobject.
        var velocity = obj.GetComponent<Rigidbody2D>().velocity.magnitude;

        // Check if the colliding object velocity is bigger than MinimumBreakSpeed or if there is a explosion radius.
        if (velocity >= MinimumBreakSpeed || obj.GetComponent<CircleCollider2D>().radius == 2)
        {
            // If the statement check result is true, then run the destory target function.
            DestroyTarget();
        }
        else
        {
            // else shows the current velocity.
            Debug.Log("Interaction speed " + velocity);
        }

    }


    public void DestroyTarget()
    {
        Destroy( gameObject );
    }
}
