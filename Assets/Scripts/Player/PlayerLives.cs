using TMPro;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public TMP_Text livesCounter;
    private const int defaultLives = 3;
    public static int lives = defaultLives;
    public static int displayLives = defaultLives;

    void Start()
    {
        livesCounter.text = lives.ToString();
    }

    public static void AddLife()
    {
        lives++;
        displayLives++;
    }

    public static void RemoveLife()
    {
        lives--;
        displayLives = (lives < 0) ? 0 : displayLives - 1;
    }

    private void Update()
    {
        livesCounter.text = displayLives.ToString();
    }
}