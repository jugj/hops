using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    //Setze Leben
    public int maxLeben = 5;
    public int jetztLeben;

    public Lebensanzeige lebensanzeige;

    public GameObject gameOverScreen;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        jetztLeben = maxLeben;
        lebensanzeige.SetzeMaxLeben(maxLeben);

        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (jetztLeben <= 0 && !isGameOver)
        {
            GameOver();
        }

        if (Input.GetKeyDown("o"))
        {
            jetztLeben -= 1;
            lebensanzeige.SetzeLeben(jetztLeben);
        }
    }

    void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
        Debug.Log("Game Over!");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}