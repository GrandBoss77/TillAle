using UnityEngine;

public class WindmillRotation : MonoBehaviour
{
    // Speed at which the windmill rotates
    public float rotationSpeed = 10f;

    void Update()
    {
        // Rotate the windmill around the y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}


