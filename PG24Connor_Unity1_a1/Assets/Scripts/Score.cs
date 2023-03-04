using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private static int score;
    private static int highScore;
    private static TextMeshProUGUI scoreText;

    /// <summary>
    /// sets the highscore and the score ui so that it can be set in children classes
    /// </summary>
    /// <param name="scoreUI">a ui object that displays the score</param>
    internal void SetScoreUI(TextMeshProUGUI scoreUI)
    {
        highScore = PlayerPrefs.GetInt("Score");
        scoreText = scoreUI;
        scoreText.text = "Score: 0 / " + PlayerPrefs.GetInt("Score", 0).ToString();
    }

    /// <summary>
    /// allow for children classes to increment the score 
    /// </summary>
    /// <param name="toAdd"></param>
    internal void AddScore(int toAdd)
    {
        score += toAdd;
        scoreText.text = "Score: " + score + " / " + highScore;

        if (score > PlayerPrefs.GetInt("Score", 0)) PlayerPrefs.SetInt("Score", score);
    }

    /// <summary>
    /// alright this ones pretty bad, I needed a quit function, I didn't wanna write the most useless class ever that just had this
    /// so it gets put here
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}