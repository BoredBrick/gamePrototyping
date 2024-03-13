using UnityEngine;

public class HighScoreDisplayManager : MonoBehaviour
{
    public HighScoreDisplayRow[] highScoreDisplayArray;

    public void Awake()
    {
        ShowScore();
    }
    public void ShowScore()
    {
        for (int i = 0; i < highScoreDisplayArray.Length; i++)
        {
            if (i < HighScore.Scores.Count)
            {
                highScoreDisplayArray[i].DisplayHighScore(HighScore.Scores[i]);
            }
            else
            {
                highScoreDisplayArray[i].HideEntryDisplay();
            }
        }
    }
}
