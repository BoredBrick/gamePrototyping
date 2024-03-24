using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text finalPoints;
    public GameObject deathScreen;
    public LevelAudio audioManager
        ;
    public void Display(int score)
    {
        audioManager.HalfVolume();
        Time.timeScale = 0;
        deathScreen.SetActive(true);
        finalPoints.text = score.ToString() + " POINTS";
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
