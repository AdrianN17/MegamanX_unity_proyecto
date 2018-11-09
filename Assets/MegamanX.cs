using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MegamanX : MonoBehaviour {
    public float dt = 0;

    public SpriteRenderer spriterenderer;
    public Animator anim;
    public Rigidbody2D rb;

    float speedx = 200;
    float vx = 0;

    bool ground = false;
    bool moving = false;
    bool jump = false;

    int hp = 10;

    
    
    void Start () {
        
        spriterenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update () {
        

        dt = Time.deltaTime;
        vx = 0;
        moving = false;


        if (Input.GetKey(KeyCode.D))
        {
            spriterenderer.flipX = true;
            vx = 1;
            moving = true;
        }

        if(Input.GetKey(KeyCode.A))
        {
            spriterenderer.flipX = false;
            vx = -1;
            moving = true;
        }

        if(Input.GetKey(KeyCode.W) && ground)
        {
            rb.AddForce(new Vector2(rb.velocity.x, 12), ForceMode2D.Impulse);
            ground = false;
            jump = true;
           
        }

        rb.velocity = new Vector2(vx * speedx * dt, rb.velocity.y);

        if(moving)
        {
            anim.SetBool("correr",true);
        }
        else
        {
            anim.SetBool("correr", false);
        }

        if(jump)
        {
            anim.SetBool("salto", true);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "plataforma")
        {
            ground = true;
            jump = false;
            anim.SetBool("salto", false);
        }
    }

}
