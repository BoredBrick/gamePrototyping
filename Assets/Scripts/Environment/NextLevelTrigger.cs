using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public CameraFade cameraFade;
    public GameObject afterLevelScreen;
    AudioSource AudioSource;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeAndNextLevel());
        }

    }

    IEnumerator FadeAndNextLevel()
    {
        cameraFade.FadeIn();
        AudioSource.volume = 0;
        yield return new WaitForSeconds(1.5f);
        GameObject.FindGameObjectWithTag("Timer").SetActive(false);
        PlayerMove.isMoving = false;
        Timer.isPaused = true;
        cameraFade.FadeOut();
        //set afterLevelScreen active and slowly fade it in, show for 3 seconds, then fade out and load next scene
        afterLevelScreen.SetActive(true);
        yield return new WaitForSeconds(9);
        cameraFade.FadeIn();
        yield return new WaitForSeconds(1.5f);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
