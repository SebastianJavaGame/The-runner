using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollision : MonoBehaviour {
    public static bool IsDeath { get; set; }

    void OnTriggerEnter2D(Collider2D other)
    {
        IsDeath = true;
    }
}
