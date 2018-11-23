using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e2 : MonoBehaviour {

    int hp = 10;

    private Rigidbody2D rb;

    public GameObject go;
    public bool start = false;
    public Animator anim;



    public GameObject misil0;
    private float contador;
    public float dt = 0;
    public Transform e2location;
    private bool isshoot = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            dt = Time.deltaTime;

            if (hp < 1)
            {
                Destroy(go);
            }

            contador = contador + dt;

            

            if (contador > 2.5)
            {
                anim.SetTrigger("disparo");
                isshoot = true;
                contador = 0;
            }

            if (isshoot)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("disparo"))
                {
                    misiles misil_0 = misil0.GetComponent<misiles>();
                    Instantiate(misil_0, e2location.position, e2location.rotation);
                    isshoot = false;
                }
                    
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 11)
        {
            int daño_bala = 0;

            if (coll.gameObject.name == "buster_1(Clone)")
            {
                daño_bala = 1;
            }
            else if (coll.gameObject.name == "buster_2(Clone)")
            {
                daño_bala = 2;
            }
            else if (coll.gameObject.name == "buster_3(Clone)")
            {
                daño_bala = 5;
            }

            hp = hp - daño_bala;

        }
    }

    void OnBecameVisible()
    {
        start = true;
    }

    void OnBecameInvisible()
    {
        if (start == true)
        {
            Destroy(go);
        }
    }
}
