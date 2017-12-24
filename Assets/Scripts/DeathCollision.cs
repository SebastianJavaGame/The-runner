using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Obstacle")
            Died();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ObstacleAnimation")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 15, ForceMode2D.Impulse);
            coll.gameObject.transform.position = new Vector2(coll.transform.position.x, coll.transform.position.y + 1.1f);
            coll.gameObject.GetComponent<Animator>().SetBool("StartExplosion", true);
            coll.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(coll.gameObject, 0.8f);
            Died();
        }
    }

    void Died()
    {
        gameObject.GetComponent<Animator>().SetBool("Death", true);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
    }
}