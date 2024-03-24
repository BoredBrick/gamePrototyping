using UnityEngine;

public class IceEffect : MonoBehaviour
{
    public static IceEffect Instance { get; private set; }

    private Rigidbody playerRigidbody;
    private bool isIceActive = false;

    // Adjust these parameters as needed
    public float iceFriction = 0.1f; // Friction coefficient on ice (lower means more slippery)
    public float iceSpeedMultiplier = 2f; // Speed multiplier on ice (higher means faster movement)

    private void Awake()
    {
        Instance = this;
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    public void ActivateIce()
    {
        isIceActive = true;
    }

    public void DeactivateIce()
    {
        isIceActive = false;
    }

    private void FixedUpdate()
    {
        if (isIceActive && playerRigidbody != null)
        {
            Debug.Log("Ice is active");
            // Reduce friction when on ice
            playerRigidbody.drag = iceFriction;

            // Increase movement speed on ice
            Vector3 velocity = playerRigidbody.velocity;
            velocity.x *= iceSpeedMultiplier;
            velocity.z *= iceSpeedMultiplier;
            playerRigidbody.velocity = velocity;
        }
        else if (playerRigidbody != null)
        {
            // Reset friction and speed when not on ice
            playerRigidbody.drag = 0.0f;
        }
    }
}
