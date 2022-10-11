using UnityEngine;

public class AirSpecialSplit : MonoBehaviour, IAirSpecial
{
    public float SplitAngleInDegrees = 10;

    public void ExecuteAirSpecial()
    {
        // Get Bluebird gameobject.
        var splitBirds = this.gameObject;

        // Set up an array for copies of Bluebirds
        GameObject[] airBird = new GameObject[2];

        // Set the rotation value based on Z axis.
        var rot = Quaternion.AngleAxis(SplitAngleInDegrees, Vector3.forward);


        // Use for loop to generate 2 Bluebirds.
        for (int i = 0; i < airBird.Length; i++)
        {
            // Generate Bluebirds
            airBird[i] = GameObject.Instantiate<GameObject>(splitBirds);

            // Set the Rigidbody simulation to True so it has physics.
            airBird[i].GetComponent<Rigidbody2D>().simulated = true;

            // Generate the Blubirds at Original Bluebird position.
            airBird[i].transform.position = this.transform.position;
            
            // Get the Direction of the Original Bluebird.
            var veloNor = this.GetComponent<Rigidbody2D>().velocity.normalized;

            // Get the updated Velocity by times Rotation degree to Direction.
            var veloBird = rot * new Vector3(veloNor.x, veloNor.y, 0f) ;

            // Set the Velocity to the copy bird.
            airBird[i].GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.magnitude * veloBird;

            // Update the opposite rotation for 2nd copy bird
            rot = Quaternion.AngleAxis(-SplitAngleInDegrees, Vector3.forward);

        }


    }
}
