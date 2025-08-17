using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
   
   //Bewegung
    public float Geschwindigkeit = 3f;
    public float Sprungkraft = 12f;
    public Rigidbody2D rigidbody;
    public Animator animator;

    Vector2 bewegungsvektor = new Vector2(0,0);
    Vector2 laufvektor = new Vector2(0,0);
    Vector2 sprungvektor = new Vector2(0,0);


    bool istInDerLuft = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalkingRight", false);
        animator.SetBool("isWalkingLeft", false);
        animator.SetBool("ishostile", false);
        animator.SetBool("isjumping", false);
 
        if (rigidbody.velocity.y == 0.0f)
        {
            istInDerLuft = false;
        }   
        else
        {
            istInDerLuft = true;
        }
            
        
        bewegungsvektor = new Vector2(0,0);
        if (Input.GetKey("w") && !istInDerLuft)
        {
          bewegungsvektor = bewegungsvektor + Vector2.up*Sprungkraft;
          animator.SetBool("isjumping", true);
        }


        if (Input.GetKey("d"))
        {
            bewegungsvektor = bewegungsvektor + Vector2.right*Geschwindigkeit;
            animator.SetBool("isWalkingRight", true);
        }

        if (Input.GetKey("a"))
        {
           bewegungsvektor = bewegungsvektor + Vector2.left*Geschwindigkeit;
           animator.SetBool("isWalkingLeft", true);
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("ishostile", true);
            Angreifen();
        }

        if (Input.GetKeyDown("s"))
        {
            Blocken();
        }

        if (Input.GetKeyDown("e"))
        {
            Interagieren();
        }

    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Enemy") 
        {
         Destroy(other.gameObject);

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
