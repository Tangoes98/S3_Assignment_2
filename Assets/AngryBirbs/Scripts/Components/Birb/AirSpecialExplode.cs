using UnityEngine;

public class AirSpecialExplode : MonoBehaviour, IAirSpecial
{
    [Range( 0, 5 )]
    public float BlastRadius = 2;

    public void ExecuteAirSpecial()
    {
        // Declare the CircleCollider of the YellowBird 
        var collider = this.gameObject.GetComponent<CircleCollider2D>();

        // When function is executed, extend circle collider radius to BlastRadius.
        collider.radius = BlastRadius;

        // Then destory the bird in 0.3 seconds.
        Destroy(gameObject, 0.3f);

    }
}
