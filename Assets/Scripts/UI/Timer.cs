using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float totalTime = 120f; // Total time in seconds
    public TMP_Text timerText;
    public static float remainingTime; // Remaining time in seconds
    public static bool doubleSpeed = false;
    Color originalColor;
    Color flashColor = Color.red;
    public float flashDuration = 0.6f;
    public float fadeDuration = 0.3f;
    public static bool flash = false;
    bool flashActive = false;
    void Start()
    {
        remainingTime = totalTime;
        originalColor = timerText.color;
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

        if (flash)
        {
            flash = false;
            StartCoroutine(FlashRoutine());
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

    IEnumerator FlashRoutine()
    {
        if (flashActive)
        {
            yield break;
        }
        flashActive = true;

        float timer = 0f;
        while (timer < 0.1f)
        {
            timer += Time.deltaTime;
            timerText.color = Color.Lerp(originalColor, flashColor, timer / 0.1f);
            Q_Vignette_Single.mainScale = Mathf.Lerp(0f, 1.7f, timer / 0.1f);
            yield return null;
        }

        // Hold at full flash color and vignette scale
        yield return new WaitForSeconds(1);

        // Fade out
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            timerText.color = Color.Lerp(flashColor, originalColor, timer / fadeDuration);
            Q_Vignette_Single.mainScale = Mathf.Lerp(1.7f, 0f, timer / fadeDuration);
            yield return null;
        }

        flashActive = false;
    }
}
