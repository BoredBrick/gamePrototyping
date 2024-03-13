using UnityEngine;

public class RandomPickUpTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip pickUpSound;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            audioSource = GameObject.FindGameObjectWithTag("Scripts").GetComponent<AudioSource>();
            audioSource.PlayOneShot(pickUpSound);
            GameObject.FindGameObjectWithTag("Scripts").GetComponent<RandomPickUps>().TriggerEffect();
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
