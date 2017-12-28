using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float SpeedFoward { get; set; }
    public static float HightJump { get; set; }

    private float playerPosX;

    void Awake()
    {
        SpeedFoward = 5;
        HightJump = 11;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GroundCollision.IsGround)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, HightJump);
            GroundCollision.IsGround = false;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(SpeedFoward, GetComponent<Rigidbody2D>().velocity.y);
        //Debug.Log(GetComponent<Rigidbody2D>().velocity);
    }

    void FixedUpdate()
    {
        if (playerPosX == transform.position.x && GetComponent<Animator>().GetBool("Death") == false)
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.01f);
        playerPosX = transform.position.x;

        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        GetComponent<Animator>().SetBool("Grounded", GroundCollision.IsGround);
    }

    public static void UpgradeSpeed()
    {
        SpeedFoward += 1.5f;
    }
}
