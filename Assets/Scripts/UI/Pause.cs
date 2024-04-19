using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public LevelAudio audioManager;
    public GameObject button;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button7) )
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
                EventSystem.current.SetSelectedGameObject(button);
            }
        }
    }
}
