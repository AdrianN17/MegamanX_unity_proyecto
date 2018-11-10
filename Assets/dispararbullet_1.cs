using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispararbullet_1 : MonoBehaviour {
    /*https://histeriagamedev.wordpress.com/2014/12/20/unity3d-creacion-de-sistema-de-ataque-a-distancia-shurikens-en-juego-2d/*/
    private float dt = 0;
    private float vx = 1;
    private float speedx = 0;
    private Rigidbody2D rb;



    public enum Direccion { l, r }
    public Direccion DireccionArma = Direccion.r;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        if (DireccionArma == Direccion.l)
        {
            speedx = -300;
        }
        else
        {
            speedx = 300;
        }
    }
	
	// Update is called once per frame
	void Update () {
        dt = Time.deltaTime;
        rb.velocity = new Vector2(vx * speedx * dt, 0);
    }
}
