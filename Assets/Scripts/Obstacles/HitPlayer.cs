using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public GameObject Sparks;
    public AudioClip[] audio;
    AudioSource audioSource;

    void OnStart()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            {
                Timer.remainingTime -= 5;
                //Instantiate(Sparks, collision.transform.position, Quaternion.identity);
                //audioSource.PlayOneShot(audio[Random.Range(0,audio.Length)]);
                Timer.flash = true;
            }
        }
    }
}
