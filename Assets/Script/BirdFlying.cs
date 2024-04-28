using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 3f; // Speed of the bird
    public float flyHeight = 1f; // Height at which the bird flies
    public Transform[] targetPoints; // Array of target positions

    private int currentTargetIndex = 0;
    private Vector3 startPos;
    private bool flyingRight = true;
    private Vector3 direction;

    void Start()
    {
        startPos = transform.position;
        direction = (targetPoints[currentTargetIndex].position - startPos).normalized;
        Destroy(gameObject, 15);
    }

    void Update()
    {
        // Calculate the next position
        Vector3 nextPos = targetPoints[currentTargetIndex].position;

        // Move the bird towards the next position
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

        // If the bird reaches the target position, switch to the next target
        if (transform.position == nextPos)
        {
            currentTargetIndex++;

            // If reached the end of the target points, start from the beginning
            if (currentTargetIndex >= targetPoints.Length)
            {
                currentTargetIndex = 0;
            }

            // Change direction towards the new target
            direction = (targetPoints[currentTargetIndex].position - transform.position).normalized;
        }

        // Adjust the bird's height
        transform.position = new Vector3(transform.position.x, startPos.y + Mathf.PingPong(Time.time, flyHeight), transform.position.z);

        // Update direction to face the next target
        UpdateDirection();
    }

    // Update direction to face the next target
    void UpdateDirection()
    {
        if (direction.x > 0 && !flyingRight || direction.x < 0 && flyingRight)
        {
            flyingRight = !flyingRight;

            // Flip the bird's sprite if flying in the opposite direction
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}





