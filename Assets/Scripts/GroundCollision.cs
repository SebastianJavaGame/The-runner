using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour {
    public static bool IsGround { get; set; }

    void OnTriggerStay2D(Collider2D other)
    {
        IsGround = true;
    }
}
