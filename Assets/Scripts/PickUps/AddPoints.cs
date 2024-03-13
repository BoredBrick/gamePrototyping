using Assets.Scripts;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip pickUpSound;
    public int PointsToAdd;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            audioSource = GameObject.FindGameObjectWithTag("Scripts").GetComponent<AudioSource>();
            Points.score += PointsToAdd * Constants.PointsMultiplier;
            audioSource.PlayOneShot(pickUpSound);
            gameObject.SetActive(false);
        }
    }
}
