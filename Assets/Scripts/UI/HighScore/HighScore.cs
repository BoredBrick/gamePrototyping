using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : ScriptableObject
{
    public static HighScore Instance;
    public static List<int> Scores { get; } = new();
    private void Awake()
    {
        Instance = this;
    }
    public void AddNewScore(int score)
    {
        Scores.Add(score);
        Scores.Sort((int x, int y) => y.CompareTo(x));
        if (Scores.Count > Constants.MaxStoredScores)
        {
            Scores.RemoveAt(Constants.MaxStoredScores);
        }
    }
}
