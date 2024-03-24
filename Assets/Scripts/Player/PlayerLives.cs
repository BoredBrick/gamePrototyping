using TMPro;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public TMP_Text livesCounter;
    private const int defaultLives = 3;
    public static int lives = defaultLives;

    void Start()
    {
        livesCounter.text = lives.ToString();
    }

    private void Update()
    {
        livesCounter.text = lives.ToString();
    }
}