using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        jetztLeben = maxLeben;
        lebensanzeige.SetzeMaxLeben(maxLeben);
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetMouseButtonDown(0))
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
}