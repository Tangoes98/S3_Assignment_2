using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [Range( 0, 5 )]
    public float HalfPathDistance = 3;
    [Range( 0, 5 )]
    public float MovementSpeed = 2;

    // Declare variable for Top, Bottom and Moving towards Vector3 position.
    Vector3 topPos;
    Vector3 bottomPos;
    Vector3 movingPos;


    private void Start()
    {
        // Set the top, bottom and Start target moving position.
        topPos = new Vector3(transform.position.x, transform.position.y + HalfPathDistance, 0);
        bottomPos = new Vector3(transform.position.x, transform.position.y + -HalfPathDistance, 0);
        movingPos = topPos;
    }
    private void FixedUpdate()
    {
        // If the gameobject reaches the top, then the moveing toward position will be set to bottom, or vise versa.
        if(transform.position == topPos)
        {
            movingPos = bottomPos;
        }
        
        if (transform.position ==  bottomPos)
        {
            movingPos = topPos;
        }

        // To make the target move by using the MoveTowards method.
        transform.position = Vector3.MoveTowards(transform.position, movingPos, MovementSpeed * Time.deltaTime);

    }
}
