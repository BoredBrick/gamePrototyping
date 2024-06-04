using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public CameraFade cameraFade;
    AudioSource audioSource;
    public AudioClip deathsound;
    bool deathStarted = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.remainingTime <= 0 && !deathStarted)
        {
            deathStarted = true;
            audioSource.PlayOneShot(deathsound);
            StartCoroutine(FadeAndLoadScene());
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
