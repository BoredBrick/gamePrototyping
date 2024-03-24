using System.Collections;
using UnityEngine;

public class WindEffect : MonoBehaviour
{
    public static WindEffect Instance { get; private set; }

    public float windForce = 43f;
    public float applyDuration = 5f; // Duration to apply wind force before switching direction
    public float applyInterval = 2f; // Interval between each application of wind force

    private Rigidbody playerRigidbody;
    private Coroutine windCoroutine;
    private bool isWindFromLeft = true; // Indicates if the wind is currently coming from the left side

    private void Awake()
    {
        Instance = this;
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    public void StartWind()
    {
        if (windCoroutine == null)
        {
            windCoroutine = StartCoroutine(WindRoutine());
        }
    }

    public void StopWind()
    {
        if (windCoroutine != null)
        {
            StopCoroutine(windCoroutine);
            windCoroutine = null;
        }
    }

    IEnumerator WindRoutine()
    {
        while (true)
        {
            // Apply wind force in the current direction every frame for the specified duration
            float timer = 0f;
            while (timer < applyDuration)
            {
                ApplyWindForce(isWindFromLeft ? Vector3.left : Vector3.right);
                timer += Time.deltaTime;
                yield return null;
            }

            // Switch wind direction
            isWindFromLeft = !isWindFromLeft;

            // Wait for the specified interval before applying wind force again
            yield return new WaitForSeconds(applyInterval);
        }
    }

    void ApplyWindForce(Vector3 direction)
    {
        if (playerRigidbody != null)
        {
            // Apply the wind force without affecting the player's current velocity
            Vector3 windVelocity = direction * windForce * Time.deltaTime;
            playerRigidbody.velocity += windVelocity;
        }
    }
}
