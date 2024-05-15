using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public CameraFade cameraFade;

    // Update is called once per frame
    void Update()
    {
        if (Timer.remainingTime <= 0)
        {
            cameraFade.FadeIn();
            StartCoroutine(FadeAndLoadScene());
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
