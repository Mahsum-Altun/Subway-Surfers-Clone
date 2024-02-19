using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text score;
    public static int scoreValue;
    //is the game over
    bool gameHasEnded = false;
    public Animator playerAnimator;
    public GameObject mainMenuPanel;
    public Animator mainMenuAnimator;
    public GameObject gameOverPanel;
    public Animator gameOverAnimator;


    private void Update()
    {
        score.text = "" + scoreValue;
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverPanel.SetActive(true);
        }
    }
    public void MainMenu()
    {
        scoreValue = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
