using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speedFoward;
    public float hightJump;
	
	void Start () {
		
	}
	
	void Update () {
        if (BaseLevel.ChangeLevel)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Platform.PlayerSpeedTemporary, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(BaseLevel.Steps[BaseLevel.ActualLevel].PlayerSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //GetComponent<Rigidbody2D>().velocity = new Vector2(speedFoward, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && GroundCollision.IsGround)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, hightJump);
            GroundCollision.IsGround = false;
        }
	}
}
