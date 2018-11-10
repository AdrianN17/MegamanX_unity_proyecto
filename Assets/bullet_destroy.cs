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
}
