using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonBallPrefab;
    public Transform firePoint;
    public float fireInterval = 3f;
    public float cannonBallSpeed = 200f;
    public float cannonBallLifetime = 5f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            timer = 0f;
            FireCannon();
        }
    }

    void FireCannon()
    {
        GameObject cannonBall = Instantiate(cannonBallPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * cannonBallSpeed);
        }
        else
        {
            Debug.LogWarning("Cannonball prefab does not have a Rigidbody component.");
        }
        Destroy(cannonBall, cannonBallLifetime);
    }
}
