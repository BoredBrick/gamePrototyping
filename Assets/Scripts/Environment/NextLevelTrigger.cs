using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
        public CameraFade cameraFade;
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
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
