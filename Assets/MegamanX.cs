using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MegamanX : MonoBehaviour {
    private float dt = 0;

    private SpriteRenderer spriterenderer;
    private Animator anim;
    private Rigidbody2D rb;

    private float speedx = 200;
    private float vx = 0;

    private bool ground = false;
    private bool moving = false;
    private bool jump = false;
    private  bool buster = false;

    private int hp = 10;

    private float cargandobuster = 0;

    public GameObject buster0;


    void Start () {
        
        spriterenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update() {


        dt = Time.deltaTime;
        vx = 0;
        moving = false;
        buster = false;


        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriterenderer.flipX = true;
            vx = 1;
            moving = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriterenderer.flipX = false;
            vx = -1;
            moving = true;
        }

        if (Input.GetKey(KeyCode.UpArrow) && ground)
        {
            rb.AddForce(new Vector2(rb.velocity.x, 12), ForceMode2D.Impulse);
            ground = false;
            jump = true;

        }

        if (Input.GetKey(KeyCode.X))
        {
            buster = true;
            cargandobuster = cargandobuster + dt;
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

        if(buster==true)
        {
            anim.SetBool("buster", true);
        }
        else if(buster==false)
        {
            anim.SetBool("buster", false);
            if(cargandobuster<0)
            {
                //disparar 
                if(cargandobuster<1)
                {
                    //carga verde
                }
                else if(cargandobuster<2)
                {
                    //carga azul
                }
                else
                {
                    //carga amarilla
                    //ArmaArrojadiza scriptShuriken = ShurikenPrefab.GetComponent<ArmaArrojadiza>();
                    dispararbullet_1 buster_d0 = buster0.GetComponent<dispararbullet_1>();
                    Instantiate(buster0, transform.position, Quaternion.identity);

                }
            }
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
