using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public int countdownTime;
    public TMP_Text countdownDisplay;
    public static bool isPlaying = false;
    void Start()
    {
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        Time.timeScale = 0;
        countdownDisplay.gameObject.SetActive(true);
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSecondsRealtime(1f);
            countdownTime--;
        }

        countdownDisplay.text = "GO";

        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;

        countdownDisplay.gameObject.SetActive(false);
        isPlaying = true;
    }
}
