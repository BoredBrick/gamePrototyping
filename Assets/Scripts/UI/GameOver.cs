using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text finalPoints;
    public GameObject deathScreen;
    public LevelAudio audioManager;
    private HighScore manager;
    private XMLHighScoreManager XMLManager;
    public void Awake()
    {
        manager = ScriptableObject.CreateInstance<HighScore>();
        XMLManager = ScriptableObject.CreateInstance<XMLHighScoreManager>();
    }
    public void Display(int score)
    {
        audioManager.HalfVolume();
        manager.AddNewScore(Points.score);
        Time.timeScale = 0;
        deathScreen.SetActive(true);
        finalPoints.text = score.ToString() + " POINTS";
    }

    public void Restart()
    {
        XMLManager.SaveScores();
        SceneManager.LoadScene("InfinityRunner");
        Points.score = 0;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        XMLManager.SaveScores();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
