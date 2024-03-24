using UnityEngine;

public class ObstacleFall : MonoBehaviour
{
    public GameObject FallingObstacle;
    private bool falling = false;
    public enum FallDirection { Left, Right }; // Enum to specify the fall direction
    public FallDirection fallDirection; // Variable to store the chosen fall direction
    private Quaternion finalRotationFallLeft = Quaternion.Euler(-90f, -90f, 180f);
    private Quaternion finalRotationFallRight = Quaternion.Euler(90, 90f, 0);
    private Quaternion finalRotation;
    private readonly float rotationSpeed = 1.5f;

    private void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.CompareTag("Player"))
        {
            falling = true;
            switch (fallDirection)
            {
                case FallDirection.Left:
                    finalRotation = finalRotationFallLeft;
                    break;
                case FallDirection.Right:
                    finalRotation = finalRotationFallRight;
                    break;
            }
        }
    }

    private void Update()
    {
        if (falling)
        {
            FallingObstacle.transform.rotation = Quaternion.Slerp(FallingObstacle.transform.rotation, finalRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
