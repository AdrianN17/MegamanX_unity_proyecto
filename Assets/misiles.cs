using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misiles : MonoBehaviour {

    private Rigidbody2D rb;

    

    private float dt = 0;
    private float vx = -400;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        dt = Time.deltaTime;
        rb.velocity = new Vector2(vx * dt, 0);

    }
}
