using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSounds : MonoBehaviour
{
    public AudioClip[] audio;
    public static bool hitSound = false;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitSound)
        {
            hitSound = false;
            audioSource.PlayOneShot(audio[Random.Range(0, audio.Length)]);
        }
    }
}
