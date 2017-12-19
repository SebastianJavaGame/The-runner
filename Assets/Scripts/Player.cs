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

        CheckPlayerDied();
    }

    void FixedUpdate()
    {
        if (BaseLevel.ChangeLevel)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Platform.PlayerSpeedTemporary, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(BaseLevel.Steps[BaseLevel.ActualLevel].PlayerSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(speedFoward, GetComponent<Rigidbody2D>().velocity.y);
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", GroundCollision.IsGround);
    }

    void CheckPlayerDied()
    {
        if (DeathCollision.IsDeath)
        {
            anim.SetBool("Death", DeathCollision.IsDeath);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<BoxCollider2D>().enabled = false;
            DeathCollision.IsDeath = false;
        }
    }
}
