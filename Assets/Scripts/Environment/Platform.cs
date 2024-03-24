using UnityEngine;

public class Platform : MonoBehaviour
{
    public float fallDelay = 1.3f;
    public float returnDelay = 2f;
    public float returnSpeed = 20f; // Speed at which the platform returns
    public Vector3 originalPosition;

    private bool playerTouchedPlatform = false;
    private bool platformFalling = false;
    private bool returnTimerStarted = false;
    private Rigidbody rb;
    private float fallTimer = 0f;
    private float returnTimer = 0f;

    private Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        rb.isKinematic = true; // Ensure kinematic is initially enabled
        targetPosition = originalPosition; // Initialize target position
    }

    void Update()
    {
        if (platformFalling)
        {
            fallTimer += Time.deltaTime;
            if (fallTimer >= fallDelay)
            {
                ResetPlatform();
            }
        }
        else if (playerTouchedPlatform && !returnTimerStarted)
        {
            returnTimer += Time.deltaTime;
            if (returnTimer >= returnDelay)
            {
                Fall();
                returnTimerStarted = true;
                returnTimer = 0f; // Reset return timer after starting the fall
            }
        }
        else if (transform.position != targetPosition)
        {
            // Smoothly move the platform back to its original position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, returnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                platformFalling = false;
                returnTimerStarted = false; // Reset return timer flag when platform reaches target position
            }
        }
    }

    void Fall()
    {
        rb.isKinematic = false; // Disable kinematic to allow gravity to act
        platformFalling = true;
        fallTimer = 0f;
    }

    void ResetPlatform()
    {
        rb.isKinematic = true; // Re-enable kinematic to stop physics simulation
        platformFalling = false;
        returnTimerStarted = false;
        playerTouchedPlatform = false;
        returnTimer = 0f;

        // Set the target position for the platform to return to
        targetPosition = originalPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!playerTouchedPlatform) // Check if this is the first touch
            {
                playerTouchedPlatform = true;
                returnTimerStarted = false; // Reset return timer flag
            }
        }
    }
}
