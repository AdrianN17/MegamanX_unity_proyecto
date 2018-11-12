using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MegamanX : MonoBehaviour {
    private float dt = 0;

    private SpriteRenderer spriterenderer;
    private Animator anim;
    private Rigidbody2D rb;

    private float speedx = 200;

    private bool ground = false;
    private bool moving = false;
    private bool jump = false;
    private bool buster = false;
    private bool dash =false;

    private int hp = 10;

    private float cargandobuster = 0;
    public enum Direccion { l, r }
    public Direccion  Xdireccion = Direccion.r;

    public GameObject buster0;
    public GameObject buster1;
    public GameObject buster2;

    public Transform playerLocation;
    void Start () {
        
        spriterenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update() {

        dt = Time.deltaTime;
        moving = false;
        buster = false;


        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriterenderer.flipX = false;
            Xdireccion = Direccion.r;
            moving = true;
            rb.velocity = new Vector2(speedx * dt, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriterenderer.flipX = true;
            Xdireccion = Direccion.l;
            moving = true;
            rb.velocity = new Vector2(-1*speedx * dt, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.UpArrow) && ground)
        {
            rb.AddForce(new Vector2(rb.velocity.x, 8), ForceMode2D.Impulse);
            ground = false;
            jump = true;

        }

        if (Input.GetKey(KeyCode.Z) && dash==false && ground)
        {
            if (Xdireccion == Direccion.r)
            {
                //rb.AddForce(new Vector2(5, rb.velocity.y), ForceMode2D.Impulse);
                rb.velocity = new Vector2(500 * dt, rb.velocity.y);
            }
            else
            {
                //rb.AddForce(new Vector2(-5, rb.velocity.y), ForceMode2D.Impulse);
                rb.velocity = new Vector2(-500 * dt, rb.velocity.y);
            }
            anim.SetTrigger("dash");
            dash = true;
        }
        else if(Input.GetKeyUp(KeyCode.Z))
        {
            dash = false;
        }

        if (Input.GetKey(KeyCode.X))
        {
            buster = true;    
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            buster = false;
            anim.SetTrigger("buster");

            if (cargandobuster > 0)
            {
                //disparar 
                if (cargandobuster < 1)
                {
                    //carga amarilla
                    dispararbullet_1 buster_0 = buster0.GetComponent<dispararbullet_1>();
                    if (Xdireccion == Direccion.r)
                    {
                        buster_0.DireccionArma = dispararbullet_1.Direccion.r;
                    }
                    else
                    {
                        buster_0.DireccionArma = dispararbullet_1.Direccion.l;
                    }

                    Instantiate(buster_0, playerLocation.position, playerLocation.rotation);
                }
                else if (cargandobuster < 2 && cargandobuster >= 1)
                {
                    //carga verde
                    dispararbullet_2 buster_1 = buster1.GetComponent<dispararbullet_2>();
                    if (Xdireccion == Direccion.r)
                    {
                        buster_1.DireccionArma = dispararbullet_2.Direccion.r;
                    }
                    else
                    {
                        buster_1.DireccionArma = dispararbullet_2.Direccion.l;
                    }

                    Instantiate(buster_1, playerLocation.position, playerLocation.rotation);
                }
                else 
                {
                    //carga azul
                    dispararbullet_3 buster_2 = buster2.GetComponent<dispararbullet_3>();
                    if (Xdireccion == Direccion.r)
                    {
                        buster_2.DireccionArma = dispararbullet_3.Direccion.r;
                    }
                    else
                    {
                        buster_2.DireccionArma = dispararbullet_3.Direccion.l;
                    }

                    Instantiate(buster_2, playerLocation.position, playerLocation.rotation);
                }
            }

            cargandobuster = 0;
        }
            

        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);

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
            cargandobuster = cargandobuster + dt;
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            ground = true;
            jump = false;
            anim.SetBool("salto", false);
        }
    }

}
