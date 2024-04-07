using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 120f; // Total time in seconds
    public TMP_Text timerText;
    private float remainingTime; // Remaining time in seconds

    void Start()
    {
        remainingTime = totalTime;
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;

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
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timerText.text = string.Format("{0:00}", seconds);
        }
    }
}
