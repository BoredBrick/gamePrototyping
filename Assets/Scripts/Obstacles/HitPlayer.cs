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
                //audioSource.PlayOneShot(audio[Random.Range(0,audio.Length)]);
                Timer.flash = true;
                StartCoroutine(SlowWalk());
            }
        }
    }

    //create coroutine that will set PlayerMove.slowWalk to true for 5 seconds
    IEnumerator SlowWalk()
    {
        PlayerMove.slowWalk = true;
        yield return new WaitForSeconds(1.5f);
        PlayerMove.slowWalk = false;
    }
}
