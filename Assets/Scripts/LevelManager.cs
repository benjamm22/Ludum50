using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public Text scoreText;

    int points = Score.score;


    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("FirstLevel");
        Score.score = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("PlayMenu");
        Score.score = 1;
    }

    public void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = points.ToString();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
