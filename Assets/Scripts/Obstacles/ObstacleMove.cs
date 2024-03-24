using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of the obstacle movement
    public float moveDistance = 2f; // Distance the obstacle moves

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.right * moveDistance;
    }

    void Update()
    {
        // Move the obstacle
        if (movingRight)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);

        // Change direction if reached the target position
        if (transform.position == targetPosition)
        {
            movingRight = false;
        }
        else if (transform.position == startPosition)
        {
            movingRight = true;
        }
    }
}
