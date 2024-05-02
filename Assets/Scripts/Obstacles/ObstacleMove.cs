using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of the obstacle movement
    public float moveDistance = 2f; // Distance the obstacle moves
    public bool startOnRight = true; // Direction of the obstacle movement

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingBack = true;

    void Start()
    {
        startPosition = transform.position;
        Vector3 movePosition = startOnRight ? Vector3.right : Vector3.left;
        targetPosition = startPosition + movePosition * moveDistance;
    }

    void Update()
    {
        // Move the obstacle
        if (movingBack)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);

        // Change direction if reached the target position
        if (transform.position == targetPosition)
        {
            movingBack = false;
        }
        else if (transform.position == startPosition)
        {
            movingBack = true;
        }
    }
}
