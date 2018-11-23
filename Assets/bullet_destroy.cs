using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_destroy : MonoBehaviour {
    public GameObject dest;


    void OnBecameInvisible ()
    {
      //Destruimos el objeto padre cuando salga fuera de la pantalla
      Destroy(dest);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 9)
        {
            Destroy(dest);

            print("eliminado");

        }
    }
}
