using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottonLeft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject getReady;
    public static int gameScore;
    public GameObject score;

    public static bool gameStarted;

    private void Awake()
    {
        bottonLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
    }
    void Start()
    {
        gameOver = false;
        gameStarted = false;
    }
    public void GameHasStarted()
    {
        getReady.SetActive(false);
        gameStarted = true;
    }
     public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore = score.GetComponent<Score>().GetScore();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
