using UnityEngine;
using UnityEngine.UIElements;

public class AirSpecialBounce : MonoBehaviour, IAirSpecial
{
    [Range( 0, 1 )]
    public float SlowDownFactor = 1;

    public void ExecuteAirSpecial()
    {
        // Indicate the ability is activated.
        Debug.Log("Red bird bounce ability activated");

        // Set Red bird's rigidbody2D variable.
        var rbVelocity = GetComponent<Rigidbody2D>().velocity;
        
        // If the RedBird's rigidbody2D.y is less than 0 then be able to reflect.
        if(rbVelocity.y < 0)
        {
            // Reflect the Redbird's rigidbody2D.velocity by Y axis.
            GetComponent<Rigidbody2D>().velocity = Vector3.Reflect(rbVelocity, Vector3.up);

            // Then use Redbird's velocity times SlowDownFactor.
            GetComponent<Rigidbody2D>().velocity *= SlowDownFactor;
        }

    }
}
