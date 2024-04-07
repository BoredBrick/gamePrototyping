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
        if (PlayerLives.lives < 0)
        {
            cameraFade.FadeIn();
            PlayerLives.lives = 3;
            StartCoroutine(FadeAndLoadScene());
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerLives.displayLives = 3;
        PlayerLives.lives = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
