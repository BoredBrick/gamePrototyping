using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public LevelAudio audioManager;
    private void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && Countdown.isPlaying)
        {
            if (pauseScreen.activeSelf)
            {
                audioManager.DefaultVolume();
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            }
            else
            {
                audioManager.HalfVolume();
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }
        }
    }
}
