using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    Text scoreText;
    int highScore;

    public Text panelScore;
    public Text panelhightScore;
    public GameObject newScoreTExt;
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highScore",highScore);
        panelhightScore.text = highScore.ToString();
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        if (score>highScore)
        {
            highScore = score;
            panelhightScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highScore",highScore);
            newScoreTExt.SetActive(true);
        }
    }

    public int GetScore()
    {
        return score;
    }
}
