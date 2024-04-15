using UnityEngine;

public static class SaveProgress
{
    public static void SaveMaxScore(int score)
    {
        if (score > LoadScore())
            PlayerPrefs.SetInt("MaxScore", score);
    }

    public static int LoadScore()
    {
        return PlayerPrefs.GetInt("MaxScore", 0);
    }
}