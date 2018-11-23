using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e1 : MonoBehaviour
{
    int hp = 5;
    float dt = 0;
    private Rigidbody2D rb;
    public GameObject go;
    public bool start = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(start)
        {
            dt = Time.deltaTime;

            rb.velocity = new Vector2(-200 * dt, rb.velocity.y);

            if (hp < 1)
            {
                Destroy(go);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 11)
        {
            int daño_bala = 0;

            if(coll.gameObject.name=="buster_1(Clone)")
            {
                daño_bala = 1;
            }
            else if(coll.gameObject.name == "buster_2(Clone)")
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
        if(start==true)
        {
            Destroy(go);
        }
    }
}
