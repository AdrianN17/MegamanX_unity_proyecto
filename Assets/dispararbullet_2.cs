using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispararbullet_2 : MonoBehaviour {

    private float dt = 0;
    private float vx = 1;
    private float speedx = 0;
    private Rigidbody2D rb;
    private SpriteRenderer spriterenderer;


    public enum Direccion { l, r }
    public Direccion DireccionArma = Direccion.r;

    void Start () {
        rb = GetComponent<Rigidbody2D>();

        spriterenderer = GetComponent<SpriteRenderer>();

        if (DireccionArma == Direccion.l)
        {
            speedx = -400;
            spriterenderer.flipX = true;
        }
        else
        {
            speedx = 400;
            spriterenderer.flipX = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        dt = Time.deltaTime;
        rb.velocity = new Vector2(vx * speedx * dt, 0);
    }


}
