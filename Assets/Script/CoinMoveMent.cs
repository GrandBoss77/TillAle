using UnityEngine;

public class CoinMoveMent : MonoBehaviour
{
    public float amplitude = 0.5f; // The amount of movement in the Y-axis
    public float speed = 1f; // The speed of the movement

    private Vector3 startPos; // The starting position of the coin

    void Start()
    {
        // Store the initial position of the coin
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new position based on sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * amplitude;

        // Update the position of the coin
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

