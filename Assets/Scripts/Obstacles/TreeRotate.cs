using UnityEngine;

public class TreeRotate : MonoBehaviour
{
    public bool rotateToLeft = false; // Set this boolean to control the rotation direction
    public GameObject objectToRotate; // Reference to the GameObject to rotate
    private bool rotated = false; // Boolean to prevent continuous rotation
    private Quaternion targetRotation; // Target rotation for smooth lerp

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !rotated)
        {
            if (rotateToLeft)
            {
                // Calculate the target rotation 90 degrees to the left
                targetRotation = objectToRotate.transform.rotation * Quaternion.Euler(0f, -180f, 0f);
            }
            else
            {
                // Calculate the target rotation 90 degrees to the right
                targetRotation = objectToRotate.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
            }

            rotated = true; // Set rotated to true to prevent continuous rotation
        }
    }

    private void Update()
    {
        if (rotated)
        {
            // Smoothly interpolate between the current rotation and the target rotation
            objectToRotate.transform.rotation = Quaternion.Lerp(objectToRotate.transform.rotation, targetRotation, Time.deltaTime * 2f);

            // Check if the rotation is almost complete
            if (Quaternion.Angle(objectToRotate.transform.rotation, targetRotation) < 1f)
            {
                // Snap to the target rotation
                objectToRotate.transform.rotation = targetRotation;
            }
        }
    }
}
