using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedFoward;
    public float hightJump;

    private float playerPosX;
    private Animator anim;

    void Start()
    {
        DeathCollision.IsDeath = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GroundCollision.IsGround)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, hightJump);
            GroundCollision.IsGround = false;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(speedFoward, GetComponent<Rigidbody2D>().velocity.y);
    }

    void FixedUpdate()
    {
        if (playerPosX == transform.position.x && DeathCollision.IsDeath == false)
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.01f);
        playerPosX = transform.position.x;

        

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", GroundCollision.IsGround);

        CheckPlayerDied();
    }

    void CheckPlayerDied()
    {
        if (DeathCollision.IsDeath)
        {
            anim.SetBool("Death", DeathCollision.IsDeath);

            if (transform.position.y < 2)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(2, -3);
            }

        }
    }
}
