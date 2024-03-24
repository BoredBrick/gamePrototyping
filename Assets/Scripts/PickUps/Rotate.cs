using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 1f; // Speed of rotation

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0); // Adjust the rotation speed along the y-axis
    }
}