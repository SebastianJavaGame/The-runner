using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartExplosion : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetBool("StartExplosion", true);
            Destroy(gameObject, 0.8f);
        }
    }
}
