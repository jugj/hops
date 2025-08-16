using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spieler : MonoBehaviour
{
    
    //Setze Leben
    public int maxLeben = 3;
    public int jetztLeben;

    public Lebensanzeige lebensanzeige;

    public float Geschwindigkeit = 3f;
    public float Sprungkraft = 12f;
    public Rigidbody2D rigidbody;

    Vector2 bewegungsvektor = new Vector2(0,0);
    Vector2 laufvektor = new Vector2(0,0);
    Vector2 sprungvektor = new Vector2(0,0);

    bool IstInDerLuft = false;

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
        
        if(rigidbody.velocity.y == 0.0f)
        {
            IstInDerLuft = false;
        }
        else{
            IstInDerLuft = true;
        }


        bewegungsvektor = new Vector2(0,0);
        if (Input.GetKey("w") && !IstInDerLuft)
        {
            bewegungsvektor = bewegungsvektor + Vector2.up * Sprungkraft;
        }


        if (Input.GetKey("d"))
        {
            bewegungsvektor = bewegungsvektor + Vector2.right * Geschwindigkeit;
        }

        if (Input.GetKey("a"))
        {
            bewegungsvektor = bewegungsvektor + Vector2.left * Geschwindigkeit;
        }

        if (Input.GetKeyDown("o"))
        {
            jetztLeben -= 1;
            lebensanzeige.SetzeLeben(jetztLeben);
        }

        if (Input.GetKeyDown("e"))
        {
            Interagieren();
        }

        if (Input.GetKeyDown("s"))
        {
            Blocken();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Angreifen();
        }
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(bewegungsvektor, ForceMode2D.Impulse);
    }

    void Interagieren()
    {
        Debug.Log("Spieler interagiert!");
    }

    void Blocken()
    {
        Debug.Log("Spieler blockt!");
    }
    
    void Angreifen()
    {
        Debug.Log("Spieler greift an!");
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