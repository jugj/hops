using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler : MonoBehaviour
{
    
    public float Geschwindigkeit = 3f;
    public float Sprungkraft = 3f;
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
 
        if (rigidbody.velocity.y == 0.0f){
            istInDerLuft = false;
        }
            

        else{
            istInDerLuft = true;
        }
            
        
        bewegungsvektor = new Vector2(0,0);
        if (Input.GetKey("space") && !istInDerLuft)
        {
          bewegungsvektor = bewegungsvektor + Vector2.up*Sprungkraft;
        }


        if (Input.GetKey("d"))
        {
            bewegungsvektor = bewegungsvektor + Vector2.right*Geschwindigkeit;
            animator.SetBool("isWalkingRight", true);
        }

        if (Input.GetKey("a"))
        {
           bewegungsvektor = bewegungsvektor + Vector2.left*Geschwindigkeit;
        }
    }
    void FixedUpdate(){
        rigidbody.AddForce(bewegungsvektor, ForceMode2D.Impulse);
    }



}
