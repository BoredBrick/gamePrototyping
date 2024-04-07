using UnityEngine;

public class RandomPickUpTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip pickUpSound;
    public TypeOfPickUp typeOfPickUp; // Set this in the Inspector

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            audioSource = GameObject.FindGameObjectWithTag("Scripts").GetComponent<AudioSource>();
            audioSource.PlayOneShot(pickUpSound);
            GameObject.FindGameObjectWithTag("Scripts").GetComponent<RandomPickUps>().TriggerPickUp(typeOfPickUp);
            gameObject.SetActive(false);
        }
    }
}
