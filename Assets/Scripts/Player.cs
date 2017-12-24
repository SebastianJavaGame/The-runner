using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedFoward;
    public float hightJump;

    private float playerPosX;

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
        if (playerPosX == transform.position.x && GetComponent<Animator>().GetBool("Death") == false)
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.01f);
        playerPosX = transform.position.x;

        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        GetComponent<Animator>().SetBool("Grounded", GroundCollision.IsGround);
    }
}
