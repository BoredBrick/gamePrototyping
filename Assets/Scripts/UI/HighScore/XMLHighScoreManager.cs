using Assets.Scripts;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XMLHighScoreManager : ScriptableObject
{
    public static XMLHighScoreManager instance;
    private Leaderboard leaderboard;
    void Awake()
    {
        instance = this;
        if (!Directory.Exists(Application.persistentDataPath + Constants.HighScoresXMLFolderPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath + Constants.HighScoresXMLFolderPath);
        }
        LoadScores();
    }
    public void SaveScores()
    {
        leaderboard = new() { };
        leaderboard.Entries.AddRange(HighScore.Scores);
        XmlSerializer serializer = new(typeof(Leaderboard));
        FileStream stream = new(Application.persistentDataPath + Constants.HighScoresXMLFilePath, FileMode.Create);
        serializer.Serialize(stream, leaderboard);
        stream.Close();
    }
    public void LoadScores()
    {
        if (File.Exists(Application.persistentDataPath + Constants.HighScoresXMLFilePath))
        {
            XmlSerializer serializer = new(typeof(Leaderboard));
            FileStream stream = new(Application.persistentDataPath + Constants.HighScoresXMLFilePath, FileMode.Open);
            leaderboard = serializer.Deserialize(stream) as Leaderboard;
            HighScore.Scores.Clear();
            HighScore.Scores.AddRange(leaderboard.Entries);
        }
    }

    [System.Serializable]
    public class Leaderboard
    {
        public List<int> Entries { get; } = new();
    }
}