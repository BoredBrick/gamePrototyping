using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float totalTime = 120f; // Total time in seconds
    public TMP_Text timerText;
    private float remainingTime; // Remaining time in seconds
    public static bool doubleSpeed = false;

    void Start()
    {
        remainingTime = totalTime;
    }

    void Update()
    {
        // If double speed is active, reduce remaining time by double the speed
        if (doubleSpeed)
        {
            remainingTime -= 6 * Time.deltaTime;
        }
        else
        {
            remainingTime -= Time.deltaTime;
        }

        // Ensure remaining time does not go below zero
        if (remainingTime < 0)
        {
            remainingTime = 0;
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);

        if (minutes > 0)
        {
            //timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            // display miliseconds
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, (remainingTime * 100) % 100);
        }
        else
        {
            //timerText.text = string.Format("{0:00}", seconds);
            // display miliseconds
            timerText.text = string.Format("{0:00}:{1:00}", seconds, (remainingTime * 100) % 100);
        }
    }
}
